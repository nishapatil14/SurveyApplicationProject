
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace SurveyApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CompletedSurvey> CompletedSurveys { get; set; }
        public DbSet<Survey> surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choices> choices { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        internal object Surveys(int surveyId)
        {
            throw new NotImplementedException();
        }
    }
}