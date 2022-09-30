namespace ECommerce.Project.Backend.Application.Commom
{
    [Serializable]
    public class Exceptions : Exception
    {
        public List<Error> Errors { get; private set; }

        public Exceptions(List<Error> errors)
        {
            this.Errors = errors;
        }

        public Exceptions(string message) : base(message) { }
        public Exceptions(string message, Exception innerException) : base(message, innerException) { }
        protected Exceptions(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}