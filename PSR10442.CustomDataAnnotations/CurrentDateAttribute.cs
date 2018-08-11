using System;
using System.ComponentModel.DataAnnotations;

namespace PSR10442.CustomDataAnnotations
{
    public class CurrentDateAttribute : ValidationAttribute
    {
		public CurrentDateAttribute() { }
		public override bool IsValid(object value)
		{
			return (DateTime)value >= DateTime.Now;
		}
	}
}
