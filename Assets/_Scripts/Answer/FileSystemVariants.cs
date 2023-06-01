using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.Answer
{
	public class FileSystemVariants : AbstractAnswer
	{
		public SimpleObj[] Files;
	}

	[Serializable]
	public class SimpleObj
	{
		public string Name;
		[ShowIf("ObjType", Answer.ObjType.File)] public string Format;
		[ShowIf("ObjType", Answer.ObjType.File)] public string Content;
		[ShowIf("ObjType", Answer.ObjType.Folder)][SerializeReference] public SimpleObj[] Files;
		public ObjType ObjType;
	}
	
	public enum ObjType
	{
		File,
		Folder
	}
}