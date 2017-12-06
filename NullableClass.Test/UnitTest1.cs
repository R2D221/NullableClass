using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullableClass;

namespace NullableClass.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void TestMethod1()
		{
			NullableOf<string> nullableValue = null;
			string value = nullableValue.Value;
		}
	}
}
