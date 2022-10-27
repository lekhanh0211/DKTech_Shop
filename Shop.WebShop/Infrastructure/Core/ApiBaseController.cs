using Shop.Model.Models;
using Shop.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.WebShop.Infrastructure.Core
{
    public class ApiBaseController : ApiController
    {
        private IErrorService _errorService;
        public ApiBaseController(IErrorService errorService)
        {
            this._errorService = errorService;
        }
        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null; // khai bao bien http tra ve bang null
            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException dex)
            {
                LogError(dex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error er = new Error();
                er.CreatedDate = DateTime.Now;
                er.Message = ex.Message;
                er.StackTrace = ex.StackTrace;
                _errorService.Create(er);
                _errorService.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}