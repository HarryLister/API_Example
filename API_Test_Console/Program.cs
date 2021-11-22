using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using API_Test.Interfaces;
using API_Test.Classes.Decorator;

namespace API_Test_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Initialise functions in API_Test assembly
            Dictionary<string, ICallableFunction> functions = new Dictionary<string, ICallableFunction>();
            Type t = typeof(ICallableFunction);
            LoadClasses<ICallableFunction> loader = new LoadClasses<ICallableFunction>();
            IEnumerable<Type> types = loader.GetAssignableTypes();
            foreach (Type function in types)
            {
                //Use reflection to get attributes of type FunctionName and add those to _functions
                IEnumerable<Attribute> attrs = function.GetCustomAttributes(typeof(FunctionName));
                //Create class instance
                ICallableFunction callableFunction = (ICallableFunction)Activator.CreateInstance(function);
                foreach (FunctionName attr in attrs)
                {
                    if (functions.ContainsKey(attr.Name))
                    {
                        //Print error to the screen
                        string functionName = functions[attr.Name].GetType().FullName;
                        Console.WriteLine($"Error in referenced assembly of type {function.FullName}. The function name {attr.Name} is already in use on function {functionName}.");
                    }
                    else
                    {
                        functions.Add(attr.Name, callableFunction);
                    }
                }
            }

            string inputMessage = "Welcome, press q to exit or type in your command.";
            Console.WriteLine(inputMessage);
            string userInput = Console.ReadLine();
            while (!string.Equals(userInput.ToLower(), "q"))
            {
                //Try to convert line to args
                try
                {
                    InputArgs a = InputArgs.Parse(userInput);
                    if (!functions.ContainsKey(a.FunctionName))
                    {
                        throw new KeyNotFoundException($"Invalid function name. There is no function with key'{a.FunctionName}'.");
                    }

                    //Execute function 
                    ICallableFunction function = functions[a.FunctionName];
                    double output = function.Execute(a.Input1, a.Input2);
                    Console.WriteLine($"Output: {output}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error executing function:");
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Welcome, press q to exit or type in your command");
                userInput = Console.ReadLine();
            }
        }
    }
}
