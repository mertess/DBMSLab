using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMEnitityFramework.Models;
using ORMEnitityFramework;
using Microsoft.EntityFrameworkCore;

namespace ORMLab5.Logic
{
    public class AuthorService : ICrud<Author>
    {
        public void Create(Author model)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var author = context.Authors.FirstOrDefault(a => a.FullName == model.FullName);
                if (author != null)
                    throw new Exception("Такой автор уже есть!");
                context.Authors.Add(model);
                context.SaveChanges();
            }
        }

        public void Delete(Author model)
        {
            using(DatabaseContext context = new DatabaseContext())
            {
                var author = context.Authors.FirstOrDefault(a => a.FullName == model.FullName);
                if (author == null)
                    throw new Exception("Такого автора нет");
                context.Authors.Remove(author);
                context.SaveChanges();
            }
        }

        public List<Author> FindAll()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Authors.ToList();
            }
        }

        public List<Author> FindAll(int offset, int count)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Authors.Skip(offset).Take(count).ToList();
            }
        }

        public Author Get(int id)
        {
            using(DatabaseContext context = new DatabaseContext())
            {
                return context.Authors.FirstOrDefault(a => a.Id == id);
            }
        }

        public void Update(Author model)
        {
            using(DatabaseContext context = new DatabaseContext())
            {
                var author = context.Authors.FirstOrDefault(a => a.Id == model.Id);
                if (author == null)
                    throw new Exception("Такого автора нет!");
                author.FullName = model.FullName;
                context.SaveChanges();
            }
        }

        public void AddAuthorToBook(int AuthorId, int BookId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                if (context.Authors.FirstOrDefault(a => a.Id == AuthorId) == null)
                    throw new Exception("Такого автора нет!");
                if (context.Books.FirstOrDefault(b => b.Id == BookId) == null)
                    throw new Exception("Такой книги нет!");
                context.BookAuthors.Add(new BookAuthor() { BookId = BookId, AuthorId = AuthorId });
                context.SaveChanges();
            }
        }

        public List<Author> GetBySubString(string subString)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Authors.Where(a => a.FullName.Contains(subString)).ToList();
            }
        }
    }
}
