using StaticDotNet.ParameterValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation
{
	/// <summary>
	/// Adds parameter validation for <see cref="IComparable{T}"/>.
	/// </summary>
	public static class IComparableExtensions
	{
		/// <summary>
		/// Validates a parameter is equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must equal.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not equal <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsEqualTo<TParameter>( this ParameterValidator<TParameter> validator, TParameter value )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_EQUAL_TO, value.ToString() );

			return validator.IsEqualTo( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must equal.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not equal <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsEqualTo<TParameter>( this ParameterValidator<TParameter> validator, TParameter value, string exceptionMessage )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value != null && value != null && validator.Value.CompareTo( value ) != 0 )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates a parameter is equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must equal.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not equal <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsEqualTo<TParameter>( this ParameterValidator<TParameter?> validator, TParameter value )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_EQUAL_TO, value.ToString() );

			return validator.IsEqualTo( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must equal.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not equal <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsEqualTo<TParameter>( this ParameterValidator<TParameter?> validator, TParameter value, string exceptionMessage )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value != null && validator.Value.Value.CompareTo( value ) != 0 )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}
	}
}
