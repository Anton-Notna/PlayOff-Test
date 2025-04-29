using Core.Game.Model;
using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.Game.UI.MainUI
{
    public class MainUIController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _level;
        [SerializeField]
        private Button _refresh;

        public event UnityAction OnRefresh
        {
            add => _refresh.onClick.AddListener(value);
            remove => _refresh.onClick.RemoveListener(value);
        }

        public IObservable<Unit> OnRefreshAsObservable() => 
            Observable.FromEvent<UnityAction, Unit>(handler => () => handler(Unit.Default), handler => OnRefresh += handler, handler => OnRefresh -= handler);

        public void Display(LevelModel level) => _level.text = $"Level {level.Index}";
    }
}