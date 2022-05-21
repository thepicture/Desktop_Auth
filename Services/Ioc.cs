using System;
using System.Linq;
using System.Windows;

namespace TelekomNevaSvyazWpfApp
{
    public static class Ioc
    {
        public static void Register<T>()
        {
            string registrationName = typeof(T)
                                .GetInterfaces()
                                .First(i =>
                                {
                                    return i.Name.Contains(typeof(T).Name);
                                }).Name;
            Application.Current.Resources[
                registrationName] = Activator.CreateInstance(typeof(T));
        }

        public static T Get<T>()
        {
            string typeName = typeof(T).Name;
            return (T)Application.Current.Resources[typeName];
        }
    }
}
