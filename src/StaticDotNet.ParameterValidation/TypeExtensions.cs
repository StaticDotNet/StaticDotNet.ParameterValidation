using StaticDotNet.ParameterValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation
{
	/// <summary>
	/// Adds parameter validation for <see cref="Type"/>.
	/// </summary>
	public static class TypeExtensions
    {
		/// <summary>
		///  Validates that the parameter is equal to <typeparamref name="TType" />. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TType">The expected value.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not equal to <typeparamref name="TType" />.</exception>
		public static ParameterValidator<Type> IsEqualTo<TType>( this ParameterValidator<Type> validator )
		{
			return validator.IsEqualTo( typeof( TType ) );
		}

		/// <summary>
		///  Validates that the parameter is equal to <typeparamref name="TType" />. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TType">The expected value.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not equal to <typeparamref name="TType" />.</exception>
		public static ParameterValidator<Type> IsEqualTo<TType>( this ParameterValidator<Type> validator, string exceptionMessage )
		{
			return validator.IsEqualTo( typeof( TType ), exceptionMessage );
		}

		/// <summary>
		///  Validates that the parameter is equal to <paramref name="value" />. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The expected value.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not equal to <paramref name="value" />.</exception>
		public static ParameterValidator<Type> IsEqualTo( this ParameterValidator<Type> validator, Type value )
		{
			if( value != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_EQUAL_TO, value.FullName );

				return validator.IsEqualTo( value, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		///  Validates that the parameter is equal to <paramref name="value" />. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The expected value.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not equal to <paramref name="value" />.</exception>
		public static ParameterValidator<Type> IsEqualTo( this ParameterValidator<Type> validator, Type value, string exceptionMessage )
		{
			if( validator.Value != null && value != null && validator.Value != value )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}
    }
}
