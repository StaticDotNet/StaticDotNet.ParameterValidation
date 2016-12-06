using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class IEnumerableExtensions_IsNotNullOrEmpty
    {
		[Fact]
		public void IEnumerableExtensions_IsNotNullOrEmpty_WithValueReturnsCorrectly()
		{
			string name = "Name";
			int[] value = new int[] { 1 };

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ParameterValidator<int[]> result = validator.IsNotNullOrEmpty();

			Assert.Same( validator, result );
		}

		[Fact]
		public void IEnumerableExtensions_IsNotNullOrEmpty_WithNullValueThrowsArgumentNullException()
		{
			string name = "Name";
			int[] value = null;

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ArgumentNullException exception = Assert.Throws<ArgumentNullException>( name, () => validator.IsNotNullOrEmpty() );

			Assert.Equal( $"Value cannot be null or empty.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void IEnumerableExtensions_IsNotNullOrEmpty_WithEmptyValueThrowsArgumentException()
		{
			string name = "Name";
			int[] value = new int[] { };

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotNullOrEmpty() );

			Assert.Equal( $"Value cannot be null or empty.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void IEnumerableExtensions_IsNotNullOrEmpty_WithInvalidValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			int[] value = new int[] { };

			ParameterValidator<int[]> validator = new ParameterValidator<int[]>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsNotNullOrEmpty( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
