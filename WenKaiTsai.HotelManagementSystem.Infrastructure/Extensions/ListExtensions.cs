using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.Infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static List<T2> ConvertAll<T1, T2>(this IEnumerable<T1> source, Func<T1, T2> action)
        {
            List<T2> result = new List<T2>();
            foreach (T1 element in source)
            {
                result.Add(action(element));
            }
            return result;
        }
    }
}
