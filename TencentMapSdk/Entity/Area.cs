using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TencentMapSdk.Entity
{
    /// <summary>
    /// 行政区划代码（adcode）规则说明
    /// 代码共6位，前两位代表省（一级）、中间两位为市/地区（二级），最后两位为区县（三级）
    /// 1）省级：前两位有值，后4位置0，如，河北省：130000
    /// 2）市/地区：前4四位有值，包含省代码与市代码，最后两位置0，如河北省保定市：130600
    /// 3）区县：6位全有值，包含前4位省市代码及区县代码，河北省保定市涿州市：130681
    /// 4）直辖市、香港、澳门：
    ///      同省级，在行政区划接口（ws/district/v1/list）中，其下直接为区级（没有二级结构填充）
    ///     例：北京,东城区 （而非：“北京,北京,东城区”）
    /// 5）直辖县：第3、4位为90的，为省直辖县
    /// </summary>
    public class Area
    {
        /// <summary>
        /// 行政区划唯一标识（adcode）
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        /// <summary>
        /// 简称，如“内蒙古”
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 简称，如“内蒙古”
        /// </summary>
        [JsonProperty("fullname")]
        public string FullName { get; set; }
        /// <summary>
        /// 简称，如“内蒙古”
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
        /// <summary>
        /// 行政区划拼音，每一下标为一个字的全拼
        /// </summary>
        [JsonProperty("pinyin")]
        public string[] PinYin { get; set; }
        /// <summary>
        /// 子级行政区划在下级数组中的下标位置
        /// </summary>
        [JsonProperty("cidx")]
        public int[] Cidx { get; set; }
    }
}
