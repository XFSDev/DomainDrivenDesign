using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Domain
{

    public class StudentValidator : IValidator<Student>
    {


        private readonly IClassRepository _classRepository;

        public StudentValidator(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public bool IsValid(Student entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }

        public IEnumerable<string> BrokenRules(Student entity)
        {
            if (string.IsNullOrEmpty(entity.SurName))
                yield return "A student must have a surname";

            Student student = _classRepository.GetStudentBySurName(entity.SurName);

            if (entity.StudentID.Equals(0))
            {
                if (student != null)
                {
                    yield return string.Format("A student with surname {0} already exist", entity.SurName);
                }
            }


            yield break;
        }
    }

}
