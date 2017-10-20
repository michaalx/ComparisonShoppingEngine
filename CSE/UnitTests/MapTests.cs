using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSE.Map;

namespace UnitTests
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        [ExpectedException(typeof(MissingFieldException))]
        public void TestDeviceLocationException()
        {
            DeviceLocation location = new DeviceLocation("");
        }

        [TestMethod]
        [ExpectedException(typeof(MissingFieldException))]
        public void TestMapException()
        {
            MapClass map = new MapClass();
            map.GetMap(0, 1, "", "");
        }

        [TestMethod]
        public void TestStoreInfo()
        {
            //Arrange
            MapClass map = new MapClass();
            //Act
            map.GetMap(0, 12, "naugarduko 24", "IKI");
            //Assert
            Assert.IsNotNull(map.GetStoreInfo());
        }
    }
}
