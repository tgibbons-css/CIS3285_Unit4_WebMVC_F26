namespace WebMVC_F26a.Models
{
    // Implements the student data contract using a list in memory instead of a database.
    // Because this service is registered as a singleton, the list is shared across requests
    // while the app is running, but its contents are lost when the app stops.
    public class StudentRepository : IStudentCRUDInterface
    {
        // Starting data makes the list view useful before students are added through the app.
        private readonly List<StudentModel> _students = new List<StudentModel>
        {
            new StudentModel(1001, "Tom", 16),
            new StudentModel(1002, "Jen", 8),
            new StudentModel(1003, "Sabah", 16)
        };

        // Return the collection used by this repository.
        public List<StudentModel> GetAllStudents()
        {
            return _students;
        }

        // Search by id; null tells the controller that the requested student was not found.
        public StudentModel? GetStudentById(int id)
        {
            foreach (StudentModel student in _students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        // Add the supplied student to the in-memory collection.
        public void AddStudent(StudentModel newStudent)
        {
            _students.Add(newStudent);
        }

        // Find the student first, then remove it if it exists.
        public void DeleteStudent(int studentId)
        {
            StudentModel? student = GetStudentById(studentId);
            if (student != null)
            {
                _students.Remove(student);
            }
        }

        // Find the student's position in the list and replace that entry when it exists.
        public void UpdateStudent(int studentId, StudentModel updatedStudent)
        {
            int index = _students.FindIndex(student => student.Id == studentId);
            if (index >= 0)
            {
                _students[index] = updatedStudent;
            }
        }
    }
}