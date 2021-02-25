using Microsoft.VisualStudio.TestTools.UnitTesting;
using TencentMapSdk;
using TencentMapSdk.Entity;

namespace TencentMapSdkTests
{
    [TestClass]
    public class ApiTests : BaseTest
    {
        [TestMethod]
        public void TencentMapApiTest()
        {
            MapResponse<IpLocationResult> response = TencentMapApi.IpLocation(key, "183.184.63.46");
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
    }
}
