using DepartmentStore.Data;
using DepartmentStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStore.Controllers
{
    public class Inventory : Controller
    {
        private ApplicationDbContext Context { get; set; }


        public Inventory(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public IActionResult Register(Register reg)

        {
            Context.register.Add(reg);
            Context.SaveChanges();

            return RedirectToAction("Home");  
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginCheck(Login lg)

        {
            //Context.login.Add(lg);
            //Context.SaveChanges();
            var obj = Context.login.Where(a => a.Name.Equals(lg.Name) && a.Password.Equals(lg.Password)).FirstOrDefault();
            if (obj != null)
            {
                //Session["UserID"] = obj.UserId.ToString();
                //Session["UserName"] = obj.UserName.ToString();
                //return RedirectToAction("UserDashBoard");
                return RedirectToAction("Home");
            }
            else
            {
                return RedirectToAction("Login");
            }



        }

        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EntryPoint(Entry e)

        {
            Context.entry.Add(e);
            Context.SaveChanges();
            return RedirectToAction("Result");
        }
        public IActionResult Result()
        {
            return View(Context.entry.ToList());

        }
       
    }
}
