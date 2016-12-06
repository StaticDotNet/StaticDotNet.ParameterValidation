using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IEnumerableExtensions_IsNotEmpty
    {
		[Fact]
		public void IEnumerableExtensions_IsNotEmpty_WithValueReturnsCorrectly()
		{
			string name = "Name";
			int[] value = new int[] { 1 };

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ParameterValidator<int[]> result = validator.IsNotEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_IsNotEmpty_WithNullValueReturnsCorrectly()
		{
			string name = "Name";
			int[] value = null;

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ParameterValidator<int[]> result = validator.IsNotEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_IsNotEmpty_WithEmptyValueThrowsArgumentException()
		{
			string name = "Name";
			int[] value = new int[] { };

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotEmpty() );

			Assert.Equal( $"Value cannot be empty.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void IEnumerableExtensions_IsNotEmpty_WithEmptyValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			int[] value = new int[] { };

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotEmpty( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
