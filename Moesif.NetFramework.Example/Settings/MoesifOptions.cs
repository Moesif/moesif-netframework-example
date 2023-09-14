using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Microsoft.Owin;
using Moesif.Api.Models;

namespace Moesif.NetFramework.Example.Settings
{
    public class MoesifOptions
    {
        public static Func<IOwinRequest, IOwinResponse, string> IdentifyUser = (IOwinRequest req, IOwinResponse res) => { 
            // Implement your custom logic to return user id
            return req?.Context?.Authentication?.User?.Identity?.Name;
        };

        public static Func<IOwinRequest, IOwinResponse, string> IdentifyCompany = (IOwinRequest req, IOwinResponse res) => {
            return req.Headers["X-Organization-Id"];
        };

        public static Func<IOwinRequest, IOwinResponse, string> GetSessionToken = (IOwinRequest req, IOwinResponse res) => {
            return req.Headers["Authorization"];
        };

        public static Func<IOwinRequest, IOwinResponse, Dictionary<string, object>> GetMetadata = (IOwinRequest req, IOwinResponse res) => {
            Dictionary<string, object> metadata = new Dictionary<string, object>
            {
                {"string_field", "value_1"},
                {"number_field", 0},
                {"object_field", new Dictionary<string, string> {
                    {"field_a", "value_a"},
                    {"field_b", "value_b"}
                    }
                }
            };
            return metadata;
        };

        public static Func<HttpRequestMessage, HttpResponseMessage, Dictionary<string, object>> GetMetadataOutgoing = (HttpRequestMessage req, HttpResponseMessage res) => {
            Dictionary<string, object> metadata = new Dictionary<string, object>
            {
                {"string_field", "value_1"},
                {"number_field", 0},
                {"object_field", new Dictionary<string, string> {
                    {"field_a", "value_a"},
                    {"field_b", "value_b"}
                    }
                }
            };
            return metadata;
        };

        static public Dictionary<string, object> moesifOptions = new Dictionary<string, object>
        {
            {"ApplicationId", "eyJhcHAiOiI1MTk6MzQ1IiwidmVyIjoiMi4xIiwib3JnIjoiNDIwOjMyMCIsImlhdCI6MTY5MzUyNjQwMH0.lK9JGmOPOS2hVHSt8sG8AYWlSE849Jf6bEOjEF7BGFc"},
            {"LocalDebug", true},
            {"LogBody", true},
            {"LogBodyOutgoing", true},
            {"ApiVersion", "1.1.0"},
            {"IdentifyUser", IdentifyUser},
            {"IdentifyCompany", IdentifyCompany},
            {"GetSessionToken", GetSessionToken},
            {"GetMetadata", GetMetadata},
            {"GetMetadataOutgoing", GetMetadataOutgoing},
            {"EnableBatching", true},
            {"BatchSize", 25}
        };
    }
}