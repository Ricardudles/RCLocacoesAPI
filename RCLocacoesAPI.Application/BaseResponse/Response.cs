﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace com.raizen.PGC.Application.Models
{
    public class Response
    {
        private IList<string> _errors;

        public Response()
        {
            IsSuccessful = true;
            _errors = new List<string>();
        }

        public IList<string> Errors { get => new ReadOnlyCollection<string>(_errors); set { _errors = value; } }

        public bool IsSuccessful { get; set; }

        public void AddError(string error)
        {
            IsSuccessful = false;
            _errors.Add(error);
        }

    }
}

