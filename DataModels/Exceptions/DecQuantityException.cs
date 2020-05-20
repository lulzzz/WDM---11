using System;
using System.Runtime.Serialization;

namespace DataModels
{
    [Serializable]
    public class DecQuantityException : Exception
    {
        public DecQuantityException()
        {
        }

        public DecQuantityException(string message) : base(message)
        {
        }

        public DecQuantityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DecQuantityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}