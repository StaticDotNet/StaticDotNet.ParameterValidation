using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation
{
    public static class Parameter
    {
		public static ParameterValidator<TParameter> Validate<TParameter>( TParameter value )
		{
			return Parameter.Validate( value, null );
		}

		public static ParameterValidator<TParameter> Validate<TParameter>( TParameter value, string name )
		{
			return new ParameterValidator<TParameter>( name, value );
		}
    }
}
