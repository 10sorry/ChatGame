using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChatScene()
    {
        SceneManager.LoadScene("ChatScene");
    }

    public void MusicScene()
    {
        SceneManager.LoadScene("Music");
    }
    
    public void ImagesScene()
    {
        SceneManager.LoadScene("Images");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("Start");
    }

}
