using System;

namespace Domain.Attributes
{
     [AttributeUsage(AttributeTargets.Method)]
    public class InTransactionAttribute : Attribute
    {
        
    }
}