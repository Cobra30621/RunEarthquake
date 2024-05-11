using System;
using GameProgress;
using Player;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MainUI : SerializedMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI phase, phaseCount, health;
        [SerializeField] private GameProgressHandler _gameProgressHandler;


        private void Start()
        {
            PlayerStatus.OnHealthChanged.AddListener(UpdateHealth);
        }

        private void Update()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            phase.text = _gameProgressHandler.CurrentStateType == StateType.Preparing ? "準備階段" : "地震中";
            phaseCount.text = $"你已撐過第 {_gameProgressHandler.CurrentPhase} 波地震";
            
        }

        private void UpdateHealth(int value)
        {
            health.text = $"生命：{value}";
        }
    }
}