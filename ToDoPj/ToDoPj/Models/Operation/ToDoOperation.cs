﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoPj.Interface;

namespace ToDoPj.Models.Operation
{
    public class ToDoOperation : ITodo<tToDo> 
    {
        ToDoDBContext _db = new ToDoDBContext();

        public bool Create(tToDo oTodo)
        {
            try
            {
                _db.DbSettToDo.Add(oTodo);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public tToDo ReadById(int Id)
        {
            try
            {
                tToDo oTodo =  _db.DbSettToDo.Find(Id);
                return oTodo;
            }
            catch 
            {

                return null;
            }
        }

        public IQueryable<tToDo> ReadByKeyword(tToDo oToDo)
        {
            try
            {
                //IQueryable<tToDo> ToDoList = _db.DbSettToDo.Select(s => s);
                var Title = oToDo.fTitle;
                var Image = oToDo.fImage;
                IQueryable<tToDo> ToDoList = from _ToDoList in _db.DbSettToDo
                                             where _ToDoList.fTitle.Contains(Title) || _ToDoList.fImage.Contains(Image)
                                             select _ToDoList;
                //if (!string.IsNullOrWhiteSpace(Title))
                //{
                //    ToDoList = ToDoList.Where(t => t.fTitle.Contains(Title));
                //}

                //if (!string.IsNullOrWhiteSpace(Image))
                //{
                //    ToDoList = ToDoList.Where(m => m.fImage.Contains(Image));
                //}




                return ToDoList;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(tToDo oTodo)
        {
            try
            {
                _db.Entry(oTodo).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }


        public bool Delete(int Id)
        {
            try
            {
               tToDo oToDo =  _db.DbSettToDo.Find(Id);
                if (oToDo != null)
                {
                    _db.DbSettToDo.Remove(oToDo);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch 
            {

                return false;
            }
        }

        public IQueryable<tToDo> ListAll()
        {
            try
            {
                IQueryable<tToDo> ToDoList = _db.DbSettToDo.OrderByDescending( s => s.fDate);
                return ToDoList;
            }
            catch 
            {

                return null;
            }
        }


        public ToDoDBContext GetDBContext()
        {
            return _db;
        }
    }
}