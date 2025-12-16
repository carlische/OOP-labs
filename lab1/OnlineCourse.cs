namespace CourseManagementSystem
{
    public class OnlineCourse : Course
    {
        public string Platform { get; set; }
        public string MeetingLink { get; set; }
        public bool HasRecordings { get; set; }
        
        public OnlineCourse(int id, string title, string description, string platform, string meetingLink, bool hasRecordings) : base(id, title, description)
        {
            Platform = platform;
            MeetingLink = meetingLink;
            HasRecordings = hasRecordings;
        }
        
        public override string GetCourseType()
        {
            return "Online Course";
        }
        
        public override string GetCourseInfo()
        {
            return $"Type: {GetCourseType()}, Platform: {Platform}, Link: {MeetingLink}, Recordings available: {HasRecordings}";
        }
    }
}