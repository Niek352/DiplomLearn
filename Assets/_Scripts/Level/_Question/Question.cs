using System.Collections.Generic;
using System.Linq;
using _Scripts.Answer;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace _Scripts.Level._Question
{
	[CreateAssetMenu(menuName = "Data/" + nameof(Question), fileName = nameof(Question))]
	public class Question : ScriptableObject
	{
		public QuestionType QuestionType;
		public string QuestionId;
		public string Url;
		[TextArea(10, 100)]
		public string Text;
		public Sprite[] Ico;
		[InlineEditor] public AbstractAnswer Answer;

#if UNITY_EDITOR
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
			var path = AssetDatabase.GenerateUniqueAssetPath($"{AssetDatabase.GetAssetPath(this).Replace(name+".asset", "")}/{AnswerType}.asset");
			AssetDatabase.CreateAsset(asset, path);
			AssetDatabase.SaveAssets();
			Answer = (AbstractAnswer)asset;
			EditorUtility.SetDirty(Answer);
			AssetDatabase.SaveAssets();
		}
		
		[Button]
		public void OpenURL()
		{
			Application.OpenURL(Url);
		}
		
		[Button]
		public void FixText()
		{
			Text = Text.Replace("ё", "е");
		}
#endif

	}

	public enum QuestionType
	{
		Type1,
		Type2,
		Type3,
		Type4,
		Type5,
		Type6,
		Type7,
		Type8,
		Type9,
		Type10,
		Type11,
		Type12,
	}
}