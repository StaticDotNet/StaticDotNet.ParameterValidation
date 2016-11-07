using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class ParameterValidator_ctor
    {
		[Fact]
		public void ParameterValidator_ctor_InitializesCorrectly()
		{
			string name = "Name";
			object value = new object();

			ParameterValidator<object> parameterValidator = new ParameterValidator<object>( name, value );

			Assert.Equal( name, parameterValidator.Name );
			Assert.Same( value, parameterValidator.Value );
		}
    }
}
