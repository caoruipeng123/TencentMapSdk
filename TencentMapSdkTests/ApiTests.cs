using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Reflection;
using TencentMapSdk;
using TencentMapSdk.Entity;

namespace TencentMapSdkTests
{
    [TestClass]
    public class ApiTests : BaseTest
    {
        /// <summary>
        /// Ip定位
        /// </summary>
        [TestMethod]
        public void TencentMapApiTest()
        {
            MapResponse<IpLocationResult> response = TencentMapApi.IpLocation("183.184.63.46", key, secretKey);
            Assert.IsTrue(response.Status == 0);
            Assert.IsTrue(response.Message != null);
            Assert.IsTrue(response.Result.IP != null);
            Assert.IsTrue(response.Result.Location != null);
            Assert.IsTrue(response.Result.AdInfo != null);
            Assert.IsTrue(response.Result.AdInfo.Nation != null);
            Assert.IsTrue(response.Result.AdInfo.Province != null);
            Assert.IsTrue(response.Result.AdInfo.City != null);
            Assert.IsTrue(response.Result.AdInfo.District != null);
            Assert.IsTrue(response.Result.AdInfo.AdCode > 0);
        }
        /// <summary>
        /// 逆地址解析
        /// </summary>
        [TestMethod]
        public void LocationToAddressTest()
        {
            MapLocationToAddressResponse<LocationToAddressResponse> response = TencentMapApi.LocationToAddress("37.7360500000,112.5656600000", 1, "address_format=short", key, secretKey);
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// 地址转坐标
        /// </summary>
        [TestMethod]
        public void AddressToLocationTest()
        {
            MapResponse<AddressToLocationResponse> response = TencentMapApi.AddressToLocation("太原市小店区平阳景苑5号楼", "太原市", key, secretKey);
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// 测试JsponProperty属性和属性名是否正确
        /// </summary>
        [TestMethod]
        public void NameTest()
        {
            var propertyes = typeof(AddressToLocationResponse).GetProperties();
            foreach (PropertyInfo p in propertyes)
            {
                CheckProperty(p);
            }
        }
        public void CheckProperty(PropertyInfo property)
        {
            var type = property.PropertyType;
            if (type == typeof(string) || type == typeof(DateTime) || type == typeof(int) || type.IsGenericType)
            {
                JsonPropertyAttribute attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                Assert.IsNotNull(attribute);
                //Ensure.NotNullOrEmpty("名称", attribute.PropertyName);
                //Ensure.Eq("名称" + property.Name, attribute.PropertyName.Replace("_", "").ToLower(), property.Name.ToLower());
                Ensure.Eq("大写字母" + property.Name, CompareChar(property.Name[0]), true);
                return;
            }
            else
            {
                var propertyes = type.GetProperties();
                foreach (PropertyInfo p in propertyes)
                {
                    CheckProperty(p);
                }
            }
        }
        /// <summary>
        /// 判断字符是否为大写字母
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>        
        private static bool CompareChar(char c)
        {
            if (c >= 'A' && c <= 'Z')

            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
