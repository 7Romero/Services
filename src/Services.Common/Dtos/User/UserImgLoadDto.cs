﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.User
{
    public class UserImgLoadDto
    {
        public IFormFile file { get; set; }
    }
}
