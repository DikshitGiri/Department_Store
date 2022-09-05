using AspNetCoreHero.ToastNotification.Abstractions;
using DepartmentStore.Data;
using DepartmentStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register reg)

        {
            if (!ModelState.IsValid) {
                //reg.Repassword= BCrypt.Net.BCrypt.HashPassword(reg.Repassword);
                //reg.Password = BCrypt.Net.BCrypt.HashPassword(reg.Password);
                
                return View();

                //return RedirectToAction("Home");
            }
            else {
                reg.Repassword = BCrypt.Net.BCrypt.HashPassword(reg.Repassword);
                reg.Password = BCrypt.Net.BCrypt.HashPassword(reg.Password);
                Context.register.Add(reg);
                Context.SaveChanges();
                _notyf.Success("Welcome Manager");
                return RedirectToAction("Home");
            }
           
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginCheck(string name,string password)
        {
          
            //var obj = Context.register.Where(a => a.Name.Equals(rg.Name) && a.Password.Equals(rg.Password)).FirstOrDefault();
            var obj = Context.register.FirstOrDefault(x => x.Name == name);
            if (obj != null && BCrypt.Net.BCrypt.Verify(password, obj.Password))
            {
                //Session["UserID"] = obj.UserId.ToString();
                //Session["UserName"] = obj.UserName.ToString();
                //return RedirectToAction("UserDashBoard");


                _notyf.Success("Welcome User");
                return RedirectToAction("Home");

            }
            else
            {
                _notyf.Error("Username or password do not matched");
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
            _notyf.Success("Data inserted successfully");
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
            _notyf.Error("Successful Delete");
            return RedirectToAction("Result");
        }

        //public  IActionResult Search(DateOnly date)
        //{
        //    return
        //}

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

