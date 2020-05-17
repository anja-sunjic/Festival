using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festival.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Festival.Web.Controllers
{
        [ServiceFilter(typeof(DblExceptionFilter))]
        public class BaseController : Controller
        {
        }
}