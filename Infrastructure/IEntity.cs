using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IEntity<T>
    {
        bool ValidatePersistence(IValidator<T> validator, out IEnumerable<string> brokenRules);
    }
}
