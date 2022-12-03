using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _effectsSource;
    private AudioSource _musicSource;
    
    private bool _isMute;

    // Singleton instance
    public static SoundManager Instance { get; private set; }

    public bool IsMute
    {
        get => _isMute;
        set
        {
            _effectsSource.mute = value;
            _musicSource.mute = value;
            _isMute = value;
        }
    }

    private void Start()
    {
        _isMute = false;
        var components = GetComponents<AudioSource>(); 
        _effectsSource = components[0];
        _musicSource = components[1];
        Instance = this;
    }
    
    /// <summary>
    /// Воспроизвести один звук
    /// </summary>
    public void Play(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }
    
    /// <summary>
    /// Воспроизвести музыку
    /// </summary>
    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();
        _musicSource.loop = true;
    }
}
