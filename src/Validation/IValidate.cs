
namespace System.Enterprise.Necessities.Validation
{
    public interface IValidate<T>
    {
        Validated<T> Validate(T obj);
    }
}
