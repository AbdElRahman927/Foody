namespace Foody_backend.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(String message) : base(message) { }
    }
    public class NotFoundException : Exception
    {
        public NotFoundException(String message) : base(message) { }
    }
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(String message) : base(message) { }
    }
}