using System;
using Domain.Models;

namespace Domain.IRepositories
{
    public interface IRepository
    {
         
    }
    public interface IRepository<T>:IRepository where T :BaseModel
    {
         void Update(T bo);
         void Insert(T bo);
         T Get(Guid id);
        bool Delete(Guid id);
        
    }
}