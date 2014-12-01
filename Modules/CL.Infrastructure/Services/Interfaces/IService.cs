using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Infrastructure.Services.Interfaces
{
    public interface IService<GType, T, W>
        //where GType : Type
        where T : class
        where W : Criteria
    {
        IList<T> Search(W criteria);

        T Get(GType Id);

        T Add(T transaction);

        T Update(T transaction);

        bool Delete(GType Id);
    }
}
