using _Scripts.Answer;
using _Scripts.Answer.View;
using UnityEngine;

namespace _Scripts.Level._Question.CodeView
{
	public class CodeView : QuestionView
	{
		[SerializeField] private CodeBlockView _prefab;
		[SerializeField] private Transform _content;

		private CodeAnswer _codeAnswer;
		
		protected override void OnSetUp(AbstractAnswerView answerView, Question question)
		{
			_codeAnswer = (CodeAnswer)question.Answer;
			Init();
		}
		
		private void Init()
		{
			foreach (var codeBlock in _codeAnswer.CodeBlocks)
			{
				var c = Instantiate(_prefab, _content);
				c.Language.text = codeBlock.Language;
				c.Code.sprite = codeBlock.Code;
			}
		}
	}
}

