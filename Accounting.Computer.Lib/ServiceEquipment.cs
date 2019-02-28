using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Accounting.Computer.Lib
{

    public struct ServiceEquipment
    {
        public void AddData<T, T1>(Dictionary<T, T1> dic, T key, T1 value)
        {
            dic.Add(key, value);
        }
    }
}
