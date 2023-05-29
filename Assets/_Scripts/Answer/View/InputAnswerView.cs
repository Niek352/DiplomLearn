using System;
using TMPro;

namespace _Scripts.Answer.View
{
	public class InputAnswerView : AbstractAnswerView
	{
		public TMP_InputField InputField;
		public AnswerButton AnswerButton; 
		
		public override event Action<string> CheckAnswer;
		
		private void Start()
		{
			AnswerButton.OnClickAnswer += OnAnsClick;	
		}
		
		private void OnAnsClick(AnswerButton obj)
		{
			if (string.IsNullOrEmpty(InputField.text))
			{
				return;
			}
			CheckAnswer?.Invoke(InputField.text.Trim().ToLowerInvariant());
		}
	}
}