namespace Core.Game.Model
{
    public struct RewardModel
    {
        public RewardType Type;
        public int Amount;

        public RewardModel(RewardType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}