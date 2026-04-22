using Student_Grade_Management_System;

/*
Bonus Challenges

    1- Add validation for grades (must be between 0-100) => DONE
    2- Add a method to drop the lowest grade before calculating average => DONE
    3- Track attendance and factor it into final grade => 
    4- Add weighted grades (different subjects have different weights)
    5- Generate grade reports that can be saved to a file
    6- Add support for extra credit
    7- Implement grade trending (improvement over time)
*/

// Create a gradebook
var gradeBook = new GradeBook("Computer Science 101");

// Create students
var student1 = new Student("S001", "Alice Johnson", "alice@school.com",37);
var student2 = new Student("S002", "Bob Smith", "bob@school.com",45);
var student3 = new Student("S003", "Charlie Brown", "charlie@school.com",47);

// Add Subjects and weights 

// Add grades for students
student1.AddGrade("Math", 95.0f);
student1.AddGrade("English", 88.0f);
student1.AddGrade("Science", 92.0f);

student2.AddGrade("Math", 78.0f);
student2.AddGrade("English", 85.0f);
student2.AddGrade("Science", 80.0f);

student3.AddGrade("Math", 90.0f);
student3.AddGrade("English", 92.0f);
student3.AddGrade("Science", 89.0f);

// Add students to gradebook
gradeBook.AddStudent(student1);
gradeBook.AddStudent(student2);
gradeBook.AddStudent(student3);

// Display all students
gradeBook.DisplayAllStudents();
Console.WriteLine();

// Get class average
Console.WriteLine("Class Average: " + gradeBook.GetClassAverage().ToString("F2"));
Console.WriteLine();

// Get top students
var topStudents = gradeBook.GetTopStudents(2);
Console.WriteLine("Top 2 Students:");
foreach(var student in topStudents)
    Console.WriteLine(student.StudentName + ": " + student.CalculateAverage().ToString("F2"));
Console.WriteLine();

// List students with gradeletter
var gradeLetterStudents = gradeBook.GetStudentsByLetterGrade("C");

foreach(var student in gradeLetterStudents)
    Console.WriteLine($"{student.StudentName} - ({student.GetLetterGrade()})");
Console.WriteLine();

// Get student info
student1.GetStudentInfo();
