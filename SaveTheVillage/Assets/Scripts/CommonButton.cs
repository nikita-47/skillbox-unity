using UnityEngine;
using UnityEngine.UI;

public class CommonButton : MonoBehaviour
{
    [SerializeField] private AudioClip clickClip;

    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SoundManager.Instance.Play(clickClip);
    }
}
