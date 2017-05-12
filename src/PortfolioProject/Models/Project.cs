using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Language { get; set; }

        public static List<Project> GetProjects()
        {
            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest("users/alexandraholcombe/starred?sort=created&direction=asc&per_page=3", Method.GET);
            request.AddHeader("User-Agent", "alexandraholcombe");
            request.AddHeader("Accept", "application/json");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonResponse.ToString());
            return projectList;

        }
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
