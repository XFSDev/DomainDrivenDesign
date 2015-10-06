using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepository<TAggregate> where TAggregate : IAggregateRoot
    {
        bool Insert(TAggregate entity);
        bool Save(TAggregate entity);
        bool Delete(TAggregate entity);
        IList<TAggregate> GetAll();
    }
}
