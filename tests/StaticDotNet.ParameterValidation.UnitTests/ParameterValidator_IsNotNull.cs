using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
	public class ParameterValidator_IsNotNull
	{
		[Fact]
		public void ParameterValidator_IsNotNull_WithNonNullValueReturnsCorrectly()
		{
			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.IsNotNull();

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_IsNotNull_WithNullValueThrowsArgumentNullException()
		{
			string name = "Name";
			object value = null;

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentNullException exception = Assert.Throws<ArgumentNullException>( name, () => validator.IsNotNull() );

			Assert.Equal( $"Value cannot be null.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void ParameterValidator_IsNotNull_WithNullValueAndExceptionMessageThrowsArgumentNullException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			object value = null;

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentNullException exception = Assert.Throws<ArgumentNullException>( name, () => validator.IsNotNull( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
