﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace OpenQbit.Inventory.DAL.DataAccess.Contr
{
    public interface IRepository
    {
        List<T> GetAll<T>() where T : class;
        T Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        List<T> FindList<T>(Expression<Func<T, bool>> predicate) where T : class;
        T FindByID<T>(int id) where T : class;
        bool Create<T>(T obj) where T : class;
        bool Update<T>(T obj) where T : class;
        bool Delete<T>(T obj) where T : class;
        bool Save();
    }
}
