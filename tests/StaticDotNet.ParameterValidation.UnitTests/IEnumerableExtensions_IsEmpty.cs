using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IEnumerableExtensions_IsEmpty
    {
		[Fact]
		public void IEnumerableExtensions_IsEmpty_WithEmptyValueReturnsCorrectly()
		{
			string name = "Name";
			int[] value = Array.Empty<int>(); ;

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ParameterValidator<int[]> result = validator.IsEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_IsEmpty_WithNullValueReturnsCorrectly()
		{
			string name = "Name";
			int[] value = null;

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ParameterValidator<int[]> result = validator.IsEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_IsEmpty_WithValueThrowsArgumentException()
		{
			string name = "Name";
			int[] value = new int[] { 1 };

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsEmpty() );

			Assert.Equal( $"Value must be empty.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void IEnumerableExtensions_IsEmpty_WithValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			int[] value = new int[] { 1 };

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsEmpty( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
