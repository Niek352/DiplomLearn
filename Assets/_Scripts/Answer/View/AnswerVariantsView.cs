using System;
using Random = UnityEngine.Random;

namespace _Scripts.Answer.View
{

	public class AnswerVariantsView : AbstractAnswerView
	{
		public AnswerButton[] Buttons;
		public override event Action<string> CheckAnswer;

		public void SetUp(AnswerVariants answerVariants)
		{
			for (var i = 0; i < answerVariants.Variants.Length; i++)
			{
				var variant = answerVariants.Variants[i];
				Buttons[i].Text.text = variant;
			}

			Buttons[Random.Range(0, Buttons.Length)].Text.text = answerVariants.Answer;

			foreach (var button in Buttons)
			{
				button.OnClickAnswer += OnClick;
			}
		}
		
		private void OnClick(AnswerButton s)
		{
			CheckAnswer?.Invoke(s.Text.text);
		}
	}
}