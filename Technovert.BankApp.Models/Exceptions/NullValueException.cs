﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models.Exceptions
{
    public class NullValueException : Exception
    {
        public NullValueException(string s) : base(s)
        {
        }
    }
}