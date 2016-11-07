using StaticDotNet.ParameterValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class ParameterValidator_IsNull
    {
		[Fact]
		public void ParameterValidator_IsNull_WithNullValueReturnsCorrectly()
		{
			string name = "Name";
			object value = null;

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.IsNull();

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_IsNull_WithNonNullValueThrowsArgumentException()
		{
			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNull() );

			Assert.Equal( $"Value must be null.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void ParameterValidator_IsNull_WithNonNullValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNull( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
