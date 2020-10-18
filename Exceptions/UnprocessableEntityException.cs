using System;
using System.Runtime.Serialization;

namespace EloGroupBack.Exceptions
{
    [Serializable]
    public class UnprocessableEntityException : Exception
    {
        public UnprocessableEntityException()
        {
        }

        public UnprocessableEntityException(string message) : base(message)
        {
        }

        public UnprocessableEntityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnprocessableEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}