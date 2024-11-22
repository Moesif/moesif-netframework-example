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

        public static Dictionary<string, object> GetMoesifOptions()
        {
            string moesifAppId = Environment.GetEnvironmentVariable("MOESIF_APPLICATION_ID") ?? "<Your-Moesif-Application-Id>";
            Dictionary<string, object> moesifOptions = new Dictionary<string, object>
            {
                {"ApplicationId", moesifAppId },
                {"LocalDebug", true},
                {"LogBody", false},
                {"LogBodyOutgoing", true},
                {"RequestMaxBodySize", 300},
                {"ResponseMaxBodySize", 300},
                {"IsLambda", false},
                {"ApiVersion", "3.1.0"},
                {"IdentifyUser", IdentifyUser},
                {"IdentifyCompany", IdentifyCompany},
                {"GetSessionToken", GetSessionToken},
                {"GetMetadata", GetMetadata},
                {"GetMetadataOutgoing", GetMetadataOutgoing},
                {"EnableBatching", true},
                {"BatchSize", 25}
            };

            return moesifOptions;
        }
    }
}