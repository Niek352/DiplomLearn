using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Answer.View
{
	public class AnswerButton : MonoBehaviour
	{
		public Button Button;
		public TextMeshProUGUI Text;

		public event Action<AnswerButton> OnClickAnswer; 
		
		private void Start()
		{
			Button.onClick.AddListener(OnClick);
		}
		
		private void OnClick()
		{
			OnClickAnswer?.Invoke(this);
		}
	}
}