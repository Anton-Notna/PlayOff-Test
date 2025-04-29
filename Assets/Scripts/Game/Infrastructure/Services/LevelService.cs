using Core.Game.Model;
using Core.Game.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Game.Infrastructure.Services 
{
    [CreateAssetMenu(fileName = "LevelService", menuName = "Scriptable Objects/LevelService")]
    public class LevelService : ScriptableObject, ILevelService
    {
        [SerializeField]
        private List<RewardType> _possibleRewards = new List<RewardType>();
        [SerializeField]
        private int _minAmount;
        [SerializeField]
        private int _maxAmount;

        private System.Random _random;

        public LevelModel Generate(int currentLevelIndex)
        {
            if (_random == null)
                _random = new System.Random();

            List<RewardModel> rewards = new List<RewardModel>();
            for (int i = 0; i < _possibleRewards.Count; i++)
            {
                int amount = _random.Next(_minAmount, _maxAmount);
                if (amount == 0)
                    continue;

                rewards.Add(new RewardModel(_possibleRewards[i], amount));
            }

            return new LevelModel(currentLevelIndex, rewards);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_minAmount < 0)
                _minAmount = 0;

            if (_maxAmount < _minAmount)
                _maxAmount = _minAmount;
        }
#endif

    }
}
