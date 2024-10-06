using Microsoft.AspNetCore.Mvc;
using QuizApp.Data_Server;
using QuizApp.Models;
namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private readonly AppDbContext _db;
        public QuizController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Quiz> ObjQuizList = _db.Quiz.ToList();
            return View(ObjQuizList);
        }
    }
}
