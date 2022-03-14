
namespace RestaurantSystem.Models
{
    public interface IMail<T>
    {
       public void SendCheck(T type, bool isInternalMail);

    }
}
