using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);

        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(obj);

        }


        //Get Delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {


                return NotFound();

            }

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();

            }


            return View(obj);


        }

        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {


                return NotFound();

            }

            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {


                return NotFound();

            }

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();

            }


            return View(obj);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(obj);

        }
    }
}
