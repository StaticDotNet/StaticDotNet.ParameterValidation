﻿using StaticDotNet.ParameterValidation.Resources;
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
		/// Validates a parameter is greater than <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be greater than.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not greater than <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsGreaterThan<TParameter>( this ParameterValidator<TParameter> validator, TParameter value )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_GREATER_THAN, value.ToString() );

			return validator.IsGreaterThan( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is greater than <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be greater than.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not greater than <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsGreaterThan<TParameter>( this ParameterValidator<TParameter> validator, TParameter value, string exceptionMessage )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value != null && value != null && validator.Value.CompareTo( value ) <= 0 )
			{
				throw new ArgumentOutOfRangeException( validator.Name, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates a parameter is greater than <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be greater than.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not greater than <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsGreaterThan<TParameter>( this ParameterValidator<TParameter?> validator, TParameter? value )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_GREATER_THAN, value.ToString() );

			return validator.IsGreaterThan( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is greater than <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be greater than.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not greater than <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsGreaterThan<TParameter>( this ParameterValidator<TParameter?> validator, TParameter? value, string exceptionMessage )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value != null && value != null && validator.Value.Value.CompareTo( value.Value ) <= 0 )
			{
				throw new ArgumentOutOfRangeException( validator.Name, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates a parameter is greater than or equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be greater than or equal to.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not greater than or equal to <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsGreaterThanOrEqualTo<TParameter>( this ParameterValidator<TParameter> validator, TParameter value )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_GREATER_THAN_OR_EQUAL_TO, value.ToString() );

			return validator.IsGreaterThanOrEqualTo( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is greater than or equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be greater than or equal to.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not greater than or equal to <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsGreaterThanOrEqualTo<TParameter>( this ParameterValidator<TParameter> validator, TParameter value, string exceptionMessage )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value != null && value != null && validator.Value.CompareTo( value ) < 0 )
			{
				throw new ArgumentOutOfRangeException( validator.Name, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates a parameter is greater than or equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be greater than or equal to.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not greater than or equal to <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsGreaterThanOrEqualTo<TParameter>( this ParameterValidator<TParameter?> validator, TParameter? value )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_GREATER_THAN_OR_EQUAL_TO, value.ToString() );

			return validator.IsGreaterThanOrEqualTo( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is greater than or equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be greater than or equal to.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not greater than or equal to <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsGreaterThanOrEqualTo<TParameter>( this ParameterValidator<TParameter?> validator, TParameter? value, string exceptionMessage )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value != null && value != null && validator.Value.Value.CompareTo( value.Value ) < 0 )
			{
				throw new ArgumentOutOfRangeException( validator.Name, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates a parameter is less than <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be less than.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not less than <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsLessThan<TParameter>( this ParameterValidator<TParameter> validator, TParameter value )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_LESS_THAN, value.ToString() );

			return validator.IsLessThan( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is less than <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be less than.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not less than <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsLessThan<TParameter>( this ParameterValidator<TParameter> validator, TParameter value, string exceptionMessage )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value != null && value != null && validator.Value.CompareTo( value ) >= 0 )
			{
				throw new ArgumentOutOfRangeException( validator.Name, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates a parameter is less than <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be less than.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not less than <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsLessThan<TParameter>( this ParameterValidator<TParameter?> validator, TParameter? value )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_LESS_THAN, value.ToString() );

			return validator.IsLessThan( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is less than <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be less than.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not less than <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsLessThan<TParameter>( this ParameterValidator<TParameter?> validator, TParameter? value, string exceptionMessage )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value != null && value != null && validator.Value.Value.CompareTo( value.Value ) >= 0 )
			{
				throw new ArgumentOutOfRangeException( validator.Name, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates a parameter is less than or equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be less than or equal to.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not less than or equal to <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsLessThanOrEqualTo<TParameter>( this ParameterValidator<TParameter> validator, TParameter value )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_LESS_THAN_OR_EQUAL_TO, value.ToString() );

			return validator.IsLessThanOrEqualTo( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is less than or equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be less than or equal to.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not less than or equal to <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter> IsLessThanOrEqualTo<TParameter>( this ParameterValidator<TParameter> validator, TParameter value, string exceptionMessage )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value != null && value != null && validator.Value.CompareTo( value ) > 0 )
			{
				throw new ArgumentOutOfRangeException( validator.Name, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates a parameter is less than or equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be less than or equal to.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not less or equal to than <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsLessThanOrEqualTo<TParameter>( this ParameterValidator<TParameter?> validator, TParameter? value )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_LESS_THAN_OR_EQUAL_TO, value.ToString() );

			return validator.IsLessThanOrEqualTo( value, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is less than or equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be less than or equal to.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not less than or equal to <paramref name="value" />.</exception>
		public static ParameterValidator<TParameter?> IsLessThanOrEqualTo<TParameter>( this ParameterValidator<TParameter?> validator, TParameter? value, string exceptionMessage )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value != null && value != null && validator.Value.Value.CompareTo( value.Value ) > 0 )
			{
				throw new ArgumentOutOfRangeException( validator.Name, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates a parameter is between <paramref name="minValue" /> and <paramref name="maxValue" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="minValue">The value the parameter must be greater than or equal to.</param>
		/// <param name="maxValue">The value the parameter must be less than or equal to.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not between <paramref name="minValue" /> and <paramref name="maxValue" />.</exception>
		public static ParameterValidator<TParameter> IsBetween<TParameter>( this ParameterValidator<TParameter> validator, TParameter minValue, TParameter maxValue )
			where TParameter : IComparable<TParameter>
		{
			if( validator.Value == null || minValue == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_BETWEEN, minValue.ToString(), maxValue.ToString() );

			return validator.IsBetween( minValue, maxValue, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is between <paramref name="minValue" /> and <paramref name="maxValue" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="minValue">The value the parameter must be greater than or equal to.</param>
		/// <param name="maxValue">The value the parameter must be less than or equal to.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not between <paramref name="minValue" /> and <paramref name="maxValue" />.</exception>
		public static ParameterValidator<TParameter> IsBetween<TParameter>( this ParameterValidator<TParameter> validator, TParameter minValue, TParameter maxValue, string exceptionMessage )
			where TParameter : IComparable<TParameter>
		{
			return validator.IsGreaterThanOrEqualTo( minValue, exceptionMessage )
				.IsLessThanOrEqualTo( maxValue, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is between <paramref name="minValue" /> and <paramref name="maxValue" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="minValue">The value the parameter must be greater than or equal to.</param>
		/// <param name="maxValue">The value the parameter must be less than or equal to.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not between <paramref name="minValue" /> and <paramref name="maxValue" />.</exception>
		public static ParameterValidator<TParameter?> IsBetween<TParameter>( this ParameterValidator<TParameter?> validator, TParameter minValue, TParameter maxValue )
			where TParameter : struct, IComparable<TParameter>
		{
			if( validator.Value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_BETWEEN, minValue.ToString(), maxValue.ToString() );

			return validator.IsBetween( minValue, maxValue, exceptionMessage );
		}

		/// <summary>
		/// Validates a parameter is between <paramref name="minValue" /> and <paramref name="maxValue" />. Otherwise, an <see cref="ArgumentOutOfRangeException" /> is thrown.
		/// </summary>
		/// <typeparam name="TParameter">The parameter type.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="minValue">The value the parameter must be greater than or equal to.</param>
		/// <param name="maxValue">The value the parameter must be less than or equal to.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the parameter is not between <paramref name="minValue" /> and <paramref name="maxValue" />.</exception>
		public static ParameterValidator<TParameter?> IsBetween<TParameter>( this ParameterValidator<TParameter?> validator, TParameter minValue, TParameter maxValue, string exceptionMessage )
			where TParameter : struct, IComparable<TParameter>
		{
			return validator.IsGreaterThanOrEqualTo( minValue, exceptionMessage )
				.IsLessThanOrEqualTo( maxValue, exceptionMessage );
		}
	}
}
