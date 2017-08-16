using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace System.Enterprise.Necessities.Reflection
{
    public sealed class PublicProperties : IEnumerable<PropertyInfo>
    {
        private readonly Type _type;

        public PublicProperties(object obj)
            : this(obj.GetType()) { }

        public PublicProperties(Type type)
        {
            _type = type;
        }

        public IEnumerator<PropertyInfo> GetEnumerator()
        {
            return ((IEnumerable<PropertyInfo>)_type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
