using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_EndsWith
    {
		[Fact]
		public void STringExtensions_EndsWith_WithParameterValueEndsWithValueReturnsCorrectly()
		{
			string value = "e";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.EndsWith( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void STringExtensions_EndsWith_WithNullParameterValueReturnsCorrectly()
		{
			string value = "V";

			string parameterName = "Name";
			string parameterValue = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.EndsWith( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void STringExtensions_EndsWith_WithNullValueReturnsCorrectly()
		{
			string value = null;

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.EndsWith( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void STringExtensions_EndsWith_WithParameterValueWhichDoesNOtStartWithValueThrowsArguementException()
		{
			string value = "DoesNotEndWith";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.EndsWith( value ) );

			Assert.Equal( $"Value must end with '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void STringExtensions_EndsWith_WithInvalidParameterValueAndExceptionMessageThrowsArguementException()
		{
			string value = "DoesNotEndWith";
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.EndsWith( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
