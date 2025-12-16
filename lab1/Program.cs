using System;

namespace CourseManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseSystem system = new CourseSystem();
            
            Teacher teacher1 = new Teacher(1, "Steve", "Harrington");
            Teacher teacher2 = new Teacher(2, "Eddie", "Munson");
            
            system.AddTeacher(teacher1);
            system.AddTeacher(teacher2);
         
            Student student1 = new Student(1, "Mike", "Wheeler");
            Student student2 = new Student(2, "Will", "Byers");
            Student student3 = new Student(3, "Dustin", "Henderson");
            Student student4 = new Student(4, "Lucas", "Sinclair");
            
            system.AddStudent(student1);
            system.AddStudent(student2);
            system.AddStudent(student3);
            system.AddStudent(student4);
            
            OnlineCourse onlineCourse = new OnlineCourse(
                id: 1,
                title: "The Upside Down",
                description: "Let's kick Vecna's ass",
                platform: "Google meet",
                meetingLink: "https://meet.google.com/meeting123",
                hasRecordings: true
            );
            
            OfflineCourse offlineCourse = new OfflineCourse(
                id: 2,
                title: "The Hellfire Club",
                description: "D&D board game club",
                classroom: "Room 666",
                schedule: "Saturday 07:00PM",
                maxCapacity: 3
            );
                
            system.AddCourse(onlineCourse);
            system.AddCourse(offlineCourse);
            
            system.AssignTeacherToCourse(1, 1); 
            system.AssignTeacherToCourse(2, 2); 
            
            system.EnrollStudentToCourse(1, 1); 
            system.EnrollStudentToCourse(2, 1); 
            system.EnrollStudentToCourse(3, 1);
            system.EnrollStudentToCourse(4, 1);
            system.EnrollStudentToCourse(1, 2); 
            system.EnrollStudentToCourse(2, 2); 
            system.EnrollStudentToCourse(3, 2);
            system.EnrollStudentToCourse(4, 2);
            
            Console.WriteLine("\nCourses taught by Steve Harrignton:");
            var SteveCourses = system.GetCoursesByTeacher(1);
            foreach (var course in SteveCourses)
            {
                Console.WriteLine($"{course.Title} ({course.GetCourseType()})");
            }
            
            Console.WriteLine("\nStudents enrolled in The Hellfire Club:");
            var dataStructuresStudents = system.GetStudentsByCourse(2);
            foreach (var student in dataStructuresStudents)
            {
                Console.WriteLine(student.GetFullName());
            }

            Console.WriteLine("\nCourse The Hellfire Club info:");
            string courseInfo = offlineCourse.GetCourseInfo();
            Console.WriteLine(courseInfo);   
        }
    }
}