using System;


namespace WuLinZhi.Core.Buff
{
	public abstract class BuffBase
	{
		public BuffBase()
		{
		}

		public bool Stackable { get; set; }
		public int Layer { get; set; }

	}
}

