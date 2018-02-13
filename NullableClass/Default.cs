using System;
using System.Collections.Generic;
using System.Text;

namespace NullableClass
{
	public static class Default<T>
		where T : class
	{
		private static Func<T> defaultValue;

		public static T Get()
		{
			if (defaultValue == null)
			{
				try
				{
					// If found, parameterless constructor will be used to create a default value
					return Activator.CreateInstance<T>();
				}
				catch
				{
					throw new InvalidOperationException($"You must configure Default<{typeof(T).Name}> before using it.");
				}
			}

			return defaultValue();
		}

		public static void Set(Func<T> defaultValue)
		{
			if (defaultValue == null)
				throw new InvalidOperationException($"You must provide a non-null delegate for Default<{typeof(T).Name}>.");
			if (Default<T>.defaultValue != null)
				throw new InvalidOperationException($"Delegate for Default<{typeof(T).Name}> must be configured only once.");

			Default<T>.defaultValue = defaultValue;
		}

		static Default()
		{
			if (typeof(T) == typeof(string))
			{
				Default<string>.Set(() => "");
			}
		}

		/// <summary>
		/// Creates a new array filled with default values for T.
		/// Warning: Creating a large array may affect performance.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static T[] NewArray(int length)
		{
			var array = new T[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = Get();
			}
			return array;
		}
	}
}
