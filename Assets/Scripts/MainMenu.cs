using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitButton()
    {
        Debug.Log("Oyun Kapatılıyor!");
        Application.Quit();
    }
}
