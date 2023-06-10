using TMPro;
using UnityEngine;

namespace _Scripts.Ranking
{
	public class RankingItem : MonoBehaviour
	{
		public TextMeshProUGUI Name;
		public TextMeshProUGUI Score;
		public TextMeshProUGUI Place;

		public void SetUp(string nam, string score, string place)
		{
			Name.text = nam;
			Score.text = score;
			Place.text = place;
		}
	}
}