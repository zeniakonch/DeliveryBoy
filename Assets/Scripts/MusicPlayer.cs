using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerMenu : MonoBehaviour
{
    public GameObject musicPlayerPanel;
    public Button playButton;
    public Button pauseButton;
    public Button nextButton;
    public Button previousButton;
    public AudioSource audioSource;
    public AudioClip[] tracks;

    private int _currentTrackIndex = 0;
    private bool _isMenuVisible = false;

    private void Start()
    {
        // Добавьте обработчики событий кнопок
        playButton.onClick.AddListener(PlayTrack);
        pauseButton.onClick.AddListener(PauseTrack);
        nextButton.onClick.AddListener(NextTrack);
        previousButton.onClick.AddListener(PreviousTrack);

        // Воспроизведение первого трека при запуске
        if (tracks.Length > 0)
        {
            audioSource.clip = tracks[_currentTrackIndex];
        }

        // Настройка панели на центр экрана
        RectTransform rectTransform = musicPlayerPanel.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;

        // Скрыть меню плеера при запуске
        musicPlayerPanel.SetActive(false);
    }

    private void Update()
    {
        // Открытие/закрытие меню по нажатию кнопки T
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        _isMenuVisible = !_isMenuVisible;
        musicPlayerPanel.SetActive(_isMenuVisible);
        Debug.Log($"Music Player Menu toggled: {(_isMenuVisible ? "Opened" : "Closed")}");
    }

    private void PlayTrack()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void PauseTrack()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    private void NextTrack()
    {
        if (tracks.Length > 0)
        {
            _currentTrackIndex = (_currentTrackIndex + 1) % tracks.Length;
            audioSource.clip = tracks[_currentTrackIndex];
            audioSource.Play();
        }
    }

    private void PreviousTrack()
    {
        if (tracks.Length > 0)
        {
            _currentTrackIndex = (_currentTrackIndex - 1 + tracks.Length) % tracks.Length;
            audioSource.clip = tracks[_currentTrackIndex];
            audioSource.Play();
        }
    }
}
