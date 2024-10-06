using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace QuizApp.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        [Required]
        public string QuestionText { get; set; }
        //public string OptionA { get; set; }
        //public string OptionB { get; set; }
        //public string OptionC { get; set; }
        //public string OptionD { get; set; }
        //public string CorrectOption { get; set; }
        //public int TimeLimitInSeconds { get; set; }
        //public int Difficulty { get; set; }

        //public int CreatedBy { get; set; }
        //public int CreatedAt { get; set; }
    }
}
