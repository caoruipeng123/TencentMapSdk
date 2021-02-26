using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
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
        protected static string Sign(SortedDictionary<string, string> dic)
        {
            return null;
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
        public string Build()
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
        public string BuildQueryString()
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
            string queryUrl = url + "?" + signStr;
            signStr = url + "?" + signStr + secretKey;
            queryUrl = queryUrl + "&sig=" + Util.MD5(signStr);
            return queryUrl;
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

