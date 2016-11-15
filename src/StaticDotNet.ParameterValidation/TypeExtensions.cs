using StaticDotNet.ParameterValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
		/// Validates that the parameter is assignable to <typeparamref name="TType" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TType">The type the parameter should be assignable to.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not assignable to <typeparamref name="TType" />.</exception>
		public static ParameterValidator<Type> IsAssignableTo<TType>( this ParameterValidator<Type> validator )
		{
			return validator.IsAssignableTo( typeof( TType ) );
		}

		/// <summary>
		/// Validates that the parameter is assignable to <typeparamref name="TType" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <typeparam name="TType">The type the parameter should be assignable to.</typeparam>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not assignable to <typeparamref name="TType" />.</exception>
		public static ParameterValidator<Type> IsAssignableTo<TType>( this ParameterValidator<Type> validator, string exceptionMessage )
		{
			return validator.IsAssignableTo( typeof( TType ), exceptionMessage );
		}

		/// <summary>
		/// Validates that the parameter is assignable to <paramref name="type" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="type">The type the parameter should be assignable to.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not assignable to <paramref name="type" />.</exception>
		public static ParameterValidator<Type> IsAssignableTo( this ParameterValidator<Type> validator, Type type )
		{
			if( type != null )
			{
				string exceptionMessage = string.Format( ExceptionMessages.VALUE_MUST_BE_ASSIGNABLE_TO, type.FullName );

				return validator.IsAssignableTo( type, exceptionMessage );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is assignable to <paramref name="type" />. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="type">The type the parameter should be assignable to.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not assignable to <paramref name="type" />.</exception>
		public static ParameterValidator<Type> IsAssignableTo( this ParameterValidator<Type> validator, Type type, string exceptionMessage )
		{
			if( validator.Value != null && type != null && !type.IsAssignableFrom( validator.Value ) )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is a class. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not a class.</exception>
		public static ParameterValidator<Type> IsClass( this ParameterValidator<Type> validator )
		{
			return validator.IsClass( ExceptionMessages.VALUE_MUST_BE_A_CLASS );
		}

		/// <summary>
		/// Validates that the parameter is a class. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not a class.</exception>
		public static ParameterValidator<Type> IsClass( this ParameterValidator<Type> validator, string exceptionMessage )
		{
			if( validator.Value != null && !validator.Value.GetTypeInfo().IsClass )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}

		/// <summary>
		/// Validates that the parameter is an interface. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not an interface.</exception>
		public static ParameterValidator<Type> IsInterface( this ParameterValidator<Type> validator )
		{
			return validator.IsInterface( ExceptionMessages.VALUE_MUST_BE_AN_INTERFACE );
		}

		/// <summary>
		/// Validates that the parameter is an interface. Otherwise, an <see cref="ArgumentException" /> is thrown.
		/// </summary>
		/// <param name="validator">The <see cref="ParameterValidator{TParameter}" />.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns>The same instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		/// <exception cref="ArgumentException">Thrown when the parameter is not an interface.</exception>
		public static ParameterValidator<Type> IsInterface( this ParameterValidator<Type> validator, string exceptionMessage )
		{
			if( validator.Value != null && !validator.Value.GetTypeInfo().IsInterface )
			{
				throw new ArgumentException( exceptionMessage, validator.Name );
			}

			return validator;
		}
	}
}
