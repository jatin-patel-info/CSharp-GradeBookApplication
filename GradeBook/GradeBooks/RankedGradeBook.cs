using System;
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
            int gradeSection = studentCount/5;

            if(studentCount < 5)
            {
                throw new InvalidOperationException();
            }
            //List<Student> OrderedStudents = new List<Student>();

            
            var orderedStudents = Students.OrderByDescending(s => s.AverageGrade).ToList();
            var sectionCount = gradeSection;

            if (averageGrade >= orderedStudents[sectionCount - 1].AverageGrade)
                return 'A';
            else if (averageGrade >= orderedStudents[sectionCount * 2 - 1].AverageGrade)
                return 'B';
            else if (averageGrade >= orderedStudents[sectionCount * 3 - 1].AverageGrade)
                return 'C';
            else if (averageGrade >= orderedStudents[sectionCount * 4 - 1].AverageGrade)
                return 'D';
            else if (averageGrade >= orderedStudents[sectionCount * 5 - 1].AverageGrade)
                return 'E';
            else
                return 'F';
        }
    }
}
