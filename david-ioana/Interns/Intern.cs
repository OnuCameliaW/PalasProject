namespace Interns
{
    using System.Collections.Generic;

    public class Intern
    {
        public Intern(string name, string grade, string email)
        {
            Name = name;
            Grade = grade;
            Email = email;
        }

        public string Email { get; set; }

        public string Grade { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> Trainers { get; set; }
    }
}