using System;
using System.Collections;
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
			Type type = typeof( IEnumerable );

			string name = "Name";
			Type value = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsAssignableTo( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableTo_WithNullParameterValueReturnsCorrectly()
		{
			Type type = typeof( IEnumerable );

			string name = "Name";
			Type value = null;

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsAssignableTo( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableTo_WithParameterAndNullTypeReturnsCorrectly()
		{
			Type type = null;

			string name = "Name";
			Type value = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsAssignableTo( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableTo_WithParameterValueNotAssignableToTypeThrowsArgumentException()
		{
			Type type = typeof( IEnumerable );

			string name = "Name";
			Type value = typeof( object );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsAssignableTo( type ) );

			Assert.Equal( $"Value must be assignable to '{ type.FullName }'.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsAssignableTo_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			Type type = typeof( IEnumerable );
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			Type value = typeof( object );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsAssignableTo( type, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsAssignableToWithTType_WithParameterValueAssignableToTTypeReturnsCorrectly()
		{
			string name = "Name";
			Type value = typeof( string );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsAssignableTo<IEnumerable>();

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableToWithTType_WithNullParameterValueReturnsCorrectly()
		{
			string name = "Name";
			Type value = null;

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsAssignableTo<IEnumerable>();

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsAssignableToWithTType_WithParameterValueNotAssignableToTTypeThrowsArgumentException()
		{
			string name = "Name";
			Type value = typeof( object );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsAssignableTo<IEnumerable>() );

			Assert.Equal( $"Value must be assignable to '{ typeof( IEnumerable ).FullName }'.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsAssignableToWithTType_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			Type value = typeof( object );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsAssignableTo<IEnumerable>( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
