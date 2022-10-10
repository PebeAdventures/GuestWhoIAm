using System.ComponentModel.DataAnnotations;

namespace GuestWhoIAm.Models
{
    public class Answer
    {

        [Key]
        public int AnswerId { get; set; }
        public int UserId { get; }
        public string? AnswerProvided { get; set; }



    }
}
