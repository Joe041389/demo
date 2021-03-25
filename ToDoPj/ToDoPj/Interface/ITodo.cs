using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPj.Interface
{
    interface ITodo<T> where T: class,new()
    {
        bool Create(T Itme);

        T ReadById(int? Id);

        IQueryable<T> ReadByKeyword(T Item);

        bool Update(T Item);

        bool Delete(int Id);

        IQueryable<T> ListAll();

    }
}
