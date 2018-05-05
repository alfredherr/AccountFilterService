using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Account_Code_Filter_Service.BusinessLogic;
using Account_Code_Filter_Service.Models;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;

namespace Account_Code_Filter_Service.Controllers
{
    [Route("/x")]
    public class HomeController
    {

        public string GetFile()
        {
            return "Hellllooooo";

        }
    }
}