using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using TencentMapSdk.Entity;

namespace TencentMapSdk
{
    /// <summary>
    /// 腾讯地图Api
    /// </summary>
    public class TencentMapApi : BaseApi
    {
        /// <summary>
        /// IP定位：通过终端设备IP地址获取其当前所在地理位置，精确到市级，常用于显示当地城市天气预报、初始化用户城市等非精确定位场景。
        /// </summary>
        /// <param name="key">开发密钥（Key）</param>
        /// <param name="ip">IP地址，缺省时会使用请求端的IP</param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static MapResponse<IpLocationResult> IpLocation(string ip, string key, string secretKey)
        {
            string query = SignBuilder.Create(secretKey, "/ws/location/v1/ip")
                .WithKeyValue("key", key)
                .WithKeyValue("ip", ip)
                .WithKeyValue("output", "json")
                .BuildQueryString();
            string url = $"https://apis.map.qq.com" + query;
            return Get<MapResponse<IpLocationResult>>(url);
        }
        /// <summary>
        /// 逆地址解析【坐标转地址】
        /// </summary>
        /// <param name="location">经纬度（GCJ02坐标系），格式：location=lat<纬度>,lng<经度>  示例：location = 39.984154,116.307490</param>
        /// <param name="get_poi">是否返回周边地点（POI）列表，可选值：0 不返回(默认)1 返回</param>
        /// <param name="poi_options"></param>
        /// <param name="key"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static MapLocationToAddressResponse<LocationToAddressResponse> LocationToAddress(string location, int get_poi, string poi_options, string key, string secretKey)
        {
            string query = SignBuilder.Create(secretKey, "/ws/geocoder/v1")
                .WithKeyValue("location", location)
                .WithKeyValue("get_poi", get_poi.ToString())
                .WithKeyValue("poi_options", poi_options.ToString())
                .WithKeyValue("key", key)
                .BuildQueryString();
            string url = "https://apis.map.qq.com" + query;
            return Get<MapLocationToAddressResponse<LocationToAddressResponse>>(url);
        }
        /// <summary>
        /// 地址解析
        /// </summary>
        /// <param name="address">地址（注：地址中请包含城市名称，否则会影响解析效果） address=北京市海淀区彩和坊路海淀西大街74号</param>
        /// <param name="region">地址所在城市（若地址中包含城市名称侧可不传） 	region=北京</param>
        /// <param name="key">开发密钥（Key）</param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static MapResponse<AddressToLocationResponse> AddressToLocation(string address, string region, string key, string secretKey)
        {
            string query = SignBuilder.Create(secretKey, "/ws/geocoder/v1")
                .WithKeyValue("address", address)
                .WithKeyValue("region", region)
                .WithKeyValue("key", key)
                .BuildQueryString();
            string url = "https://apis.map.qq.com" + query;
            return Get<MapResponse<AddressToLocationResponse>>(url);
        }
        /// <summary>
        /// 获取所有省市区列表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static AreaResponse<List<List<Area>>> GetAreas(string key, string secretKey)
        {
            string query = SignBuilder.Create(secretKey, "/ws/district/v1/list")
                .WithKeyValue("key", key)
                .BuildQueryString();
            string url = "https://apis.map.qq.com" + query;
            return Get<AreaResponse<List<List<Area>>>>(url);
        }
        /// <summary>
        /// 获取下级行政区划
        /// </summary>
        /// <param name="id">父级行政区划ID（adcode），缺省时返回一级行政区划，也就是省级</param>
        /// <param name="get_polygon">返回行政区划轮廓点串（经纬度点串），0 默认，不返回轮廓1 包含海域，3公里抽稀粒度 2 纯陆地行政区划，可通过max_offset设置返回轮廓的抽稀级别</param>
        /// <param name="max_offset">轮廓点串的抽稀精度（仅对get_polygon=2时支持），单位米，可选值：100 ：100米（当缺省id返回省级区划时，将按500米返回，其它级别正常生效） 500 ：500米 1000：1000米 3000：3000米</param>
        /// <param name="key"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static AreaResponse<List<List<Area>>> GetSonAreas(string id, int get_polygon, string max_offset, string key, string secretKey)
        {
            string query = SignBuilder.Create(secretKey, "/ws/district/v1/getchildren")
                .WithKeyValue("key", key)
                .WithKeyValue("id", id)
                .WithKeyValue("get_polygon", get_polygon.ToString())
                .WithKeyValue("max_offset", max_offset)
                .BuildQueryString();
            string url = "https://apis.map.qq.com" + query;
            return Get<AreaResponse<List<List<Area>>>>(url);
        }
        /// <summary>
        /// 获取下级行政区划
        /// </summary>
        /// <param name="keyword">搜索关键词：1.支持输入一个文本关键词2.支持多个行政区划代码(adcode)，英文逗号分隔</param>
        /// <param name="get_polygon">返回行政区划轮廓点串（经纬度点串），0 默认，不返回轮廓1 包含海域，3公里抽稀粒度 2 纯陆地行政区划，可通过max_offset设置返回轮廓的抽稀级别</param>
        /// <param name="max_offset">轮廓点串的抽稀精度（仅对get_polygon=2时支持），单位米，可选值：100 ：100米（当缺省id返回省级区划时，将按500米返回，其它级别正常生效） 500 ：500米 1000：1000米 3000：3000米</param>
        /// <param name="key"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static AreaResponse<List<List<Area>>> SearchAreas(string keyword, int get_polygon, string max_offset, string key, string secretKey)
        {
            string query = SignBuilder.Create(secretKey, "/ws/district/v1/search")
                .WithKeyValue("key", key)
                .WithKeyValue("keyword", keyword)
                .WithKeyValue("get_polygon", get_polygon.ToString())
                .WithKeyValue("max_offset", max_offset)
                .BuildQueryString();
            string url = "https://apis.map.qq.com" + query;
            return Get<AreaResponse<List<List<Area>>>>(url);
        }
        /// <summary>
        ///   实现从其它地图供应商坐标系或标准GPS坐标系，批量转换到腾讯地图坐标系。
        /// </summary>
        /// <param name="locations">
        /// 预转换的坐标，支持批量转换，
        /// 格式：纬度前，经度后，纬度和经度之间用",“分隔，每组坐标之间使用”;"分隔；
        /// 批量支持坐标个数以HTTP GET方法请求上限为准
        /// locations=39.12,116.83;30.21,115.43
        /// </param>
        /// <param name="type">
        /// 输入的locations的坐标类型
        /// 可选值为[1, 6] 之间的整数，每个数字代表的类型说明：
        /// 1 GPS坐标
        /// 2 sogou经纬度
        /// 3 baidu经纬度
        /// 4 mapbar经纬度
        /// 5 [默认] 腾讯、google、高德坐标
        /// 6 sogou墨卡托
        /// </param>
        /// <param name="key"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static LocationTranslateResponse LocationTranslate(string locations, int type, string key, string secretKey)
        {
            string query = SignBuilder.Create(secretKey, "/ws/coord/v1/translate")
                .WithKeyValue("key", key)
                .WithKeyValue("locations", locations)
                .WithKeyValue("type", type.ToString())
                .BuildQueryString();
            string url = "https://apis.map.qq.com" + query;
            return Get<LocationTranslateResponse>(url);
        }
        /// <summary>
        ///  距离矩阵（DistanceMatrix），用于批量计算一组起终点的路面距离（或称导航距离），可应用于网约车派单、多目的地最优路径智能计算等场景中，支持驾车、步行、骑行多种交通方式，满足不同应用需要。
        /// </summary>
        /// <param name="mode">计算方式，取值：driving：驾车 walking：步行 bicycling：自行车</param>
        /// <param name="from">起点坐标 格式： lat,lng[, heading];lat,lng[, heading] from=39.071510,117.190091  from=39.071510,117.190091,270;39.108951,117.279396,180</param>
        /// <param name="to">终点坐标 格式： lat,lng;lat,lng…</param>
        /// <param name="key"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static MapResponse<DistanceMatrixResponse> DistanceMatrix(string mode, string from, string to, string key, string secretKey)
        {
            string query = SignBuilder.Create(secretKey, "/ws/distance/v1/matrix")
                .WithKeyValue("key", key)
                .WithKeyValue("mode", mode)
                .WithKeyValue("from", from)
                .WithKeyValue("to", to)
                .BuildQueryString();
            string url = "https://apis.map.qq.com" + query;
            return Get<MapResponse<DistanceMatrixResponse>>(url);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="boundary"></param>
        /// <param name="filter"></param>
        /// <param name="orderby">排序，目前仅周边搜索（boundary=nearby）支持按距离由近到远排序，取值：_distance</param>
        /// <param name="page_size"></param>
        /// <param name="page_index"></param>
        /// <param name="key"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static SearchResponse Search(string keyword, string boundary, string filter, string orderby, int? page_size, int? page_index, string key, string secretKey)
        {
            string query = SignBuilder.Create(secretKey, "/ws/place/v1/search")
                .WithKeyValue("key", key)
                .WithKeyValue("keyword", keyword)
                .WithKeyValue("boundary", boundary)
                .WithKeyValue("filter", filter)
                .WithKeyValue("orderby", orderby)
                .WithKeyValue("page_size", page_size?.ToString())
                .WithKeyValue("page_index", page_index?.ToString())
                .BuildQueryString(true);
            string url = "https://apis.map.qq.com" + query;
            return Get<SearchResponse>(url);
        }
    }
    /// <summary>
    /// Api请求基类
    /// </summary>
    public class BaseApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Response"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected static Response Get<Response>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                string body = response.Content.ReadAsStringAsync().Result;
                Response res = JsonConvert.DeserializeObject<Response>(body);
                return res;
            }
        }
        ///// <summary>
        ///// 组装Get请求QueryUrl
        ///// </summary>
        ///// <typeparam name="Request"></typeparam>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //protected static string GetQueryUrl<Request>(Request request)
        //{
        //    PropertyInfo[] propertyInfos = typeof(Request).GetProperties();
        //    StringBuilder builder = new StringBuilder();
        //    foreach (PropertyInfo property in propertyInfos)
        //    {
        //        var ingore = property.GetCustomAttribute<JsonIgnoreAttribute>();
        //        if (ingore == null)
        //        {

        //            var nameAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
        //            string key = null;
        //            if (nameAttribute != null && nameAttribute.PropertyName.IsNotNullOrEmpty())
        //            {
        //                key = nameAttribute.PropertyName;
        //            }
        //            else
        //            {
        //                key = property.Name;
        //            }

        //            object value = property.GetValue(request);
        //            if (value != null && value.ToString().IsNotNullOrEmpty())
        //            {
        //                builder.Append($"&{key}={value}");
        //            }
        //        }
        //    }
        //    return builder.ToString().Substring(1);
        //}
    }
    /// <summary>
    /// 
    /// </summary>
    public class SignBuilder
    {
        SortedDictionary<string, string> dic;
        string secretKey;
        string url = "";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SignBuilder Create(string secretKey, string url)
        {
            return new SignBuilder()
            {
                dic = new SortedDictionary<string, string>(),
                secretKey = secretKey,
                url = url
            };
        }
        /// <summary>
        /// 创建签名字符串
        /// </summary>
        /// <returns></returns>
        public string BuildSignStr()
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> item in dic)
            {
                builder.Append($"&{item.Key}={item.Value}");
            }
            string signStr = builder.ToString();
            if (signStr.Length <= 1)
            {
                signStr = "";
            }
            else
            {
                signStr = builder.ToString().Substring(1);
            }
            signStr = url + "?" + signStr + secretKey;
            return Util.MD5(signStr);
        }
        private string GetQueryString(bool isEncode = false)
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> item in dic)
            {
                string value = isEncode ? HttpUtility.UrlEncode(item.Value) : item.Value;
                builder.Append($"&{item.Key}={value}");
            }
            string query = builder.ToString();
            if (query.Length <= 1)
            {
                query = "";
            }
            else
            {
                query = builder.ToString().Substring(1);
            }
            return query;
        }
        private string GetSignString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> item in dic)
            {
                builder.Append($"&{item.Key}={item.Value}");
            }
            string query = builder.ToString();
            if (query.Length <= 1)
            {
                query = "";
            }
            else
            {
                query = builder.ToString().Substring(1);
            }
            return url + "?" + query + secretKey;
        }
        /// <summary>
        /// 创建QueryString
        /// </summary>
        /// <returns></returns>
        public string BuildQueryString(bool isEncode = false)
        {
            //StringBuilder builder = new StringBuilder();
            //foreach (KeyValuePair<string, string> item in dic)
            //{
            //    builder.Append($"&{item.Key}={item.Value}");
            //}
            //string signStr = builder.ToString();
            //if (signStr.Length <= 1)
            //{
            //    signStr = "";
            //}
            //else
            //{
            //    signStr = builder.ToString().Substring(1);
            //}

            //string queryUrl = url + "?" + signStr;
            //signStr = url + "?" + signStr + secretKey;
            //queryUrl = queryUrl + "&sig=" + Util.MD5(signStr);
            //return queryUrl;
            string queryStr = url + "?" + GetQueryString(isEncode);
            string signStr = GetSignString();
            return queryStr + "&sig=" + Util.MD5(signStr);
        }
        /// <summary>
        /// 设置KeyValue
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public SignBuilder WithKeyValue(string key, string value)
        {
            if (value.IsNotNullOrEmpty())
            {
                dic[key] = value;
            }
            return this;
        }
    }
}

