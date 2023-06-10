using _Scripts.Menu.Settings;
using _Scripts.Sound;
using _Scripts.Widgets;

namespace _Scripts.Menu.Presenters
{
	public class SettingsPresenter
	{
		private readonly ButtonWidget _buttonWidget;
		private readonly SettingsPanel _settingsPanel;

		public SettingsPresenter(ButtonWidget buttonWidget, SettingsPanel settingsPanel)
		{
			_buttonWidget = buttonWidget;
			_settingsPanel = settingsPanel;
		}

		public void Enable()
		{
			_buttonWidget.Button.onClick.AddListener(OnClick);
			_buttonWidget.Text.text = "Настройки";
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