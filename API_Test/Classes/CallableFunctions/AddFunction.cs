using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using API_Test.Classes.Decorator;
using API_Test.Interfaces;

namespace API_Test.Classes.CallableFunctions
{
    [FunctionName("ADD")]
    [FunctionName("+")]
    public class AddFunction : ICallableFunction
    {
        public AddFunction()
        {

        }
        public double Execute(double input1, double input2) => input1 + input2;
    }
}
