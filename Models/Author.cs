using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stoica_Alexandru_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        [Display(Name = "Author First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Author Last Name")]
        public string LastName { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
