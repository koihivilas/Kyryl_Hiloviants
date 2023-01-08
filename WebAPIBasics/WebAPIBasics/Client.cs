using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBasics
{
    public class Client
    {
        private string TOKEN = "sl.BWg6nGjQfpgQQ4gVSqYOXyz4pkPv3OMCjdIO5EhIQ_OplURSpy_OElzYWSDDaXgtFcGCQI2vqjh5di4O2FAOJYZX30rukOId98mXMF0pgvI6Dc7RcaHGkJa5aC-3fgbQrDJntsQ";
        private HttpClient _client;

        public Client() => _client = new HttpClient();

        public JObject UploadFile(string filePath, string dropboxPath)
        {
            // Set up HTTP request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://content.dropboxapi.com/2/files/upload"),
                Headers = {
                    { "Authorization", $"Bearer {TOKEN}" },
                    { "Dropbox-API-Arg", $"{{\"autorename\":false,\"mode\":\"overwrite\",\"mute\":false,\"path\":\"{dropboxPath}\",\"strict_conflict\":false}}" }
                },
                Content = new StreamContent(new FileStream(filePath, FileMode.Open)),
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            // Send request and get response
            var response = _client.SendAsync(request).Result;

            // Check status code
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to upload file");
            }

            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public JObject GetFileMetadata(string dropboxPath)
        {
            // Set up HTTP request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.dropboxapi.com/2/files/get_metadata"),
                Headers = {
                    { "Authorization", $"Bearer {TOKEN}" }
                },
                Content = new StringContent($"{{\"path\": \"{dropboxPath}\"}}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Send request and get response
            var response = _client.SendAsync(request).Result;

            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public JObject DeleteFile(string dropboxPath)
        {
            // Set up HTTP request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.dropboxapi.com/2/files/delete"),
                Headers = {
                    { "Authorization", $"Bearer {TOKEN}" }
                },
                Content = new StringContent($"{{\"path\": \"{dropboxPath}\"}}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            // Send request and get response
            var response = _client.SendAsync(request).Result;

            // Check status code
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete file");
            }

            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }
    }
}
