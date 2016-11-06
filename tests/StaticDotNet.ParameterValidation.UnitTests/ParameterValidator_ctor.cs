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
			string parameterName = "ParameterName";
			object parameterValue = new object();

			ParameterValidator<object> parameterValidator = new ParameterValidator<object>( parameterName, parameterValue );

			Assert.Equal( parameterName, parameterValidator.ParameterName );
			Assert.Same( parameterValue, parameterValidator.ParameterValue );
		}
    }
}
