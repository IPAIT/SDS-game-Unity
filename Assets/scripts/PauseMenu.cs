using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Ссылка на панель меню
    public Slider volumeSlider;    // Ползунок громкости

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false); // Скрываем меню при старте
        volumeSlider.value = AudioListener.volume; // Устанавливаем текущую громкость
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Возвращаем нормальную скорость игры
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Останавливаем время
        isPaused = true;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Меняем громкость звука
    }

    public void QuitGame()
    {
        Application.Quit(); // Закрываем игру
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Останавливаем игру в редакторе
        #endif
    }
}
