using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_IsNotWhiteSpace
    {
		[Fact]
		public void StringExtensions_IsNotWhiteSpace_WithValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsNotWhiteSpace();

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsNotWhiteSpace_WithNullValueReturnsCorrectly()
		{
			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsNotWhiteSpace();

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsNotWhiteSpace_WithEmptyValueThrowsArgumentException()
		{
			string name = "Name";
			string value = " ";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotWhiteSpace() );

			Assert.Equal( $"Value cannot be empty or white space.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_IsNotWhiteSpace_WithWhiteSpaceValueThrowsArgumentException()
		{
			string name = "Name";
			string value = " ";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotWhiteSpace() );

			Assert.Equal( $"Value cannot be empty or white space.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_IsNotWhiteSpace_WithWhiteSpaceValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = " ";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotWhiteSpace( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
