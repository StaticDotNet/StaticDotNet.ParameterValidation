using StaticDotNet.ParameterValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation
{
    public static class StringExtensions
    {
		/// <summary>
		/// Validates that the parameter is not empty. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when the parameter is empty.</exception>
		public static ParameterValidator<string> IsNotEmpty( this ParameterValidator<string> validator )
		{
			return validator.IsNotEmpty( ExceptionMessages.VALUE_CANNOT_BE_EMPTY );
		}

		/// <summary>
		/// Validates that the parameter is not empty. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when the parameter is empty.</exception>
		public static ParameterValidator<string> IsNotEmpty( this ParameterValidator<string> validator, string exceptionMessage )
		{
			if( validator.Value != null && validator.Value.Length == 0 )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is not empty or white space. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when the parameter is empty or white space.</exception>
		public static ParameterValidator<string> IsNotWhiteSpace( this ParameterValidator<string> validator )
		{
			return validator.IsNotWhiteSpace( ExceptionMessages.VALUE_CANNOT_BE_EMPTY_OR_WHITE_SPACE );
		}

		/// <summary>
		/// Validates that the parameter is not empty or white space. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when the parameter is empty or white space.</exception>
		public static ParameterValidator<string> IsNotWhiteSpace( this ParameterValidator<string> validator, string exceptionMessage )
		{
			if( validator.Value != null && string.IsNullOrWhiteSpace( validator.Value ) )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is not null or empty. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when the parameter is null or empty.</exception>
		public static ParameterValidator<string> IsNotNullOrEmpty( this ParameterValidator<string> validator )
		{
			return validator.IsNotNullOrEmpty( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY );
		}

		/// <summary>
		/// Validates that the parameter is not null or empty. Otherwise, an <see cref="System.ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when the parameter is null or empty.</exception>
		public static ParameterValidator<string> IsNotNullOrEmpty( this ParameterValidator<string> validator, string exceptionMessage )
		{
			validator.IsNotNull( exceptionMessage )
				.IsNotEmpty( exceptionMessage );

			return validator;
		}
    }
}
