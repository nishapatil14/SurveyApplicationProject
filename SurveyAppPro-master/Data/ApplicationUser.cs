﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Data
{
    public class ApplicationUser:IdentityUser
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}
