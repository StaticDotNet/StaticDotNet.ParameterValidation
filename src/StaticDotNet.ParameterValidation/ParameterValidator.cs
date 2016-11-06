using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation
{
    public class ParameterValidator<TParameter>
    {
		public ParameterValidator( string parameterName, TParameter parameterValue )
		{
			this.ParameterName = parameterName;
			this.ParameterValue = parameterValue;
		}

		public string ParameterName { get; }

		public TParameter ParameterValue { get; }
    }
}
