using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TencentMapSdk.Entity
{
    /// <summary>
    /// 坐标转换
    /// </summary>
    public class LocationTranslateResponse
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
        /// 坐标转换结果，转换后的坐标顺序与输入顺序一致
        /// </summary>
        [JsonProperty("locations")]
        public Location[] Locations { get; set; }
    }
}
