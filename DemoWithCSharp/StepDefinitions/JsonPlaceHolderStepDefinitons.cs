using NUnit.Framework;
using TechTalk.SpecFlow;
using RestSharp;
using AutomationTests.StepDefinitions;
using System.Net;

namespace APIDemoCSharp.StepDefinitions
{
    [Binding]
    class JsonPlaceHolderStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private RestClient _restAPIClient;
        public JsonPlaceHolderStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
        }
        [Given(@"the site service is up and running")]
        public void GivenTheSiteServiceIsUpAndRunning()
        {
            var apiEndpoint = AppSettings.Instance.GetConfigValue("ServiceHost");
            _restAPIClient = new RestClient(apiEndpoint + "/posts");
            Assert.IsNotNull(_restAPIClient);
        }

        [When(@"I post with json data of")]
        public void WhenIPostWithJsonDataOf(Table table)
        {
            var request = new RestRequest(Method.POST);
            foreach (var row in table.Rows)
            {
                request.AddParameter(row[0], row[1]);
            }
            var response = _restAPIClient.Post(request);
            _scenarioContext.Add("Response", response);
            _scenarioContext.Add("Request", table);
        }

        [Then(@"I should get successful response code")]
        public void ThenIShouldGetSuccessfulResponseCode()
        {
            var response = _scenarioContext.Get<IRestResponse>("Response");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            var inputTable = _scenarioContext.Get<Table>("Request");
            foreach (var row in inputTable.Rows)
            {
                Assert.IsTrue(response.Content.Contains(row[0]));
                Assert.IsTrue(response.Content.Contains(row[1]));
            }
        }
    }
}