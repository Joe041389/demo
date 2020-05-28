using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Demo.Models.Interface
{
    interface ICRUD<T> where T : class, new()
    {
        bool Create(T Itme);

        T ReadById(int? Id);

        IQueryable<T> ReadByKeyword(string Keyword);

        bool Update(T Item);

        bool Delete(int Id);

        IQueryable<T> ListAll();
    }
}
