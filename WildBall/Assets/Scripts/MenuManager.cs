using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private Button playButton;

    private static bool _isPlayWasAlreadyClicked;

    private void Start()
    {
        if (_isPlayWasAlreadyClicked)
        {
            playButton.gameObject.SetActive(false);
            levelsPanel.gameObject.SetActive(true);
        }
    }

    public void OpenMenuPanel()
    {
        levelsPanel.SetActive(true);
        playButton.gameObject.SetActive(false);
    }

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
        _isPlayWasAlreadyClicked = true;
    }
}
