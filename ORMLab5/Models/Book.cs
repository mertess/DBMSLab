using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORMEnitityFramework.Enums;

namespace ORMEnitityFramework.Models
{
    public class Book
    {
        public int Id { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        public string Language { set; get; }
        [Required]
        public DateTime PublicationDate { set; get; }
        [DefaultValue(StatusEnum.Available)]
        public StatusEnum Status { set; get; }
        [ForeignKey("BookId")]
        public virtual List<BookAuthor> BookAuthors { set; get; }
        [ForeignKey("BookId")]
        public virtual List<BookGivenAway> BookGivenAways { set; get; }
    }
}
