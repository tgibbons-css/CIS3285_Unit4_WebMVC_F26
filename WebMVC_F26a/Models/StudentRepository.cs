namespace WebMVC_F26a.Models
{
    public class StudentRepository : IStudentCRUDInterface
    {
        private readonly List<StudentModel> _students = new List<StudentModel>
        {
            new StudentModel(1001, "Tom", 16),
            new StudentModel(1002, "Jen", 8),
            new StudentModel(1003, "Sabah", 16)
        };

        public List<StudentModel> GetAllStudents()
        {
            return _students;
        }

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

        public void AddStudent(StudentModel newStudent)
        {
            _students.Add(newStudent);
        }

        public void DeleteStudent(int studentId)
        {
            StudentModel? student = GetStudentById(studentId);
            if (student != null)
            {
                _students.Remove(student);
            }
        }

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