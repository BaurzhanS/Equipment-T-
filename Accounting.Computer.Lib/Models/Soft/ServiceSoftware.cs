using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Computer.Lib.Models.Soft
{
    
    public class ServiceSoftware<T> : LiteDbEntity<T>
    {
        public ServiceSoftware(string DbName) :base(DbName){}

        public void AddSoftware(T softWare)
        {
            this.Add(softWare);
        }
    }
}
