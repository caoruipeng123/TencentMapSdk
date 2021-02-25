using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TencentMapSdk.Entity
{
    /// <summary>
    /// Ip定位信息
    /// </summary>
    public class IpLocationResult
    {
        /// <summary>
        /// 用于定位的IP地址
        /// </summary>
        [JsonProperty("ip")]
        public string IP { get; set; }
        /// <summary>
        /// 定位坐标
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
        /// <summary>
        /// 定位行政区划信息
        /// </summary>
        [JsonProperty("ad_info")]
        public AdInfo AdInfo { get; set; }
    }
    /// <summary>
    /// 定位坐标
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [JsonProperty("lat")]
        public decimal Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        [JsonProperty("lng")]
        public decimal Lng { get; set; }
    }
    /// <summary>
    /// 定位行政区划信息
    /// </summary>
    public class AdInfo
    {
        /// <summary>
        /// 国家
        /// </summary>
        [JsonProperty("nation")]
        public string Nation { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
        /// <summary>
        /// 小店区
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }
        /// <summary>
        /// 行政区划代码
        /// </summary>
        [JsonProperty("adcode")]
        public int AdCode { get; set; }
    }

}
