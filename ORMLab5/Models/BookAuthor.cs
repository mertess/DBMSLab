using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMEnitityFramework.Models
{
    public class BookAuthor
    {
        public int Id { set; get; }
        public int BookId { set; get; }
        public int AuthorId { set; get; }
        public virtual Book Book { set; get; }
        public virtual Author Author { set; get; }
    }
}
