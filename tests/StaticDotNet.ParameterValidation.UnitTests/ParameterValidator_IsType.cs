using StaticDotNet.ParameterValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class ParameterValidator_IsType
    {
		[Fact]
		public void ParameterValidator_IsType_WithParameterValueIsTypeReturnsCorrectly()
		{
			Type type = typeof( IEnumerable );

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsType( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_IsType_WithNullParameterValueReturnsCorrectly()
		{
			Type type = typeof( IEnumerable );

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsType( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_IsType_WithNullTypeReturnsCorrectly()
		{
			Type type = null;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsType( type );

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_IsType_WithParameterValueIsNotTypeThrowsArugmentException()
		{
			Type type = typeof( IEnumerable );

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsType( type ) );

			Assert.Equal( $"Value must be type '{ type.FullName }'.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void ParameterValidator_IsType_WithInvalidParameterValueAndExceptionMessageThrowsArugmentException()
		{
			Type type = typeof( IEnumerable );
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsType( type, exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void ParameterValidator_IsTypeWithTType_WithParameterValueIsTTypeReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsType<IEnumerable>();

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_IsTypeWithTType_WithNullParameterValueReturnsCorrectly()
		{
			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsType<IEnumerable>();

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_IsTypeWithTType_WithParameterValueIsNotTTypeThrowsArgumentException()
		{
			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsType<IEnumerable>() );

			Assert.Equal( $"Value must be type '{ typeof( IEnumerable ).FullName }'.\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void ParameterValidator_IsTypeWithTType_WithInvalidParameterValueAndExceptionMessageThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsType<IEnumerable>( exceptionMessage ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );
		}

		[Fact]
		public void ParameterValidator_IsTypeWithTType_WithParameterValueIsTTypeAndOutInstanceReturnsCorrectly()
		{
			IEnumerable instance;

			string name = "Name";
			string value = "Value";

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsType<IEnumerable>( out instance );

			Assert.Same( validator, result );
			Assert.NotNull( instance );
			Assert.Same( validator.Value, instance );
		}

		[Fact]
		public void ParameterValidator_IsTypeWithTType_WithNullParameterValueAndOutInstanceReturnsCorrectly()
		{
			IEnumerable instance;

			string name = "Name";
			string value = null;

			ParameterValidator<string> validator = new ParameterValidator<string>( name, value );

			ParameterValidator<string> result = validator.IsType<IEnumerable>( out instance );

			Assert.Same( validator, result );
			Assert.Null( instance );
		}

		[Fact]
		public void ParameterValidator_IsTypeWithTType_WithParameterValueIsNotTTypeAndOutInstanceThrowsArgumentException()
		{
			IEnumerable instance = null;

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsType<IEnumerable>( out instance ) );

			Assert.Equal( $"Value must be type '{ typeof( IEnumerable ).FullName }'.\r\nParameter name: { name }", exception.Message );

			Assert.Null( instance );
		}

		[Fact]
		public void ParameterValidator_IsTypeWithTType_WithInvalidParameterValueExceptionMessageAndOutInstanceThrowsArgumentException()
		{
			string exceptionMessage = "ExceptionMessage";
			IEnumerable instance = null;

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ArgumentException exception = Assert.Throws<ArgumentException>( name, () => validator.IsType<IEnumerable>( exceptionMessage, out instance ) );

			Assert.Equal( $"{ exceptionMessage }\r\nParameter name: { name }", exception.Message );

			Assert.Null( instance );
		}
	}
}
