using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Connection.SQLServer
{
    public class SqlserverImpl<T> : Isqlserver<T> where T : class
    {
        DataContext dataContext;
        DbSet<T> table;
        public SqlserverImpl(DataContext dataContext)
        {
            this.dataContext = dataContext;
            this.table = this.dataContext.Set<T>();
        }
        public void delete(object id)
        {
            T obj = table.Find(id);
            table.Remove(obj);
            save();
        }

        public IEnumerable<T> getAll()
        {
            return table.ToList();
        }

        public T getById(object id)
        {
            return table.Find(id);
        }

        public void insert(T obj)
        {
            dataContext.Add(obj).State = EntityState.Added;
            save();
        }

        public void save()
        {
            dataContext.SaveChanges();
        }

        public void update(T obj)
        {
            table.Update(obj);
            save();
        }
    }
}
