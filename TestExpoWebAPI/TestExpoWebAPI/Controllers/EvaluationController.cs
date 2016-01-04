using DataTableStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestExpoWebAPI.Model;
using TextExpoStorageSample.Model;

namespace TestExpoWebAPI.Controllers
{
    public class EvaluationController : ApiController
    {
        EvaluationClient client = new EvaluationClient();
        [HttpPost]
        public HttpResponseMessage SubmitEvaluation([FromBody] Evaluation eval)
        {
            try
            {
                EvaluationsEntity evalEntity = new EvaluationsEntity(eval.deviceID, eval.presentationId);
                evalEntity.rating = eval.rating;
                evalEntity.speakerID = eval.speakerId;
                evalEntity.comment = eval.comment;
                evalEntity.timestamp = DateTime.Now;
                client.InsertUserEval(evalEntity);
            }
            catch(AlreadyExistsException e)
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
