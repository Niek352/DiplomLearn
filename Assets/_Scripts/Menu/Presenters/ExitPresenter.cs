using _Scripts.Sound;
using _Scripts.Widgets;
using UnityEngine;

namespace _Scripts.Menu.Presenters
{
	public class ExitPresenter
	{
		private readonly ButtonWidget _buttonWidget;
		
		public ExitPresenter(ButtonWidget buttonWidget)
		{
			_buttonWidget = buttonWidget;
		}

		public void Enable()
		{
			_buttonWidget.Button.onClick.AddListener(OnClick);
			_buttonWidget.Text.text = "Выход";
		}
		
		private void OnClick()
		{
			Application.Quit();
			SoundManager.Instance.Play("Button");
		}

		public void Disable()
		{
			_buttonWidget.Button.onClick.RemoveListener(OnClick);
		}
	}
}