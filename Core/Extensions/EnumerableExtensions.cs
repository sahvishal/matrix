using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns the number of elements in the given enumerable collection.
        /// </summary>
        /// <param name="enumerable">The enumerable to count the items of.</param>
        /// <returns>The number of elements in the given enumerable.</returns>
        public static int Count(this IEnumerable enumerable)
        {
            int count = 0;
            foreach (var item in enumerable)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// Gets whether or not the given collection has any items.
        /// </summary>
        /// <param name="enumerableToCheck">The collection to check.</param>
        /// <returns>True if the collection contains no items; false otherwise.</returns>
        public static bool IsEmpty(this IEnumerable enumerableToCheck)
        {
            return enumerableToCheck.Count() == 0;
        }

        /// <summary>
        /// Gets whether or not the given collection is null or has any items.
        /// </summary>
        /// <param name="enumerableToCheck">The collection to check.</param>
        /// <returns>True if the collection is null or contains no items; false otherwise.</returns>
        public static bool IsNullOrEmpty(this IEnumerable enumerableToCheck)
        {
            return enumerableToCheck == null || enumerableToCheck.Count() == 0;
        }

        /// <summary>
        /// Gets whether or not a given collection has only one item.
        /// </summary>
        /// <param name="listToCheck">The collection to check.</param>
        /// <returns>True if the collection contains exactly one item; false otherwise.</returns>
        public static bool HasSingleItem(this IEnumerable listToCheck)
        {
            return listToCheck.Count() == 1;
        }

        /// <summary>
        /// Sorts the given collection in the specified order.
        /// </summary>
        /// <param name="listToSort">The collection to sort.</param>
        /// <param name="sortDirection">The direction in which the given collection will be sorted.</param>
        /// <param name="selector">The selector statement to get the field on which to sort the collection.</param>
        /// <returns>The sorted collection.</returns>
        public static IEnumerable<T> Sort<T, TKey>(this IEnumerable<T> listToSort, OrderByDirection sortDirection, Func<T, TKey> selector)
        {
            switch (sortDirection)
            {
                case OrderByDirection.Descending:
                    return listToSort.ToList().OrderByDescending(selector);
                default:
                    return listToSort.ToList().OrderBy(selector);
            }
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            var table = new DataTable();

            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor prop = properties[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            var values = new object[properties.Count];

            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            return table;
        }

        public static void ForEach<T>(this IEnumerable<T> data, Action<T> action)
        {
            foreach (var item in data)
            {
                action(item);
            }
        }

    }
}