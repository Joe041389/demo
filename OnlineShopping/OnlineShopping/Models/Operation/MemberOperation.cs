using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping.Models.Interface;

namespace OnlineShopping.Models.Operation
{
    public class MemberOperation : ICRUD<Members>
    {
        private readonly OnlineShoppingEntities _db = new OnlineShoppingEntities();

        public bool Create(Members oMember)
        {
            try
            {
                _db.DbSetMembers.Add(oMember);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }


        public bool Delete(int? Id)
        {
            try
            {
                Members oMember = _db.DbSetMembers.Find(Id);
                _db.DbSetMembers.Remove(oMember);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Members> ListAll()
        {
            try
            {
                IQueryable<Members> MemberList = from _MemberList in _db.DbSetMembers
                                                 select _MemberList;
                return MemberList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Members ReadById(int? Id)
        {
            try
            {
                Members oMember = _db.DbSetMembers.Where(s => s.Id == Id).FirstOrDefault();
                return oMember;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Members ReadByEmail(string Email)
        {
            try
            {
                Members oMember = _db.DbSetMembers.Where(s => s.Email == Email).FirstOrDefault();
                return oMember;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public IQueryable<Members> ReadByKeyword(string Keyword)
        {
            try
            {
                IQueryable<Members> MemberList = from _MemberList in _db.DbSetMembers
                                                 where (_MemberList.Name.Contains(Keyword)
                                                 || _MemberList.Phone.Contains(Keyword)
                                                 )
                                                 select _MemberList;
                return MemberList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Members Login(string Email,string Pwd)
        {
            try
            {
                Members oMember = _db.DbSetMembers.Where(m => m.Email == Email && m.Pwd == Pwd).FirstOrDefault();
                return oMember;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(Members oMember)
        {
            try
            {
                _db.Entry(oMember).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DBDispose()
        {
            _db.Dispose() ;
        }
    }
}