using RestaurantSystem.Models;
using Xunit;

namespace RestaurantSystem.UnitTests
{
    public class ConvertingTest
    {
        [Fact]
        public void Test_If_Function_FromStringToDouble_Correctly_Parse_To_Double()
        {
            var convertedDouble1 = ExceptionsHandle.FromStringToDouble(null);
            var convertedDouble2 = ExceptionsHandle.FromStringToDouble("jsg");
            var convertedDouble3 = ExceptionsHandle.FromStringToDouble("5.99");
            
            
            Assert.Equal(0.0, convertedDouble1);
            Assert.Equal(0.0, convertedDouble2);
            Assert.Equal(5.99, convertedDouble3);

        }
    }
}
