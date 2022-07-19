using System.ComponentModel.DataAnnotations;

namespace GuestWhoIAm.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Provide name")]
        public string Author { get; set; }
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage = "Provide entry content")]
        [RegularExpression(@"^.{0,500}$", ErrorMessage = "Maximum number of characters is 500")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Provide email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Provide correct email adress")]
        public string Email { get; set; }




    }
}
