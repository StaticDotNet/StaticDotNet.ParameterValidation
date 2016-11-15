using StaticDotNet.ParameterValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
		/// Validates that the parameter is not null. Otherwise, an <see cref="System.ArgumentNullException" /> is thrown.
		/// </summary>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when parameter is null.</exception>
		public ParameterValidator<TParameter> IsNotNull()
		{
			return this.IsNotNull( ExceptionMessages.VALUE_CANNOT_BE_NULL );
		}

		/// <summary>
		/// Validates that the parameter is not null. Otherwise, an <see cref="System.ArgumentNullException" /> is thrown
		/// with the <paramref name="exceptionMessage" /> as the exception message.
		/// </summary>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when parameter is null.</exception>
		public ParameterValidator<TParameter> IsNotNull( string exceptionMessage )
		{
			if( this.Value == null )
			{
				throw new ArgumentNullException( this.Name, exceptionMessage );
			}

			return this;
		}

		/// <summary>
		/// Validates that the parameter is null. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not null.</exception>
		public ParameterValidator<TParameter> IsNull()
		{
			return this.IsNull( ExceptionMessages.VALUE_MUST_BE_NULL );
		}

		/// <summary>
		/// Validates that the parameter is null. Otherwise, an <see cref="System.ArgumentException" /> is thrown
		/// with the <paramref name="exceptionMessage" /> as the exception message.
		/// </summary>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when parameter is not null.</exception>
		public ParameterValidator<TParameter> IsNull( string exceptionMessage )
		{
			if( this.Value != null )
			{
				throw new ArgumentException( exceptionMessage, this.Name );
			}

			return this;
		}

		/// <summary>
		/// Validates that the parameter is equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="value">The value the parameter must be equal to.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not equal to <paramref name="value" />.</exception>
		public ParameterValidator<TParameter> IsEqualTo( TParameter value )
		{
			if( value != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_EQUAL_TO, value.ToString() );

				return this.IsEqualTo( value, exceptionMessage );
			}

			return this;
		}

		/// <summary>
		/// Validates that the parameter is equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="value">The value the parameter must be equal to.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not equal to <paramref name="value" />.</exception>
		public ParameterValidator<TParameter> IsEqualTo( TParameter value, string exceptionMessage )
		{
			if( this.Value != null && value != null && !this.Value.Equals( value ) )
			{
				throw new ArgumentException( exceptionMessage, this.Name );
			}

			return this;
		}

		/// <summary>
		/// Validates that the parameter is not equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="value">The value the parameter must not be equal to.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is equal to <paramref name="value" />.</exception>
		public ParameterValidator<TParameter> IsNotEqualTo( TParameter value )
		{
			if( value != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_NOT_BE_EQUAL_TO, value.ToString() );

				return this.IsNotEqualTo( value, exceptionMessage );
			}

			return this;
		}

		/// <summary>
		/// Validates that the parameter is not equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="value">The value the parameter must not be equal to.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is equal to <paramref name="value" />.</exception>
		public ParameterValidator<TParameter> IsNotEqualTo( TParameter value, string exceptionMessage )
		{
			if( this.Value != null && value != null && this.Value.Equals( value ) )
			{
				throw new ArgumentException( exceptionMessage, this.Name );
			}

			return this;
		}

		/// <summary>
		/// Validates that the parameter is type <typeparamref name="TType" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TType">The type the parameter should be.</typeparam>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not type <typeparamref name="TType" />.</exception>
		public ParameterValidator<TParameter> IsType<TType>()
		{
			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_TYPE, typeof( TType ).FullName );

			return this.IsType<TType>( exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter is type <typeparamref name="TType" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TType">The type the parameter should be.</typeparam>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not type <typeparamref name="TType" />.</exception>
		public ParameterValidator<TParameter> IsType<TType>( string exceptionMessage )
		{
			if( this.Value != null && !( this.Value is TType ) )
			{
				throw new ArgumentException( exceptionMessage, this.Name );
			}

			return this;
		}

		/// <summary>
		/// Validates that the parameter is type <typeparamref name="TType" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TType">The type the parameter should be.</typeparam>
		/// <param name="instance">The instance cast as <typeparamref name="TType" />. If the parameter value is null, the instance is null.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not type <typeparamref name="TType" />.</exception>
		public ParameterValidator<TParameter> IsType<TType>( out TType instance )
			where TType : class
		{
			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_TYPE, typeof( TType ).FullName );

			return this.IsType( exceptionMessage, out instance );
		}

		/// <summary>
		/// Validates that the parameter is type <typeparamref name="TType" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TType">The type the parameter should be.</typeparam>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <param name="instance">The instance cast as <typeparamref name="TType" />. If the parameter value is null, the instance is null.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not type <typeparamref name="TType" />.</exception>
		public ParameterValidator<TParameter> IsType<TType>( string exceptionMessage, out TType instance )
			where TType : class
		{
			instance = null;

			if( this.Value != null )
			{
				instance = this.Value as TType;
				if( instance == null )
				{
					throw new ArgumentException( exceptionMessage, this.Name );
				}
			}

			return this;
		}

		/// <summary>
		/// Validates that the parameter is type <paramref name="type" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="type">The type the parameter should be.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not type <paramref name="type" />.</exception>
		public ParameterValidator<TParameter> IsType( Type type )
		{
			if( type != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_TYPE, type.FullName );

				return this.IsType( type, exceptionMessage );
			}

			return this;
		}

		/// <summary>
		/// Validates that the parameter is type <paramref name="type" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="type">The type the parameter should be.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not type <paramref name="type" />.</exception>
		public ParameterValidator<TParameter> IsType( Type type, string exceptionMessage )
		{
			if( this.Value != null && type != null && !type.IsAssignableFrom( this.Value.GetType() ) )
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
		/// <param name="trueExpression">The validation to run if the <paramref name="condition" /> returns true.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		public ParameterValidator<TParameter> When( bool condition, Action<ParameterValidator<TParameter>> trueExpression )
		{
			return this.When( condition, trueExpression, null );
		}

		/// <summary>
		/// Adds additional validation based on the <paramref name="condition" /> returning true or false.
		/// </summary>
		/// <param name="condition">The condition.</param>
		/// <param name="trueExpression">The validation to run if the <paramref name="condition" /> returns true.</param>
		/// <param name="falseExpression">The validation to run if the <paramref name="condition" /> returns false.</param>
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

		/// <summary>
		/// Throws an <see cref="System.ArgumentException" /> if the <paramref name="conditionExpression" /> evaluates to true.
		/// </summary>
		/// <param name="conditionExpression">The expression to evaluate.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">If the <paramref name="conditionExpression" /> evalutes to true.</exception>
		public ParameterValidator<TParameter> ThrowIf( Func<TParameter, bool> conditionExpression, string exceptionMessage )
		{
			if( conditionExpression != null )
			{
				return this.ThrowIf( conditionExpression( this.Value ), exceptionMessage );
			}

			return this;
		}

		/// <summary>
		/// Throws an <see cref="System.ArgumentException" /> if the <paramref name="condition" /> evaluates to true.
		/// </summary>
		/// <param name="condition">The condition.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">If the <paramref name="condition" /> evalutes to true.</exception>
		public ParameterValidator<TParameter> ThrowIf( bool condition, string exceptionMessage )
		{
			if( condition )
			{
				throw new ArgumentException( exceptionMessage, this.Name );
			}

			return this;
		}
	}
}
