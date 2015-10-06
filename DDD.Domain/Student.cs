using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Student : IEntity<Student>
    {
        public int ClassID { get; set; }
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public double Gpa { get; set; }

        public virtual Class Class { get; set; }




        public bool ValidatePersistence(IValidator<Student> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}
