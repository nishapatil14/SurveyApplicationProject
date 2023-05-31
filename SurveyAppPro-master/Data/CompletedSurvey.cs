﻿using Microsoft.AspNetCore.Identity;

namespace SurveyApp.Data
{
    public class CompletedSurvey
    {
        public int Id { get; set; }

        public string SurveyResult { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}