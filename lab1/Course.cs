namespace CourseManagementSystem
{
    public abstract class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Teacher? AssignedTeacher { get; set; }
        public List<Student> EnrolledStudents { get; set; }
        
        protected Course(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            EnrolledStudents = new List<Student>();
        }
        
        public void AssignTeacher(Teacher teacher)
        {
            AssignedTeacher = teacher;
        }
        
        public void EnrollStudent(Student student)
        {
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
            }
        }
        
        public void RemoveStudent(Student student)
        {
            EnrolledStudents.Remove(student);
        }
        
        public abstract string GetCourseType();
        
        public abstract string GetCourseInfo();
    }
}