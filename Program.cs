using System;
using System.Collections.Generic;

namespace LabWork
{
    public interface IBuilda
    {
        void AddSubject(string subject);
        void SetDuration(int weeks);
        void SetComplexityLevel(string complexity);
        EducationalProgram Build();
    }
    public class Builda : IBuilda
    {
        private readonly EducationalProgram _program = new EducationalProgram();

        public void AddSubject(string subject)
        {
            _program.Subjects.Add(subject);
        }

        public void SetDuration(int weeks)
        {
            _program.DurationInWeeks = weeks;
        }

        public void SetComplexityLevel(string complexity)
        {
            _program.ComplexityLevel = complexity;
        }

        public EducationalProgram Build()
        {
            return _program;
        }
    }
    public class EducationalProgram
    {
        public List<string> Subjects { get; set; } = new List<string>();
        public int DurationInWeeks { get; set; }
        public string ComplexityLevel { get; set; }

        public override string ToString()
        {
            return $"Educational Program:\n" +
                   $"Subjects: {string.Join(", ", Subjects)}\n" +
                   $"Duration: {DurationInWeeks} weeks\n" +
                   $"Complexity Level: {ComplexityLevel}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Builda builder = new Builda();
            Console.WriteLine("Add subjects, enter . to move on.");
            bool complete = false;
            string a;
            while (!complete) {
                a = Console.ReadLine();
                if (a == ".") { complete = true; }
                else { builder.AddSubject(a); }

            }
            Console.WriteLine("Enter duration in weeks");
            builder.SetDuration(System.Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Enter complexity as a string");
            builder.SetComplexityLevel(Console.ReadLine());
            var example = builder.Build();
            Console.WriteLine(example);

        }
    }
}