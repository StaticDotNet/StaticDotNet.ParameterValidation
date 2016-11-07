using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation
{
	/// <summary>
	/// Class used to validate parameters.
	/// </summary>
    public static class Parameter
    {
		/// <summary>
		/// Validates a parameter.
		/// </summary>
		/// <typeparam name="TParameter">The type of parameter.</typeparam>
		/// <param name="value">The value of the parameter.</param>
		/// <returns>An instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		public static ParameterValidator<TParameter> Validate<TParameter>( TParameter value )
		{
			return Parameter.Validate( value, null );
		}

		/// <summary>
		/// Validates a parameter.
		/// </summary>
		/// <typeparam name="TParameter">The type of the parameter.</typeparam>
		/// <param name="value">The value of the parameter.</param>
		/// <param name="name">The name of the parameter.</param>
		/// <returns>An instance of <see cref="ParameterValidator{TParameter}" />.</returns>
		public static ParameterValidator<TParameter> Validate<TParameter>( TParameter value, string name )
		{
			return new ParameterValidator<TParameter>( name, value );
		}
    }
}
