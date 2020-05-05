using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMEnitityFramework.Models
{
    public class BookGivenAway
    {
        public int Id { set; get; }
        [Required]
        public DateTime ReturnDate { set; get; }
        public int BookId { set; get; }
        public int ClientCardId { set; get; }
        public virtual Book Book { set; get; }
        public virtual Client Client { set; get; }
    }
}
