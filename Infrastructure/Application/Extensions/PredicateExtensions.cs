using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LinqExpression = System.Linq.Expressions.Expression;
using SD.LLBLGen.Pro.LinqSupportClasses.ExpressionHandlers;

namespace Falcon.App.Infrastructure.Application.Extensions
{
    public static class PredicateExtensions
    {
        public static Expression<Func<T, bool>> Null<T>() { return null; }

        public static Expression<Func<T, bool>> AddWithOr<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null)
            {
                return expr2;
            }
            var replacer = new ExpressionReplacer(CreateFromToReplaceSet(expr2.Parameters, expr1.Parameters), null, null, null, null);
            var rightExpression = (LambdaExpression)replacer.HandleExpression(expr2);

            return Expression.Lambda<Func<T, bool>>
                 (Expression.OrElse(expr1.Body, rightExpression.Body), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> AddWithAnd<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null)
            {
                return expr2;
            }
            var replacer = new ExpressionReplacer(CreateFromToReplaceSet(expr2.Parameters, expr1.Parameters), null, null, null, null);
            var rightExpression = (LambdaExpression)replacer.HandleExpression(expr2);
            return Expression.Lambda<Func<T, bool>>
                 (Expression.AndAlso(expr1.Body, rightExpression.Body), expr1.Parameters);
        }


        private static Dictionary<LinqExpression, LinqExpression> CreateFromToReplaceSet(IList<ParameterExpression> from,
                                            IList<ParameterExpression> to)
        {
            var toReturn = new Dictionary<LinqExpression, LinqExpression>();
            for (int i = 0; i < from.Count; i++)
            {
                toReturn.Add(from[i], to[i]);
            }
            return toReturn;
        }
    }
}