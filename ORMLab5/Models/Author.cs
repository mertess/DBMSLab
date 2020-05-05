using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMEnitityFramework.Models
{
    public class Author
    {
        public int Id { set; get; }
        [Required]
        public string FullName { set; get; }
        [ForeignKey("AuthorId")]
        public virtual List<BookAuthor> BookAuthors { set; get; }
    }
}
