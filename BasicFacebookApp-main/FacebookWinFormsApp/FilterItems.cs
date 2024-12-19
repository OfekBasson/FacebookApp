using CefSharp.DevTools.Accessibility;
using CefSharp.DevTools.CSS;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    internal static class FilterItems
    {
       
        public static List<T> FilterByProperty<T>(List<T> i_Items, string i_PropertyName, string i_FilterValue)
        {
            if (i_Items == null)
                throw new ArgumentNullException(nameof(i_Items), "Items list cannot be null.");
            if (string.IsNullOrWhiteSpace(i_PropertyName) || i_FilterValue == "")
            {
                return i_Items;
            }

            if (i_PropertyName == "ToString")
            {
                return filterByToString(i_Items, i_PropertyName, i_FilterValue);
            }

            return filterByDefaultProperty(i_Items, i_PropertyName, i_FilterValue);
        }

        private static List<T> filterByDefaultProperty<T>(List<T> i_Items, string i_PropertyName, string i_FilterValue)
        {
            // Check if the property exists in type T
            var property = typeof(T).GetProperty(i_PropertyName);
            if (property == null)
                throw new InvalidOperationException($"Type {typeof(T)} does not have a property named '{i_PropertyName}'.");

            return i_Items
                .Where(item =>
                {
                    var value = property.GetValue(item);
                    if (value is DateTime dateTimeValue)
                    {
                        return dateTimeValue.ToString("dd/MM/yyyy HH:m:s").Contains(i_FilterValue);
                    }
                    else
                    {
                        value = property.GetValue(item) as string;
                        return value != null && value.ToString().Contains(i_FilterValue);
                    }
                })
                .ToList();
        }

        private static List<T> filterByToString<T>(List<T> i_Items, string i_PropertyName, string i_FilterValue)
        {
            return i_Items
                .Where(item => item.ToString() != null && item.ToString().Contains(i_FilterValue)).ToList();
        }

        public static List<T> FilterByMember<T>(IEnumerable<T> i_Collection, string i_MemberName)
        {
            var filteredList = new List<T>();

            foreach (var item in i_Collection)
            {
                var property = item.GetType().GetProperty(i_MemberName);
                if (property != null)
                {
                    var value = property.GetValue(item, null)?.ToString();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        filteredList.Add(item);
                    }
                }
            }

            return filteredList; 
        }


    }
}
