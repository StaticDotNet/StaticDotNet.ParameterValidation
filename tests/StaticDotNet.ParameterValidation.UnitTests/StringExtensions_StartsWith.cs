using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_StartsWith
    {
		[Fact]
		public void STringExtensions_StartWith_WithParameterValueStartsWithValueReturnsCorrectly()
		{
			string value = "V";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.StartsWith( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void STringExtensions_StartWith_WithNullParameterValueReturnsCorrectly()
		{
			string value = "V";

			string parameterName = "Name";
			string parameterValue = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.StartsWith( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void STringExtensions_StartWith_WithNullValueReturnsCorrectly()
		{
			string value = null;

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.StartsWith( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void STringExtensions_StartWith_WithParameterValueWhichDoesNOtStartWithValueThrowsArguementException()
		{
			string value = "DoesNotStartWith";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.StartsWith( value ) );

			Assert.Equal( $"Value must start with '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void STringExtensions_StartWith_WithInvalidParameterValueAndExceptionMessageThrowsArguementException()
		{
			string value = "DoesNotStartWith";
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.StartsWith( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
