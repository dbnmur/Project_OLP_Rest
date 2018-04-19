using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Rest.ResponseModels
{
    public class ExerciseResponse
    {
        public string ChatBotResponse { get; set; }
        public ExerciseEvent Exercise { get; set; }

        public ExerciseResponse()
        {

        }
    }

    public class ExerciseEvent
    {
        public int ExerciseId { get; set; }
        public bool Show { get; set; }
        public bool MarkDone { get; set; }
    }
}
