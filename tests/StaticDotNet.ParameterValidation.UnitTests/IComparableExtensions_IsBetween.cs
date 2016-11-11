using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IComparableExtensions_IsBetween
    {
		[Fact]
		public void IComparableExtensions_IsBetween_WithParameterValueEqualToMinValueReturnsCorrectly()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int parameterValue = 1;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsBetween( minValue, maxValue );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsBetween_WithParameterValueGreaterThanMinValueAndLessThanMaxValueReturnsCorrectly()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int parameterValue = 2;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsBetween( minValue, maxValue );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsBetween_WithParameterValueEqualToMaxValueReturnsCorrectly()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int parameterValue = 3;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ParameterValidator<int> result = validator.IsBetween( minValue, maxValue );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsBetween_WithParameterValueLessThanMinValueThrowsArgumentOutOfRangeException()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int parameterValue = 0;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsBetween( minValue, maxValue ) );

			Assert.Equal( $"Value must be between '{ minValue }' and '{ maxValue }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsBetween_WithParameterValueGreaterThanMaxValueThrowsArgumentOutOfRangeException()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int parameterValue = 4;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsBetween( minValue, maxValue ) );

			Assert.Equal( $"Value must be between '{ minValue }' and '{ maxValue }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsBetween_WithInvalidParameterValueAndExceptionMessageThrowsArgumentOutOfRangeException()
		{
			int minValue = 1;
			int maxValue = 3;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int parameterValue = 4;

			ParameterValidator<int> validator = new ParameterValidator<int>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsBetween( minValue, maxValue, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsBetweenWithNullableTParameter_WithParameterValueEqualToMinValueReturnsCorrectly()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int? parameterValue = 1;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsBetween( minValue, maxValue );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsBetweenWithNullableTParameter_WithParameterValueGreaterThanMinValueAndLessThanMaxValueReturnsCorrectly()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int? parameterValue = 2;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsBetween( minValue, maxValue );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsBetweenWithNullableTParameter_WithParameterValueEqualToMaxValueReturnsCorrectly()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int? parameterValue = 3;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsBetween( minValue, maxValue );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsBetweenWithNullableTParameter_WithNullParameterValueReturnsCorrectly()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int? parameterValue = null;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ParameterValidator<int?> result = validator.IsBetween( minValue, maxValue );

			Assert.Same( validator, result );
		}

		[Fact]
		public void IComparableExtensions_IsBetweenWithNullableTParameter_WithParameterValueLessThanMinValueThrowsArgumentOutOfRangeException()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int? parameterValue = 0;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsBetween( minValue, maxValue ) );

			Assert.Equal( $"Value must be between '{ minValue }' and '{ maxValue }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsBetweenWithNullableTParameter_WithParameterValueGreaterThanMaxValueThrowsArgumentOutOfRangeException()
		{
			int minValue = 1;
			int maxValue = 3;

			string parameterName = "ParameterName";
			int? parameterValue = 4;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsBetween( minValue, maxValue ) );

			Assert.Equal( $"Value must be between '{ minValue }' and '{ maxValue }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void IComparableExtensions_IsBetweenWithNullableTParameter_WithInvalidParameterValueAndExceptionMessageThrowsArgumentOutOfRangeException()
		{
			int minValue = 1;
			int maxValue = 3;
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			int? parameterValue = 4;

			ParameterValidator<int?> validator = new ParameterValidator<int?>( parameterName, parameterValue );

			ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>( parameterName, () => validator.IsBetween( minValue, maxValue, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
