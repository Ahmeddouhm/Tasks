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
        public const int TotalAttendanceDays = 50;
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public int AttendaceDays { get; set; }
        public Dictionary<string, float> Grades { get; set; } = new Dictionary<string, float>(StringComparer.OrdinalIgnoreCase);
        public Dictionary<string, float> SubjectsWeights { get; set; } = new();        

        public Student(string id , string name , string email , int attendance)
        {
            StudentID = id;
            StudentName = name;
            StudentEmail = email;
            AttendaceDays = attendance;
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

        public void SetAttendance(int attendance) => AttendaceDays = attendance;

        public void SetSubjectWeights(string subject , float weight) 
        {
            if (string.IsNullOrEmpty(subject))
            {
                Console.WriteLine("[ERROR] Empty Subject Value !");
                return;
            }

            SubjectsWeights.Add(subject, weight);
        }

        public float CalculateAverage() 
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            return Grades.Values.Average();
        }
        public float CalculateAverageWithAttendance() 
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            return (float)(Grades.Values.Average()* 0.9) + (float)(((AttendaceDays/TotalAttendanceDays)*100)*0.1);
        }
        public float CalculateHighestAverage() 
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            var gradesList = Grades.Values.ToList();

            if (Grades.Count > 1)
            {
                gradesList.Remove(gradesList.Min());
            }

            return gradesList.Average();
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
            Console.WriteLine("=== Student Information ===");
            Console.WriteLine($"ID : {StudentID}");
            Console.WriteLine($"Name : {StudentName}");
            Console.WriteLine($"Email : {StudentEmail}");
            Console.WriteLine("Grades :");
            foreach (var grade in Grades)
            {
                Console.WriteLine($"    {grade.Key} : {grade.Value}");
            }
            Console.WriteLine($"Average : {CalculateAverage():F2}");
        }

    }
}
