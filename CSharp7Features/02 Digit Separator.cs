// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local
#pragma warning disable 219

namespace CSharp7Features
{
	internal static class DigitSeparator
	{
		private static void Demo()
		{
			var a = 123_456;
			var b = 0XDead_BeefUL;
			var e = 0b1001_0110;
			var f = 123_456.789_123D;
			var g = 123_456.789_123F;
			var h = 123_456.789_123M;

			// Разделитель цифр можно ставить между цифрами в любом месте в любом количестве
		}
	}
}