using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Grade_Management_System
{
    /*
    Properties/Attributes:

        className (string): Name of the class
        students (List/Array of Student objects): List of all students

    Methods:

        Constructor to initialize the gradebook
        addStudent(student): Adds a student to the gradebook
        removeStudent(studentId): Removes a student by ID
        findStudent(studentId): Finds and returns a student
        getClassAverage(): Returns the average grade of all students
        getTopStudents(count): Returns the top performing students
        displayAllStudents(): Shows all students and their averages
        getStudentsByLetterGrade(letterGrade): Returns students with specific letter grade    
    */


    internal class GradeBook
    {
        public string ClassName { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public GradeBook(string className)
        {
            this.ClassName = className;
        }

        public void AddStudent(Student student) 
        {
            Students.Add(student);
        }

        public void RemoveStudent(string studentID) 
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("[ERROR] Empty Students List");
                return;
            }

            foreach (var student in Students)
            {
                if (studentID == null)
                {
                    Console.WriteLine("[ERROR] Please Enter Student ID");
                    return;
                }

                if (student.StudentID == studentID)
                {
                    Students.Remove(student);
                }
            }
        }

        public Student? FindStudent(string studentId) 
        {

            foreach (var student in Students)
            {
                if (student.StudentID == studentId)
                {
                    return student;
                }
            }

            return null;
        }

        public float GetClassAverage()
        {
            var classcount = Students.Count;
            float sum = 0f;

            foreach (var student in Students)
                sum += student.CalculateAverage();
            
            return sum / classcount;
        }

        public List<Student> GetTopStudents(int count)
        {
            var tempList = new List<(Student s, float avg)>();

            foreach (var student in Students)
            {
                var avg = student.CalculateAverage();
                tempList.Add((student , avg));
            }

            // DESC bubble sort 
            for (int i = 0; i < tempList.Count - 1; i++)
            {
                for (int j = 0; j < tempList.Count - i - 1; j++)
                {
                    if (tempList[j].avg < tempList[j+1].avg)
                    {
                        (tempList[j], tempList[j + 1]) = (tempList[j + 1], tempList[j]);
                    }
                }
            }

            var topStudentList = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                topStudentList.Add(tempList[i].s);
            }

            return topStudentList;
        }

        public void DisplayAllStudents()
        {
            Console.WriteLine($"=== {ClassName} - All Students ===");
            foreach (var student in Students)
            {
                Console.WriteLine($"{student.StudentID} - {student.StudentName} : {student.CalculateAverage():F2} ({student.GetLetterGrade()})");
            }
        }

        public List<Student>? GetStudentsByLetterGrade(string letterGrade)
        {
            var letterGradeList = new List<Student>();

            Console.WriteLine($"=== Students With Grade ({letterGrade}) ===");
            foreach (var student in Students)
            {
                if (student.GetLetterGrade() == letterGrade)
                {
                    letterGradeList.Add(student);
                }
            }

            return letterGradeList ?? new List<Student>();
        }

        public void ExportReport(string filePath) 
        {
            StringBuilder reportContent = new StringBuilder();
            reportContent.AppendLine($"{this.ClassName} Report - {DateTime.Today:d}");
            reportContent.AppendLine("==============");
            foreach (var student in Students)
            {
                reportContent.AppendLine($"{student.StudentID} - {student.StudentName} : {student.CalculateAverage():F2} ({student.GetLetterGrade()})");
            }
            File.WriteAllText(filePath, reportContent.ToString());
        }
    }
}
