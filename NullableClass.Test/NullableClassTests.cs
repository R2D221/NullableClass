using System;
using System.Collections.Generic;
using System.Linq;
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

		public class Rectangle
		{
			public int Width { get; set; }
			public int Height { get; set; }
		}

		[TestMethod]
		public void GettingDefaultValue()
		{
			var defaultRectangle = Default<Rectangle>.Get();

			Assert.IsNotNull(defaultRectangle);
			Assert.AreEqual(0, defaultRectangle.Width);
			Assert.AreEqual(0, defaultRectangle.Height);
		}

		public class Person
		{
			public string Name { get; set; } = "";
			
			public Person(string name)
			{
				Name = name;
			}
		}

		[TestMethod]
		public void GettingDefaultValueWithNoParameterlessConstructor()
		{
			Assert.Throws<InvalidOperationException>(() =>
			{
				var defaultPerson = Default<Person>.Get();
			});
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

		[TestMethod]
		public void DefaultIfEmpty_WithEmptyLists()
		{
			var list1 = new List<string	>();
			var list2 = new List<int	>();
			var list3 = new List<NullableOf<string>	>();
			var list4 = new List<Nullable<int>	>();
			
			Assert.AreEqual(""	, list1.DefaultIfEmpty_().First());
			Assert.AreEqual(0	, list2.DefaultIfEmpty_().First());
			Assert.AreEqual(null	, list3.DefaultIfEmpty_().First());
			Assert.AreEqual(null	, list4.DefaultIfEmpty_().First());
		}

		[TestMethod]
		public void DefaultIfEmpty_WithFilledLists()
		{
			var list1 = new List<string	> { "a"	};
			var list2 = new List<int	> { 5	};
			var list3 = new List<NullableOf<string>	> { "a"	};
			var list4 = new List<Nullable<int>	> { 5	};

			Assert.AreEqual("a"	, list1.DefaultIfEmpty_().First());
			Assert.AreEqual(5	, list2.DefaultIfEmpty_().First());
			Assert.AreEqual("a"	, list3.DefaultIfEmpty_().First());
			Assert.AreEqual(5	, list4.DefaultIfEmpty_().First());
		}

		[TestMethod]
		public void ElementAtOrDefault_WithEmptyLists()
		{
			var list1 = new List<string	>();
			var list2 = new List<int	>();
			var list3 = new List<NullableOf<string>	>();
			var list4 = new List<Nullable<int>	>();
			
			Assert.AreEqual(""	, list1.ElementAtOrDefault_(10));
			Assert.AreEqual(0	, list2.ElementAtOrDefault_(10));
			Assert.AreEqual(null	, list3.ElementAtOrDefault_(10));
			Assert.AreEqual(null	, list4.ElementAtOrDefault_(10));
		}

		[TestMethod]
		public void ElementAtOrDefault_WithFilledLists()
		{
			var list1 = new List<string	> { "a"	, "b"	};
			var list2 = new List<int	> { 5	, 10	};
			var list3 = new List<NullableOf<string>	> { "a"	, "b"	};
			var list4 = new List<Nullable<int>	> { 5	, 10	};

			Assert.AreEqual("b"	, list1.ElementAtOrDefault_(1));
			Assert.AreEqual(10	, list2.ElementAtOrDefault_(1));
			Assert.AreEqual("b"	, list3.ElementAtOrDefault_(1));
			Assert.AreEqual(10	, list4.ElementAtOrDefault_(1));
		}

		[TestMethod]
		public void FirstOrDefault_WithEmptyLists()
		{
			var list1 = new List<string	>();
			var list2 = new List<int	>();
			var list3 = new List<NullableOf<string>	>();
			var list4 = new List<Nullable<int>	>();
			
			Assert.AreEqual(""	, list1.FirstOrDefault_());
			Assert.AreEqual(0	, list2.FirstOrDefault_());
			Assert.AreEqual(null	, list3.FirstOrDefault_());
			Assert.AreEqual(null	, list4.FirstOrDefault_());
		}

		[TestMethod]
		public void FirstOrDefault_WithFilledLists()
		{
			var list1 = new List<string	> { "a"	, "b"	};
			var list2 = new List<int	> { 5	, 10	};
			var list3 = new List<NullableOf<string>	> { "a"	, "b"	};
			var list4 = new List<Nullable<int>	> { 5	, 10	};

			Assert.AreEqual("a"	, list1.FirstOrDefault_());
			Assert.AreEqual(5	, list2.FirstOrDefault_());
			Assert.AreEqual("a"	, list3.FirstOrDefault_());
			Assert.AreEqual(5	, list4.FirstOrDefault_());
		}

		[TestMethod]
		public void FirstOrDefault_WithFalsePredicate()
		{
			var list1 = new List<string	> { "a"	, "b"	};
			var list2 = new List<int	> { 5	, 10	};
			var list3 = new List<NullableOf<string>	> { "a"	, "b"	};
			var list4 = new List<Nullable<int>	> { 5	, 10	};
			
			Assert.AreEqual(""	, list1.FirstOrDefault_(x => x == "c"	));
			Assert.AreEqual(0	, list2.FirstOrDefault_(x => x == 9	));
			Assert.AreEqual(null	, list3.FirstOrDefault_(x => x == "c"	));
			Assert.AreEqual(null	, list4.FirstOrDefault_(x => x == 9	));
		}

		[TestMethod]
		public void FirstOrDefault_WithTruePredicate()
		{
			var list1 = new List<string	> { "a"	, "b"	};
			var list2 = new List<int	> { 5	, 10	};
			var list3 = new List<NullableOf<string>	> { "a"	, "b"	};
			var list4 = new List<Nullable<int>	> { 5	, 10	};

			Assert.AreEqual("a"	, list1.FirstOrDefault_(x => x == "a"	));
			Assert.AreEqual(5	, list2.FirstOrDefault_(x => x == 5	));
			Assert.AreEqual("a"	, list3.FirstOrDefault_(x => x == "a"	));
			Assert.AreEqual(5	, list4.FirstOrDefault_(x => x == 5	));
		}

		[TestMethod]
		public void SingleOrDefault_WithEmptyLists()
		{
			var list1 = new List<string	>();
			var list2 = new List<int	>();
			var list3 = new List<NullableOf<string>	>();
			var list4 = new List<Nullable<int>	>();
			
			Assert.AreEqual(""	, list1.SingleOrDefault_());
			Assert.AreEqual(0	, list2.SingleOrDefault_());
			Assert.AreEqual(null	, list3.SingleOrDefault_());
			Assert.AreEqual(null	, list4.SingleOrDefault_());
		}

		[TestMethod]
		public void SingleOrDefault_WithFilledLists()
		{
			var list1 = new List<string	> { "a"	};
			var list2 = new List<int	> { 5	};
			var list3 = new List<NullableOf<string>	> { "a"	};
			var list4 = new List<Nullable<int>	> { 5	};

			Assert.AreEqual("a"	, list1.SingleOrDefault_());
			Assert.AreEqual(5	, list2.SingleOrDefault_());
			Assert.AreEqual("a"	, list3.SingleOrDefault_());
			Assert.AreEqual(5	, list4.SingleOrDefault_());
		}

		[TestMethod]
		public void SingleOrDefault_WithFalsePredicate()
		{
			var list1 = new List<string	> { "a"	, "b"	};
			var list2 = new List<int	> { 5	, 10	};
			var list3 = new List<NullableOf<string>	> { "a"	, "b"	};
			var list4 = new List<Nullable<int>	> { 5	, 10	};
			
			Assert.AreEqual(""	, list1.SingleOrDefault_(x => x == "c"	));
			Assert.AreEqual(0	, list2.SingleOrDefault_(x => x == 9	));
			Assert.AreEqual(null	, list3.SingleOrDefault_(x => x == "c"	));
			Assert.AreEqual(null	, list4.SingleOrDefault_(x => x == 9	));
		}

		[TestMethod]
		public void SingleOrDefault_WithTruePredicate()
		{
			var list1 = new List<string	> { "a"	, "b"	};
			var list2 = new List<int	> { 5	, 10	};
			var list3 = new List<NullableOf<string>	> { "a"	, "b"	};
			var list4 = new List<Nullable<int>	> { 5	, 10	};

			Assert.AreEqual("a"	, list1.SingleOrDefault_(x => x == "a"	));
			Assert.AreEqual(5	, list2.SingleOrDefault_(x => x == 5	));
			Assert.AreEqual("a"	, list3.SingleOrDefault_(x => x == "a"	));
			Assert.AreEqual(5	, list4.SingleOrDefault_(x => x == 5	));
		}

		[TestMethod]
		public void LastOrDefault_WithEmptyLists()
		{
			var list1 = new List<string	>();
			var list2 = new List<int	>();
			var list3 = new List<NullableOf<string>	>();
			var list4 = new List<Nullable<int>	>();
			
			Assert.AreEqual(""	, list1.LastOrDefault_());
			Assert.AreEqual(0	, list2.LastOrDefault_());
			Assert.AreEqual(null	, list3.LastOrDefault_());
			Assert.AreEqual(null	, list4.LastOrDefault_());
		}

		[TestMethod]
		public void LastOrDefault_WithFilledLists()
		{
			var list1 = new List<string	> { "a"	, "b"	};
			var list2 = new List<int	> { 5	, 10	};
			var list3 = new List<NullableOf<string>	> { "a"	, "b"	};
			var list4 = new List<Nullable<int>	> { 5	, 10	};

			Assert.AreEqual("b"	, list1.LastOrDefault_());
			Assert.AreEqual(10	, list2.LastOrDefault_());
			Assert.AreEqual("b"	, list3.LastOrDefault_());
			Assert.AreEqual(10	, list4.LastOrDefault_());
		}

		[TestMethod]
		public void LastOrDefault_WithFalsePredicate()
		{
			var list1 = new List<string	> { "a"	, "b"	};
			var list2 = new List<int	> { 5	, 10	};
			var list3 = new List<NullableOf<string>	> { "a"	, "b"	};
			var list4 = new List<Nullable<int>	> { 5	, 10	};
			
			Assert.AreEqual(""	, list1.LastOrDefault_(x => x == "c"	));
			Assert.AreEqual(0	, list2.LastOrDefault_(x => x == 9	));
			Assert.AreEqual(null	, list3.LastOrDefault_(x => x == "c"	));
			Assert.AreEqual(null	, list4.LastOrDefault_(x => x == 9	));
		}

		[TestMethod]
		public void LastOrDefault_WithTruePredicate()
		{
			var list1 = new List<string	> { "a"	, "b"	};
			var list2 = new List<int	> { 5	, 10	};
			var list3 = new List<NullableOf<string>	> { "a"	, "b"	};
			var list4 = new List<Nullable<int>	> { 5	, 10	};

			Assert.AreEqual("a"	, list1.LastOrDefault_(x => x == "a"	));
			Assert.AreEqual(5	, list2.LastOrDefault_(x => x == 5	));
			Assert.AreEqual("a"	, list3.LastOrDefault_(x => x == "a"	));
			Assert.AreEqual(5	, list4.LastOrDefault_(x => x == 5	));
		}
	}
}
