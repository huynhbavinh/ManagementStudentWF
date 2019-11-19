using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateORupdate
{
    class ClassManagement
    {
        
        public @class[] GetClasses()
        {
            var db = new CsharpDATABASEEntities();
            var classes = db.classes.ToArray();

            return classes;
        }
        public void AddClass(string name, string descrip)
        {
            var NewClass = new @class();
            NewClass.name = name;
            NewClass.descrip = descrip;

            var db = new CsharpDATABASEEntities();
            db.classes.Add(NewClass);
            db.SaveChanges();

        }
        public void EditClass(int id, string name, string descrip)
        {
            var db = new CsharpDATABASEEntities();
            var OldClass = db.classes.Find(id);
            OldClass.name = name;
            OldClass.descrip = descrip;

            db.Entry(OldClass).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteClass(int id)
        {
            var db = new CsharpDATABASEEntities();
            var DelClass = db.classes.Find(id);
            db.classes.Remove(DelClass);
            db.SaveChanges();
        }
        public @class GetClass(int id)
        {
            var db = new CsharpDATABASEEntities();
            var Class1 = db.classes.Find(id);
            return Class1;
        }
    }
}
