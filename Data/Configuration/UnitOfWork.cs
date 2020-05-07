using System;
using NHibernate;

namespace Data.Configuration
{
    public class UnitOfWork:IUnitOfWork
    {
        [ThreadStatic]
       private static UnitOfWork unitOfWork;
        public static UnitOfWork Current{
            get{return unitOfWork ;}
            set{unitOfWork=value;}
        }
        public ISession Session{get;private set;}

        private readonly ISessionFactory sessionFactory;
        private ITransaction transaction;
        public UnitOfWork(ISessionFactory currentSessionFactory)
        {
            sessionFactory=currentSessionFactory;
        }
        public void BeginTransaction()
        {
            Session=sessionFactory.OpenSession();
            transaction=Session.BeginTransaction();
        }

        public void Commit()
        {
           try{
               transaction.Commit();
           }
           catch(Exception ex){
                WriteException(ex);
                throw;
             }
             finally{
                 Session.Close();
             }
        }
        void WriteException(Exception exception){
            /// <summary>
            /// todo write exceptionLog
            /// </summary>
        }
        public void Rollback()
        {
           try{
               transaction.Rollback();
           }
           finally{
               Session.Close();
           }
        }
        
    }
}