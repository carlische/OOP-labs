namespace CourseManagementSystem
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public Teacher(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
        
        public string GetFullName()
        {
            return $"{Name} {Surname}";
        }
    }
}