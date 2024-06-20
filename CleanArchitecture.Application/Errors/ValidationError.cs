namespace CleanArchitecture.Application.Common.Behaviors
{
    public class ValidationError
    {
        public string propertyName { get; private set; }
        public string errorMessage { get; private set; }

        public ValidationError(string propertyName, string errorMessage)
        {
            this.propertyName = propertyName;
            this.errorMessage = errorMessage;
        }
    }
}