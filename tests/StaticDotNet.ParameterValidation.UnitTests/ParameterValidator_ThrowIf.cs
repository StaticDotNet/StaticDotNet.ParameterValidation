using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class ParameterValidator_ThrowIf
    {
		[Fact]
		public void ParameterValidator_ThrowIf_WithConditionExpressionFalseReturnsCorrectly()
		{
			string name = "Name";
			object value = new object();

			Func<object, bool> conditionExpression = x => false;
			string exceptionMessage = "ExceptionMessage";

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.ThrowIf( conditionExpression, exceptionMessage );

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_ThrowIf_WithConditionExpressionTrueThrowsArgumentException()
		{
			string name = "Name";
			object value = new object();

			Func<object, bool> conditionExpression = x => true;
			string exceptionMessage = "ExceptionMessage";

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.ThrowIf( conditionExpression, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: {name}", exception.Message );
		}

		[Fact]
		public void ParameterValidator_ThrowIf_WithNullConditionExpressionReturnsCorrectly()
		{
			string name = "Name";
			object value = new object();

			Func<object, bool> conditionExpression = null;
			string exceptionMessage = "ExceptionMessage";

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.ThrowIf( conditionExpression, exceptionMessage );

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_ThrowIf_WithConditionFalseReturnsCorrectly()
		{
			string name = "Name";
			object value = new object();

			bool condition = false;
			string exceptionMessage = "ExceptionMessage";

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.ThrowIf( condition, exceptionMessage );

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_ThrowIf_WithConditionTrueThrowsArgumentException()
		{
			string name = "Name";
			object value = new object();

			bool condition = true;
			string exceptionMessage = "ExceptionMessage";

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.ThrowIf( condition, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: {name}", exception.Message );
		}
	}
}
