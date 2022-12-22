using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePanel;

    public void OnResumeClick()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    
    public void OnPauseClick()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void OnOpenMainMenuClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
