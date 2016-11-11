using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class TypeExtensions_IsEqualTo
    {
		[Fact]
		public void TypeExtensions_IsEqualToWithTType_WithParameterValueEqualToTTypeReturnsCorrectly()
		{
			string parameterName = "ParameterName";
			Type parameterValue = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( parameterName, parameterValue );

			ParameterValidator<Type> result = validator.IsEqualTo<string>();

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsEqualToWithTType_WithParameterValueNotEqualToTTypeThrowsArgumentException()
		{
			string parameterName = "ParameterName";
			Type parameterValue = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsEqualTo<object>() );

			Assert.Equal( $"Value must be equal to '{ typeof( object ).FullName }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsEqualToWithTType_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			Type parameterValue = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsEqualTo<object>( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsEqualTo_WithParameterValueEqualToValueReturnsCorrectly()
		{
			Type value = typeof( string );

			string parameterName = "ParameterName";
			Type parameterValue = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( parameterName, parameterValue );

			ParameterValidator<Type> result = validator.IsEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsEqualTo_WithNullParameterValueReturnsCorrectly()
		{
			Type value = typeof( string );

			string parameterName = "ParameterName";
			Type parameterValue = null;

			ParameterValidator<Type> validator = new ParameterValidator<Type>( parameterName, parameterValue );

			ParameterValidator<Type> result = validator.IsEqualTo( value );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsEqualTo_WithParameterValueNotEqualToValueThrowsArgumentException()
		{
			Type value = typeof( object );

			string parameterName = "ParameterName";
			Type parameterValue = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsEqualTo( value ) );

			Assert.Equal( $"Value must be equal to '{ value.FullName }'.\r\nParameter name: { parameterName }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsEqualTo_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			Type value = typeof( object );
			string exceptionMessage = "ExceptionMessage";

			string parameterName = "ParameterName";
			Type parameterValue = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( parameterName, parameterValue );

			ArgumentException exception = Assert.Throws<ArgumentException>( parameterName, () => validator.IsEqualTo( value, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { parameterName }", exception.Message );
		}
	}
}
