using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class Parameter_Validate
    {
		[Fact]
		public void Parameter_Validate_WithValueReturnsCorrectly()
		{
			object value = new object();

			ParameterValidator<object> result = Parameter.Validate( value );

			Assert.Same( value, result.Value );
			Assert.Null( result.Name );
		}

		[Fact]
		public void Parameter_Validate_WithValueAndNameReturnsCorrectly()
		{
			object value = new object();
			string name = "Name";

			ParameterValidator<object> result = Parameter.Validate( value, name );

			Assert.Same( value, result.Value );
			Assert.Equal( name, result.Name );
		}
	}
}
