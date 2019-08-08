namespace Interns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<Intern> GetInterns()
        {
            return new List<Intern>
                       {
                           new Intern("Ioana Mihaela Cegus", "10", "IoanaMihaela.Cegus@endava.com"),
                           new Intern("Mihai Huminiuc", "10", "Mihai.Huminiuc@endava.com"),
                           new Intern("Teodor Frunza", "10", "Teodor.Frunza@endava.com"),
                           new Intern("Lucian Cumpata", "10", "Lucian.Cumpata@endava.com"),
                           new Intern("Ilie Petrasco", "10", "Ilie.Petrasco@yahoo.com"),
                           new Intern("Anca Cazacu", "10", "Anca.Cazacu@yahoo.comm"),
                           new Intern("Cristian Chircan", "10", "Cristian.Chircan@endava.com"),
                           new Intern("David Zanoschi", "10", "David.Zanoschi@gmail.com"),
                           new Intern("Ioana Croitoru", "10", "Ioana.Croitoru@endava.com"),
                           new Intern("Camelia Onu", "10", "Camelia.Onu@endava.com")
                       };
        }

        // private static void InsertData()
        // {
        // var interns = GetInterns();
        // var internDb = new InternDb();

        // if (internDb.Interns.Any())
        // {
        // return;
        // }

        // foreach (var intern in interns)
        // {
        // internDb.Interns.Add(intern);
        // }

        // internDb.SaveChanges();
        // }
        private static void Main(string[] args)
        {
            var interns = GetInterns();
            interns[0].Trainers = new List<string> { "Andrei", "Raluca" };
            interns[1].Trainers = new List<string> { "Andrei" };
            interns[2].Trainers = new List<string> { "Mara" };

            var filteredInterns = interns;

            // select endava people (from email), look through methods
            filteredInterns = interns.Where(x => x.Email.Contains("@endava")).ToList();
            // query syntax get all 10 grade orderby name 
            filteredInterns = (from intern in interns where intern.Grade == "10" orderby intern.Name select intern).ToList();

            // select first Ioana (first/firstOrDefault)
            var ioana = interns.FirstOrDefault(x => x.Name.Contains("Asdsf")) == null ? string.Empty : interns.FirstOrDefault(x => x.Name.Contains("Asdsf")).Name;
            Console.WriteLine(ioana);

            // select single Mihai
            ioana = interns.SingleOrDefault(x => x.Name.Contains("Mihai")) == null ? string.Empty : interns.FirstOrDefault(x => x.Name.Contains("Asdsf")).Name;
            Console.WriteLine(ioana);
            // order in which methods are written 
            var names = interns.WhereGradeIs10().Select(
                x => { return new { Grade = x.Grade, Name = x.Name }; }).ToList();

            // select anonymous types

            // custom filter -no

            foreach (var filteredIntern in filteredInterns)
            {
                Console.WriteLine(filteredIntern.Name);
            }

            Console.ReadLine();
        }
    }
}