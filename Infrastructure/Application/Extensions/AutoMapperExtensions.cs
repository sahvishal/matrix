using System.Linq;
using AutoMapper;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Application.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreEntityBaseFields<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mapping)
        {
            foreach (var property in typeof(TDestination).GetProperties())
            {
                if ((property.DeclaringType == typeof(SD.LLBLGen.Pro.ORMSupportClasses.EntityBase2) 
                        || property.GetCustomAttributes(typeof(System.ComponentModel.BrowsableAttribute),false).Any()) && property.Name != "IsNew") //little hack!
                {
                    mapping = mapping.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return mapping;
        }

        public static IMappingExpression<TSource, TDestination> IgnoreEntityCollection<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mapping)
        {
            foreach (var property in typeof(TDestination).GetProperties())
            {
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericArguments().Where(t => t.BaseType == typeof(CommonEntityBase)).Any()) // another hack to avoid EntityCollection
                {
                    mapping = mapping.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return mapping;
        }
    }
     
}