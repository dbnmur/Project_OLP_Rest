namespace Project_OLP_Rest.Domain
{
    public class Exercise : Record
    {
        public string AnswerRegex { get; set; }
        public bool IsCompleted { get; set; }
    }
}
