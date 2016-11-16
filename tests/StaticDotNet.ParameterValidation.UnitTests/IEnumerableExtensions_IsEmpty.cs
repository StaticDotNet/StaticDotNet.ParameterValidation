using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IEnumerableExtensions_IsEmpty
    {
		[Fact]
		public void IEnumerableExtensions_IsEmpty_WithEmptyValueReturnsCorrectly()
		{
			string name = "Name";
			string value = string.Empty;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_IsEmpty_WithNullValueReturnsCorrectly()
		{
			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_IsEmpty_WithValueThrowsArgumentException()
		{
			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsEmpty() );

			Assert.Equal( $"Value must be empty.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void IEnumerableExtensions_IsEmpty_WithValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsEmpty( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
