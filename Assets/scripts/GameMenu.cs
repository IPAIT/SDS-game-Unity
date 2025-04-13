using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("OurGame"); // Имя вашей сцены
    }

    public void OpenSettings(GameObject settingsPanel)
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings(GameObject settingsPanel)
    {
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Остановка в редакторе
#endif
    }
    public GameObject settingsPanel; // Панель с настройками

    public void OpenSettings()
    {
        settingsPanel.SetActive(true); // Включаем панель
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // Выключаем панель
    }
}
