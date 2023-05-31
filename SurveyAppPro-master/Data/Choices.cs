using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Data
{
    public class Choices
    {
        [Key]
        public int choiceId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question question { get; set; }
        public string choicedata { get; set; }

    }
}
