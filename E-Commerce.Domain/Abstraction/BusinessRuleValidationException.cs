﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Abstraction
{
    public class BusinessRuleValidationException : Exception
    {
        public IBusinessRule BrokenRule { get; }

        public string Details { get; }

        public BusinessRuleValidationException(IBusinessRule brokenRule) :base(brokenRule.Message)
        {
            brokenRule = brokenRule;
            this.Details = brokenRule.Message;
        }

        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName} : {BrokenRule.Message}";
        }
    }
}
