
using Domain.Models;
using NHibernate;
using Data.Configuration;
using Domain.IRepositories;
using System;
using Domain.Attributes;
using System.Linq;
using System.Collections.Generic;
using NHibernate.Criterion;
using System.Text;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using System.Collections;

namespace Data.Repositories
{
       public class BaseRepository
    {

    }
    public abstract class BaseRepository<T> : BaseRepository, IRepository<T> where T : BaseModel
    {

        protected ISession Session { get { return UnitOfWork.Current.Session; } }


        protected IQueryable<T> Queryable
        {
            get
            {
                return Session.Query<T>();
                //.Where(s => s.Tenant == context.TenantId || s.Tenant == null); 
            }
        }
        protected IQueryOver<T, T> QueryOverable
        {
            get
            {
                return Session.QueryOver<T>();
                //.Where(s => s.Tenant == context.TenantId); 
            }
        }





        [InTransaction]
        public virtual T GetById(Guid id)
        {

            return Session.Get<T>(id);
        }

        public IQueryable<T> GetList()
        {

            return Queryable;
        }

        public virtual List<T> GetByIds(List<Guid> ids)
        {
            
            return Session.QueryOver<T>().Where(s => s.Id.IsIn(ids)).List().ToList();
        }

        public virtual T Get(Guid id)
        {
            return Session.Get<T>(id);
        }

        [InTransaction]
        public virtual void Insert(T entity)
        {

            //entity.Tenant = context.TenantId;

            Session.Save(entity);

        }
        [InTransaction]
        public virtual void Update(T entity)
        {
            Session.Merge(entity);
        }

        //[InTransaction]
        public bool Delete(Guid id)
        {
            try{
                var obj=Session.Get<T>(id);
                Session.Delete(obj);
                return true;
            }catch{
                return false;
            }
        }

        public virtual List<T> GetAll()
        {
            return Session.QueryOver<T>().Where(d => d.Tenant != null).List().ToList();
        }
   

    }
 
}