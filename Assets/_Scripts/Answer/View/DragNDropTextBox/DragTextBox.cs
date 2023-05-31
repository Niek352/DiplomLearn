using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Answer.View.DragNDropTextBox
{
	public class DragTextBox : MonoBehaviour
	{
		public Button Button;
		public string Text;
		public TextMeshProUGUI Fake;
		public TextMeshProUGUI True;
		public event Action<DragTextBox> OnClick;
		public bool IsActive;
		
		private void OnValidate()
		{
			UpdateText();
		}
		
		public void SetUp(string text)
		{
			Text = text;
			UpdateText();
			Button.onClick.AddListener(OnClickBtn);
		}

		private void OnClickBtn()
		{
			OnClick?.Invoke(this);
			IsActive = !IsActive;
			Button.image.color = IsActive ? Color.gray : Color.white;
		}
		
		private void UpdateText()
		{
			True.text = Text;
			Fake.text = True.text;
		}
	}
}