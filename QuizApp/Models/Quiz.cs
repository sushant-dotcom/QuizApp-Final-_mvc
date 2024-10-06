using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Quiz
    {
        [Key]
        public int  quiz_id { get; set; }
        [Required]
        public string Topic { get; set; }

    }
}
