using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FHIR.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace FHIR.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            const string baseUrl = "https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/";
            const string patientId = "Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB";

            //const string baseUrl = "https://fhir-open.sandboxcerner.com/dstu2/0b8a0111-e8e6-4c26-a91c-5069cbc6b1ca";
            //const string patientId = "687969";

            var client =
                new FhirClient(baseUrl, true)
                {
                    UseFormatParam = true,
                    PreferredFormat = ResourceFormat.Json
                };

            var patient = client.Read<Patient>($"Patient/{patientId}");

            var patients = client.Search<Patient>(criteria: new[] { "name=a" });

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
