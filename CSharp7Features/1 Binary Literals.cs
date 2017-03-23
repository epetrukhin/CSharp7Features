// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local
#pragma warning disable 219
using System;

namespace CSharp7Features
{
	internal static class BinaryLiterals
	{
		private static void Demo()
		{
			// Литералы для чисел до C#7
			var aDec = 123456;
			var aHex = 0X123456;
			var bDec = 123456U;
			var bHex = 0X123456U;
			var cDec = 123456L;
			var cHex = 0X123456L;
			var dDec = 123456UL;
			var dHex = 0X123456UL;

			var e = 123.456D;
			var f = 123.456F;
			var g = 123.456M;

			// Двоичные литералы
			var aBin = 0b11110001001000000;
			var bBin = 0b11110001001000000U;
			var cBin = 0b11110001001000000L;
			var dBin = 0b11110001001000000UL;
		}

		[Flags]
		private enum Foo
		{
			None  = 0b00000, //  0
			Flag1 = 0b00001, //  1
			Flag2 = 0b00010, //  2
			Flag3 = 0b00100, //  4
			Flag4 = 0b01000, //  8
			Flag5 = 0b10000  // 16
		}
	}
}