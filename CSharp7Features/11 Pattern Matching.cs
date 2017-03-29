using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// ReSharper disable UnusedMember.Global

namespace CSharp7Features
{
	internal static class PatternMatching
	{
		private static int Sum(object o)
		{
			if (o is null)
				return 0;
			if (o is int i)
				return i;
			if (o is IEnumerable xs)
			{
				var result = 0;
				foreach (var x in xs)
					result += Sum(x);
				return result;
			}

			Debug.Assert(o is var other);
			Console.WriteLine(other.ToString());

			throw new ArgumentException("Unsupported argument type");
		}

		public static void Test()
		{
			var sum = Sum(new object[]
			{
				1,
				null,
				new List<int> { 10, 11 },
				3
			}); // 25
		}

		private static int Sum2(object o)
		{
			switch (o)
			{
				case int i:
					return i;
				case IReadOnlyCollection<int> lst when lst.Count == 0:
					return 0;
				case IEnumerable<int> xs:
					return xs.Sum();
				case IEnumerable seq:
					var result = 0;
					foreach (var x in seq)
						result += Sum2(x);
					return result;
				default:
					throw new ArgumentException("Unsupported argument type");
				case null:
					return 0;
			}
		}

		public static void Test2()
		{
			var sum = Sum2(new object[]
			{
				1,
				null,
				new List<int> { 10, 11 },
				3,
				new int[0],
				new object[] { null, 7 }
			}); // 32
		}
	}
}