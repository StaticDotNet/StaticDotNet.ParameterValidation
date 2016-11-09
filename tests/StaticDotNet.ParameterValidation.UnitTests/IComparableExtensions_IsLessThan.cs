using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IComparableExtensions_IsLessThan
    {
		[Fact]
		public void IComparableExtensions_IsLessThan_WithParameterValueLessThanValueReturnsCorrectly()
		{
			int value = 1;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsLessThan( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsLessThan_WithParameterValueEqualToValueThrowsArgumentException()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsLessThan( value ) );

			Assert.Equal( $"Value must be less than '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsLessThan_WithParameterValueGreaterThanValueThrowsArgumentException()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsLessThan( value ) );

			Assert.Equal( $"Value must be less than '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsLessThan_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			int value = -1;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsLessThan( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}





		[Fact]
		public void IComparableExtensions_IsLessThanWithNullableTParameter_WithParameterValueLessThanValueReturnsCorrectly()
		{
			int value = 1;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsLessThan( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanWithNullableTParameter_WithNullParameterValueReturnsCorrectly()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int? parameterValue = null;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsLessThan( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanWithNullableTParameter_WithParameterValueEqualToValueThrowsArgumentException()
		{
			int value = 0;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsLessThan( value ) );

			Assert.Equal( $"Value must be less than '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanWithNullableTParameter_WithParameterValueGreaterThanValueThrowsArgumentException()
		{
			int value = -1;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsLessThan( value ) );

			Assert.Equal( $"Value must be less than '{ value }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsLessThanWithNullableTParameter_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			int value = -1;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsLessThan( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
