using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Geep.Common.Helpers
{
    public static class BOIHelper
    {
        public static HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                }
                return _client;

            }
        }
        private static HttpClient _client;
        public static async Task<HttpResponseMessage> PusheToWhiteList(BOIFields boiFields)
        {
            _client = null;

            Client.BaseAddress = new Uri("http://whitelist.tradermoni.ng");
            Client.DefaultRequestHeaders.Accept.Clear();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer DI0YWRhcHRlcjoxMjM0NTY3OHVp");

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            return await Client.PostAsJsonAsync("/api/candidate/create", boiFields);
        }

        public static async Task<HttpResponseMessage> UpdateRecordOnPortal(UpdateRecordOnPortalModel model)
        {
            _client = null;

            //Client.BaseAddress = new Uri("http://localhost:5000/");
            Client.BaseAddress = new Uri("https://dev.cforce.live/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Add("X-Tenant-Id", "-306299295");

            return await Client.PutAsJsonAsync("api/record/dashboardupdaterecord", model);

        }
        public static async Task<HttpResponseMessage> GetGeepTeamUsers()
        {
            _client = null;

            //Client.BaseAddress = new Uri("http://localhost:5000/");
            Client.BaseAddress = new Uri("https://dev.cforce.live/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Add("X-Tenant-Id", "-306299295");

            return await Client.GetAsync("api/team/getteamusersfordashboard");

        }

    }
}
