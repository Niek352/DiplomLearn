using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Answer
{
	public class CodeAnswer : AbstractAnswer
	{
		[TableList] public CodeBlock[] CodeBlocks = new []
		{
			new CodeBlock(){Language =  "Бейсик"},
			new CodeBlock(){Language =  "Python"},
			new CodeBlock(){Language =  "Паскаль"},
			new CodeBlock(){Language =  "Алгоритмический язык"},
			new CodeBlock(){Language =  "С++"},
		};
	}

	[Serializable]
	public struct CodeBlock
	{
		[TableColumnWidth(75, false)]
		public string Language;
		[PreviewField]
		public Sprite Code;
	}
}