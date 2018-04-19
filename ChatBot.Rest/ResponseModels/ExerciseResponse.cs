using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Rest.ResponseModels
{
    public class ExerciseResponse
    {
        public int ExerciseId { get; set; }
        public bool Show { get; set; }
        public bool MarkDone { get; set; }
    }
}
