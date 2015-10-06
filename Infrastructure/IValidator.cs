using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IValidator<T>
    {
        bool IsValid(T entity, out IEnumerable<string> brokenRules);
        IEnumerable<string> BrokenRules(T entity);
    } 
}
