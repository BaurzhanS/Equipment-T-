using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Computer.Lib
{
    public delegate void PrintMessage(string str);
    public delegate void ShowError(Exception ex);
    public delegate void SendNotification<T>(T data);
}
