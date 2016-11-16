using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtension_Match
    {
		[Fact]
		public void StringExtensions_Match_WithParameterValueMatchesPatternReturnsCorrectly()
		{
			string pattern = "^V";

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( pattern );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_Match_WithNullParameterValueReturnsCorrectly()
		{
			string pattern = "^V";

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( pattern );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_Match_WithNullPatternReturnsCorrectly()
		{
			string pattern = null;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( pattern );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_Match_WithParameterValueDoeNotMatchPatternThrowsArgumentException()
		{
			string pattern = "^v";

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.Match( pattern ) );

			Assert.Equal( $"Value must match the regular expression '{ pattern }'.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_Match_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			string pattern = "^v";
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.Match( pattern, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_Match_WithParameterValueMatchesPatternAndOutMatchReturnsCorrectly()
		{
			string pattern = "^V";
			Match match;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( pattern, out match );

			Assert.Same( validator, result );
			Assert.NotNull( match );
			Assert.True( match.Success );
		}

		[Fact]
		public void StringExtensions_Match_WithNullParameterValueAndOutMatchReturnsCorrectly()
		{
			string pattern = "^V";
			Match match;

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( pattern, out match );

			Assert.Same( validator, result );
			Assert.Null( match );
		}

		[Fact]
		public void StringExtensions_Match_WithNullPatternAndOutMatchReturnsCorrectly()
		{
			string pattern = null;
			Match match;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( pattern, out match );

			Assert.Same( validator, result );
			Assert.Null( match );
		}

		[Fact]
		public void StringExtensions_Match_WithParameterValueDoeNotMatchPatternAndOutMatchThrowsArgumentException()
		{
			string pattern = "^v";
			Match match = null;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.Match( pattern, out match ) );

			Assert.Equal( $"Value must match the regular expression '{ pattern }'.\r\nParameter name: { name }", exception.Message );
			Assert.NotNull( match );
			Assert.False( match.Success );
		}

		[Fact]
		public void StringExtensions_Match_WithInvalidParameterValueExceptionMessageAndOutMatchThrowsArgumentException()
		{
			string pattern = "^v";
			string exceptionMessage = "ExceptionMessage";
			Match match = null;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.Match( pattern, exceptionMessage, out match ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
			Assert.NotNull( match );
			Assert.False( match.Success );
		}

		[Fact]
		public void StringExtensions_Match_WithParameterValueMatchesRegexReturnsCorrectly()
		{
			Regex regex = new Regex( "^V" );

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( regex );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_Match_WithNullParameterValueAndRegexReturnsCorrectly()
		{
			Regex regex = new Regex( "^V" );

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( regex );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_Match_WithNullRegexReturnsCorrectly()
		{
			Regex regex = null;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( regex );

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_Match_WithParameterValueDoeNotMatchRegexThrowsArgumentException()
		{
			Regex regex = new Regex( "^v" );

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.Match( regex ) );

			Assert.Equal( $"Value must match the regular expression '{ regex.ToString() }'.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_Match_WithInvalidParameterValueRegexAndExceptionMessageThrowsArgumentException()
		{
			Regex regex = new Regex( "^v" );
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.Match( regex, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_Match_WithParameterValueMatchesRegexAndOutMatchReturnsCorrectly()
		{
			Regex regex = new Regex( "^V" );
			Match match;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( regex, out match );

			Assert.Same( validator, result );
			Assert.NotNull( match );
			Assert.True( match.Success );
		}

		[Fact]
		public void StringExtensions_Match_WithNullParameterValueRegexAndOutMatchReturnsCorrectly()
		{
			Regex regex = new Regex( "^V" );
			Match match;

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( regex, out match );

			Assert.Same( validator, result );
			Assert.Null( match );
		}

		[Fact]
		public void StringExtensions_Match_WithNullRegexAndOutMatchReturnsCorrectly()
		{
			Regex regex = null;
			Match match;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.Match( regex, out match );

			Assert.Same( validator, result );
			Assert.Null( match );
		}

		[Fact]
		public void StringExtensions_Match_WithParameterValueDoeNotMatchRegexAndOutMatchThrowsArgumentException()
		{
			Regex regex = new Regex( "^v" );
			Match match = null;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.Match( regex, out match ) );

			Assert.Equal( $"Value must match the regular expression '{ regex.ToString() }'.\r\nParameter name: { name }", exception.Message );
			Assert.NotNull( match );
			Assert.False( match.Success );
		}

		[Fact]
		public void StringExtensions_Match_WithInvalidParameterValueRegexExceptionMessageAndOutMatchThrowsArgumentException()
		{
			Regex regex = new Regex( "^v" );
			string exceptionMessage = "ExceptionMessage";
			Match match = null;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.Match( regex, exceptionMessage, out match ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
			Assert.NotNull( match );
			Assert.False( match.Success );
		}
	}
}
