﻿// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WinDynamicDesktop
{
    class LocationIQData
    {
        public string place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public string osm_id { get; set; }
        public List<string> boundingbox { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string display_name { get; set; }
        public string @class { get; set; }
        public string type { get; set; }
        public double importance { get; set; }
        public string icon { get; set; }
    }

    class LocationIQService
    {
        private static string apiKey = Encoding.UTF8.GetString(Convert.FromBase64String(
            "cGsuYmRhNTk1NDRhN2VjZWMxYjAxMDZkNzg5MzdlMDQzOTk ="));

        public static LocationIQData GetLocationData(string locationStr)
        {
            var client = new RestClient("https://us1.locationiq.org");

            var request = new RestRequest("v1/search.php");
            request.AddParameter("key", apiKey);
            request.AddParameter("q", locationStr);
            request.AddParameter("format", "json");
            request.AddParameter("limit", "1");

            var response = client.Execute<List<LocationIQData>>(request);
            if (!response.IsSuccessful)
            {
                return null;
            }

            return response.Data[0];
        }
    }
}
