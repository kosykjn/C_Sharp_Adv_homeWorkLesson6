using System;
using System.IO;
using System.Reflection;


namespace homeWorkLesson6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load("homeWorkLesson6_1");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Type type = assembly.GetType("homeWorkLesson6_1.TemperatureConverter");

            object instance = Activator.CreateInstance(type);

            MethodInfo methodConverToCelsius = type.GetMethod("ConverToCelsius");

            Console.WriteLine("Введите температуру в Фаренгейтах:");
            int userFahrenheitNumber = Convert.ToInt32(Console.ReadLine());

            object[] parameters = { userFahrenheitNumber };

            Console.WriteLine(methodConverToCelsius.Invoke(instance, parameters));

            MethodInfo methodConverToFahrenheit = type.GetMethod("ConverToFahrenheit");

            Console.WriteLine("Введите температуру в Цельсиях:");
            int userCelsiusNumber = Convert.ToInt32(Console.ReadLine());

            object[] parameters2 = { userCelsiusNumber };

            Console.WriteLine(methodConverToFahrenheit.Invoke(instance, parameters2));

            Console.ReadKey();
        }
    }
}
