﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Core_API_3._1_Demo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public string[] Get()
        {
            return new[] {"Just", "a simple", "Return"};
        }
    }
}
