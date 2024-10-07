using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Quiz
    {
        [Key]
        public int  quiz_id { get; set; }
        [Required]
        [MaxLength(15)]
        [DisplayName("Topic Name")]
        public string Topic { get; set; }

    }
}
