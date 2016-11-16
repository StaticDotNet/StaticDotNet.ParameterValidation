using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IEnumerableExtensions_Contains
    {
		[Fact]
		public void IEnumerableExtensions_Contains_WithParameterValueContainsValueReturnsCorrectly()
		{
			char value = 'V';

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.Contains( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_Contains_WithNullParameterValueReturnsCorrectly()
		{
			char value = 'V';

			string parameterName = "Name";
			string parameterValue = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ParameterValidator<string> result = validator.Contains( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_Contains_WithNullValueReturnsCorrectly()
		{
			object value = null;

			string parameterName = "Name";
			object[] parameterValue = { new object() };

			ParameterValidator<object[]> validator = new ParameterValidator<object[]>( parameterName, parameterValue );

			ParameterValidator<object[]> result = validator.Contains( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_Contains_WithParameterValueDoesNotContainValueReturnsCorrectly()
		{
			char value = 'X';

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.Contains( value ) );

			Assert.Equal( $"Value must contain '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IEnumerableExtensions_Contains_WithInvalidParameterValueAndExceptionMessageReturnsCorrectly()
		{
			char value = 'X';
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "Name";
			string parameterValue = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.Contains( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
