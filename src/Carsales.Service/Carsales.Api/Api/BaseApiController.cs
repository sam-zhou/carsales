using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Carsales.Core.Uow;

namespace Carsales.Api.Api
{
    public abstract class BaseApiController:ApiController
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        protected BaseApiController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}