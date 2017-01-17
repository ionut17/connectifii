using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface IGroupRepository<T> : IRepository<T> where T : class, IEntity
    {
    }
}
