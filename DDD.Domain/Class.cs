using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Class : IEntity<Class>, IAggregateRoot
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string Location { get; set; }
        public string TeacherName { get; set; }
        public virtual ICollection<Student> Students { get; set; }



        public bool ValidatePersistence(IValidator<Class> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }


        public void UpdateClass(Class classTobeUpdated)
        {
            this.ClassName = classTobeUpdated.ClassName;
            this.Location = classTobeUpdated.Location;
            this.TeacherName = classTobeUpdated.TeacherName;
        }

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            Student studentToBeUpdated = this.Students.SingleOrDefault(s => s.StudentID == student.StudentID);

            if (studentToBeUpdated != null)
            {
                studentToBeUpdated.Age = student.Age;
                studentToBeUpdated.FirstName = student.FirstName;
                studentToBeUpdated.Gpa = student.Gpa;
                studentToBeUpdated.SurName = student.SurName;
            }
        }

    }
}
