using Core.Game.Model;

namespace Core.Game.Services
{
    public interface ILevelService
    {
        public LevelModel Generate(int currentLevelIndex);
    }
}