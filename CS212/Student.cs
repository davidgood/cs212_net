using System;
using System.Collections.Generic;

namespace CS212
{
    public class Student(string name, string id, StudentType studentType) : Person(name, id)
    {
        private readonly Dictionary<IGradable, Grade> _grades = new();

        private StudentType StudentType => studentType;

        public void AddGrade(IGradable gradable, int grade)
        {
            _grades[gradable] = new Grade(grade);
        }

        public int? GetGrade(IGradable gradable)
        {
            return _grades.TryGetValue(gradable, out var grade) ? grade.Points : null;
        }

        protected double CalculateAverageGrade()
        {
            if (_grades.Count == 0) return 0;
            var total = _grades.Values.Aggregate<Grade?, double>(0, (current, grade) => current + grade?.Points ?? 0);
            return total / _grades.Count;
        }

        public override void SimulateApiPost()
        {
            Console.WriteLine("Posting student data to external system:");
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Student ID: {Id}");
            Console.WriteLine($"Student Type: {StudentType}");

            foreach (var entry in _grades)
            {
                Console.WriteLine($"Assignment: {entry.Key.Name}, Grade: {entry.Value.Points}");
            }

            Console.WriteLine($"Average Grade: {CalculateAverageGrade()}");
        }
    }
}