using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace API_Test_Console
{
    internal class LoadClasses<T> 
    {
        private Assembly _assembly = null;
        private IEnumerable<Type> _types = null;
        private Type _typeT = typeof(T);
        public LoadClasses()
        {
            _assembly = Assembly.GetAssembly(typeof(T));
            _types = _assembly.GetTypes();//.Where(x => x.IsAssignableFrom(typeof(T)));
        }

        public IEnumerable<Type> GetAssignableTypes()
        {
            foreach(Type t in _types)
            {
                bool isClass = t.IsClass;
                bool implementsType = _typeT.IsAssignableFrom(t);
                if (isClass && implementsType)
                {
                    yield return t;
                }
            }
        }
        public IEnumerable<T> CreateInstances()
        {
            foreach (Type type in GetAssignableTypes())
            {
                yield return (T)Activator.CreateInstance(type);
            }
        }
    }
}
