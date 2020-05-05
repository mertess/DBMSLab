using ORMEnitityFramework.Models;
using System;
using System.Collections.Generic;
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
            Book book = new Book()
            {
                Title = Title,
                Language = Language,
                PublicationDate = PublicationDate
            };
            bookService.Create(book);
        }
        
        public void CreateClient(string FullName, string PhoneNumber)
        {
            Client client = new Client()
            {
                FullName = FullName,
                PhoneNumber = PhoneNumber
            };
            clientService.Create(client);
        }

        public void CreateAuthor(string FullName)
        {
            Author author = new Author() { FullName = FullName };
            authorService.Create(author);
        }

        public void AddAuthorToBook(int authorId, int bookid)
        {
            authorService.AddAuthorToBook(authorId, bookid);
        }

        public void AddBookGivenAway(int bookId, int clientId, DateTime returnDate)
        {
            bookService.AddBookGivenAway(bookId, clientId, returnDate);
        }

        public void ShowAllRecords()
        {
            Console.WriteLine("AllRecords");

            foreach (var book in bookService.FindAll())
            {
                Console.WriteLine($"{book.Id} {book.Title} {book.Language} " +
                    $"{book.PublicationDate.ToShortDateString()} {book.Status}");
                /*
                Console.WriteLine($"Authors id {book.Title}: ");

                foreach (var author in book.BookAuthors)
                    Console.WriteLine($"{author.AuthorId}");
                Console.WriteLine($"Client id : {book.BookGivenAways[0].ClientCardId}");
                Console.WriteLine($"ReturnDate : {book.BookGivenAways[0].ReturnDate}");*/
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
