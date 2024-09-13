using System.Runtime.Serialization;

namespace CleanArchitecture.Application.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public object errors;

        public ValidationException()
        {
            this.errors = new object();
        }

        public ValidationException(object errors)
        {
            this.errors = errors;
        }

        public ValidationException(string? message) : base(message)
        {
        }

        public ValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}