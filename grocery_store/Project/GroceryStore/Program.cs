using System;
using System.IO;
using System.Linq;
using GroceryStore.Time;
using GroceryStore.Utility;

namespace GroceryStore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

                if (args.Count() != 1)
                {
                    Console.WriteLine("Incorrect number of arguments.  End program.");
                    return;
                }
                    
                if(!File.Exists(args[0].Trim()))
                {
                    Console.WriteLine("Input file: " + args[0] +  " could not be found. End program.");
                    return;
                }
                
                var mapper = new DataMapper(File.ReadAllLines(args[0].Trim()));

                var groceryStore = new GroceryStore(mapper, new Clock());

                groceryStore.Start();
            }   
            catch (Exception exception)
            {
                PrintException(exception);
            }
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            PrintException((Exception)e.ExceptionObject);
        }

        private static void PrintException(Exception ex)
        {
            Console.WriteLine(string.Format("Exception: {0} - InnerException: {1} - Source: {2} -  StackTrace: {3}"
                , ex.Message, ex.InnerException, ex.Source, ex.StackTrace));
        }
    }
}