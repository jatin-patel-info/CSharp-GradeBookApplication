﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int studentCount = Students.Count;
            int gradeSection = (int)Math.Ceiling(studentCount/5.0);

            if(studentCount < 5)
            {
                throw new InvalidOperationException();
            }
            //List<Student> OrderedStudents = new List<Student>();

            
            var orderedStudentsGrade = Students.OrderByDescending(s => s.AverageGrade).Select(s=>s.AverageGrade).ToList();
            var sectionCount = gradeSection; 

            if (averageGrade >= orderedStudentsGrade[sectionCount - 1])
                return 'A';
            if (averageGrade >= orderedStudentsGrade[sectionCount * 2 - 1])
                return 'B';
            if (averageGrade >= orderedStudentsGrade[sectionCount * 3 - 1])
                return 'C';
            if (averageGrade >= orderedStudentsGrade[sectionCount * 4 - 1])
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            int studentCount = Students.Count;

            if (studentCount < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            int studentCount = Students.Count;

            if (studentCount < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
