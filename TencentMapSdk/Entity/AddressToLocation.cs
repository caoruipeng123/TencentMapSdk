using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TencentMapSdk.Entity
{
    /// <summary>
    /// 地址解析
    /// </summary>
    public class AddressToLocationResponse
    {
        /// <summary>
        /// 解析到坐标所用到的关键地址、地点
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// 解析到的坐标（GCJ02坐标系）
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
        /// <summary>
        /// 解析后的地址部件
        /// </summary>
        [JsonProperty("address_components")]
        public AddressToLocationAddressComponent AddressComponent { get; set; }
        /// <summary>
        /// 行政区划信息
        /// </summary>
        [JsonProperty("ad_info")]
        public AddressToLocationAdInfo AdInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("similarity")]
        [Obsolete("即将下线，由reliability代替")]
        public decimal Similarity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("deviation")]
        [Obsolete("即将下线，由level代替")]
        public decimal Deviation { get; set; }
        /// <summary>
        /// 可信度参考：值范围 1 <低可信> - 10 <高可信>我们根据用户输入地址的准确程度，在解析过程中，将解析结果的可信度(质量)，由低到高，分为1 - 10级，该值>=7时，解析结果较为准确，<7时，会存各类不可靠因素，开发者可根据自己的实际使用场景，对于解析质量的实际要求，进行参考。
        /// </summary>
        [JsonProperty("reliability")]
        public decimal Reliability { get; set; }
        /// <summary>
        /// 解析精度级别，分为11个级别，一般>=9即可采用（定位到点，精度较高） 也可根据实际业务需求自行调整，完整取值表见下文。
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }
    }
    public class AddressToLocationAddressComponent
    {
        /// <summary>
        /// 北京市
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }
        /// <summary>
        /// 北京市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
        /// <summary>
        /// 海淀区
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }
        /// <summary>
        /// 北四环西路
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }
        /// <summary>
        /// 北四环西路66号
        /// </summary>
        [JsonProperty("street_number")]
        public string StreetNumber { get; set; }
    }
    /// <summary>
    /// 行政区划信息
    /// </summary>
    public class AddressToLocationAdInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }
    }
}
