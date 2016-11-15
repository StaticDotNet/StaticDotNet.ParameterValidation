using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class TypeExtensions_IsClass
    {
		[Fact]
		public void TypeExtensions_IsClass_WithParameterValueIsClassReturnsCorrectly()
		{
			string name = "Name";
			Type value = typeof( object );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsClass();

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsClass_WithNullParameterValueReturnsCorrectly()
		{
			string name = "Name";
			Type value = null;

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsClass();

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsClass_WithParameterValueIsNotClassThrowsArgumentException()
		{
			string name = "Name";
			Type value = typeof( IEnumerable );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsClass() );

			Assert.Equal( $"Value must be a class.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsClass_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			Type value = typeof( IEnumerable );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsClass( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
