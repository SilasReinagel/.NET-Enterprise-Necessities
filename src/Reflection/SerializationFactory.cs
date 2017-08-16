using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace System.Enterprise.Necessities.Reflection
{
    public sealed class SerializationFactory<T>
    {
        private static readonly Func<T> _create = CreateFactory();

        public T Create()
        {
            return _create();
        }

        private static Func<T> CreateFactory()
        {
            var t = typeof(T);
            if (t == typeof(string))
                return Expression.Lambda<Func<T>>(Expression.Constant(string.Empty)).Compile();
            if (HasDefaultConstructor(t))
                return Expression.Lambda<Func<T>>(Expression.New(t)).Compile();
            return () => (T)FormatterServices.GetUninitializedObject(t);
        }

        private static bool HasDefaultConstructor(Type t)
        {
            return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
        }
    }
}
