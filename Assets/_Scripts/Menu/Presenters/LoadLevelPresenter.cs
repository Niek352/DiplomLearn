using _Scripts.Sound;
using _Scripts.Widgets;
using UnityEngine.SceneManagement;

namespace _Scripts.Menu.Presenters
{
	public class LoadLevelPresenter
	{
		private readonly ButtonWidget _buttonWidget;
		
		public LoadLevelPresenter(ButtonWidget buttonWidget)
		{
			_buttonWidget = buttonWidget;
		}

		public void Enable()
		{
			_buttonWidget.Button.onClick.AddListener(OnClick);
			_buttonWidget.Text.text = "Уровни";
		}
		
		private void OnClick()
		{
			SceneManager.LoadScene("Scenes/Levels");
			SoundManager.Instance.Play("Button");
		}

		public void Disable()
		{
			_buttonWidget.Button.onClick.RemoveListener(OnClick);
		}
	}

}