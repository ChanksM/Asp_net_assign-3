using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetAssign.Models;

namespace AspNetAssign.Controllers
{
    public class HomeController : Controller
    {
        StudentsContext db;

        public HomeController(StudentsContext context)
        {
            db = context;
            if (!db.Courses.Any())
            {
                Course python = new Course { Name = "Python" };
                Course aspnet = new Course { Name = "AspNET" };
                Course reactNative = new Course { Name = "React Native" };
                Course angular = new Course { Name = "Angular" };

                Student student1 = new Student { Name = "Mushni Chankseliani", Course = angular };
                Student student2 = new Student { Name = "Giorgi Giorgadze", Course = angular };
                Student student3 = new Student { Name = "Nika Nikadze", Course = reactNative };
                Student student4 = new Student { Name = "Nini Ninidze", Course = reactNative };
                Student student5 = new Student { Name = "Ani Anidze", Course = aspnet };
                Student student6 = new Student { Name = "Saba Sabadze", Course = aspnet };
                Student student7 = new Student { Name = "Vazha Vazhadze", Course = python };
                Student student8 = new Student { Name = "Mariam Mariamidze", Course = python };

                db.Courses.AddRange(angular, reactNative, aspnet, python);
                db.Students.AddRange(student1, student2, student3, student4, student5, student6, student7, student8);
                db.SaveChanges();
            }
        }

        public async Task<IActionResult> Index(SortState sortOrder = SortState.StudentAsc)
        {
            IQueryable<Student>? users = db.Students.Include(x => x.Course);

            ViewData["StudentSort"] = sortOrder == SortState.StudentAsc ? SortState.StudentDesc : SortState.StudentAsc;
            ViewData["CourseSort"] = sortOrder == SortState.CourseAsc ? SortState.CourseDesc : SortState.CourseAsc;

            users = sortOrder switch
            {
                SortState.StudentDesc => users.OrderByDescending(s => s.Name),
                SortState.CourseAsc => users.OrderBy(s => s.Course!.Name),
                SortState.CourseDesc => users.OrderByDescending(s => s.Course!.Name),
                _ => users.OrderBy(s => s.Name),
            };
            return View(await users.AsNoTracking().ToListAsync());
        }
    }
}