using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TencentMapSdk.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class DistanceMatrixResponse
    {
        /// <summary>
        /// 多点到多点距离计算，结果为二维数组，rows为行，elements为列 结果数组（行）
        /// </summary>
        [JsonProperty("rows")]
        public DistanceMatrixRow[] Rows { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DistanceMatrixRow
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("elements")]
        public DistanceMatrixLocation[] Elements { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DistanceMatrixLocation
    {
        /// <summary>
        /// 起点到终点的距离，单位：米
        /// </summary>
        [JsonProperty("distance")]
        public decimal? Distance { get; set; }
        /// <summary>
        /// 表示从起点到终点的结合路况的时间，秒为单位
        /// 注：步行/骑行方式（不计算耗时）以及起终点附近没有道路造成无法计算时，不返回本此节点
        /// </summary>
        [JsonProperty("duration")]
        public decimal? Duration { get; set; }
        /// <summary>
        /// 本对起终点计算的状态码，取值：
        /// 4 代表附近没有路，距离计算失败，此时distance为直线距离，预估耗时（duraction）会返回 0。
        /// 计算结果正常返回时，不返回status
        /// </summary>
        [JsonProperty("status")]
        public decimal? Status { get; set; }
    }
}
