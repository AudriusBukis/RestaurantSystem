using System.Text.RegularExpressions;
using Xunit;

namespace RestaurantSystem.UnitTests
{
    public class MailRegexTests
    {
       [Fact]
       public void Test_Email_Regex_Validator_IsMatch_Works_Correctly()
       {


            Regex EmailRegexValidator = new("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

            var TestEmail1 = "bandymas@gmail..rfgrg";
            var TestEmail2 = "bandymas.@bandymelis@gmail.rfgrg"; 
            var TestEmail3 = "bandymas..@gmail.khad";
            var TestEmail4 = "audr.buki@gmail.com";
            var regexAnsver1 = EmailRegexValidator.IsMatch(TestEmail1);
            var regexAnsver2 = EmailRegexValidator.IsMatch(TestEmail2);
            var regexAnsver3 = EmailRegexValidator.IsMatch(TestEmail3);
            var regexAnsver4 = EmailRegexValidator.IsMatch(TestEmail4);



            Assert.False(regexAnsver1);
            Assert.False(regexAnsver2);
            Assert.False(regexAnsver3);
            Assert.True(regexAnsver4);


       }
    }
}
