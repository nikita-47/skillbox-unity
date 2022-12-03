using UnityEngine;
using UnityEngine.UI;

public class CreateUnitManager : MonoBehaviour
{
    private bool _isTrainInProgress;
    private int _unitCost;
    private int _trainingTime;
    private float _lastTrainStartTime;

    [SerializeField] private Text priceText;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private Image progressImage;
    [SerializeField] private Button button;

    public delegate void UnitCreationFinished();
    private event UnitCreationFinished OnCreated;

    public delegate void UnitCreationStarted();
    private event UnitCreationStarted OnStarted;

    public delegate float GetFoodCountDelegate();
    private GetFoodCountDelegate _getFoodCount;

    private void Start()
    {
        _isTrainInProgress = false;
        button.onClick.AddListener(TrainUnitClick);
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateButtonInteractable();
        
        if (Time.timeScale == 0) return;
        
        if (!_isTrainInProgress) return;
        
        if (Time.time - _lastTrainStartTime > _trainingTime)
        {
            _isTrainInProgress = false;
            OnCreated?.Invoke();
            progressImage.fillAmount = 1f;
        }
        else
        {
            progressImage.fillAmount = (Time.time - _lastTrainStartTime) / _trainingTime;
        }
    }

    private void UpdateButtonInteractable()
    {
        button.interactable = !(_getFoodCount() < _unitCost) && !_isTrainInProgress && Time.timeScale != 0;
    }

    /// <summary>
    /// Настроить инстанс строителя инюта 
    /// </summary>
    /// <param name="trainTime">Время создания юнита</param>
    /// <param name="unitCost">Стоиомсть юнита</param>
    /// <param name="getFoodCount">Функция получения текущего количества юнитов</param>
    /// <param name="onCreationFinished">Callback - юнит создан</param>
    /// <param name="onCreationStarted">Callback - юнит начал создаваться</param>
    public void BuildUnitCreator(
        int trainTime, 
        int unitCost,
        GetFoodCountDelegate getFoodCount,
        UnitCreationFinished onCreationFinished,
        UnitCreationStarted onCreationStarted)
    {
        _trainingTime = trainTime;
        _unitCost = unitCost;
        _getFoodCount = getFoodCount;
        OnCreated += onCreationFinished;
        OnStarted += onCreationStarted;
        priceText.text = $"Стоимость - {unitCost}";
    }

    private void TrainUnitClick()
    {
        if (_isTrainInProgress) return;

        if (_getFoodCount() < _unitCost) return;
        
        if (Time.timeScale == 0) return;

        SoundManager.Instance.Play(clickClip);

        progressImage.fillAmount = 0f;
        _isTrainInProgress = true;
        OnStarted?.Invoke();
        _lastTrainStartTime = Time.time;
    }
}
