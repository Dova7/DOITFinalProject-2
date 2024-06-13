namespace Application.Service.Exceptions
{
    public class TopicIsInactiveException : Exception
    {
        public TopicIsInactiveException() : base("Topic is inactive")
        {
            
        }
    }
}
