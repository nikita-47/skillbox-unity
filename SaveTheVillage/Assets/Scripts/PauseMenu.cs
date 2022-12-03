using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button soundButton;
    [SerializeField] private Sprite checkboxOnImage;
    [SerializeField] private Sprite checkboxOffImage;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameManager gameManager;
    
    private void Start()
    {
        soundButton.GetComponent<Image>().sprite = SoundManager.Instance.IsMute ? checkboxOffImage : checkboxOnImage;
    }

    /// <summary>
    /// Вкл/выкл звука
    /// </summary>
    public void OnToggleSoundClick()
    {
        SoundManager.Instance.IsMute = !SoundManager.Instance.IsMute;
        soundButton.GetComponent<Image>().sprite = SoundManager.Instance.IsMute ? checkboxOffImage : checkboxOnImage;
    }

    /// <summary>
    /// Продолжить игру (Time.timeScale = 1)
    /// </summary>
    public void OnResumeButtonClick()
    {
        gameManager.ResumeGame();
        pausePanel.SetActive(false);
    }

    /// <summary>
    /// Пауза игры (Time.timeScale = 0)
    /// </summary>
    public void OnPauseButtonClick()
    {
        gameManager.PauseGame();
        pausePanel.SetActive(true);
    }
}
