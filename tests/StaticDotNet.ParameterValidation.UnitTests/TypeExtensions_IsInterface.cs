using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class TypeExtensions_IsInterface
    {
		[Fact]
		public void TypeExtensions_IsInterface_WithParameterValueIsInterfaceReturnsCorrectly()
		{
			string name = "Name";
			Type value = typeof( IEnumerable );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsInterface();

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsInterface_WithNullParameterValueReturnsCorrectly()
		{
			string name = "Name";
			Type value = null;

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ParameterValidator<Type> result = validator.IsInterface();

			Assert.Same( validator, result );
		}

		[Fact]
		public void TypeExtensions_IsInterface_WithParameterValueIsNotInterfaceThrowsArgumentException()
		{
			string name = "Name";
			Type value = typeof( object );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsInterface() );

			Assert.Equal( $"Value must be an interface.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void TypeExtensions_IsInterface_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			Type value = typeof( object );

			ParameterValidator<Type> validator = new ParameterValidator<Type>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsInterface( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}
	}
}
