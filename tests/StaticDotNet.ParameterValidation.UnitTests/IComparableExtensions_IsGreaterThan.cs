using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IComparableExtensions_IsGreaterThan
    {
		[Fact]
		public void IComparableExtensions_IsGreaterThan_WithParameterValueGreaterThanValueReturnsCorrectly()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsGreaterThan( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThan_WithParameterValueEqualToValueThrowsArgumentException()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThan( value ) );

			Assert.Equal( $"Value must be greater than '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThan_WithParameterValueLessThanValueThrowsArgumentException()
		{
			int value = 1;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThan( value ) );

			Assert.Equal( $"Value must be greater than '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThan_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			int value = 1;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThan( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanWithNullableTParameter_WithParameterValueGreaterThanValueReturnsCorrectly()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsGreaterThan( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanWithNullableTParameter_WithNullParameterValueReturnsCorrectly()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int? parameterValue = null;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsGreaterThan( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanWithNullableTParameter_WithParameterValueEqualToValueThrowsArgumentException()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThan( value ) );

			Assert.Equal( $"Value must be greater than '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanWithNullableTParameter_WithParameterValueLessThanValueThrowsArgumentException()
		{
			int value = 1;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThan( value ) );

			Assert.Equal( $"Value must be greater than '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsGreaterThanWithNullableTParameter_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			int value = 1;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsGreaterThan( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
