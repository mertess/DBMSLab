using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMEnitityFramework.Models
{
    public class Client
    {
        public int Id { set; get; }
        [Required]
        public string FullName { set; get; }
        [Required]
        public string PhoneNumber { set; get; }
        [ForeignKey("ClientCardId")]
        public virtual List<BookGivenAway> BookGivenAways { set; get; }
    }
}
