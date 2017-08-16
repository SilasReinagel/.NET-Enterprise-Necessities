
namespace System.Enterprise.Necessities.Response
{
    public interface IResponse<out T>
    {
        bool Succeeded { get; }
        string ErrorMessage { get; }
        T Content { get; }
    }
}
