using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingSample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            this.logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogInformation(LoggingEvents.GET_ALL_VALUES, "Getting all values.");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            logger.LogInformation(LoggingEvents.GET_VALUE_BY_ID, $"Getting value: {id}.", id);
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            logger.LogInformation(LoggingEvents.POST_VAUE, "Posting value: {value}.", value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            logger.LogInformation(LoggingEvents.PUT_VAUE, "Putting value: {value} for id: {id}.", value, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation(LoggingEvents.DELETE_VAUE, "Deleting value: {id}.", id);
        }
    }
}
