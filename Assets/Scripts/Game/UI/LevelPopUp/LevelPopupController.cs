using Core.Game.Model;
using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.Game.UI.LevelPopup
{
    public class LevelPopupController : MonoBehaviour
    {
        private readonly List<RewardItemView> _spawnedUnits = new List<RewardItemView>();

        [SerializeField]
        private Canvas _root;
        [SerializeField]
        private TextMeshProUGUI _level;
        [SerializeField]
        private Button _select;
        [SerializeField]
        private RewardItemView _rewardPrefab;
        [SerializeField]
        private Transform _rewardsRoot;

        public event UnityAction OnSelect
        {
            add => _select.onClick.AddListener(value);
            remove => _select.onClick.RemoveListener(value);
        }

        public IObservable<Unit> OnSelectAsObservable() =>
            Observable.FromEvent<UnityAction, Unit>(handler => () => handler(Unit.Default), h => OnSelect += h, h => OnSelect -= h);

        public void Display(LevelModel level)
        {
            _level.text = $"Level {level.Index}";

            for (int i = 0; i < level.Reward.Count; i++)
                GetActiveUnit(i).Display(level.Reward[i]);

            for (int i = level.Reward.Count; i < _spawnedUnits.Count; i++)
                _spawnedUnits[i].Hide();

            _root.enabled = true;
        }

        public void Close() => _root.enabled = false;

        private RewardItemView GetActiveUnit(int index)
        {
            while (_spawnedUnits.Count <= index)
                _spawnedUnits.Add(Instantiate(_rewardPrefab, _rewardsRoot));

            return _spawnedUnits[index];
        }
    }
}