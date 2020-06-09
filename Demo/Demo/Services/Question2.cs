using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Demo.Services
{
    public class Question2
    {
        public int Run()
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10000; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    GetNextId();
                }));
            }
            Task.WaitAll(tasks.ToArray());
           
            string strCurrentID = "currentId=" + GetCurrentId();
            return GetCurrentId();
        }

        private int currentId;
        public int GetNextId()
        {
            currentId++;
            return currentId;
        }

        public int GetCurrentId()
        {
            return currentId;
        }

    }
}