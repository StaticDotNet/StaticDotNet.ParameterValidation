using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IComparableExtensions_IsLessThanOrEqualTo
    {
		[Fact]
		public void IComparableExtensions_IsLessThanOrEqualTo_WithParameterValueLessThanValueReturnsCorrectly()
		{
			int value = 1;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsLessThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanOrEqualTo_WithParameterValueEqualToValueReturnsCorrectly()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsLessThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanOrEqualTo_WithParameterValueGreaterThanValueThrowsArgumentOutOfRangeException()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsLessThanOrEqualTo( value ) );

			Assert.Equal( $"Value must be less than or equal to '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanOrEqualTo_WithInvalidParameterValueAndExceptionMessageThrowsArgumentOutOfRangeException()
		{
			int value = -1;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsLessThanOrEqualTo( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanOrEqualToWithNullableTParameter_WithParameterValueLessThanValueReturnsCorrectly()
		{
			int value = 1;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsLessThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanOrEqualToWithNullableTParameter_WithNullParameterValueReturnsCorrectly()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int? parameterValue = null;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsLessThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanOrEqualToWithNullableTParameter_WithParameterValueEqualToValueThrowsArgumentOutOfRangeException()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsLessThanOrEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanOrEqualToWithNullableTParameter_WithParameterValueGreaterThanValueThrowsArgumentOutOfRangeException()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsLessThanOrEqualTo( value ) );

			Assert.Equal( $"Value must be less than or equal to '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanOrEqualToWithNullableTParameter_WithInvalidParameterValueAndExceptionMessageThrowsArgumentOutOfRangeException()
		{
			int value = -1;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsLessThanOrEqualTo( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
