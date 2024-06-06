using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    internal class ValidationException : Exception
    {
        private object errors;

        public ValidationException()
        {
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