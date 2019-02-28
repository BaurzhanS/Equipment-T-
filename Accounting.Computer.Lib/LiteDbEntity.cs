using System;
using LiteDB;
using Accounting.Computer.Lib.Models.Soft;
using Accounting.Computer.Lib.Interfaces;
using System.Collections.Generic;

namespace Accounting.Computer.Lib
{
    public class LiteDbEntity<T> : ILiteDbEntity<T> where T: class
    {
        public T obj = default(T);

        List<T> list = new List<T>();

        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public LiteDbEntity(string DbName)
        {
            this.DbName = DbName;
        }
        private string DbName { get; set; }

        public event PrintMessage printMessage;
        public event ShowError showError;
        public event SendNotification<T> sendNotification;

        public void Add(T data)
        {
            try
            {
                if (string.IsNullOrEmpty(DbName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(DbName))
                {
                    var collection = db.GetCollection<T>(typeof(T).Name);
                    collection.Insert(data);
                }

                if (printMessage != null)
                    printMessage.Invoke("Запись добавлена успешно");

                if (sendNotification != null)
                    sendNotification.Invoke(data);
            }
            catch (Exception ex)
            {
                if (showError != null)
                    showError.Invoke(ex);
            }
        }

        public void Edit(T data)
        {
            try
            {
                if (string.IsNullOrEmpty(DbName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(DbName))
                {
                    var collection = db.GetCollection<T>(typeof(T).Name);
                    collection.Update(data);
                }

                if (printMessage != null)
                    printMessage.Invoke("Запись добавлена изменена");

                //if (sendNotification != null)
                //    sendNotification.Invoke(data);
            }
            catch (Exception ex)
            {
                if (showError != null)
                    showError.Invoke(ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(DbName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(DbName))
                {
                    var collection = db.GetCollection<T>(typeof(T).Name);
                    collection.Delete(id);
                }
                if (printMessage != null)
                    printMessage.Invoke("Запись удалена успешно");
            }
            catch (Exception ex)
            {
                if (showError != null)
                    showError.Invoke(ex);
            }
        }

        //public List<T> SearchEquipment(string name)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(DbName))
        //            throw new Exception("Строка подключения к базе данных не должна быть пустой");

        //        using (LiteDatabase db = new LiteDatabase(DbName))
        //        {
        //            var collection = db.GetCollection<T>(typeof(T).Name);
        //            if(typeof(T).Name.Equals("Equipment"))
        //            {
        //                List<Equipment> listEq = null;

        //                listEq = collection.Find();
        //            }
                    
        //        }
        //        return listEq;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (showError != null)
        //        {
        //            showError.Invoke(ex);
        //        }
        //        return listEq;
        //    }
        //}
    }
}
