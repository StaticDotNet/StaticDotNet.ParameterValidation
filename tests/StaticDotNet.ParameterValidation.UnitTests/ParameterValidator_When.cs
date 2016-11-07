using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StaticDotNet.ParameterValidation.UnitTests
{
    public class ParameterValidator_When
    {
		[Fact]
		public void ParameterValidator_When_WithConditionExpressionTrueInvokesTrueExpressionAndReturnsCorrectly()
		{
			bool wasTrueExpressionInvoked = false;

			Func<object, bool> conditionExpression = x => true;
			Action<ParameterValidator<object>> trueExpression = x => wasTrueExpressionInvoked = true;

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.When( conditionExpression, trueExpression );

			Assert.Same( validator, result );
			Assert.True( wasTrueExpressionInvoked );
		}

		[Fact]
		public void ParameterValidator_When_WithConditionExpressionFalseInvokesFalseExpressionAndReturnsCorrectly()
		{
			bool wasTrueExpressionInvoked = false;
			bool wasFalseExpressionInvoked = false;

			Func<object, bool> conditionExpression = x => false;
			Action<ParameterValidator<object>> trueExpression = x => wasTrueExpressionInvoked = true;
			Action<ParameterValidator<object>> falseExpression = x => wasFalseExpressionInvoked = true;

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.When( conditionExpression, trueExpression, falseExpression );

			Assert.Same( validator, result );
			Assert.False( wasTrueExpressionInvoked );
			Assert.True( wasFalseExpressionInvoked );
		}

		[Fact]
		public void ParameterValidator_When_WithConditionTrueInvokesTrueExpressionAndReturnsCorrectly()
		{
			bool wasTrueExpressionInvoked = false;

			bool condition = true;
			Action<ParameterValidator<object>> trueExpression = x => wasTrueExpressionInvoked = true;

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.When( condition, trueExpression );

			Assert.Same( validator, result );
			Assert.True( wasTrueExpressionInvoked );
		}

		[Fact]
		public void ParameterValidator_When_WithConditionFalseInvokesFalseExpressionAndReturnsCorrectly()
		{
			bool wasTrueExpressionInvoked = false;
			bool wasFalseExpressionInvoked = false;

			bool condition = false;
			Action<ParameterValidator<object>> trueExpression = x => wasTrueExpressionInvoked = true;
			Action<ParameterValidator<object>> falseExpression = x => wasFalseExpressionInvoked = true;

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.When( condition, trueExpression, falseExpression );

			Assert.Same( validator, result );
			Assert.False( wasTrueExpressionInvoked );
			Assert.True( wasFalseExpressionInvoked );
		}

		[Fact]
		public void ParameterValidator_When_WithNullConditionExpressionReturnsCorrectly()
		{
			bool wasTrueExpressionInvoked = false;
			bool wasFalseExpressionInvoked = false;

			Func<object, bool> conditionExpression = null;
			Action<ParameterValidator<object>> trueExpression = x => wasTrueExpressionInvoked = true;
			Action<ParameterValidator<object>> falseExpression = x => wasFalseExpressionInvoked = true;

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.When( conditionExpression, trueExpression, falseExpression );

			Assert.Same( validator, result );
			Assert.False( wasTrueExpressionInvoked );
			Assert.False( wasFalseExpressionInvoked );
		}

		[Fact]
		public void ParameterValidator_When_WithNullTrueExpressionReturnsCorrectly()
		{
			bool condition = true;
			Action<ParameterValidator<object>> trueExpression = null;
			Action<ParameterValidator<object>> falseExpression = x => { };

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.When( condition, trueExpression, falseExpression );

			Assert.Same( validator, result );
		}

		[Fact]
		public void ParameterValidator_When_WithNullFalseExpressionReturnsCorrectly()
		{
			bool condition = false;
			Action<ParameterValidator<object>> trueExpression = x => { };
			Action<ParameterValidator<object>> falseExpression = null;

			string name = "Name";
			object value = new object();

			ParameterValidator<object> validator = new ParameterValidator<object>( name, value );

			ParameterValidator<object> result = validator.When( condition, trueExpression, falseExpression );

			Assert.Same( validator, result );
		}
	}
}
