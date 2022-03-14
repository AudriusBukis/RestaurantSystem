using RestaurantSystem.Models;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace RestaurantSystem.UnitTests
{
    public class FileWriteReadTest
    {
        [Fact]
        public void Test_If_FileService_WriteAllText_And_Read_File_Get_The_Same_Results()
        {
            var testWriteReadFile = new FileService("Test1.txt");
            var testWritelist = new List<string>();
            
            testWritelist.Add("string element 1");
            testWritelist.Add("string element 2");
            testWritelist.Add("string element 3");
            testWritelist.Add("string element 4");
            testWritelist.Add("string element 5");

            testWriteReadFile.WriteAllText(testWritelist.ToArray());
            List<string> testReadlist = testWriteReadFile.GetAllLines();

            Assert.True(testReadlist[0] == testWritelist[0]);
            Assert.True(testReadlist[3] == testWritelist[3]);
            Thread.Sleep(5000);
            testWriteReadFile.DelateFile();
        }
        [Fact]
        public void Test_If_FileService_AppendText_And_Read_File_Get_The_Same_Results()
        {
            var testWriteReadFile = new FileService("Test2.txt");
            var testWritelist = new List<string>();
            testWriteReadFile.WriteAllText(testWritelist.ToArray());
            
            testWriteReadFile.AppendText("string element 1");
            testWriteReadFile.AppendText("string element 2");
            testWriteReadFile.AppendText("string element 3");
            testWriteReadFile.AppendText("string element 4");

            List<string>  testReadlist = testWriteReadFile.GetAllLines();

            Assert.True(testReadlist[0] == "string element 1");
            Assert.True(testReadlist[2] == "string element 3");
            
            Thread.Sleep(5000);
            testWriteReadFile.DelateFile();
        }
    }
}
