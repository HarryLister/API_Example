using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test_Console
{
    public class InputArgs
    {
        public static InputArgs Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("Input string contained no arguments. Expected 3.");
            }
            InputArgs args = new InputArgs();

            var splitString = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitString.Length != 3)
            {
                throw new ArgumentOutOfRangeException("Invalid number of parameters in input string.");
            }

            if (!double.TryParse(splitString[0], out double x1))
            {
                throw new ArgumentException("Error parsing argument 1, was not a double.");
            }

            string name = splitString[1];
            args.FunctionName = name;

            if (!double.TryParse(splitString[2], out double x2))
            {
                throw new ArgumentException("Error parsing argument 2, was not a double.");
            }

            args.Input1 = x1;
            args.Input2 = x2;

            return args;
        }

        public string FunctionName { get; set; }
        public double Input1 { get; set; }
        public double Input2 { get; set; }
    }
}
