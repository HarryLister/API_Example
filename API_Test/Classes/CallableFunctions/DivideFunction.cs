using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API_Test.Classes.Decorator;
using API_Test.Interfaces;

namespace API_Test.Classes.CallableFunctions
{
    [FunctionName("DIVIDE")]
    [FunctionName("/")]
    public class DivideFunction : ICallableFunction
    {
        public DivideFunction()
        {

        }
        public double Execute(double input1, double input2) => input1 - input2;
    }
}
