using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    public interface IName<T>
    {
        void SetName(T name);
        T GetName();
    }
}
