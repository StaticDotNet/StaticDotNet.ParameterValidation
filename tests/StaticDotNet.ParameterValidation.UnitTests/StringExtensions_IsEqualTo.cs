using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_IsEqualTo
    {
		[Fact]
		public void StringExtensions_IsEqualTo_WithParameterValueEqualToValueReturnsCorrectly()
		{
			string value = "Value";
			bool ignoreCase = false;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.IsEqualTo( value, ignoreCase );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsEqualTo_WithParameterValueEqualToValueAndIgnoreCaseTrueReturnsCorrectly()
		{
			string value = "value";
			bool ignoreCase = true;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.IsEqualTo( value, ignoreCase );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsEqualTo_WithNullParameterValueReturnsCorrectly()
		{
			string value = "Value";
			bool ignoreCase = false;

			string parameterName = "ParameterName";
			string parameterValue = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.IsEqualTo( value, ignoreCase );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsEqualTo_WithNullValueReturnsCorrectly()
		{
			string value = null;
			bool ignoreCase = false;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.IsEqualTo( value, ignoreCase );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsEqualTo_WithParameterValueNotEqualToValueReturnsCorrectly()
		{
			string value = "value";
			bool ignoreCase = false;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsEqualTo( value, ignoreCase ) );

			Assert.Equal( $"Value must be equal to '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void StringExtensions_IsEqualTo_WithParameterValueNotEqualToValueWithIgnoreCaseTrueReturnsCorrectly()
		{
			string value = "NotEqual";
			bool ignoreCase = true;

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsEqualTo( value, ignoreCase ) );

			Assert.Equal( $"Value must be equal to '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void StringExtensions_IsEqualTo_WithInvalidParameterValueIgnoreCaseTrueAndExceptionMessageTrueReturnsCorrectly()
		{
			string value = "NotEqual";
			bool ignoreCase = true;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsEqualTo( value, ignoreCase, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
