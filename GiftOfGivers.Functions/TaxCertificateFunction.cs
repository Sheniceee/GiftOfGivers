using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace GiftOfGivers.Functions
{
    public class TaxCertificateFunction
    {
        [Function("GenerateTaxCertificate")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "GenerateTaxCertificate")] HttpRequestData req)
        {
            var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
            var donorName = query["donorName"] ?? "Anonymous Donor";

            var certificate = $"TAX-CERT-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");
            await response.WriteStringAsync($"{{\"donor\":\"{donorName}\",\"certificateNumber\":\"{certificate}\",\"message\":\"Donation tax certificate generated successfully\"}}");
            return response;
        }
    }
}