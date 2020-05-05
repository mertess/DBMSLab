using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMLab5.Logic
{
    public interface ICrud<T>
    {
        List<T> FindAll();
        T Get(int id);
        List<T> FindAll(int offset, int count);
        void Update(T model);
        void Create(T model);
        void Delete(T model);
    }
}
