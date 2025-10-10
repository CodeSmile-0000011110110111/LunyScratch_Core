using System;

namespace LunyScratch
{
	/// <summary>
	/// Event that becomes true once when a collision enters on the associated ScratchBehaviour.
	/// Optional filters by other object's name and/or tag.
	/// </summary>
	public sealed class CollisionEnterEventBlock : EventBlock
	{
		private readonly String _nameFilter;
		private readonly String _tagFilter;

		public CollisionEnterEventBlock(String name = null, String tag = null)
		{
			_nameFilter = name;
			_tagFilter = tag;
		}

		internal override Boolean Evaluate(IScratchContext context) =>
			context != null && context.QueryCollisionEnterEvents(_nameFilter, _tagFilter);
	}
}
