// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertToAutoPropertyWhenPossible

#pragma warning disable 660,661

namespace CSharp7Features
{
	internal sealed class ExpressionBodiedMembers
	{
		private int _value;

		#region Появилось в C# 6
		public bool IsPositive => _value > 0;

		public override string ToString() => _value.ToString();

		public static bool operator ==(ExpressionBodiedMembers left, ExpressionBodiedMembers right) => Equals(left, right);

		public static bool operator !=(ExpressionBodiedMembers left, ExpressionBodiedMembers right) => !Equals(left, right);
		#endregion

		#region Появилось в C# 7
		public ExpressionBodiedMembers(int value) => _value = value;

		~ExpressionBodiedMembers() => _value = 0;

		public int Value
		{
			get => _value;
			set => _value = value;
		}

		public int GetOnly
		{
			get => _value;
		}

		public int SetOnly
		{
			set => _value = value;
		}
		#endregion
	}
}