using System;

namespace ProductLib.ProductExceptions
{
    /// <summary>
    /// A class that is used if the dataset doesn't have the required information
    /// </summary>
    public class InvalidDataException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the InvalidDataException class
        /// </summary>
        public InvalidDataException()
            : base("There are not suitable data") { }
        /// <summary>
        /// Initializes a new instance of the InvalidDataException class with specific error message
        /// </summary>
        public InvalidDataException(string message)
            : base(message) { }

    }
}
