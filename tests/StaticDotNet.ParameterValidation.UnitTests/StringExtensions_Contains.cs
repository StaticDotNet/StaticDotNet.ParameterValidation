using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_Contains
    {
		[Fact]
		public void StringExtensions_Contains_WithParameterValueContainsValueReturnsCorrectly()
		{
			string value = "a";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.Contains( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_Contains_WithNullParameterValueReturnsCorrectly()
		{
			string value = "a";

			string parameterName = "Name";
			string parameterValue = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.Contains( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_Contains_WithNullValueReturnsCorrectly()
		{
			string value = null;

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.Contains( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_Contains_WithParameterValueDoesNotContainValueThrowsArgumentException()
		{
			string value = "DoesNotContain";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.Contains( value ) );

			Assert.Equal( $"Value must contain '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void StringExtensions_Contains_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			string value = "DoesNotContain";
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.Contains( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
