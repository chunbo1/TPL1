using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflection
{
    class Class1
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = 15 / 7;
            try
            {
                Dictionary<int, string> dict =
                        new Dictionary<int, string>();
                dict.Add(1, "---1");
                dict.Add(2, "2");
                Console.WriteLine(dict[1]);
                throw new Exception(); 
            }
            catch (Exception e)
            { Console.WriteLine("in catch"); }
            finally
            { Console.WriteLine("in finally"); }
            Class1 c1 = new Class1();
            //  Show the current module.
            Module m = c1.GetType().Module;
            Console.WriteLine("The current module is {0}.", m.Name);

            //  List all modules in the assembly.
            Assembly curAssembly = typeof(Program).Assembly;
            Console.WriteLine("The current executing assembly is {0}.", curAssembly);

            Module[] mods = curAssembly.GetModules();
            foreach (Module md in mods)
            {
                Console.WriteLine("This assembly contains the {0} module", md.Name);
            }
            Console.ReadLine();
        }
    }
}
