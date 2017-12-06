using System;
using System.Collections.Generic;
using System.Text;

namespace NullableClass
{
	public static class Default<T>
		where T : class
	{
		private static Func<T> defaultValue;

		public static void Set(Func<T> defaultValue) => Default<T>.defaultValue = defaultValue;
		public static T Get() => defaultValue();

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
