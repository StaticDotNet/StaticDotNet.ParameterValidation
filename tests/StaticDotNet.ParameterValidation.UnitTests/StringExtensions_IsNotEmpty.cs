using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
	public class StringExtensions_IsNotEmpty
	{
		[Fact]
		public void StringExtensions_IsNotEmpty_WithNonEmptyValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsNotEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsNotEmpty_WithNullValueReturnsCorrectly()
		{
			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsNotEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsNotEmpty_WithEmptyValueThrowsArgumentException()
		{
			string name = "Name";
			string value = string.Empty;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotEmpty() );

			Assert.Equal( $"Value cannot be empty.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_IsNotEmpty_WithEmptyValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = string.Empty;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotEmpty( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
