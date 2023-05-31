using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Data
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }
        public string title { get; set; }
        public List<Question> questions { get; set; }

    }
}
