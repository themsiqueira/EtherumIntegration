using Integration.Business;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Integration.Controllers
{
    public class SaveDataController
    {
        [RoutePrefix("api")]
        public class GeoidController
        {
            [HttpPost]
            [Route("add")]
            public Object Save(dynamic Data)
            {
                DataBusiness dataBusiness = new DataBusiness();
                string Result = dataBusiness.Add(Data);

                if (Result != null)
                {
                    return Result;
                }

                return null;
            }

            [HttpGet]
            [Route("get")]
            public Object Get()
            {
                var dataBusiness = new DataBusiness();
                List<dynamic> Result = dataBusiness.Get();

                if (Result != null)
                {
                    return Result;
                }

                return null;
            }
        }

    }
}