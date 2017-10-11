﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Responsible.Core
{
    internal class Response : IResponse
    {
        public bool Success { get; internal set; }
        public ResponseStatus Status { get; internal set; }
        public IEnumerable<string> Messages { get; internal set; }
        public bool HasException { get; internal set; }
        public Exception Exception { get; internal set; }
        public string SingleMessage
        {
            get
            {
                if (Messages != null && Messages.Any())
                {
                    return string.Join(Environment.NewLine, Messages.ToArray());
                }

                return "";
            }
        }
    }

    internal class Response<T> : Response, IResponse<T>
    {
        public T Value { get; internal set; }
    }
}