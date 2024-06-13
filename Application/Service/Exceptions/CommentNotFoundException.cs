namespace Application.Service.Exceptions
{
    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException() : base("Comment not found")
        {

        }
    }
}