namespace WebMVC_F26a.Models
{
    public interface IStudentCRUDInterface
    {
        List<StudentModel> GetAllStudents();
        StudentModel? GetStudentById(int id);
        void AddStudent(StudentModel newStudent);
        void UpdateStudent(int studentId, StudentModel updatedStudent);
        void DeleteStudent(int studentId);
    }
}