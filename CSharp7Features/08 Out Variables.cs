// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CSharp7Features
{
	internal static class OutVariables
	{
		public static void Examples()
		{
			var dict = new Dictionary<int, string>();

			string value;
			if (dict.TryGetValue(42, out value))
			{
				Console.WriteLine(value);
			}
			else
			{
				Debug.Assert(value == null);
			}
			Console.WriteLine(value);

			//////////////////////////////////////////////////////

			if (dict.TryGetValue(42, out string val)) // out var val
			{
				Console.WriteLine(value);
			}
			else
			{
				Debug.Assert(val == null);
			}
			Console.WriteLine(val);
		}

		public static void Discard(string str)
		{
			if (int.TryParse(str, out _))
				Console.WriteLine("An int!");
			else
				Console.WriteLine(":-(");

			TwoOuts(out var x, out _);
			TwoOuts(out _, out var y);
		}

		private static void TwoOuts(out int x, out int y) => throw new NotImplementedException();
	}
}