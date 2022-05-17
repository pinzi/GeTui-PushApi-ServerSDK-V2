﻿using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GeTuiPushApiV2.ServerSDK.Core.Utility
{
    /// <summary>
    /// HTTP请求工具类
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 异步get请求
        /// </summary>
        /// <param name="url">请求地址</param>    
        /// <param name="headers">header键值对</param>
        /// <returns></returns>
        public async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers)
        {
            HttpClient httpClient = new HttpClient();
            foreach (KeyValuePair<string, string> kv in headers)
            {
                httpClient.DefaultRequestHeaders.Add(kv.Key, kv.Value);
            }
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            var resp = await httpClient.SendAsync(request);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// 同步get请求
        /// </summary>
        /// <param name="url">请求地址</param>    
        /// <param name="headers">header键值对</param>
        /// <returns></returns>
        public string HttpGet(string url, Dictionary<string, string> headers)
        {
            HttpClient httpClient = new HttpClient();
            foreach (KeyValuePair<string, string> kv in headers)
            {
                httpClient.DefaultRequestHeaders.Add(kv.Key, kv.Value);
            }
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            var resp = httpClient.Send(request);
            return resp.Content.ReadAsStringAsync().Result;
        }
        /// <summary>
        /// 异步post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">header键值对</param>
        /// <param name="formData">表单参数</param>
        /// <returns></returns>
        public async Task<string> HttpPostAsync<T>(string url, Dictionary<string, string> headers, T formData)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(formData));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.ContentType.CharSet = "UTF-8";
            foreach (KeyValuePair<string, string> kv in headers)
            {
                client.DefaultRequestHeaders.Add(kv.Key, kv.Value);
            }
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post,
                Content = content
            };
            HttpResponseMessage resp = await client.SendAsync(request);
            //resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// 同步post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">header键值对</param>
        /// <param name="formData">表单参数</param>
        /// <returns></returns>
        public string HttpPost<T>(string url, Dictionary<string, string> headers, T formData)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(formData));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.ContentType.CharSet = "UTF-8";
            foreach (KeyValuePair<string, string> kv in headers)
            {
                client.DefaultRequestHeaders.Add(kv.Key, kv.Value);
            }
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post,
                Content = content
            };
            HttpResponseMessage resp = client.SendAsync(request).Result;
            return resp.Content.ReadAsStringAsync().Result;
        }
        /// <summary>
        /// 异步Delete请求
        /// </summary>
        /// <param name="url">请求地址</param>    
        /// <param name="headers">header键值对</param>
        /// <returns></returns>
        public async Task<string> HttpDeleteAsync(string url, Dictionary<string, string> headers)
        {
            HttpClient httpClient = new HttpClient();
            foreach (KeyValuePair<string, string> kv in headers)
            {
                httpClient.DefaultRequestHeaders.Add(kv.Key, kv.Value);
            }
            var resp = await httpClient.DeleteAsync(new Uri(url));
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// 同步Delete请求
        /// </summary>
        /// <param name="url">请求地址</param>    
        /// <param name="headers">header键值对</param>
        /// <returns></returns>
        public string HttpDelete(string url, Dictionary<string, string> headers)
        {
            HttpClient httpClient = new HttpClient();
            foreach (KeyValuePair<string, string> kv in headers)
            {
                httpClient.DefaultRequestHeaders.Add(kv.Key, kv.Value);
            }
            var resp = httpClient.DeleteAsync(new Uri(url));
            return resp.GetAwaiter().GetResult().Content.ReadAsStringAsync().Result;
        }
    }
}
