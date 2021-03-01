using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TencentMapSdk.Entity
{
    /// <summary>
    /// 地点搜索信息
    /// </summary>
    public class SearchResponse
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
        /// 本次搜索结果总数，另外本服务限制最多返回200条数据(data)，翻页（page_index）超过搜索结果总数 或 最大200条限制时，将返回最后一页数据。
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        /// <summary>
        /// 本次请求唯一ID
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestID { get; set; }
        /// <summary>
        /// 搜索结果POI数组，每项为一个POI对象
        /// </summary>
        [JsonProperty("data")]
        public List<SearchDataItem> Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("region")]
        public Region Region { get; set; }
    }
    /// <summary>
    /// 行政区域信息
    /// </summary>
    public class SearchAdInfo
    {
        /// <summary>
        /// 行政区划代码
        /// </summary>
        [JsonProperty("adcode")]
        public int AdCode { get; set; }
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
        /// 西城区
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }
    }

    public class SearchDataItem
    {
        /// <summary>
        /// POI唯一标识
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        /// <summary>
        /// POI名称 海底捞火锅(西单店)
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [JsonProperty("tel")]
        public string Tel { get; set; }
        /// <summary>
        /// POI分类 美食:火锅
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }
        /// <summary>
        /// POI类型，值说明：0:普通POI / 1:公交车站 / 2:地铁站 / 3:公交线路 / 4:行政区划
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }
        /// <summary>
        /// 坐标
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
        /// <summary>
        /// 距离，单位： 米，在周边搜索、城市范围搜索传入定位点时返回
        /// </summary>
        [JsonProperty("_distance")]
        public decimal? Distance { get; set; }
        /// <summary>
        /// 行政区划信息
        /// </summary>
        [JsonProperty("ad_info")]
        public SearchAdInfo AdInfo { get; set; }
    }

    public class Region
    {
        /// <summary>
        /// 北京市
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }


}
