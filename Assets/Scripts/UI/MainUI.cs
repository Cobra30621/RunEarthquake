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
        [SerializeField] private TextMeshProUGUI phase, phaseCount;
        [SerializeField] private GameProgressHandler _gameProgressHandler;

        [SerializeField] private HealthUI _healthUI;
        private void Awake()
        {
            PlayerStatus.OnHealthChanged.AddListener(UpdateHealth);
        }

        private void Start()
        {
            UpdateUI();
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
            _healthUI.UpdateHealth(value);
        }
    }
}