using System;
using System.Collections.Generic;

namespace Core.Game.Model
{
    public class LevelModel
    {
        public const int MinLevel = 1;

        private readonly List<RewardModel> _reward;

        public LevelModel(int index, IEnumerable<RewardModel> reward)
        {
            if (index < MinLevel)
                throw new ArgumentException($"Level index below {MinLevel}");

            if (reward == null)
                throw new ArgumentNullException(nameof(reward));

            Index = index;
            _reward = new List<RewardModel>(reward);
        }

        public int Index { get; }

        public IReadOnlyList<RewardModel> Reward => _reward;
    }
}