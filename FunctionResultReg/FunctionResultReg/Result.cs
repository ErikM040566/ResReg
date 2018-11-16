using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace FunctionResultReg
{
    public static class Result
    {
        [FunctionName("Result")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            HttpResponseMessage res;
            // Get request body
            object data = await req.Content.ReadAsAsync<object>();

            if (data != null)
            {
                res = req.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                res = req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");
            }

            return res;
        }
    }
}
