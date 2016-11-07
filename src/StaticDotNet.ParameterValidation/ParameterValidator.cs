using StaticDotNet.ParameterValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation
{
	/// <summary>
	/// Used to validate parameters.
	/// </summary>
	/// <typeparam name="TParameter">The type of the parameter.</typeparam>
    public class ParameterValidator<TParameter>
    {
		/// <summary>
		/// Instantiates a new instance of <see cref="ParameterValidator{TParameter}" />.
		/// </summary>
		/// <param name="name">The name of the parameter to validate.</param>
		/// <param name="value">The value of the parameter to validate.</param>
		public ParameterValidator( string name, TParameter value )
		{
			this.Name = name;
			this.Value = value;
		}

		/// <summary>
		/// Returns the name of the parameter.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Returns the value of the parameter.
		/// </summary>
		public TParameter Value { get; }

		/// <summary>
		/// Validates that the <see cref="Value" /> is not null. Otherwise, an <see cref="System.ArgumentNullException" /> is thrown.
		/// </summary>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when <see cref="Value" /> is null.</exception>
		public ParameterValidator<TParameter> IsNotNull()
		{
			return this.IsNotNull( ExceptionMessages.VALUE_CANNOT_BE_NULL );
		}

		/// <summary>
		/// Validates that the <see cref="Value" /> is not null. Otherwise, an <see cref="System.ArgumentNullException" /> is thrown
		/// with the <paramref name="exceptionMessage" /> as the exception message.
		/// </summary>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when <see cref="Value" /> is null.</exception>
		public ParameterValidator<TParameter> IsNotNull( string exceptionMessage )
		{
			if( this.Value == null )
			{
				throw new ArgumentNullException( this.Name, exceptionMessage );
			}

			return this;
		}

		/// <summary>
		/// Validates that the <see cref="Value" /> is null. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when <see cref="Value" /> is not null.</exception>
		public ParameterValidator<TParameter> IsNull()
		{
			return this.IsNull( ExceptionMessages.VALUE_MUST_BE_NULL );
		}

		/// <summary>
		/// Validates that the <see cref="Value" /> is null. Otherwise, an <see cref="System.ArgumentException" /> is thrown
		/// with the <paramref name="exceptionMessage" /> as the exception message.
		/// </summary>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when <see cref="Value" /> is not null.</exception>
		public ParameterValidator<TParameter> IsNull( string exceptionMessage )
		{
			if( this.Value != null )
			{
				throw new ArgumentException( exceptionMessage, this.Name );
			}

			return this;
		}

		/// <summary>
		/// Adds additional validation based on the <paramref name="conditionExpression" /> returning true.
		/// </summary>
		/// <param name="conditionExpression">The expression to evaluate.</param>
		/// <param name="trueExpression">The validation to run if the <paramref name="conditionExpression" /> returns true.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		public ParameterValidator<TParameter> When( Func<TParameter, bool> conditionExpression, Action<ParameterValidator<TParameter>> trueExpression )
		{
			return this.When( conditionExpression, trueExpression, null );
		}

		/// <summary>
		/// Adds additional validation based on the <paramref name="conditionExpression" /> returning true or false.
		/// </summary>
		/// <param name="conditionExpression">The expression to evaluate.</param>
		/// <param name="trueExpression">The validation to run if the <paramref name="conditionExpression" /> returns true.</param>
		/// <param name="falseExpression">The validation to run if the <paramref name="conditionExpression" /> returns false.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		public ParameterValidator<TParameter> When( Func<TParameter, bool> conditionExpression, Action<ParameterValidator<TParameter>> trueExpression, Action<ParameterValidator<TParameter>> falseExpression )
		{
			if( conditionExpression != null )
			{
				return this.When( conditionExpression( this.Value ), trueExpression, falseExpression );
			}

			return this;
		}

		/// <summary>
		/// Adds additional validation based on the <paramref name="condition" /> returning true.
		/// </summary>
		/// <param name="condition">The condition.</param>
		/// <param name="trueExpression">The validation to run if the <paramref name="conditionExpression" /> returns true.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		public ParameterValidator<TParameter> When( bool condition, Action<ParameterValidator<TParameter>> trueExpression )
		{
			return this.When( condition, trueExpression, null );
		}

		/// <summary>
		/// Adds additional validation based on the <paramref name="condition" /> returning true or false.
		/// </summary>
		/// <param name="condition">The condition.</param>
		/// <param name="trueExpression">The validation to run if the <paramref name="conditionExpression" /> returns true.</param>
		/// <param name="falseExpression">The validation to run if the <paramref name="conditionExpression" /> returns false.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		public ParameterValidator<TParameter> When( bool condition, Action<ParameterValidator<TParameter>> trueExpression, Action<ParameterValidator<TParameter>> falseExpression )
		{
			if( condition )
			{
				trueExpression?.Invoke( this );
			}
			else
			{
				falseExpression?.Invoke( this );
			}

			return this;
		}
	}
}
