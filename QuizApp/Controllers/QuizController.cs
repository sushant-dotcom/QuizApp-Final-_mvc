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
            List<Quiz> ObjQuizList = _db.Quiz.OrderBy(u => u.quiz_id).ToList();
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
                TempData["Success"] = "Topic added successfully";
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
            //Quiz Editquiz = _db.Quiz.Find(id);      //finds the record with the help of only primary key
            Quiz Editquiz = _db.Quiz.FirstOrDefault(u=>u.quiz_id==id);
            //Quiz Editquiz2 = _db.Quiz.Where(u => u.quiz_id == id).FirstOrDefault();
            if (Editquiz == null) 
            { 
                return NotFound(); 
            }
            return View(Editquiz);
        }
        [HttpPost]
        public IActionResult Edit(Quiz _obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Quiz.Update(_obj);
                _db.SaveChanges();
                TempData["Success"] = "Topic changed successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Quiz? Editquiz = _db.Quiz.Find(id);      //finds the record with the help of only primary key
            if (Editquiz == null)
            {
                return NotFound();
            }
            return View(Editquiz);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Quiz? obj = _db.Quiz.Find(id);
            if(obj == null)
                   return NotFound();
            _db.Quiz.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Topic deleted successfully";
            return RedirectToAction("Index");

  
        }
    }
}
