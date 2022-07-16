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
        public string Content { get; set; }
        [Required(ErrorMessage = "Provide entry email adress")]
        public string Email { get; set; }




    }
}
