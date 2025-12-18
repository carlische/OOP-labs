using Xunit;

namespace CourseManagementSystem.Tests
{
    public class CourseSystemTests
    {
        [Fact]
        public void AddNewCourse()
        {
            var system = new CourseSystem();
            var course1 = new OfflineCourse(1, "Math", "Mathematics", "Room 1", "Monday 07:00AM", 5);
            var course2 = new OnlineCourse(2, "Phys", "Physics", "Zoom", "https:/zoom.com/meeting123", true);
            var course3 = new OfflineCourse(1, "Math2", "Mathematics2", "Room 2", "Monday 07:00AM", 5);

            system.AddCourse(course1);
            system.AddCourse(course2);
            system.AddCourse(course3);

            var teacher = new Teacher(1, "Nancy", "Wheeler");
            system.AddTeacher(teacher);
            system.AssignTeacherToCourse(1, 1);
            
            Assert.Single(system.GetCoursesByTeacher(1));
        }

        [Fact]
        public void RemoveCourseByID()
        {
            var system = new CourseSystem();
            var course = new OfflineCourse(1, "Math", "Mathematics", "Room 1", "Monday 07:00AM", 5);

            system.AddCourse(course);

            var teacher = new Teacher(1, "Nancy", "Wheeler");
            system.AddTeacher(teacher);
            system.AssignTeacherToCourse(1, 1);
            
            Assert.Single(system.GetCoursesByTeacher(1));

            system.RemoveCourse(1);
            
            Assert.Empty(system.GetCoursesByTeacher(1));
        }

        [Fact]
        public void AddNewTeacher()
        {
            var system = new CourseSystem();
            var teacher = new Teacher(1, "Nancy", "Wheeler");

            system.AddTeacher(teacher);

            var course = new OfflineCourse(1, "Math", "Mathematics", "Room 1", "Monday 07:00AM", 5);
            system.AddCourse(course);
            system.AssignTeacherToCourse(1, 1);
            
            Assert.Single(system.GetCoursesByTeacher(1));
        }

        [Fact]
        public void RemoveTeacherById()
        {
            var system = new CourseSystem();
            var teacher = new Teacher(1, "Nancy", "Wheeler");

            system.AddTeacher(teacher);

            var course = new OfflineCourse(1, "Math", "Mathematics", "Room 1", "Monday 07:00AM", 5);
            system.AddCourse(course);
            system.AssignTeacherToCourse(1, 1);
            
            Assert.Single(system.GetCoursesByTeacher(1));

            system.RemoveTeacher(1);
            
            Assert.Empty(system.GetCoursesByTeacher(1));
        }

        [Fact]
        public void AssignedTeacherToCourse()
        {
            var system = new CourseSystem();
            var teacher = new Teacher(1, "Nancy", "Wheeler");
            var course = new OfflineCourse(1, "Math", "Mathematics", "Room 1", "Monday 07:00AM", 5);

            system.AddTeacher(teacher);
            system.AddCourse(course);
            
            system.AssignTeacherToCourse(1, 1);

            Assert.Single(system.GetCoursesByTeacher(1));

            system.AssignTeacherToCourse(2, 1);
            system.AssignTeacherToCourse(1, 2);

            Assert.Single(system.GetCoursesByTeacher(1));
        }

        [Fact]
        public void AddNewStudent()
        {
            var system = new CourseSystem();
            var student1 = new Student(1, "Will", "Byers");
            var student2 = new Student(2, "Mike", "Wheeler");
            var student3 = new Student(1, "Lucas", "SinClair");

            system.AddStudent(student1);
            system.AddStudent(student2);
            system.AddStudent(student3);

            var course = new OfflineCourse(1, "Math", "Mathematics", "Room 1", "Monday 07:00AM", 5);
            system.AddCourse(course);
            system.EnrollStudentToCourse(1, 1);
            system.EnrollStudentToCourse(2, 1);
            
            Assert.Equal(2, system.GetStudentsByCourse(1).Count);
        }

        [Fact]
        public void RemoveStudentById()
        {
            var system = new CourseSystem();
            var student1 = new Student(1, "Will", "Byers");

            system.AddStudent(student1);

            system.RemoveStudent(1);
            system.RemoveStudent(2);

            var course = new OfflineCourse(1, "Math", "Mathematics", "Room 1", "Monday 07:00AM", 5);
            system.AddCourse(course);
            system.EnrollStudentToCourse(1, 1);
            
            Assert.Single(system.GetStudentsByCourse(1));

            system.RemoveStudent(1);
            
            Assert.Empty(system.GetStudentsByCourse(1));
        }

        [Fact]
        public void EnrolledStudentToCourse()
        {
            var system = new CourseSystem();
            var course = new OfflineCourse(1, "Math", "Mathematics", "Room 1", "Monday 07:00AM", 1);
            var student1 = new Student(1, "Will", "Byers");
            var student2 = new Student(2, "Mike", "Wheeler");

            system.AddCourse(course);
            system.AddStudent(student1);
            system.AddStudent(student2);

            system.EnrollStudentToCourse(1, 1);

            Assert.Single(system.GetStudentsByCourse(1)); 

            system.EnrollStudentToCourse(1, 2);
            system.EnrollStudentToCourse(2, 1);
            system.EnrollStudentToCourse(3, 1);

            Assert.Single(system.GetStudentsByCourse(1));
        }
    }
}