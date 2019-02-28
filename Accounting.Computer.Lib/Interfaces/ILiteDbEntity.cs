using Accounting.Computer.Lib.Models.Soft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Computer.Lib.Interfaces
{
    public interface ILiteDbEntity<T> 
    {
        event PrintMessage printMessage;
        event ShowError showError;
        event SendNotification<T> sendNotification;

        void Add(T data);
        void Edit(T data);
        void Delete(int id);
    }
}   
