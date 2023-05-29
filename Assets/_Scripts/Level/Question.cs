using System.Collections.Generic;
using System.Linq;
using _Scripts.Answer;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace _Scripts.Level
{
	[CreateAssetMenu(menuName = "Data/" + nameof(Question), fileName = nameof(Question))]
	public class Question : ScriptableObject
	{
		public string QuestionId;
		public string Url;
		[TextArea(10, 40)]
		public string Text;
		public Sprite[] Ico;
		[InlineEditor] public AbstractAnswer Answer;

		[ValueDropdown(nameof(GetNames), IsUniqueList = true, DropdownWidth = 250, SortDropdownItems = true)]
		public string AnswerType;
		
		static string[] GetNames()
		{
			return new List<string>()
				.Concat(TypeCache.GetTypesDerivedFrom<AbstractAnswer>()
				.Select(type => type.Name)).ToArray();
		}
		
		[Button]
		public void CreateAnswer()
		{
			var asset = CreateInstance(AnswerType);
			
			AssetDatabase.CreateAsset(asset, $"{AssetDatabase.GetAssetPath(this).Replace(name+".asset", "")}/{AnswerType}.asset");
			AssetDatabase.SaveAssets();
			Answer = (AbstractAnswer)asset;
			AssetDatabase.SaveAssets();
		}
	}

}