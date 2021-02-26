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
        /// Ip��λ
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
        /// ���ַ����
        /// </summary>
        [TestMethod]
        public void LocationToAddressTest()
        {
            MapLocationToAddressResponse<LocationToAddressResponse> response = TencentMapApi.LocationToAddress("37.7360500000,112.5656600000", 1, "address_format=short", key, secretKey);
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// ��ַת����
        /// </summary>
        [TestMethod]
        public void AddressToLocationTest()
        {
            MapResponse<AddressToLocationResponse> response = TencentMapApi.AddressToLocation("̫ԭ��С����ƽ����Է5��¥", "̫ԭ��", key, secretKey);
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// ����JsponProperty���Ժ��������Ƿ���ȷ
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
                //Ensure.NotNullOrEmpty("����", attribute.PropertyName);
                //Ensure.Eq("����" + property.Name, attribute.PropertyName.Replace("_", "").ToLower(), property.Name.ToLower());
                Ensure.Eq("��д��ĸ" + property.Name, CompareChar(property.Name[0]), true);
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
        /// �ж��ַ��Ƿ�Ϊ��д��ĸ
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
