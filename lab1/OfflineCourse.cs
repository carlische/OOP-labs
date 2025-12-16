namespace CourseManagementSystem
{
    public class OfflineCourse : Course
    {
        public string Classroom { get; set; }
        public string Schedule { get; set; }
        public int MaxCapacity { get; set; }
        
        public OfflineCourse(int id, string title, string description, string classroom, string schedule, int maxCapacity) : base(id, title, description)
        {
            Classroom = classroom;
            Schedule = schedule;
            MaxCapacity = maxCapacity;
        }
        
        public override string GetCourseType()
        {
            return "Offline Course";
        }
        
        public override string GetCourseInfo()
        {
            return $"Type: {GetCourseType()}, Classroom: {Classroom}, Schedule: {Schedule}, Max Capacity: {MaxCapacity}";
        }
        
        public bool HasAvailableSeats()
        {
            return EnrolledStudents.Count < MaxCapacity;
        }
    }
}