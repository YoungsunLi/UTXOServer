using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace UTXOServer {
    class HttpRequest {
        /// <summary>
        /// 1个参数(params)的Get方法
        /// </summary>
        /// <param name="_method">请求的方法</param>
        /// <param name="_params">请求的参数</param>
        /// <param name="_id">可选参数请求的id,默认值:1</param>
        /// <param name="_node">节点地址,格式"http://域名||IP:端口"</param>
        /// <returns></returns>
        public JObject Get(string _method, string _params, int _id = 1, string _node = "http://212.64.42.147:40332") {
            using(HttpClient httpClient = new HttpClient()) {
                string url = _node + "/?jsonrpc=2.0&method=" + _method + "&params=[\"" + _params + "\"]&id=" + 1;
                string result = httpClient.GetStringAsync(url).Result;
                return JObject.Parse(result);
            }
        }
        /// <summary>
        /// 1个参数(params)的Post方法
        /// </summary>
        /// <param name="_method">请求的方法</param>
        /// <param name="_params">请求的参数</param>
        /// <param name="_id">可选参数请求的id,默认值:1</param>
        /// <param name="_node">节点地址,格式"http://域名||IP:端口"</param>
        /// <returns></returns>
        public JObject Post(string _method, string _params, int _id = 1, string _node = "http://212.64.42.147:40332") {
            using(HttpClient httpClient = new HttpClient()) {
                string body = "{\"jsonrpc\": \"2.0\",\"method\": \"" + _method + "\",\"params\": [\"" + _params + "\"],\"id\": " + _id + "}";
                HttpResponseMessage httpResponseMessage = httpClient.PostAsync(_node, new StringContent(body)).Result;
                string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return JObject.Parse(result);
            }
        }
        /// <summary>
        ///获取块信息的Get方法(2个参数(params))
        /// </summary>
        /// <param name="_blockNum">要获取的块</param>
        /// <param name="_node">节点地址,格式"http://域名||IP:端口"</param>
        /// <returns></returns>
        public JObject GetBlock(long _blockNum, string _node = "http://212.64.42.147:40332") {
            using(HttpClient httpClient = new HttpClient()) {
                string url = _node + "/?jsonrpc=2.0&method=getblock&params=[" + _blockNum + ",1]&id=" + 1;
                string result = httpClient.GetStringAsync(url).Result;
                return JObject.Parse(result);
            }
        }
    }
}