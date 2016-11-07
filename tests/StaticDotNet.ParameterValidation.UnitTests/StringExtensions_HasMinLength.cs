using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_HasMinLength
    {
		[Fact]
		public void StringExtensions_HasMinLength_WithValueLengthEqualToMinLengthReturnsCorrectly()
		{
			int minLength = 10;

			string name = "Name";
			string value = new string( 'A', minLength );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasMinLength( minLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasMinLength_WithValueLengthGreaterThanMinLengthReturnsCorrectly()
		{
			int minLength = 10;

			string name = "Name";
			string value = new string( 'A', minLength + 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasMinLength( minLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasMinLength_WithNullValueReturnsCorrectly()
		{
			int minLength = 10;

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasMinLength( minLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasMinLength_WithValueLengthLessThanMinLengthThrowsArgumentException()
		{
			int minLength = 10;

			string name = "Name";
			string value = new string( 'A', minLength - 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.HasMinLength( minLength ) );

			Assert.Equal( $"Value must have a length greater than or equal to { minLength }.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_HasMinLength_WithInvalidValueLengthAndExceptionMessageThrowsArgumentException()
		{
			int minLength = 10;
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = new string( 'A', minLength - 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.HasMinLength( minLength, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
