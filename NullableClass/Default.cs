using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NullableClass
{
	public static class Default<T>
		where T : class
	{
		static Func<T> constructor;
		static Default()
		{
			if (typeof(T) == typeof(string))
			{
				constructor = () => "" as T;
				return;
			}
			try
			{
				constructor = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
				return;
			}
			catch
			{
				constructor = () => throw new InvalidOperationException($"Reference type {typeof(T).FullName} doesn't have a parameterless constructor.");
				return;
			}
		}

		public static T Get() => constructor();

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
