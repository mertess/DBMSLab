using ORMLab5.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMLab5
{
    class Program
    {
        static void Main(string[] args)
        {
            MainLogic mainLogic = new MainLogic(new AuthorService(), new ClientService(), new BookService());
            try
            {
                //mainLogic.ShowAllRecords();
                //mainLogic.ShowFilteredRecords();
                //mainLogic.ShowFirstPageOfRecords();
                mainLogic.ShowStatistic();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static void Init(MainLogic mainLogic)
        {
            mainLogic.CreateBook("Искусство программирования 1", "RU", DateTime.Parse("11.03.1999"));
            mainLogic.CreateBook("Искусство программирования 2", "RU", DateTime.Parse("11.03.2000"));
            mainLogic.CreateBook("Искусство программирования 3", "RU", DateTime.Parse("11.03.2003"));
            mainLogic.CreateBook("Programming language C++", "EN", DateTime.Parse("23.07.2000"));
            mainLogic.CreateBook("Современные операционные системы", "RU", DateTime.Parse("05.02.2008"));

            mainLogic.CreateAuthor("Страуструп");
            mainLogic.CreateAuthor("Таненбаум");
            mainLogic.CreateAuthor("Кнут");

            mainLogic.AddAuthorToBook(3, 1);
            mainLogic.AddAuthorToBook(3, 2);
            mainLogic.AddAuthorToBook(3, 3);
            mainLogic.AddAuthorToBook(1, 4);
            mainLogic.AddAuthorToBook(2, 5);

            mainLogic.CreateClient("Лагин Дмитрий Андреевич", "89374525024");
            mainLogic.CreateClient("Тягин Игорь Васильевич", "89021234256");
            mainLogic.CreateClient("Перменев Алексей Сергеевич", "89033355256"); 

            mainLogic.AddBookGivenAway(4, 1, DateTime.Parse("20.06.2020"));
            mainLogic.AddBookGivenAway(3, 1, DateTime.Parse("20.05.2020"));
            mainLogic.AddBookGivenAway(1, 3, DateTime.Parse("05.06.2020"));
        }
    }
}
