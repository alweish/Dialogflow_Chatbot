using Chatbot.Business.Handlers;
using Chatbot.Business.Repository;
using Chatbot.Models;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Chatbot.Controllers {
    public class BotController : ApiController {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(BotController));
        private readonly RequestManager _requestManager;
        private readonly ResponseManager _responseManager;
        public BotController() {
            _requestManager = new RequestManager(new RepositoryInitialiser());
            _responseManager = new ResponseManager(new RepositoryInitialiser());
        }
        
        [HttpGet]
        public IHttpActionResult Index() {
            return Ok(_responseManager.Response());
        }

        [HttpPost]
        public IHttpActionResult Index(WebhookRequest query)  {

            var q = query.queryResult.outputContexts;
            var input = q.Where(ctx => ctx.name.EndsWith("informationdata")).FirstOrDefault();
            //var input = query.queryResult.outputContexts[0];
           
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(input.parameters.ToString());
            
            var request = _requestManager.ProcessRequest(data);
            var response = _responseManager.CreateResponse(request);

            if (query != null) {
                return Ok(response);
            } else {
                return BadRequest();
            }
        }

        //[HttpPost]
        //public IHttpActionResult Test([FromBody] JToken jsonbody) {
        //    return Ok();
        //}


    }
}