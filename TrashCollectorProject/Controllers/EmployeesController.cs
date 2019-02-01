using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            string checkedId = User.Identity.GetUserId();

            List<Employee> empList = db.Employees.Where(c => c.ApplicationUserId == checkedId).ToList();
            if (empList.Count > 1)
            {
                while(empList.Count > 1)
                {
                    Employee extraInfo = empList[0];
                    empList.RemoveAt(0);
                    db.Employees.Remove(extraInfo);
                    db.SaveChanges();
                }
                return View(empList);
            }
            else
            {
                return View(empList);
            }      
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,zipCode,firstName,lastName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationUserId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,zipCode,firstName,lastName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationUserId = User.Identity.GetUserId();
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Employees/Approve/5
        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Employees/Approve/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            customer.dueBalance += 10;
            customer.pickupStatus = PickupStatus.Approved;
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Filter()
        {
            return View();
        }

        // GET: Employees/Filter
        [HttpGet, ActionName("Filter")]
        public ActionResult Filter(Day? day)
        {
            string checkedId = User.Identity.GetUserId();
            List<Employee> empList = db.Employees.Where(e => e.ApplicationUserId == checkedId).ToList();
            int checkedZip = empList[empList.Count - 1].zipCode;

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Monday", Value = "1" });
            items.Add(new SelectListItem() { Text = "Tuesday", Value = "2" });
            items.Add(new SelectListItem() { Text = "Wednesday", Value = "3" });
            items.Add(new SelectListItem() { Text = "Thursday", Value = "4" });
            items.Add(new SelectListItem() { Text = "Friday", Value = "5" });
            items.Add(new SelectListItem() { Text = "Saturday", Value = "6" });
            var ddl = from d in items
                      select d.Text;
            ViewBag.Day = ddl;

            var custList = db.Customers.Where(c => c.pickupDay == day);
            custList = custList.Where(c => c.zipCode == checkedZip && c.pickupStatus != PickupStatus.Approved);

            return View(custList);
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
