using Domain.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Data.Mappings
{
    public class OrderMapping : IAutoMappingOverride<Order>
    {
        public void Override(AutoMapping<Order> mapping)
        {
            mapping.Id(it=>it.Id);
            mapping.Map(it=>it.RefId);
            mapping.Table("Order");
            mapping.Schema("CaterSoft");
            mapping.Map(it=>it.Tenant);
        }
    }
}