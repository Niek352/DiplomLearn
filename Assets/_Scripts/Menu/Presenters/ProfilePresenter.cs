using _Scripts.Sound;
using _Scripts.Widgets;

namespace _Scripts.Menu.Presenters
{
	public class ProfilePresenter
	{
		private readonly ButtonWidget _buttonWidget;
		private readonly ProfilePanel _settingsPanel;

		public ProfilePresenter(ButtonWidget buttonWidget, ProfilePanel settingsPanel)
		{
			_buttonWidget = buttonWidget;
			_settingsPanel = settingsPanel;
		}

		public void Enable()
		{
			_buttonWidget.Button.onClick.AddListener(OnClick);
			_buttonWidget.Text.text = "Профиль";
		}
		
		private void OnClick()
		{
			SoundManager.Instance.Play("Button");
			_settingsPanel.Show();
		}

		public void Disable()
		{
			_buttonWidget.Button.onClick.RemoveListener(OnClick);
		}
	}
}