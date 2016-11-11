using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class TypeExtensions_IsAssignableTo
    {
		[Fact]
		public void TypeExtensions_IsAssignableTo_WithParameterValueAssignableToTypeReturnsCorrectly()
		{
			Type type = typeof( object );

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsAssignableTo( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableTo_WithNullParameterValueReturnsCorrectly()
		{
			Type type = typeof( object );

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsAssignableTo( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableTo_WithNullTypeReturnsCorrectly()
		{
			Type type = null;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsAssignableTo( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableTo_WithParameterValueNotAssignableToTypeThrowsArgumentException()
		{
			Type type = typeof( string );

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsAssignableTo( type ) );

			Assert.Equal( $"Value must be assignable to '{ type.FullName }'.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsAssignableTo_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			Type type = typeof( string );
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsAssignableTo( type, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsAssignableToWithTypeParameter_WithParameterValueAssignableToTypeReturnsCorrectly()
		{
			Type type = typeof( object );

			string name = "Name";
			Type value = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsAssignableTo( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableToWithTypeParameter_WithNullParameterValueReturnsCorrectly()
		{
			Type type = typeof( object );

			string name = "Name";
			Type value = null;

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsAssignableTo( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableToWithTypeParameter_WithNullTypeReturnsCorrectly()
		{
			Type type = null;

			string name = "Name";
			Type value = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsAssignableTo( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableToWithTypeParameter_WithParameterValueNotAssignableToTypeThrowsArgumentException()
		{
			Type type = typeof( string );

			string name = "Name";
			Type value = typeof( object );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsAssignableTo( type ) );

			Assert.Equal( $"Value must be assignable to '{ type.FullName }'.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsAssignableToWithTypeParameter_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			Type type = typeof( string );
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			Type value = typeof( object );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsAssignableTo( type, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
