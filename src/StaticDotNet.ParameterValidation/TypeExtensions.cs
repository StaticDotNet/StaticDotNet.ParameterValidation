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
    }
}
