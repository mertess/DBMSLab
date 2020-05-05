using ORMEnitityFramework;
using ORMEnitityFramework.Models;
using ORMEnitityFramework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ORMLab5.Logic
{
    public class BookService : ICrud<Book>
    {
        public void Create(Book model)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Title == model.Title &&
                b.PublicationDate == model.PublicationDate);
                if (book != null)
                    throw new Exception("Такая книга уже есть!");
                model.Status = StatusEnum.Available;
                context.Books.Add(model);
                context.SaveChanges();
            }
        }

        public void Delete(Book model)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Title == model.Title &&
                b.PublicationDate == model.PublicationDate);
                if (book == null)
                    throw new Exception("Такой книги нет!");
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }

        public List<Book> FindAll()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Books.Include(b => b.BookAuthors)
                    .Include(b => b.BookGivenAways)
                    .ToList();
            }
        }

        public List<Book> FindAll(int offset, int count)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Books.Skip(offset).Take(count)
                    .Include(b => b.BookAuthors)
                    .Include(b => b.BookGivenAways)
                    .ToList();
            }
        }

        public Book Get(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Books.FirstOrDefault(b => b.Id == id);
            }
        }

        public void Update(Book model)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == model.Id);
                if (book == null)
                    throw new Exception("Такой книги нет!");
                book.Title = model.Title;
                book.Language = model.Language;
                book.PublicationDate = model.PublicationDate;
                book.Status = model.Status;
                context.SaveChanges();
            }
        }

        public void AddBookGivenAway(int bookId, int clientId, DateTime returnDate)
        {
            using(DatabaseContext context = new DatabaseContext())
            {
                if (context.Books.FirstOrDefault(b => b.Id == bookId) == null)
                    throw new Exception("Такой книги нет!");
                if (context.Clients.FirstOrDefault(c => c.Id == clientId) == null)
                    throw new Exception("Такого клиента нет!");
                context.BookGivenAways.Add(new BookGivenAway()
                {
                    ReturnDate = returnDate,
                    ClientCardId = clientId,
                    BookId = bookId
                });
                context.Books.FirstOrDefault(b => b.Id == bookId).Status = StatusEnum.Unavailable;
                context.SaveChanges();
            }
        }

        public List<Book> GetByLanguage(string Language)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Books.Where(b => b.Language.Equals(Language)).ToList();
            }
        }

        public void GetStatisticLanguage()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                //.GroupBy в версии EF > 3.0 больше не поддерживает 
                //прямой запрос без использования .AsEnumerable
                //и вызывает исключение Client side is not support ...
                foreach(var elem in context.Books.ToList().GroupBy(b => b.Language))
                {
                    Console.WriteLine($"{elem.Key} : {elem.Count()}");
                }
            }
        }
    }
}
