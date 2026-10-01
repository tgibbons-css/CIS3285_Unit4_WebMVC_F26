namespace WebMVC_F26a.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }

        public StudentModel(int id, string name, int credits)
        {
            Id = id;
            Name = name;
            Credits = credits;
        }
        public StudentModel()
        {
        }
    }
}
