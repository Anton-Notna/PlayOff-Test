using Core.Game.Model;
using TMPro;
using UnityEngine;

namespace Core.Game.UI.LevelPopup
{
    public class RewardItemView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _info;

        public void Display(RewardModel reward)
        {
            _info.text = $"{reward.Type} x{reward.Amount}";
            gameObject.SetActive(true);
        }

        public void Hide() => gameObject.SetActive(false);
    }
}