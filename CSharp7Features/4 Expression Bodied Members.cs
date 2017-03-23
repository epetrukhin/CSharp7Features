// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertToAutoPropertyWhenPossible

namespace CSharp7Features
{
	internal sealed class ExpressionBodiedMembers
	{
		private int value;

		#region Появилось в C# 6
		public bool IsPositive => value > 0;

		public override string ToString() => value.ToString();

		public static bool operator ==(ExpressionBodiedMembers left, ExpressionBodiedMembers right) => Equals(left, right);

		public static bool operator !=(ExpressionBodiedMembers left, ExpressionBodiedMembers right) => !Equals(left, right);
		#endregion

		#region Появилось в C# 7
		public ExpressionBodiedMembers(int value) => this.value = value;

		~ExpressionBodiedMembers() => value = 0;

		public int Value
		{
			get => value;
			set => this.value = value;
		}

		public int GetOnly
		{
			get => value;
		}

		public int SetOnly
		{
			set => this.value = value;
		}
		#endregion
	}
}