using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceStation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RangeUntilCurrentYearAttribute : RangeAttribute
    {
        public RangeUntilCurrentYearAttribute(int minimum)
            : base(minimum, DateTime.Now.Year)
        {
        }
    }
}