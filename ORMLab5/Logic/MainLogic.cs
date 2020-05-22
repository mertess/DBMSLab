using ORMEnitityFramework.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMLab5.Logic
{
    public class MainLogic
    {
        private readonly AuthorService authorService;
        private readonly ClientService clientService;
        private readonly BookService bookService;
        private const int page_size = 3;

        public MainLogic(AuthorService authorService, ClientService clientService, BookService bookService)
        {
            this.authorService = authorService;
            this.bookService = bookService;
            this.clientService = clientService;
        }

        public void CreateBook(string Title, string Language, DateTime PublicationDate)
        {
            bookService.Create(new Book()
            {
                Title = Title,
                Language = Language,
                PublicationDate = PublicationDate
            });
        }
        
        public void CreateClient(string FullName, string PhoneNumber)
        {
            clientService.Create(new Client()
            {
                FullName = FullName,
                PhoneNumber = PhoneNumber
            });
        }

        public void CreateAuthor(string FullName)
        {
            authorService.Create(new Author() { FullName = FullName });
        }

        public void AddAuthorToBook(int authorId, int bookid)
        {
            authorService.AddAuthorToBook(authorId, bookid);
        }

        public void AddBookGivenAway(int bookId, int clientId, DateTime returnDate)
        {
            bookService.AddBookGivenAway(bookId, clientId, returnDate);
        }

        public void DeleteBook(string Title, DateTime PublicationDate)
        {
            bookService.Delete(new Book() { Title = Title, PublicationDate = PublicationDate });
        }

        public void DeleteClient(string FullName)
        {
            clientService.Delete(new Client() { FullName = FullName });
        }

        public void DeleteAuthor(string FullName)
        {
            authorService.Delete(new Author() { FullName = FullName });
        }

        public void ShowAllRecords()
        {
            Console.WriteLine("AllRecords");

            foreach (var book in bookService.FindAll())
            {
                Console.WriteLine($"{book.Id} {book.Title} {book.Language} " +
                    $"{book.PublicationDate.ToShortDateString()} {book.Status}");
            }
            Console.WriteLine();

            foreach (var author in authorService.FindAll())
                Console.WriteLine($"{author.Id} {author.FullName}");
            Console.WriteLine();

            foreach (var client in clientService.FindAll())
                Console.WriteLine($"{client.Id} {client.FullName} {client.PhoneNumber}");
            Console.WriteLine();
        }

        public void ShowFirstPageOfRecords()
        {
            Console.WriteLine("First Page Of Records : ");
            foreach (var book in bookService.FindAll(0, page_size))
                Console.WriteLine($"{book.Id} {book.Title} {book.Language} " +
                   $"{book.PublicationDate.ToShortDateString()} {book.Status}");
            Console.WriteLine();

            foreach (var author in authorService.FindAll(0, page_size))
                Console.WriteLine($"{author.Id} {author.FullName}");
            Console.WriteLine();

            foreach (var client in clientService.FindAll(0, page_size))
                Console.WriteLine($"{client.Id} {client.FullName} {client.PhoneNumber}");
            Console.WriteLine();
        }

        public void ShowFilteredRecords()
        {
            foreach(var book in bookService.GetByLanguage("RU"))
                Console.WriteLine($"{book.Id} {book.Title} {book.Language} " +
                       $"{book.PublicationDate.ToShortDateString()} {book.Status}");
            Console.WriteLine();
            foreach(var client in clientService.GetByPhoneNumber("89374525024"))
                Console.WriteLine($"{client.Id} {client.FullName} {client.PhoneNumber}");
            Console.WriteLine();
            foreach(var author in authorService.GetBySubString("Танен"))
                Console.WriteLine($"{author.Id} {author.FullName}");
        }

        public void ShowStatistic()
        {
            bookService.GetStatisticLanguage();
        }
    }
}
