using _Scripts.Menu.Presenters;
using _Scripts.Menu.Settings;
using _Scripts.Ranking;
using _Scripts.Widgets;
using UnityEngine;

namespace _Scripts.Menu
{
	public class MenuController : MonoBehaviour
	{
		[SerializeField] private ButtonWidget _menuButtonPrefab;
		[SerializeField] private Transform _buttonHolder;
		[SerializeField] private SettingsPanel _settingsPanel;
		[SerializeField] private RankingPanel _rankingPanel;
		[SerializeField] private ProfilePanel _profilePanel;
		private LoadLevelPresenter _loadLevelPresenter;
		private RankingPresenter _rankingPresenter;
		private ExitPresenter _exitPresenter;
		private SettingsPresenter _settingsPresenter;
		private ProfilePresenter _profilePresenter;

		private void Awake()
		{
			CreateButtons();
		}
		
		private void CreateButtons()
		{
			var l = Instantiate(_menuButtonPrefab, _buttonHolder);
			_loadLevelPresenter = new LoadLevelPresenter(l);
			_loadLevelPresenter.Enable();
			
			var a = Instantiate(_menuButtonPrefab, _buttonHolder);
			_rankingPresenter = new RankingPresenter(a, _rankingPanel);
			_rankingPresenter.Enable();
			
			var s = Instantiate(_menuButtonPrefab, _buttonHolder);
			_settingsPresenter = new SettingsPresenter(s, _settingsPanel);
			_settingsPresenter.Enable();
			
			var p = Instantiate(_menuButtonPrefab, _buttonHolder);
			_profilePresenter = new ProfilePresenter(p, _profilePanel);
			_profilePresenter.Enable();
			
			var e = Instantiate(_menuButtonPrefab, _buttonHolder);
			_exitPresenter = new ExitPresenter(e);
			_exitPresenter.Enable();
		}
	}
}