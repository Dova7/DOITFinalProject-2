namespace Application.Service.Exceptions
{
    public class TopicNotFoundException : Exception
    {
        public TopicNotFoundException() : base("Topic not found")
        {

        }
    }
}
