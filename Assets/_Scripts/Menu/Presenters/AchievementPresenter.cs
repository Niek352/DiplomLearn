using _Scripts.Sound;
using _Scripts.Widgets;

namespace _Scripts.Menu.Presenters
{
	public class AchievementPresenter
	{
		private readonly ButtonWidget _buttonWidget;
		
		public AchievementPresenter(ButtonWidget buttonWidget)
		{
			_buttonWidget = buttonWidget;
		}

		public void Enable()
		{
			_buttonWidget.Button.onClick.AddListener(OnClick);
			_buttonWidget.Text.text = "Достижения";
		}
		
		private void OnClick()
		{
			SoundManager.Instance.Play("Button");
		}

		public void Disable()
		{
			_buttonWidget.Button.onClick.RemoveListener(OnClick);
		}
	}

}