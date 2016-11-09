using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IComparableExtensions_IsGreaterThanOrEqualTo
    {
		[Fact]
		public void IComparableExtensions_IsGreaterThanOrEqualTo_WithParameterValueGreaterThanValueReturnsCorrectly()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsGreaterThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanOrEqualTo_WithParameterValueEqualToValueReturnsCorrectly()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsGreaterThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanOrEqualTo_WithParameterValueLessThanValueThrowsArgumentException()
		{
			int value = 1;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThanOrEqualTo( value ) );

			Assert.Equal( $"Value must be greater than or equal to '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanOrEqualTo_WithInvalidParameterValueAndExecptionMessageThrowsArgumentException()
		{
			int value = 1;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThanOrEqualTo( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanOrEqualToWithNullableTParameter_WithParameterValueGreaterThanValueReturnsCorrectly()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsGreaterThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanOrEqualToWithNullableTParameter_WithParameterValueEqualToValueReturnsCorrectly()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsGreaterThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanOrEqualToWithNullableTParameter_WithNullParameterValueReturnsCorrectly()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int? parameterValue = null;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsGreaterThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanOrEqualToWithNullableTParameter_WithParameterValueLessThanValueThrowsArgumentException()
		{
			int value = 1;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThanOrEqualTo( value ) );

			Assert.Equal( $"Value must be greater than or equal to '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanOrEqualToWithNullableTParameter_WithInvalidParameterValueAndExecptionMessageThrowsArgumentException()
		{
			int value = 1;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThanOrEqualTo( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
