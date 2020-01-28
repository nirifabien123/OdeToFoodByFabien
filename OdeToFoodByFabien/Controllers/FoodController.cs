using System.Linq;

using System.Web.Mvc;

using OdeToFoodByFabien.Models;
using System.Data.Entity.Infrastructure;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OdeToFoodByFabien.Context;




namespace OdeToFoodByFabien.Controllers
{
    public class FoodController : Controller
    {
        private FoodDbContext db = new FoodDbContext();

        // GET: fOOD
        public ActionResult Index(int? SelectedFood)
        {
            var foods = db.Foods.OrderBy(q => q.FoodName).ToList();
            ViewBag.SelectedFood = new SelectList(foods, "FoodId", "Name", SelectedFood);
            int FoodId = SelectedFood.GetValueOrDefault();

            IQueryable<Food> fooder = db.Foods
                .Where(c => !SelectedFood.HasValue || c.FoodId == FoodId)
                .OrderBy(d => d.FoodId);
            var sql = foods.ToString();
            return View(foods.ToList());
        }
        
        
        

        // GET: Food/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }


        public ActionResult Create()
        {
//            PopulateFoodsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Food food)
        {
       
            try
            {
                if (ModelState.IsValid)
                {
                    
                    db.Foods.Add(food);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
      
            return View(food);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return RedirectToAction("Index");
            }
            db.SaveChanges();
            return View(food);
        }
        
        

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePost(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var foodToUpdate = db.Foods.Find(id);
          
//            PopulateFoodsDropDownList(foodToUpdate.FoodId);
            return View(foodToUpdate);
        }
////
//        private void PopulateFoodsDropDownList(object selectedFood = null)
//        {
//            var foodsQuery = from d in db.Foods
//                                   orderby d.FoodName
//                                   select d;
//            ViewBag.FoodId = new SelectList(foodsQuery, "FoodId", "FoodName", selectedFood);
//        }







       // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        
    }
}
