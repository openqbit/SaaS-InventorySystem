using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using System.Data.Entity;
using OpenQbit.Inventory.DAL.DataAccess.Contr;
using OpenQbit.Inventory.Common.Utils.Logs;
using Microsoft.Practices.Unity;

namespace OpenQbit.Inventory.DAL.DataAccess
{
    public class Repository : IRepository
    {
        private OpenQbitInventoryContext _db = new OpenQbitInventoryContext();

        private ILogger _logger;

        [InjectionConstructor]
        public Repository( ILogger logger)
        {
            this._logger = logger;
        }

        public List<T> GetAll<T>() where T : class
        {
            return _db.Set<T>().ToList();
        }

        

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _db.Set<T>().FirstOrDefault<T>(predicate);
        }

        public List<T> FindList<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _db.Set<T>().Where<T>(predicate).ToList();
        }


        public bool Create<T>(T obj) where T : class
        {
           // _db.Item.Add()
            try
            {
                _db.Set<T>().Add(obj);
                return true;
            }
            catch (Exception edb)
            {
                
                return false;
            }

        }

        public bool Update<T>(T obj) where T : class
        {
            try
            {
                var edbstate = _db.Entry(obj);
                _db.Set<T>().Attach(obj);
                edbstate.State = EntityState.Modified;
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }

        public bool Delete<T>(T obj) where T : class
        {
            try
            {
                _db.Set<T>().Remove(obj);
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (Exception edb)
            {
                return false;
            }
        }

        public T FindById<T>(int id) where T : class
        {
            return _db.Set<T>().Find(id);
        }
    }
}
