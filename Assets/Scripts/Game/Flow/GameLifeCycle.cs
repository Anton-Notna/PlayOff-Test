using Core.Game.Model;
using Core.Game.Services;
using Core.Game.UI.LevelPopup;
using Core.Game.UI.MainUI;
using System;
using UniRx;
using Zenject;

namespace Core.Game.Flow
{
    public class GameLifeCycle : IInitializable, IDisposable
    {
        private ILevelService _levelService;
        private MainUIController _mainUI;
        private LevelPopupController _popupUI;
        private CompositeDisposable _subs = new CompositeDisposable();
        private int _currentIndex = LevelModel.MinLevel;

        public GameLifeCycle(ILevelService levelService, MainUIController mainUI, LevelPopupController levelPopup)
        {
            _levelService = levelService;
            _mainUI = mainUI;
            _popupUI = levelPopup;
        }

        public void Initialize()
        {
            LevelModel first = _levelService.Generate(_currentIndex);
            _mainUI.Display(first);
            _popupUI.Close();

            _mainUI.OnRefreshAsObservable()
                .SelectMany(_ =>
                    Observable.Defer(() =>
                    {
                        _currentIndex++;
                        LevelModel model = _levelService.Generate(_currentIndex);
                        _popupUI.Display(model);
                        return _popupUI.OnSelectAsObservable().Take(1).Select(_ => model);
                    })
                    .Do(model =>
                    {
                        _popupUI.Close();
                        _mainUI.Display(model);
                    })
                )
                .Repeat()
                .Subscribe()
                .AddTo(_subs);
        }

        public void Dispose() => _subs.Dispose();
    }
}