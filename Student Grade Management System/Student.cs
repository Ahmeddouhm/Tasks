using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Student_Grade_Management_System
{
    /*
    Properties/Attributes:

        studentId (string): Unique student ID
        name (string): Student's full name
        email (string): Student's email
        grades (Map/Dictionary/Associative Array): Subject names (keys) and grades (values)

    Methods:

        Constructor to initialize the student
        addGrade(subject, grade): Add or update a grade for a subject
        getGrade(subject): Returns the grade for a specific subject
        calculateAverage(): Returns the average of all grades
        getLetterGrade(): Returns letter grade based on average (A, B, C, D, F)
        getStudentInfo(): Returns formatted student information with all grades 
    */
    internal class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public Dictionary<string, float> Grades { get; set; }

        public Student(string id , string name , string email)
        {
            StudentID = id;
            StudentName = name;
            StudentEmail = email;
            Grades = new Dictionary<string, float>(StringComparer.OrdinalIgnoreCase);
        }

        public void AddGrade(string subject , float grade) 
        {
            if (string.IsNullOrEmpty(subject))
            {
                Console.WriteLine("[ERROR] Empty Subject Value !");
                return;
            }

            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("[ERROR] Wrong Grade Value !");
                return;
            }

            Grades[subject] = grade;
        }

        public float GetGrade(string subject) 
        {
            if (Grades.TryGetValue(subject , out float grade))
            {
                return grade;
            }

            Console.WriteLine("[ERROR] Subject Not Found !");
            return -1;
        }

        public float CalculateAverage() 
        {
            return Grades.Values.Average();
        }

        public string GetLetterGrade() 
        {
            if (Grades.Count == 0)
                return "N/A";

            var avgGrades = CalculateAverage();

            return avgGrades switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };
        }

        public void GetStudentInfo() 
        {
            Console.WriteLine($"{StudentName}");
            Console.WriteLine("============");
            Console.WriteLine($"ID : {StudentID}");
            Console.WriteLine($"E-Mail : {StudentEmail}");
            Console.WriteLine("============");
            foreach (var grade in Grades)
            {
                Console.WriteLine($"{grade.Key} : {grade.Value}");
            }
        }

    }
}
