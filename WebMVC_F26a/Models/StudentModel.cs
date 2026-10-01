namespace WebMVC_F26a.Models
{
    // Represents the student data passed between the controller, repository, and views.
    public class StudentModel
    {
        // The student's identifier, used to find the student in the repository.
        public int Id { get; set; }

        // Start with a non-null value so the property is safe to use before a name is entered.
        public string Name { get; set; } = string.Empty;

        // Number of credits earned by the student.
        public int Credits { get; set; }

        // Convenient constructor for creating a student with all three values.
        public StudentModel(int id, string name, int credits)
        {
            Id = id;
            Name = name;
            Credits = credits;
        }

        // ASP.NET Core model binding uses this constructor when creating a model from form fields.
        public StudentModel()
        {
        }
    }
}
