using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using NullableClass;

namespace NullableClass.Test
{
	[TestClass]
	public class NullableClassTests : BaseTest
	{
		[TestMethod]
		public void CreatesNullableAndGetsValue()
		{
			NullableOf<string> nullableString = "Hello, World!";
			Assert.IsTrue(nullableString.HasValue);
			Assert.AreEqual("Hello, World!", nullableString.Value);
		}

		[TestMethod]
		public void GettingValueFromNullThrows()
		{
			NullableOf<string> nullableString = null;
			Assert.IsFalse(nullableString.HasValue);
			Assert.Throws<InvalidOperationException>(() =>
			{
				var value = nullableString.Value;
			});
		}

		[TestMethod]
		public void GettingDefaultValueIfNull()
		{
			var string1 = (NullableOf<string>)"Hello, World!";
			var string2 = (NullableOf<string>)null;

			Assert.IsNotNull(string1.GetValueOrDefault());
			Assert.IsNotNull(string2.GetValueOrDefault());
			Assert.AreEqual("", string2.GetValueOrDefault());
		}

		class Window
		{
			public int Width { get; set; }
			public int Height { get; set; }
		}

		[TestMethod]
		public void SettingDefaultValueForNewType()
		{
			// This should be set in the static constructor.
			// Adding it here just for the test.
			Default<Window>.Set(() => new Window { Width = 500, Height = 350 });

			var defaultWindow = Default<Window>.Get();

			Assert.IsNotNull(defaultWindow);
			Assert.AreEqual(500, defaultWindow.Width);
		}

		[TestMethod]
		public void Equality()
		{
			var a = "a";
			var b = "b";
			var null_a = (NullableOf<string>)"a";
			var null_b = (NullableOf<string>)"b";
			var null_null = (NullableOf<string>)null;

			Assert.IsTrue(null_a.Equals(a));
			Assert.IsFalse(null_a.Equals(b));
			Assert.IsTrue(null_a.Equals(null_a));
			Assert.IsFalse(null_a.Equals(null_b));

			Assert.IsFalse(null_null.Equals(null_a));
			Assert.IsTrue(null_null.Equals(null_null));

			// This is false because string has no knowledge of NullableOf<string>.
			Assert.IsFalse(a.Equals(null_a));
		}

		[TestMethod]
		public void EqualityWithMixedTypes()
		{
			var null_a = (NullableOf<string>)"a";
			var number = 5;
			var obj = new object();

			Assert.IsFalse(null_a.Equals(number));
			Assert.IsFalse(null_a.Equals(obj));
		}

		[TestMethod]
		public void EqualityWithSameObjectsButMixedTypes()
		{
			var nullableString = (NullableOf<string>)"a";
			var nullableObject = (NullableOf<object>)"a";

			// This is false because the declared types are incompatible
			Assert.IsFalse(nullableString.Equals(nullableObject));
		}
	}
}
