using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.Classes.Decorator
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class FunctionName : Attribute
    {
        public FunctionName(string name)
            : base()
        {
            Name = name;
        }

        public string Name { get; } = string.Empty;
    }
}
