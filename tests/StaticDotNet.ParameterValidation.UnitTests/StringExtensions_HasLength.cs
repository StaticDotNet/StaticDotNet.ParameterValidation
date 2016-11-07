using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_HasLength
    {
		[Fact]
		public void StringExtensions_HasLength_WithValueLengthEqualsExpectedLengthReturnsCorrectly()
		{
			int expectedLength = 10;

			string name = "Name";
			string value = new string( 'A', expectedLength );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasLength( expectedLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasLength_WithNullValueReturnsCorrectly()
		{
			int expectedLength = 10;

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasLength( expectedLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasLength_WithValueLengthNotEqualToExpectedLengthThrowsArgumentException()
		{
			int expectedLength = 10;

			string name = "Name";
			string value = new string( 'A', expectedLength - 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.HasLength( expectedLength ) );

			Assert.Equal( $"Value must have a length equal to { expectedLength }.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_HasLength_WithInvalidValueLengthAndExceptionMessageThrowsArgumentException()
		{
			int expectedLength = 10;
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = new string( 'A', expectedLength - 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.HasLength( expectedLength, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
