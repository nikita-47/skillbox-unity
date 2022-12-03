using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float harvestCycleTime;

    [SerializeField] private float foodCycleTime;

    [SerializeField] private float initialFoodCount;

    [SerializeField] private Image foodCycleImage;
    [SerializeField] private Image harvestCycleImage;

    private float _lastHarvestStartTime;
    private float _lastFoodEatingStartTime;

    // Managers
    [SerializeField] private TimerManager timerManager;
    [SerializeField] private CreateUnitManager createWarriorManager;
    [SerializeField] private CreateUnitManager createFarmerManager;

    // Farmer settings
    [SerializeField] private int workerCost;
    [SerializeField] private int workerTrainingTime;
    [SerializeField] private int oneWorkerPerformance;

    // Warrior settings
    [SerializeField] private float warriorFoodConsumingPerCycle;
    [SerializeField] private int warriorCost;
    [SerializeField] private int warriorTrainingTime;

    // Raid Settings
    [SerializeField] private int raidCycleTime;

    // Game State resources and units
    private int _warriorsCount;
    private int _workersCount;
    private float _foodCount;

    // Game statistics
    private int _winsCount;
    private int _loseCount;
    [SerializeField] private Text winCountText;
    [SerializeField] private Text loseCountText;

    // Texts for resources and units
    [SerializeField] private Text warriorsCountText;
    [SerializeField] private Text workersCountText;
    [SerializeField] private Text foodCountText;
    [SerializeField] private Text waveCountText;
    [SerializeField] private Text enemyCountText;

    // Waves settings
    private List<int> _enemyInWaves;
    private int _waveNumber;
    private int _enemiesCountInCurrentWave;
    private bool _isRaidInProgress;

    // UI panels
    [SerializeField] private GameObject gameStatusPanel;
    [SerializeField] private Text gameStatusText;
    [SerializeField] private GameObject raidStatusPanel;
    [SerializeField] private Text raidStatusText;
    [SerializeField] private GameObject descriptionPanel;

    // Audio clips
    [SerializeField] private AudioClip mainMusic;
    [SerializeField] private AudioClip eatCycleAudioClip;
    [SerializeField] private AudioClip farmerAudioClip;
    [SerializeField] private AudioClip harvestAudioClip;
    [SerializeField] private AudioClip warriorAudioClip;
    [SerializeField] private AudioClip winAudioClip;
    [SerializeField] private AudioClip loseAudioClip;

    private void Start()
    {
        gameStatusPanel.SetActive(false);
        TimerManager.OnFinished += FinishWave;

        createWarriorManager.BuildUnitCreator(
            warriorTrainingTime,
            warriorCost,
            () => _foodCount,
            () =>
            {
                _warriorsCount += 1;
                SoundManager.Instance.Play(warriorAudioClip);
            },
            () => { _foodCount -= warriorCost; }
        );

        createFarmerManager.BuildUnitCreator(
            workerTrainingTime,
            workerCost,
            () => _foodCount,
            () =>
            {
                _workersCount += 1;
                SoundManager.Instance.Play(farmerAudioClip);
            },
            () => { _foodCount -= workerCost; }
        );

        _isRaidInProgress = false;
        PauseGame();
    }

    /// <summary>
    /// Полная перезагрузка игры
    /// </summary>
    public void RefreshGame()
    {
        SoundManager.Instance.PlayMusic(mainMusic);
        _lastFoodEatingStartTime = 0;
        _lastHarvestStartTime = 0;
        _warriorsCount = 0;
        _workersCount = 0;
        _foodCount = initialFoodCount;
        gameStatusPanel.SetActive(false);
        _winsCount = 0;
        _loseCount = 0;
        winCountText.text = _winsCount.ToString();
        loseCountText.text = _loseCount.ToString();
        _waveNumber = 0;
        _enemyInWaves = new List<int> { 0, 0, 2, 6, 4, 3, 6, 8, 4, 10 };
        _foodCount = initialFoodCount;
        StartNewRaidCycle();
    }

    /// <summary>
    /// Завершение цикла рейда
    /// </summary>
    private void FinishWave()
    {
        var shouldPlayWinSound = false;
        if (_warriorsCount >= _enemiesCountInCurrentWave)
        {
            shouldPlayWinSound = true;
            raidStatusText.text = "Вы пережили волну!";
            _winsCount += 1;
            _warriorsCount -= _enemiesCountInCurrentWave;
        }
        else
        {
            raidStatusText.text = "Вы проиграли в этой волне!";
            _loseCount += 1;
            _warriorsCount = 0;
        }

        winCountText.text = _winsCount.ToString();
        loseCountText.text = _loseCount.ToString();
        _isRaidInProgress = false;
        PauseGame();

        if (_waveNumber == 10)
        {
            if (_winsCount > 5)
            {
                shouldPlayWinSound = true;
            }

            gameStatusPanel.SetActive(true);
            gameStatusText.text = _winsCount > 5 ? "Вы выиграли игру!" : "Вы проиграли!";
        }
        else
        {
            raidStatusPanel.SetActive(true);
        }

        SoundManager.Instance.Play(shouldPlayWinSound ? winAudioClip : loseAudioClip);
    }

    /// <summary>
    /// Запуск нового цикла рейда
    /// </summary>
    public void StartNewRaidCycle()
    {
        descriptionPanel.SetActive(false);
        gameStatusPanel.SetActive(false);
        raidStatusPanel.SetActive(false);
        _isRaidInProgress = true;
        ResumeGame();
        _waveNumber += 1;
        _enemiesCountInCurrentWave = _enemyInWaves.First();
        _enemyInWaves.RemoveAt(0);
        timerManager.StartTimer(raidCycleTime);
    }

    private void Update()
    {
        ProduceFood();
        EatFood();
        UpdateResourcePanel();
    }

    /// <summary>
    /// Обновить панель ресурсов
    /// </summary>
    private void UpdateResourcePanel()
    {
        waveCountText.text = _waveNumber.ToString();
        if (_enemyInWaves is { Count: > 0 })
        {
            enemyCountText.text = _enemiesCountInCurrentWave.ToString();
        }

        warriorsCountText.text = _warriorsCount.ToString();
        workersCountText.text = _workersCount.ToString();
        foodCountText.text = Math.Truncate(_foodCount).ToString();
    }

    /// <summary>
    /// Обработка цикла производства еды
    /// </summary>
    private void ProduceFood()
    {
        if (_lastHarvestStartTime == 0)
        {
            _lastHarvestStartTime = Time.time;
        }

        if (Time.time > _lastHarvestStartTime + harvestCycleTime && _workersCount > 0)
        {
            SoundManager.Instance.Play(harvestAudioClip);
            _foodCount += _workersCount * oneWorkerPerformance;
            _lastHarvestStartTime = 0;
            harvestCycleImage.fillAmount = 1;
        }
        else
        {
            harvestCycleImage.fillAmount = (Time.time - _lastHarvestStartTime) / harvestCycleTime;
        }
    }

    /// <summary>
    /// Обработка цикла потребления еды
    /// </summary>
    private void EatFood()
    {
        if (_lastFoodEatingStartTime == 0)
        {
            _lastFoodEatingStartTime = Time.time;
        }

        if (Time.time > _lastFoodEatingStartTime + foodCycleTime &&
            _foodCount >= _warriorsCount * warriorFoodConsumingPerCycle)
        {
            SoundManager.Instance.Play(eatCycleAudioClip);
            _foodCount -= _warriorsCount * warriorFoodConsumingPerCycle;
            _lastFoodEatingStartTime = 0;
            foodCycleImage.fillAmount = 1;
        }
        else
        {
            foodCycleImage.fillAmount = (Time.time - _lastFoodEatingStartTime) / foodCycleTime;
        }
    }

    public void ResumeGame()
    {
        if (_isRaidInProgress)
        {
            Time.timeScale = 1;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
}