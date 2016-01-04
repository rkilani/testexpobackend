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
    public class GeneralEvaluationController : ApiController
    {
        GeneralEvaluationClient client = new GeneralEvaluationClient();
        [HttpPost]
        public HttpResponseMessage SubmitEvaluation([FromBody] GeneralEvaluation eval)
        {
            try
            {
                GeneralEvaluationsEntity evalEntity = new GeneralEvaluationsEntity(eval.deviceID, eval.questionNumber);
                evalEntity.rating = eval.rating;
                evalEntity.questionNumber = eval.questionNumber;
                evalEntity.comment = eval.comment;
                evalEntity.willAttendAgain = eval.WillAttendAgain;
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
