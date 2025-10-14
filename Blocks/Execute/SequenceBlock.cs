using System;
using System.Collections.Generic;

namespace LunyScratch
{
	internal sealed class SequenceBlock : IScratchBlock
	{
		private readonly List<IScratchBlock> _blocks;
		private Int32 _currentIndex;
		private Int32 _progressVersion;

		public Int32 ProgressVersion => _progressVersion; // increments when sequence advances between blocks

		public SequenceBlock(params IScratchBlock[] blocks)
		{
			_blocks = new List<IScratchBlock>(blocks);
			_currentIndex = 0;
			_progressVersion = 0;
		}

		public SequenceBlock(List<IScratchBlock> blocks)
		{
			_blocks = blocks;
			_currentIndex = 0;
			_progressVersion = 0;
		}
		
		public void OnEnter()
		{
			_currentIndex = 0;
			if (_blocks.Count > 0)
				_blocks[0].OnEnter();
		}
		
		public void Run(IScratchContext context, Double deltaTimeInSeconds)
		{
			// Execute as many blocks as possible within a single frame.
			// Stop when a block is not yet complete or when the sequence finishes.
			while (_currentIndex < _blocks.Count)
			{
				var currentBlock = _blocks[_currentIndex];
				currentBlock.Run(context, deltaTimeInSeconds);

				if (!currentBlock.IsComplete())
					break; // Wait until next frame when current block completes

				currentBlock.OnExit();
				_currentIndex++;
				_progressVersion++; // advanced past a block
				
				if (_currentIndex >= _blocks.Count)
					break; // Sequence finished this frame
				
				// Enter next block and continue within this frame
				_blocks[_currentIndex].OnEnter();
			}
		}
		
		public void OnExit()
		{
			if (_currentIndex < _blocks.Count)
				_blocks[_currentIndex].OnExit();
		}
		
		public Boolean IsComplete() => _currentIndex >= _blocks.Count;
	}
}
