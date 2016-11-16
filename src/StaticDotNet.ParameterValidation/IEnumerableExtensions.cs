using StaticDotNet.ParameterValidation.Extensions;
using StaticDotNet.ParameterValidation.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation
{
	/// <summary>
	/// Adds parameter validation for <see cref="IEnumerable" /> and <see cref="IEnumerable{T}" />.
	/// </summary>
	public static class IEnumerableExtensions
    {
		/// <summary>
		/// Validates that the parameter is not empty. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when the parameter is empty.</exception>
		public static ParameterValidator<TParameter> IsNotEmpty<TParameter>( this ParameterValidator<TParameter> validator )
			where TParameter : IEnumerable
		{
			return validator.IsNotEmpty( ExceptionMessages.VALUE_CANNOT_BE_EMPTY );
		}

		/// <summary>
		/// Validates that the parameter is not empty. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty.</exception>
		public static ParameterValidator<TParameter> IsNotEmpty<TParameter>( this ParameterValidator<TParameter> validator, string exceptionMessage )
			where TParameter : IEnumerable
		{
			if( validator.Value != null && validator.Value.IsEmpty() )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is empty. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when the parameter is not empty.</exception>
		public static ParameterValidator<TParameter> IsEmpty<TParameter>( this ParameterValidator<TParameter> validator )
			where TParameter : IEnumerable
		{
			return validator.IsEmpty( ExceptionMessages.VALUE_MUST_BE_EMPTY );
		}

		/// <summary>
		/// Validates that the parameter is empty. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not empty.</exception>
		public static ParameterValidator<TParameter> IsEmpty<TParameter>( this ParameterValidator<TParameter> validator, string exceptionMessage )
			where TParameter : IEnumerable
		{
			if( validator.Value != null && !validator.Value.IsEmpty() )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is not null or empty. Otherwise, an <see cref="ArgumentNullException" /> or <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty.</exception>
		public static ParameterValidator<TParameter> IsNotNullOrEmpty<TParameter>( this ParameterValidator<TParameter> validator )
			where TParameter : IEnumerable
		{
			return validator.IsNotNullOrEmpty( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY );
		}

		/// <summary>
		/// Validates that the parameter is not null or empty. Otherwise, an <see cref="ArgumentNullException" /> or <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty.</exception>
		public static ParameterValidator<TParameter> IsNotNullOrEmpty<TParameter>( this ParameterValidator<TParameter> validator, string exceptionMessage )
			where TParameter : IEnumerable
		{
			return validator.IsNotNull( exceptionMessage )
				.IsNotEmpty( exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter contains <paramref name="value" />. Otherwise an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <typeparam name="TValue">The type the parameter value contains.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must contain.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Occurs when the parameter does not contain <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> Contains<TParameter, TValue>( this ParameterValidator<TParameter> validator, TValue value )
			where TParameter : IEnumerable<TValue>
		{
			if( value != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_CONTAIN, value.ToString() );

				return validator.Contains( value, exceptionMessage );
			}

			return validator;	
		}

		/// <summary>
		/// Validates that the parameter contains <paramref name="value" />. Otherwise an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <typeparam name="TValue">The type the parameter value contains.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must contain.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Occurs when the parameter does not contain <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> Contains<TParameter, TValue>( this ParameterValidator<TParameter> validator, TValue value, string exceptionMessage )
			where TParameter : IEnumerable<TValue>
		{
			if( validator.Value != null & value != null && !validator.Value.Contains( value ) )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}
    }
}
