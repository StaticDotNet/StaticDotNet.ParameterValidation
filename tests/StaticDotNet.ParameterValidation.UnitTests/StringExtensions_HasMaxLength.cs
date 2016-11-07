using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_HasMaxLength
    {
		[Fact]
		public void StringExtensions_HasMaxLength_WithValueLengthEqualToMaxLengthReturnsCorrectly()
		{
			int maxLength = 10;

			string name = "Name";
			string value = new string( 'A', maxLength );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasMaxLength( maxLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasMaxLength_WithValueLengthLessThanMaxLengthReturnsCorrectly()
		{
			int maxLength = 10;

			string name = "Name";
			string value = new string( 'A', maxLength - 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasMaxLength( maxLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasMaxLength_WithNullValueReturnsCorrectly()
		{
			int maxLength = 10;

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasMaxLength( maxLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasMaxLength_WithValueLengthGreaterThanMaxLengthThrowsArgumentException()
		{
			int maxLength = 10;

			string name = "Name";
			string value = new string( 'A', maxLength + 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.HasMaxLength( maxLength ) );

			Assert.Equal( $"Value must have a length less than or equal to { maxLength }.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_HasMaxLength_WithInvalidValueLengthAndExceptionMessageThrowsArgumentException()
		{
			int maxLength = 10;
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = new string( 'A', maxLength + 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.HasMaxLength( maxLength, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
