using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            return View(userlist);
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }
 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // Add the new user to the list
                userlist.Add(user);

                // Redirect to the Index action to show the list of users
                return RedirectToAction("Index");
            }
            catch
            {
                // If an error occurs, return to the Create view
                return View();
            }
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            var userInList = userlist.FirstOrDefault(u => u.Id == id);
            if (userInList == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Update the user's information
                userlist.Remove(userInList);
                userlist.Add(user);

                // Redirect to the Index action to show the updated list of users
                return RedirectToAction("Index");
            }
            catch
            {
                // If an error occurs, return to the Edit view with the user's information
                return View(user);
            }
        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Remove the user from the list
                userlist.Remove(user);

                // Redirect to the Index action to show the updated list of users
                return RedirectToAction("Index");
            }
            catch
            {
                // If an error occurs, return to the Delete view with the user's information
                return View(user);
            }
        }


    }
}
