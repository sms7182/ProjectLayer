using System;
using Data.Mappings;
using Domain.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Data.Configuration
{
    public class ORMSession
    {
          
       public static ISessionFactory CreateMSSqlNhSessionFactory(){
           
          var automappings= AutoMap.AssemblyOf<OrderMapping>();
         
         var dbConfig=MsSqlConfiguration.MsSql2012.
                         
                ConnectionString(@"Integrated Security=False;data source=localhost;
                Database=TestDB;User ID=sa;Password=sa123;Persist Security Info=True;Max Pool Size=50000;Pooling=True;");
               //  .Provider("System.Data.SqlClient");
            var mappings= Fluently.Configure().
                Database(dbConfig.ShowSql())
               
               .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Order>().
               UseOverridesFromAssemblyOf<OrderMapping>()
              .Where(d=>d.BaseType==typeof(BaseModel)
               )
               ));


             ISessionFactory buildSessionFactory=null ;
            try{
               FluentConfiguration fluentConfiguration=mappings.ExposeConfiguration(d => 
               { new SchemaUpdate(d).Execute(true,true);
                            new SchemaExport(d)
                .Create(false,false);});
               buildSessionFactory= fluentConfiguration.BuildSessionFactory();
               }
               catch(Exception ex){
                     Console.Write("exeption is ",ex.StackTrace);
               }
            return buildSessionFactory;
       }       
          
    }
}