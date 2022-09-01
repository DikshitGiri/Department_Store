using AspNetCoreHero.ToastNotification.Abstractions;
using DepartmentStore.Data;
using DepartmentStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStore.Controllers
{
    public class Inventory : Controller
    {
        private readonly INotyfService _notyf;
        private ApplicationDbContext Context { get; set; }


        public Inventory(ApplicationDbContext context, INotyfService notyf)
        {
            this.Context = context;
            _notyf = notyf;
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
        public IActionResult LoginCheck(Register rg)

        {
            //Context.login.Add(lg);
            //Context.SaveChanges();
            var obj = Context.register.Where(a => a.Name.Equals(rg.Name) && a.Password.Equals(rg.Password)).FirstOrDefault();
            if (obj != null)
            {
                //Session["UserID"] = obj.UserId.ToString();
                //Session["UserName"] = obj.UserName.ToString();
                //return RedirectToAction("UserDashBoard");
                _notyf.Success("Successful Login");
                
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
        public IActionResult Edit(int id)
        {
            return View(Context.entry.Find(id));
        }
        public IActionResult Update(Entry ee)
        {
            Context.entry.Update(ee);
           
            Context.SaveChanges();
            _notyf.Success("Successful Update ");
            return RedirectToAction("Result");
        }
        public IActionResult Delete(int id)

        {
         var deleteid = Context.entry.Find(id);
           
            Context.entry.Remove(deleteid);
            Context.SaveChanges();
            _notyf.Success("Successful Delete");
            return RedirectToAction("Result");
        }

        public IActionResult Summury()
        {
            return View();
        }
        public IActionResult Logout()
        {

            return RedirectToAction("Login");
        }
    }
}
