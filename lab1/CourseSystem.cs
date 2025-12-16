using System;
using System.Collections.Generic;
using System.Linq;
namespace CourseManagementSystem
{
    public class CourseSystem
    {
        private List<Course> courses;
        private List<Teacher> teachers;
        private List<Student> students;
        
        public CourseSystem()
        {
            courses = new List<Course>();
            teachers = new List<Teacher>();
            students = new List<Student>();
        }
        
        public void AddCourse(Course course)
        {
            if (!courses.Any(c => c.Id == course.Id))
            {
                courses.Add(course);
                Console.WriteLine($"Course '{course.Title}' added.");
            }
            else
            {
                Console.WriteLine($"ID {course.Id} is busy.");
            }
        }
        
        public void RemoveCourse(int courseId)
        {
            var course = courses.FirstOrDefault(c => c.Id == courseId);
            if (course != null)
            {
                courses.Remove(course);
                Console.WriteLine($"Course '{course.Title}' removed.");
            }
            else
            {
                Console.WriteLine($"ID {courseId} is not found.");
            }
        }
        
        public void AddTeacher(Teacher teacher)
        {
            if (!teachers.Any(t => t.Id == teacher.Id))
            {
                teachers.Add(teacher);
                Console.WriteLine($"Teacher '{teacher.GetFullName()}' added.");
            }
            else
            {
                Console.WriteLine($"ID {teacher.Id} is busy.");
            }
        }
        
        public void RemoveTeacher(int teacherId)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacher != null)
            {
                foreach (var course in courses)
                {
                    if (course.AssignedTeacher?.Id == teacherId)
                    {
                        course.AssignedTeacher = null;
                    }
                }
                teachers.Remove(teacher);
                Console.WriteLine($"Teacher '{teacher.GetFullName()}' removed.");
            }
            else
            {
                Console.WriteLine($"ID {teacherId} is not found.");
            }
        }

        public void AssignTeacherToCourse(int teacherId, int courseId)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == teacherId);
            var course = courses.FirstOrDefault(c => c.Id == courseId);
            
            if (teacher == null)
            {
                Console.WriteLine($"Teacher with ID {teacherId} is not found.");
                return;
            }
            
            if (course == null)
            {
                Console.WriteLine($"Course with ID {courseId} is not found.");
                return;
            }
            
            course.AssignTeacher(teacher);
            Console.WriteLine($"Teacher '{teacher.GetFullName()}' assigned to course '{course.Title}'.");
        }
        
        public void AddStudent(Student student)
        {
            if (!students.Any(s => s.Id == student.Id))
            {
                students.Add(student);
                Console.WriteLine($"Student '{student.GetFullName()}' added.");
            }
            else
            {
                Console.WriteLine($"ID {student.Id} is busy.");
            }
        }
        
        public void RemoveStudent(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                foreach (var course in courses)
                {
                    course.RemoveStudent(student);
                }
                students.Remove(student);
                Console.WriteLine($"Student '{student.GetFullName()}' removed.");
            }
            else
            {
                Console.WriteLine($"ID {studentId} is not found.");
            }
        }
        
        public void EnrollStudentToCourse(int studentId, int courseId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            var course = courses.FirstOrDefault(c => c.Id == courseId);
            
            if (student == null)
            {
                Console.WriteLine($"Student with ID {studentId} is not found.");
                return;
            }
            
            if (course == null)
            {
                Console.WriteLine($"Course with ID {courseId} is not found.");
                return;
            }
            
            if (course is OfflineCourse offlineCourse)
            {
                if (!offlineCourse.HasAvailableSeats())
                {
                    Console.WriteLine($"Course '{course.Title}' is full.");
                    return;
                }
            }
            
            course.EnrollStudent(student);
            Console.WriteLine($"Student '{student.GetFullName()}' enrolled to course '{course.Title}'.");
        }
        
        public List<Course> GetCoursesByTeacher(int teacherId)
        {
            return courses.Where(c => c.AssignedTeacher?.Id == teacherId).ToList();
        }
        
        public List<Student> GetStudentsByCourse(int courseId)
        {
            var course = courses.FirstOrDefault(c => c.Id == courseId);
            return course?.EnrolledStudents ?? new List<Student>();
        }
    }
}