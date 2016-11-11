using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_IsNotEqualTo
    {
		[Fact]
		public void StringExtensions_IsNotEqualTo_WithParameterValueNotEqualToValueReturnsCorrectly()
		{
			string value = "value";
			bool ignoreCase = false;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.IsNotEqualTo( value, ignoreCase );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsNotEqualTo_WithParameterValueNotEqualToValueAndIgnoreCaseTrueReturnsCorrectly()
		{
			string value = "NotEqual";
			bool ignoreCase = true;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.IsNotEqualTo( value, ignoreCase );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsNotEqualTo_WithNullParameterValueReturnsCorrectly()
		{
			string value = "Value";
			bool ignoreCase = false;

			string parameterName = "ParameterName";
			string parameterValue = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.IsNotEqualTo( value, ignoreCase );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsNotEqualTo_WithNullValueReturnsCorrectly()
		{
			string value = null;
			bool ignoreCase = false;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.IsNotEqualTo( value, ignoreCase );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsNotEqualTo_WithParameterValueEqualToValueThrowsArgumentException()
		{
			string value = "Value";
			bool ignoreCase = false;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsNotEqualTo( value, ignoreCase ) );

			Assert.Equal( $"Value must not be equal to '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}


		[Fact]
		public void StringExtensions_IsNotEqualTo_WithParameterValueEqualToValueWithIgnoreCaseTrueThrowsArgumentException()
		{
			string value = "value";
			bool ignoreCase = true;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsNotEqualTo( value, ignoreCase ) );

			Assert.Equal( $"Value must not be equal to '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void StringExtensions_IsNotEqualTo_WithInvalidParameterValueIgnoreCaseTrueAndExceptionMessageTrueThrowsArgumentExceptiony()
		{
			string value = "Value";
			bool ignoreCase = true;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsNotEqualTo( value, ignoreCase, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
