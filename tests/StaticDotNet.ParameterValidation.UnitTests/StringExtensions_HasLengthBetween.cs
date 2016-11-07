using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_HasLengthBetween
    {
		[Fact]
		public void StringExtensions_HasLengthBetween_WithValueLengthEqualToMinLengthReturnsCorrectly()
		{
			int minLength = 5;
			int maxLength = 10;

			string name = "Name";
			string value = new string( 'A', minLength );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasLengthBetween( minLength, maxLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasLengthBetween_WithValueLengthEqualToMaxLengthReturnsCorrectly()
		{
			int minLength = 5;
			int maxLength = 10;

			string name = "Name";
			string value = new string( 'A', maxLength );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasLengthBetween( minLength, maxLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasLengthBetween_WithValueLengthBetweenMinLengthAndMaxLengthReturnsCorrectly()
		{
			int minLength = 5;
			int maxLength = 10;

			string name = "Name";
			string value = new string( 'A', maxLength - 2 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasLengthBetween( minLength, maxLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasLengthBetween_WithNullValueReturnsCorrectly()
		{
			int minLength = 5;
			int maxLength = 10;

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.HasLengthBetween( minLength, maxLength );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_HasLengthBetween_WithValueLengthLessThanMinLengthThrowsArgumentException()
		{
			int minLength = 5;
			int maxLength = 10;

			string name = "Name";
			string value = new string( 'A', minLength - 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.HasLengthBetween( minLength, maxLength ) );

			Assert.Equal( $"Value must have a length between { minLength } and { maxLength }.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_HasLengthBetween_WithValueLengthGreaterThanMaxLengthThrowsArgumentException()
		{
			int minLength = 5;
			int maxLength = 10;

			string name = "Name";
			string value = new string( 'A', maxLength + 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.HasLengthBetween( minLength, maxLength ) );

			Assert.Equal( $"Value must have a length between { minLength } and { maxLength }.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_HasLengthBetween_WithInvalidValueLengthAndExceptionMessageThrowsArgumentException()
		{
			int minLength = 5;
			int maxLength = 10;
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = new string( 'A', maxLength + 1 );

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.HasLengthBetween( minLength, maxLength, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
