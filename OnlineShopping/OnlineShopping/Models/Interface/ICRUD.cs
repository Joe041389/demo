using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.Interface
{
    interface ICRUD<T> where T : class, new()
    {
        bool Create(T Itme);

        T ReadById(int? Id);

        IQueryable<T> ReadByKeyword(string Keyword);

        bool Update(T Item);

        bool Delete(int? Id);

        IQueryable<T> ListAll();

        void DBDispose();
    }
}