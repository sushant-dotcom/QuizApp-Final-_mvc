using Microsoft.AspNetCore.Mvc;
using QuizApp.Data_Server;
using QuizApp.Models;
using System.Runtime.CompilerServices;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Quiz _obj)
        {
            if (int.TryParse(_obj.Topic, out int result))
            {
                ModelState.AddModelError("", "Topic cannot be an numeric value");
            }
            if (ModelState.IsValid)
            {
                _db.Quiz.Add(_obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0) 
            { 
                return NotFound(); 
            }
            Quiz Editquiz = _db.Quiz.Find(id);
            Quiz Editquiz = _db.Quiz.FirstOrDefault(u=>u.quiz_id==id);
                Quiz Editquiz = _db.Quiz.Find(id);
            if (Editquiz == null) 
            { 
                return NotFound(); 
            }
            return View(Editquiz);
        }
        [HttpPost]
        public IActionResult Edit(Quiz _obj)
        {
            if (int.TryParse(_obj.Topic, out int result))
            {
                ModelState.AddModelError("", "Topic cannot be an numeric value");
            }
            if (ModelState.IsValid)
            {
                _db.Quiz.Add(_obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
