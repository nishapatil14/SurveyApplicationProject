using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Data
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [ForeignKey("Survey")]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public string type { get; set; }
        [NotMapped]
        public string[] choices{get; set; }

        public bool isRequired { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public bool? hasOther { get; set; }
        public string visibleIf { get; set; }

    }
}
