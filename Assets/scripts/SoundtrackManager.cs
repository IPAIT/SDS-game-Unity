using UnityEngine;
using UnityEngine.UI;

public class SoundtrackManager : MonoBehaviour
{
    // Массив с аудиофайлами (треками)
    public AudioClip[] tracks;

    // Компонент AudioSource
    private AudioSource audioSource;

    // Индекс текущего трека
    private int currentTrackIndex = 0;

    // Кнопка для переключения трека
    public Button nextTrackButton;

    // Опция для зацикливания текущего трека (по умолчанию false)
    public bool isLoopingTrack = false;

    private void Start()
    {
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();

        // Добавляем обработчик на кнопку для переключения трека
        if (nextTrackButton != null)
        {
            nextTrackButton.onClick.AddListener(SwitchToNextTrack);
        }

        // Начинаем воспроизведение первого трека
        PlayTrack(currentTrackIndex);
    }

    private void Update()
    {
        // Если трек завершился и не установлен флаг зацикливания, переключаемся на следующий
        if (!audioSource.isPlaying && !isLoopingTrack)
        {
            SwitchToNextTrack();
        }
    }

    // Метод для переключения на следующий трек
    public void SwitchToNextTrack()
    {
        // Увеличиваем индекс и переходим к следующему треку (цикл)
        currentTrackIndex = (currentTrackIndex + 1) % tracks.Length;
        Debug.Log("Button clicked");
        // Воспроизводим следующий трек
        PlayTrack(currentTrackIndex);
    }

    // Метод для воспроизведения трека по индексу
    private void PlayTrack(int trackIndex)
    {
        // Устанавливаем новый трек
        audioSource.clip = tracks[trackIndex];
        audioSource.Play();

        // Если трек не зацикливается, продолжаем переключение
        if (!isLoopingTrack)
        {
            audioSource.loop = false;
        }
        else
        {
            audioSource.loop = true;
        }
    }
}
