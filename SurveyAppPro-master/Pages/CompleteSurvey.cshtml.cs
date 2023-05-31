using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SurveyApp.Data;
using Microsoft.AspNetCore.Builder;

namespace SurveyApp.Pages
{
    public class CompleteSurveyModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

       
        public string SurveyResult { get; set; }
        public string QuestionResult { get; set; }

        public CompleteSurveyModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;            
        }
        
        public async Task OnGetAsync()
        {
            var userId = User.GetUserId();

            var surveyResult = await _dbContext.CompletedSurveys
                .Where(s => s.UserId == userId)
                .FirstOrDefaultAsync(); 
            
            SurveyResult = surveyResult?.SurveyResult ?? "{}";
          
           await OnGetQuestionAsyncs(1);
        }

        public async Task OnGetQuestionAsyncs(int surveyId)
        {
            
            //survey.title = "abc";
            //survey.SurveyId = 1;
            try
            {
                var surveytitle =_dbContext.surveys
                    .Where(s => s.SurveyId == surveyId).FirstOrDefault();
                var questionResult = _dbContext.Questions
                    .Where(s => s.SurveyId ==surveyId).ToList();
                foreach( var questiondata in questionResult)
                {
                    Choices choiceResult = _dbContext.choices.
                        Where(s => s.QuestionId == questiondata.QuestionId).FirstOrDefault();
                    if (choiceResult != null) {
                        questiondata.choices = choiceResult.choicedata.Split(",");
                   }                    
                }
             
                surveytitle.questions = questionResult;
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                // This tells your serializer that multiple references are okay.
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //QuestionResult = "{ title: \"Tell us, what technologies do you use?\", questions:[{ type: \"radiogroup\", choices:[\"Yes\", \"No\"], isRequired: true, name: \"frameworkUsing\", title: \"Do you use any front-end framework like Bootstrap?\" }]}";
                QuestionResult = surveytitle != null ? Newtonsoft.Json.JsonConvert.SerializeObject(surveytitle,settings) : "{}";
            }
            catch(Exception e)
            {
                string err = e.Message;
            }
        }


        public async Task<IActionResult> OnPostSaveAsync(string data)
        {
            var userId = User.GetUserId();

            var surveyResult = await _dbContext.CompletedSurveys
                .Where(s => s.UserId == userId)
                .FirstOrDefaultAsync();
            if (surveyResult != null)
            {
                surveyResult.SurveyResult = data;
            }
            else
            {
                _dbContext.CompletedSurveys.Add(new CompletedSurvey
                {
                    SurveyResult = data,
                    UserId = userId
                });
            }
            await _dbContext.SaveChangesAsync();
            
            return new OkResult();
        }
    }
}