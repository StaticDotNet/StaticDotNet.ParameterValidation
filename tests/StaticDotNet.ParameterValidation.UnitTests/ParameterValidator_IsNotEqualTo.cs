using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class ParameterValidator_IsNotEqualTo
    {
		[Fact]
		public void ParameterValidator_IsNotEqualTo_WithParameterValueNotEqualToValueReturnsCorrectly()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int parameterValue = -1;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsNotEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_IsNotEqualTo_WithParameterValueEqualToThrowsArgumentException()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsNotEqualTo( value ) );

			Assert.Equal( $"Value must not be equal to '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void ParameterValidator_IsNotEqualTo_WithInvalidParameterValueWithExceptionMessageThrowsArgumentException()
		{
			int value = 0;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsNotEqualTo( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
