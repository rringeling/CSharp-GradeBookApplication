using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook( string name ) : base( name ) { Type = GradeBookType.Ranked; }

        public override char GetLetterGrade( double averageGrade )
        {
            if ( Students.Count < 5 ) throw new InvalidOperationException();

            var threshold = (int)Math.Ceiling( Students.Count * 0.2 );
            var grades = Students.OrderByDescending( s => s.AverageGrade ).Select( s => s.AverageGrade ).ToList();

            if ( grades[threshold - 1] <= averageGrade ) { return 'A'; }
            if ( grades[threshold * 2] - 1 <= averageGrade ) { return 'B'; }
            if ( grades[threshold * 2] - 1 <= averageGrade ) { return 'C'; }
            if ( grades[threshold * 2] - 1 <= averageGrade ) { return 'D'; }

            return 'F';
        }
    }
}
