using Microsoft.AspNetCore.Mvc;
using WebMVC_F26a.Models;

namespace WebMVC_F26a.Controllers
{
    // Coordinates student-related requests, delegates data work to the repository, and selects views.
    public class StudentController : Controller
    {
        private readonly IStudentCRUDInterface _studentRepository;

        // The interface keeps this controller independent of how student data is stored.
        // ASP.NET Core supplies the registered implementation through dependency injection.
        public StudentController(IStudentCRUDInterface studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Pass the student list as the view's model so the view can display it.
        public IActionResult Index()
        {
            return View(_studentRepository.GetAllStudents());
        }

        // GET displays an empty form for entering a new student.
        [HttpGet]
        public IActionResult Create()
        {
            return View(new StudentModel());
        }

        // POST validates the submitted student, rejects duplicate ids, and adds it to the repository.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            if (_studentRepository.GetStudentById(student.Id) != null)
            {
                ModelState.AddModelError(nameof(student.Id), "A student with this ID already exists.");
                return View(student);
            }

            _studentRepository.AddStudent(student);
            return RedirectToAction(nameof(Index));
        }

        // The id comes from the request; return HTTP 404 if no matching student exists.
        public IActionResult Details(int id)
        {
            StudentModel? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET displays the edit form with the current student values.
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

        // POST receives the submitted form, validates it, updates the repository, then redirects.
        // The anti-forgery check helps reject form submissions from another site.
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

        // GET displays a confirmation page; it does not delete the student yet.
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

        // POST performs the deletion after confirmation. ActionName keeps the URL/action name "Delete"
        // while this method has a distinct C# name from the GET action.
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
