using System.Enterprise.Necessities.Response;

namespace System.Enterprise.Necessities.Validation
{
    public sealed class Validated<T> : IResponse<T>
    {
        public bool Succeeded { get; }
        public string ErrorMessage { get; }
        public T Content { get; }
    }
}
