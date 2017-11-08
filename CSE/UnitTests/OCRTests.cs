using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Xunit;
using BackEnd.ImageAnalysis;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class OCRTests
    {
        [TestMethod]
        public void TestTextWhichIsRetrievedFromImageByIron_Failed()
        {
            //Arrange
            var imageProcessing = new ImageProcessing();
            //Act
            var imageToTest = new System.Drawing.Bitmap(Directory.GetCurrentDirectory() + "ContentsToTest/Image_To_Test_v1.png");
            var notExpectedResult = "This test will obviously fail.";
            var actualResult = imageProcessing.ImageToText(imageToTest).ToString();
            //Assert
            Assert.AreEqual(notExpectedResult, actualResult);
        }
    }
}
