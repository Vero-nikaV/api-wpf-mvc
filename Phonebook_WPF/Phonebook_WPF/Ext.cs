using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_WPF
{
    internal static class Ext
    {
        /// <summary>
        /// Перевод IEnumerable<Contact> в ObservableCollection<Contact> для вывода в listview
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static ObservableCollection<Contact> ToObservableCollection(this IEnumerable<Contact> e)
        {
            ObservableCollection<Contact> t = new ObservableCollection<Contact>();
            foreach (var item in e)
            {
                t.Add(item);
            }
            return t;
        }
    }
}
