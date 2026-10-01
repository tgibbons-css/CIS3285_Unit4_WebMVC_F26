using Microsoft.AspNetCore.Mvc;
using WebMVC_F26a.Models;

namespace WebMVC_F26a.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentCRUDInterface _studentRepository;

        public StudentController(IStudentCRUDInterface studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View(_studentRepository.GetAllStudents());
        }

        public IActionResult Details(int id)
        {
            StudentModel? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentModel? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            if (_studentRepository.GetStudentById(student.Id) == null)
            {
                return NotFound();
            }

            _studentRepository.UpdateStudent(student.Id, student);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            StudentModel? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_studentRepository.GetStudentById(id) == null)
            {
                return NotFound();
            }

            _studentRepository.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
