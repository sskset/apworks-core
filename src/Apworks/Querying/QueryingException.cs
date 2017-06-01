﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apworks.Querying
{
    public class QueryingException : ApworksException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryingException"/> class.
        /// </summary>
        public QueryingException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryingException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public QueryingException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryingException"/> class.
        /// </summary>
        /// <param name="format">The format of the error message.</param>
        /// <param name="args">The arguments to be used for constructing the error message.</param>
        public QueryingException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApworksException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public QueryingException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}