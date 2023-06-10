using _Scripts.Ranking;
using _Scripts.Sound;
using _Scripts.Widgets;

namespace _Scripts.Menu.Presenters
{
	public class RankingPresenter
	{
		private readonly ButtonWidget _buttonWidget;
		private readonly RankingPanel _rankingPanel;

		public RankingPresenter(ButtonWidget buttonWidget, RankingPanel rankingPanel)
		{
			_buttonWidget = buttonWidget;
			_rankingPanel = rankingPanel;
		}

		public void Enable()
		{
			_buttonWidget.Button.onClick.AddListener(OnClick);
			_buttonWidget.Text.text = "Рейтинг";
		}
		
		private void OnClick()
		{
			SoundManager.Instance.Play("Button");
			_rankingPanel.Show();
		}

		public void Disable()
		{
			_buttonWidget.Button.onClick.RemoveListener(OnClick);
		}
	}

}