namespace Dixin.Linq.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    internal static partial class CompiledExpressionTree
    {
        internal static void LinqToEntities(IQueryable<Product> source)
        {
            ParameterExpression productParameter = Expression.Parameter(typeof(Product), "product");
            Expression<Func<Product, bool>> predicateExpression = Expression.Lambda<Func<Product, bool>>(
                Expression.GreaterThan(
                    Expression.Property(productParameter, nameof(Product.ListPrice)),
                    Expression.Constant(0M, typeof(decimal))),
                productParameter);

            IQueryable<Product> query = Queryable.Where(source, predicateExpression); // Define query.
            foreach (Product result in query) // Execute query.
            {
                Trace.WriteLine(result.Name);
            }
        }
    }

    internal static partial class CompiledExpressionTree
    {
        [CompilerGenerated]
        private static Func<Product, bool> cachedPredicate;

        [CompilerGenerated]
        private static bool Predicate(Product product) => product.ListPrice > 0M;

        public static void LinqToObjects(IEnumerable<Product> source)
        {
            Func<Product, bool> predicate = cachedPredicate ?? (cachedPredicate = Predicate);
            IEnumerable<Product> query = Enumerable.Where(source, predicate);
            foreach (Product result in query) // Execute query.
            {
                Trace.WriteLine(result.Name);
            }
        }
    }
}