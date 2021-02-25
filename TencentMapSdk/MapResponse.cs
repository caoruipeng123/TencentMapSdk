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
    }
}
