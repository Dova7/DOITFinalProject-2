namespace Application.Service.Exceptions
{
    public class InvalidStateException : Exception
    {
        public InvalidStateException() : base("Can only choose between hide and show")
        {
            
        }
    }
}
