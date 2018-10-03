using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MP.ActiveDirectoryInfo.Extensions
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            ObservableCollection<T> list = new ObservableCollection<T>();

            foreach (T item in collection)
            {
                list.Add(item);
            }

            return list;
        }
    }
}