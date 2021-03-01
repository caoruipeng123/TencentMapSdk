using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TencentMapSdk
{
    /// <summary>
    /// 腾讯地图全局响应类
    /// </summary>
    public class MapResponse<T>
    {
        /// <summary>
        /// 状态码，0为正常,
        /// 310 请求参数信息有误，
        /// 311 Key格式错误,
        /// 306 请求有护持信息请检查字符串,
        /// 110 请求来源未被授权
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }
        /// <summary>
        /// 对status的描述
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// 用于定位的IP地址
        /// </summary>
        [JsonProperty("result")]
        public T Result { get; set; }
        /// <summary>
        /// 腾讯地图接口返回的原始报文
        /// </summary>
        //public string Body { get; set; }
    }
    /// <summary>
    /// 逆地址解析
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MapLocationToAddressResponse<T> : MapResponse<T>
    {
        /// <summary>
        /// 本次请求的唯一标识
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestID { get; set; }
    }
    /// <summary>
    /// 行政区域
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AreaResponse<T> : MapResponse<T>
    {
        /// <summary>
        /// 行政区划数据版本，便于您判断更新
        /// </summary>
        [JsonProperty("data_version")]
        public decimal DataVersion { get; set; }
    }

}
