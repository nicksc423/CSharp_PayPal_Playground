using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceSite.Helpers
{
    public class IntegerLengthAttribute : ValidationAttribute
    {
        public int _MaximumLength { get; set; }
        public IntegerLengthAttribute(int MaximumLength)
        {
            _MaximumLength = MaximumLength;
        }

        public override bool IsValid(object value)
        {
            try
            {
                Int32.Parse(value.ToString());
                return value.ToString().Length < _MaximumLength;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }
    }
}