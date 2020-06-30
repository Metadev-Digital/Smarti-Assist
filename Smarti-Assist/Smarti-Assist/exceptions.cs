using System;
using System.Runtime.Serialization;

namespace Smarti_Assist
{
    [Serializable()]
    public class IncompatibleFileVersionException : Exception, ISerializable
    {
        public IncompatibleFileVersionException() : base() { }
        public IncompatibleFileVersionException(string message) : base(message) { }
        public IncompatibleFileVersionException(string message, System.Exception inner) : base(message, inner) { }
        public IncompatibleFileVersionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable()]
    public class IncompatibleFileException : Exception, ISerializable
    {
        public IncompatibleFileException() : base() { }
        public IncompatibleFileException(string message) : base(message) { }
        public IncompatibleFileException(string message, System.Exception inner) : base(message, inner) { }
        public IncompatibleFileException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
