using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Domain
{ 

    public class ClassValidator : IValidator<Class>
    {
        public bool IsValid(Class entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }

        public IEnumerable<string> BrokenRules(Class entity)
        {
            if (string.IsNullOrEmpty(entity.ClassName))
                yield return "A class must have a name";

            yield break;
        }
    }
}
