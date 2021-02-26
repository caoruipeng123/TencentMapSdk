using Newtonsoft.Json;
using System.Collections.Generic;

namespace TencentMapSdk.Entity
{
    /// <summary>
    /// 逆地址解析
    /// </summary>
    public class LocationToAddressResponse
    {
        /// <summary>
        /// 以行政区划+道路+门牌号等信息组成的标准格式化地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>
        /// 结合知名地点形成的描述性地址，更具人性化特点
        /// </summary>
        [JsonProperty("formatted_addresses")]
        public FormattedAddresses FormattedAddresses { get; set; }
        /// <summary>
        /// 地址部件，address不满足需求时可自行拼接
        /// </summary>
        [JsonProperty("address_component")]
        public AddressComponent AddressComponent { get; set; }
        /// <summary>
        /// 行政区划信息
        /// </summary>
        [JsonProperty("ad_info")]
        public QueryAdInfo AdInfo { get; set; }
        /// <summary>
        /// 	坐标相对位置参考
        /// </summary>
        [JsonProperty("address_reference")]
        public AddressReference AddressReference { get; set; }
        /// <summary>
        /// 查询的周边poi的总数，仅在传入参数get_poi=1时返回
        /// </summary>
        [JsonProperty("poi_count")]
        public int PoiCount { get; set; }
        /// <summary>
        /// 周边地点（POI）数组，数组中每个子项为一个POI对象
        /// </summary>
        [JsonProperty("pois")]
        public List<PoisItem> Pois { get; set; }
    }
    /// <summary>
    /// 结合知名地点形成的描述性地址，更具人性化特点
    /// </summary>
    public class FormattedAddresses
    {
        /// <summary>
        /// 推荐使用的地址描述，描述精确性较高 海淀区中关村中国技术交易大厦(彩和坊路)
        /// </summary>
        [JsonProperty("recommend")]
        public string Recommend { get; set; }
        /// <summary>
        /// 粗略位置描述 海淀区中关村中国技术交易大厦(彩和坊路)
        /// </summary>
        [JsonProperty("rough")]
        public string Rough { get; set; }
    }
    /// <summary>
    /// 地址部件，address不满足需求时可自行拼接
    /// </summary>
    public class AddressComponent
    {
        /// <summary>
        /// 中国
        /// </summary>
        [JsonProperty("nation")]
        public string Nation { get; set; }
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
    public class QueryAdInfo
    {
        /// <summary>
        /// 国家代码（ISO3166标准3位数字码）
        /// </summary>
        [JsonProperty("nation_code")]
        public string NationCode { get; set; }
        /// <summary>
        /// 行政区划代码
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }
        /// <summary>
        /// 城市代码，由国家码+行政区划代码（提出城市级别）组合而来，总共为9位
        /// </summary>
        [JsonProperty("city_code")]
        public string CityCode { get; set; }
        /// <summary>
        /// 中国,北京市,北京市,海淀区
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
        /// <summary>
        /// 中国
        /// </summary>
        [JsonProperty("nation")]
        public string Nation { get; set; }
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
    }
    /// <summary>
    /// 知名区域，如商圈或人们普遍认为有较高知名度的区域
    /// </summary>
    public class FamousArea
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        /// <summary>
        /// 中关村
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("_distance")]
        public decimal? Distance { get; set; }
        /// <summary>
        /// 内
        /// </summary>
        [JsonProperty("_dir_desc")]
        public string DirDesc { get; set; }
    }
    /// <summary>
    /// 乡镇街道
    /// </summary>
    public class Town
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        /// <summary>
        /// 海淀街道
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("_distance")]
        public decimal? Distance { get; set; }
        /// <summary>
        /// 内
        /// </summary>
        [JsonProperty("_dir_desc")]
        public string DirDesc { get; set; }
    }
    /// <summary>
    /// 坐标相对位置参考
    /// </summary>
    public class AddressReference
    {
        /// <summary>
        /// 知名区域，如商圈或人们普遍认为有较高知名度的区域
        /// </summary>
        [JsonProperty("famous_area")]
        public FamousArea FamousArea { get; set; }
        /// <summary>
        /// 商圈，目前与famous_area一致
        /// </summary>
        [JsonProperty("business_area")]
        public FamousArea BusinessArea { get; set; }
        /// <summary>
        /// 乡镇街道
        /// </summary>
        [JsonProperty("town")]
        public Town Town { get; set; }
        /// <summary>
        /// 一级地标，可识别性较强、规模较大的地点、小区等
        /// </summary>
        [JsonProperty("landmark_l1")]
        public FamousArea Landmarkl1 { get; set; }
        /// <summary>
        /// 二级地标，较一级地标更为精确，规模更小
        /// </summary>
        [JsonProperty("landmark_l2")]
        public FamousArea Landmarkl2 { get; set; }
        /// <summary>
        /// 街道
        /// </summary>
        [JsonProperty("street")]
        public FamousArea Street { get; set; }
        /// <summary>
        /// 门牌
        /// </summary>
        [JsonProperty("street_number")]
        public FamousArea StreetNumber { get; set; }
        /// <summary>
        /// 交叉路口 
        /// </summary>
        [JsonProperty("crossroad")]
        public FamousArea Crossroad { get; set; }
        /// <summary>
        /// 水系
        /// </summary>
        [JsonProperty("water")]
        public FamousArea Water { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ItemAdInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("adcode")]
        public string AdCode { get; set; }
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
    }
    /// <summary>
    /// 	周边地点（POI）数组，数组中每个子项为一个POI对象
    /// </summary>
    public class PoisItem
    {
        /// <summary>
        /// 地点（POI）唯一标识
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("title")]
        public string title { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>
        /// 地点分类信息
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }
        /// <summary>
        /// 提示所述位置坐标
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
        /// <summary>
        /// 行政区划信息
        /// </summary>
        [JsonProperty("ad_info")]
        public ItemAdInfo AdInfo { get; set; }
        /// <summary>
        /// 该POI到逆地址解析传入的坐标的直线距离
        /// </summary>
        [JsonProperty("_distance")]
        public decimal? Distance { get; set; }
        /// <summary>
        /// 内
        /// </summary>
        [JsonProperty("_dir_desc")]
        public string DirDesc { get; set; }
    }
}
