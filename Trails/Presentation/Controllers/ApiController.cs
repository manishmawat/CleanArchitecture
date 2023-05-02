using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ApiController:ControllerBase
    {
        public ISender Sender;
        public ApiController(ISender sender)
        {
            Sender = sender;
        }

        public ApiController()
        {
            
        }
    }
}
