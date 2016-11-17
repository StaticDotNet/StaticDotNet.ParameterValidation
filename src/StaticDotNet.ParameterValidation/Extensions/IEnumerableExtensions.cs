using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticDotNet.ParameterValidation.Extensions
{
	/// <summary>
	/// Extension methods for <see cref="IEnumerable" />.
	/// </summary>
    public static class IEnumerableExtensions
    {
		/// <summary>
		/// Checks if an <see cref="IEnumerable" /> is empty.
		/// </summary>
		/// <param name="enumerable">The <see cref="IEnumerable" />.</param>
		/// <returns>Whether or not the <see cref="IEnumerable"/> is empty.</returns>
		public static bool IsEmpty( this IEnumerable enumerable )
		{
			IEnumerator enumerator = enumerable.GetEnumerator();

			try
			{
				return !enumerator.MoveNext();
			}
			finally
			{
				( enumerator as IDisposable )?.Dispose();
			}
		}
    }
}
