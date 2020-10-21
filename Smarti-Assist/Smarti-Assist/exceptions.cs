using System;
using System.Runtime.Serialization;


/*Smart-i Assist -Exceptions- Version 1.0.0.5
 * Created: 6/29/2020
 * Updated: 7/9/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@metadevdigital.com
 * 
 * Copyright Copyright MIT Liscenece  - Enjoy boys, keep updating without me. Fork to your hearts content
 */

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
