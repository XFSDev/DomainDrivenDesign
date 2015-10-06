using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public interface IClassRepository : IRepository<Class>
    {
        Student GetStudentBySurName(string surName);

        bool DeleteStudent(Student student);
    }
}
