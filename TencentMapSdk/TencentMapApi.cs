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
        /// 通过终端设备IP地址获取其当前所在地理位置，精确到市级，常用于显示当地城市天气预报、初始化用户城市等非精确定位场景。
        /// </summary>
        /// <param name="key">开发密钥（Key）</param>
        /// <param name="ip">IP地址，缺省时会使用请求端的IP</param>
        /// <returns></returns>
        public static MapResponse<IpLocationResult> IpLocation(string key, string ip)
        {
            string url = $"https://apis.map.qq.com/ws/location/v1/ip?key={key}&ip={ip}&output=json";
            return Get<MapResponse<IpLocationResult>>(url);
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
}
