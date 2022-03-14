
namespace RestaurantSystem.Models
{
    public interface ICheck
    {
        public double TotalPrice { get; set; }
        public void GenerateCheck(Table table); 
    }
}
