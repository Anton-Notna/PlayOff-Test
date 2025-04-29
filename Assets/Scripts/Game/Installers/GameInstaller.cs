using Core.Game.Flow;
using Core.Game.Infrastructure.Services;
using Core.Game.Services;
using Core.Game.UI.LevelPopup;
using Core.Game.UI.MainUI;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private LevelService _levelService;
        [SerializeField]
        private MainUIController _mainUI;
        [SerializeField]
        private LevelPopupController _popup;

        public override void InstallBindings()
        {
            Container.Bind<ILevelService>().FromInstance(_levelService).AsSingle();
            Container.BindInstance(_mainUI).AsSingle();
            Container.BindInstance(_popup).AsSingle();
            Container.BindInterfacesTo<GameLifeCycle>().AsSingle().NonLazy();
        }
    }
}