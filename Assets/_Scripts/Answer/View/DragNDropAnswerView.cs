using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Answer.View.DragNDropTextBox;
using TMPro;
using UnityEngine;

namespace _Scripts.Answer.View
{
	public class DragNDropAnswerView : AbstractAnswerView
	{
		[SerializeField] private DragTextBox _textBoxPrefab;
		[SerializeField] private Transform _holder;
		private readonly List<DragTextBox> _all = new List<DragTextBox>();
		public override event Action<string> CheckAnswer;
		public AnswerButton AnswerButton;
		public List<DragTextBox> Answers;
		public TextMeshProUGUI AnswerText;
		
		public string Ans => Answers.Count == 0 ? "" :
			Answers.Select(s => s.Text).Aggregate((s, s1) => s + s1);

		public void SetUp(DragNDropVariants answer)
		{
			foreach (var v in answer.Variants)
			{
				var variant = Instantiate(_textBoxPrefab, _holder);
				variant.SetUp(v);
				variant.OnClick += OnClickAnswer;
				_all.Add(variant);
			}
			
			AnswerButton.Button.interactable = false;
			AnswerButton.OnClickAnswer += OnClickAnswer;
		}
		
		private void OnClickAnswer(DragTextBox obj)
		{
			if (Answers.Contains(obj))
			{
				Answers.Remove(obj);
			}
			else
			{
				Answers.Add(obj);
			}
			AnswerText.text = Ans;
			AnswerButton.Button.interactable = Answers.Count == _all.Count;
		}

		private void OnClickAnswer(AnswerButton obj)
		{
			CheckAnswer?.Invoke(Ans);
		}
	}
}