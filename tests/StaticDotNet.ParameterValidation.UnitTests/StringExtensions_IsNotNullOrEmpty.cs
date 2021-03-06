﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class StringExtensions_IsNotNullOrEmpty
    {
		[Fact]
		public void StringExtensions_IsNotNullOrEmpty_WithValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsNotNullOrEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void StringExtensions_IsNotNullOrEmpty_WithNullValueThrowsArgumentNullException()
		{
			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentNullException exception = Assert.Throws<ArgumentNullException>( name, () => validator.IsNotNullOrEmpty() );

			Assert.Equal( $"Value cannot be null or empty.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_IsNotNullOrEmpty_WithEmptyValueThrowsArgumentException()
		{
			string name = "Name";
			string value = string.Empty;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotNullOrEmpty() );

			Assert.Equal( $"Value cannot be null or empty.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void StringExtensions_IsNotNullOrEmpty_WithInvalidValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			string value = string.Empty;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotNullOrEmpty( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
