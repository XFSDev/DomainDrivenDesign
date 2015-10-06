using CodeTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Persistence
{
    public class ClassRepository : IClassRepository
    {

        private readonly ISchoolDatabase _schoolDatabase;

        public ClassRepository()
            : this(new SchoolDatabase())
        {

        }


        public ClassRepository(ISchoolDatabase schoolDatabase)
        {
            _schoolDatabase = schoolDatabase;
        }


        public Student GetStudentBySurName(string surName)
        {
            return _schoolDatabase.Students.SingleOrDefault(s => s.SurName == surName);
        }

        public bool DeleteStudent(Student student)
        {
            Student studentToBeDeleted = _schoolDatabase.Students.SingleOrDefault(s => s.StudentID == student.StudentID);

            if (studentToBeDeleted != null)
            {
                _schoolDatabase.Students.Remove(studentToBeDeleted);
                return _schoolDatabase.CommitChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public bool Insert(Class entity)
        {
            _schoolDatabase.Classess.Add(entity);
            return _schoolDatabase.CommitChanges() > 0;
        }

        public bool Save(Class entity)
        {
            Class classTobeUpdated = _schoolDatabase.Classess.SingleOrDefault(c => c.ClassID == entity.ClassID);

            classTobeUpdated.UpdateClass(entity);

            return _schoolDatabase.CommitChanges() > 0;
        }

        public bool Delete(int id)
        {
            Class classTobeDeleted = _schoolDatabase.Classess.SingleOrDefault(c => c.ClassID == id);

            _schoolDatabase.Classess.Remove(classTobeDeleted);

            return _schoolDatabase.CommitChanges() > 0;
        }

        public IList<Class> GetAll()
        {
            return _schoolDatabase.Classess.ToList();
        }



        public IEnumerable<Student> GetStudentsByClassID(int id)
        {
            return _schoolDatabase.Students.Where(s => s.ClassID == id);
        }

        public bool Insert(Student classInfo)
        {
            this._schoolDatabase.Students.Add(classInfo);
            return _schoolDatabase.CommitChanges() > 0;
        }

        public bool Save(Student classInfo)
        {
             Student studentToBeUpdated = this._schoolDatabase.Students.SingleOrDefault(s => s.StudentID == classInfo.StudentID);
             studentToBeUpdated.Age = classInfo.Age;
             studentToBeUpdated.FirstName = classInfo.FirstName;
             studentToBeUpdated.Gpa = classInfo.Gpa;
             studentToBeUpdated.SurName = classInfo.SurName;

             return _schoolDatabase.CommitChanges() > 0;
        }
    }
}
