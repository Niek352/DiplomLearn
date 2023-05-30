using System;
using _Scripts.Sound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Answer.View
{
	public class AnswerButton : MonoBehaviour
	{
		public Button Button;
		public TextMeshProUGUI Text;
		public string AudioName = "Button";
		public event Action<AnswerButton> OnClickAnswer; 
		
		private void Start()
		{
			Button.onClick.AddListener(OnClick);
		}
		
		private void OnClick()
		{
			SoundManager.Instance.Play(AudioName);
			OnClickAnswer?.Invoke(this);
		}
	}
}