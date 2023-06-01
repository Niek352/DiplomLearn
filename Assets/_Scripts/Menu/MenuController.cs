using _Scripts.Menu.Presenters;
using _Scripts.Widgets;
using UnityEngine;

namespace _Scripts.Menu
{
	public class MenuController : MonoBehaviour
	{
		[SerializeField] private ButtonWidget _menuButtonPrefab;
		[SerializeField] private Transform _buttonHolder;
		private LoadLevelPresenter _loadLevelPresenter;
		private AchievementPresenter _achievementPresenter;
		private ExitPresenter _exitPresenter;

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
			_achievementPresenter = new AchievementPresenter(a);
			_achievementPresenter.Enable();
			
			var e = Instantiate(_menuButtonPrefab, _buttonHolder);
			_exitPresenter = new ExitPresenter(e);
			_exitPresenter.Enable();
		}
	}
}