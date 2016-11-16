using StaticDotNet.ParameterValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation
{
	/// <summary>
	/// Adds parameter validation for <see cref="string"/>.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Validates that the parameter is equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be equal to.</param>
		/// <param name="ignoreCase">Whether or not to ignore case.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not equal to <paramref name="value" />.</exception>
		public static ParameterValidator<string> IsEqualTo( this ParameterValidator<string> validator, string value, bool ignoreCase )
		{
			if( value != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_EQUAL_TO, value );

				return validator.IsEqualTo( value, ignoreCase, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must be equal to.</param>
		/// <param name="ignoreCase">Whether or not to ignore case.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is not equal to <paramref name="value" />.</exception>
		public static ParameterValidator<string> IsEqualTo( this ParameterValidator<string> validator, string value, bool ignoreCase, string exceptionMessage )
		{
			if( validator.Value != null && value != null && string.Compare( validator.Value, value, ignoreCase ) != 0 )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is not equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must not be equal to.</param>
		/// <param name="ignoreCase">Whether or not to ignore case.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is equal to <paramref name="value" />.</exception>
		public static ParameterValidator<string> IsNotEqualTo( this ParameterValidator<string> validator, string value, bool ignoreCase )
		{
			if( value != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_NOT_BE_EQUAL_TO, value );

				return validator.IsNotEqualTo( value, ignoreCase, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is not equal to <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must not be equal to.</param>
		/// <param name="ignoreCase">Whether or not to ignore case.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="System.ArgumentException">Thrown when parameter is equal to <paramref name="value" />.</exception>
		public static ParameterValidator<string> IsNotEqualTo( this ParameterValidator<string> validator, string value, bool ignoreCase, string exceptionMessage )
		{
			if( validator.Value != null && value != null && string.Compare( validator.Value, value, ignoreCase ) == 0 )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

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
		/// Validates that the parameter is not empty. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty.</exception>
		public static ParameterValidator<string> IsNotEmpty( this ParameterValidator<string> validator, string exceptionMessage )
		{
			if( validator.Value != null && validator.Value.Length == 0 )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is not empty or white space. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty or white space.</exception>
		public static ParameterValidator<string> IsNotWhiteSpace( this ParameterValidator<string> validator )
		{
			return validator.IsNotWhiteSpace( ExceptionMessages.VALUE_CANNOT_BE_EMPTY_OR_WHITE_SPACE );
		}

		/// <summary>
		/// Validates that the parameter is not empty or white space. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty or white space.</exception>
		public static ParameterValidator<string> IsNotWhiteSpace( this ParameterValidator<string> validator, string exceptionMessage )
		{
			if( validator.Value != null && string.IsNullOrWhiteSpace( validator.Value ) )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is not null or empty. Otherwise, an <see cref="ArgumentNullException" /> or <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty.</exception>
		public static ParameterValidator<string> IsNotNullOrEmpty( this ParameterValidator<string> validator )
		{
			return validator.IsNotNullOrEmpty( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY );
		}

		/// <summary>
		/// Validates that the parameter is not null or empty. Otherwise, an <see cref="ArgumentNullException" /> or <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty.</exception>
		public static ParameterValidator<string> IsNotNullOrEmpty( this ParameterValidator<string> validator, string exceptionMessage )
		{
			validator.IsNotNull( exceptionMessage )
				.IsNotEmpty( exceptionMessage );

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is not null, empty or white space. Otherwise, an <see cref="ArgumentNullException" /> or <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty or white space.</exception>
		public static ParameterValidator<string> IsNotNullOrWhiteSpace( this ParameterValidator<string> validator )
		{
			return validator.IsNotNullOrWhiteSpace( ExceptionMessages.VALUE_CANNOT_BE_NULL_EMPTY_OR_WHITE_SPACE );
		}

		/// <summary>
		/// Validates that the parameter is not null, empty or white space. Otherwise, an <see cref="ArgumentNullException" /> or <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the parameter is empty or white space.</exception>
		public static ParameterValidator<string> IsNotNullOrWhiteSpace( this ParameterValidator<string> validator, string exceptionMessage )
		{
			validator.IsNotNull( exceptionMessage )
				.IsNotWhiteSpace( exceptionMessage );

			return validator;
		}

		/// <summary>
		/// Validates that the parameter has the expected length. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="expectedLength">The expected length.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter length is not equal to <paramref name="expectedLength" />.</exception>
		public static ParameterValidator<string> HasLength( this ParameterValidator<string> validator, int expectedLength )
		{
			if( validator.Value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_HAVE_LENGTH_EQUAL_TO, expectedLength.ToString() );

			return validator.HasLength( expectedLength, exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter has the expected length. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="expectedLength">The expected length.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter length is not equal to <paramref name="expectedLength" />.</exception>
		public static ParameterValidator<string> HasLength( this ParameterValidator<string> validator, int expectedLength, string exceptionMessage )
		{
			if( validator.Value != null && validator.Value.Length != expectedLength )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is less than or equal to the <paramref name="maxLength"/>. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="maxLength">The maximum length.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter length is not less than or equal to the <paramref name="maxLength" />.</exception>
		public static ParameterValidator<string> HasMaxLength( this ParameterValidator<string> validator, int maxLength )
		{
			if( validator.Value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_HAVE_LENGTH_LESS_THAN_OR_EQUAL_TO, maxLength.ToString() );

			return validator.HasMaxLength( maxLength, exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter is less than or equal to the <paramref name="maxLength"/>. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="maxLength">The maximum length.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter length is not less than or equal to the <paramref name="maxLength" />.</exception>
		public static ParameterValidator<string> HasMaxLength( this ParameterValidator<string> validator, int maxLength, string exceptionMessage )
		{
			if( validator.Value != null && validator.Value.Length > maxLength )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is greater than or equal to the <paramref name="minLength"/>. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="minLength">The minimum length.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter length is not greater than or equal to the <paramref name="minLength" />.</exception>
		public static ParameterValidator<string> HasMinLength( this ParameterValidator<string> validator, int minLength )
		{
			if( validator.Value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_HAVE_LENGTH_GREATER_THAN_OR_EQUAL_TO, minLength.ToString() );

			return validator.HasMinLength( minLength, exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter is greater than or equal to the <paramref name="minLength"/>. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="minLength">The minimum length.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter length is not greater than or equal to the <paramref name="minLength" />.</exception>
		public static ParameterValidator<string> HasMinLength( this ParameterValidator<string> validator, int minLength, string exceptionMessage )
		{
			if( validator.Value != null && validator.Value.Length < minLength )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is greater than or equal to the <paramref name="minLength"/> and less than or equal to <paramref name="maxLength" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="minLength">The minimum length.</param>
		/// <param name="maxLength">The maximum length.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter length is not greater than or equal to the <paramref name="minLength" /> and less than or equal to <paramref name="maxLength"/>.</exception>
		public static ParameterValidator<string> HasLengthBetween( this ParameterValidator<string> validator, int minLength, int maxLength )
		{
			if( validator.Value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_HAVE_LENGTH_BETWEEN, minLength.ToString(), maxLength.ToString() );

			return validator.HasLengthBetween( minLength, maxLength, exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter is greater than or equal to the <paramref name="minLength"/> and less than or equal to <paramref name="maxLength" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="minLength">The minimum length.</param>
		/// <param name="maxLength">The maximum length.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter length is not greater than or equal to the <paramref name="minLength" /> and less than or equal to <paramref name="maxLength"/>.</exception>
		public static ParameterValidator<string> HasLengthBetween( this ParameterValidator<string> validator, int minLength, int maxLength, string exceptionMessage )
		{
			validator.HasMinLength( minLength, exceptionMessage )
				.HasMaxLength( maxLength, exceptionMessage );

			return validator;
		}

		/// <summary>
		/// Validates that the parameter contains the specific <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must contain.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter value does not contain <paramref name="value" />.</exception>
		public static ParameterValidator<string> Contains( this ParameterValidator<string> validator, string value )
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_CONTAIN, value );

			return validator.Contains( value, exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter contains the specific <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must contain.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter value does not contain <paramref name="value" />.</exception>
		public static ParameterValidator<string> Contains( this ParameterValidator<string> validator, string value, string exceptionMessage )
		{
			if( validator.Value != null && value != null && !validator.Value.Contains( value ) )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter must start with the specified <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must start with.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter value does not start with <paramref name="value" />.</exception>
		public static ParameterValidator<string> StartsWith( this ParameterValidator<string> validator, string value )
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_START_WITH, value );

			return validator.StartsWith( value, exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter must start with the specified <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must start with.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter value does not start with <paramref name="value" />.</exception>
		public static ParameterValidator<string> StartsWith( this ParameterValidator<string> validator, string value, string exceptionMessage )
		{
			if( validator.Value != null && value != null && !validator.Value.StartsWith( value ) )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter must end with the specified <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must end with.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter value does not end with <paramref name="value" />.</exception>
		public static ParameterValidator<string> EndsWith( this ParameterValidator<string> validator, string value )
		{
			if( validator.Value == null || value == null )
			{
				return validator;
			}

			string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_END_WITH, value );

			return validator.EndsWith( value, exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter must end with the specified <paramref name="value" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="value">The value the parameter must end with.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter value does not end with <paramref name="value" />.</exception>
		public static ParameterValidator<string> EndsWith( this ParameterValidator<string> validator, string value, string exceptionMessage )
		{
			if( validator.Value != null && value != null && !validator.Value.EndsWith( value ) )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter matches the specified regular expression <paramref name="pattern" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="pattern">The regular expression pattern.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not match <paramref name="pattern" />.</exception>
		public static ParameterValidator<string> Match( this ParameterValidator<string> validator, string pattern )
		{
			Match match;

			return validator.Match( pattern, out match );
		}

		/// <summary>
		/// Validates that the parameter matches the specified regular expression <paramref name="pattern" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="pattern">The regular expression pattern.</param>
		/// <param name="match">The <see cref="System.Text.RegularExpressions.Match"/>.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not match <paramref name="pattern" />.</exception>
		public static ParameterValidator<string> Match( this ParameterValidator<string> validator, string pattern, out Match match )
		{
			if( pattern != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_MATCH_REGULAR_EXPRESSION, pattern );

				return validator.Match( pattern, exceptionMessage, out match );
			}

			match = null;
			return validator;
		}

		/// <summary>
		/// Validates that the parameter matches the specified regular expression <paramref name="pattern" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="pattern">The regular expression pattern.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not match <paramref name="pattern" />.</exception>
		public static ParameterValidator<string> Match( this ParameterValidator<string> validator, string pattern, string exceptionMessage )
		{
			Match match;

			return validator.Match( pattern, exceptionMessage, out match );
		}

		/// <summary>
		/// Validates that the parameter matches the specified regular expression <paramref name="pattern" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="pattern">The regular expression pattern.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <param name="match">The <see cref="System.Text.RegularExpressions.Match"/>.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not match <paramref name="pattern" />.</exception>
		public static ParameterValidator<string> Match( this ParameterValidator<string> validator, string pattern, string exceptionMessage, out Match match )
		{
			if( pattern != null )
			{
				Regex regex = new Regex( pattern );

				return validator.Match( regex, exceptionMessage, out match );
			}

			match = null;
			return validator;
		}

		/// <summary>
		/// Validates that the parameter matches the specified regular expression <paramref name="regex" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="regex">The regular expression.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not match <paramref name="regex" />.</exception>
		public static ParameterValidator<string> Match( this ParameterValidator<string> validator, Regex regex )
		{
			if( regex != null )
			{
				Match match;
				return validator.Match( regex, out match );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter matches the specified regular expression <paramref name="regex" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="regex">The regular expression.</param>
		/// <param name="match">The <see cref="System.Text.RegularExpressions.Match"/>.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not match <paramref name="regex" />.</exception>
		public static ParameterValidator<string> Match( this ParameterValidator<string> validator, Regex regex, out Match match )
		{
			if( regex != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_MATCH_REGULAR_EXPRESSION, regex.ToString() );

				return validator.Match( regex, exceptionMessage, out match );
			}

			match = null;
			return validator;
		}

		/// <summary>
		/// Validates that the parameter matches the specified regular expression <paramref name="regex" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="regex">The regular expression.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not match <paramref name="regex" />.</exception>
		public static ParameterValidator<string> Match( this ParameterValidator<string> validator, Regex regex, string exceptionMessage )
		{
			Match match;

			return validator.Match( regex, exceptionMessage, out match );
		}

		/// <summary>
		/// Validates that the parameter matches the specified regular expression <paramref name="regex" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="regex">The regular expression.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <param name="match">The <see cref="System.Text.RegularExpressions.Match"/>.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter does not match <paramref name="regex" />.</exception>
		public static ParameterValidator<string> Match( this ParameterValidator<string> validator, Regex regex, string exceptionMessage, out Match match )
		{
			match = null;

			if( validator.Value != null && regex != null )
			{
				match = regex.Match( validator.Value );
				if( !match.Success )
				{
					throw new ArgumentException( exceptionMessage, validator.Name );
				}
			}

			return validator;
		}
	}
}
