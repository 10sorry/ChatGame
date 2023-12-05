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
        SceneManager.LoadScene("Chat");
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

    public void PrivateChat()
    {
        SceneManager.LoadScene("PrivateChat");
    }
    
    public void Quotes()
    {
        SceneManager.LoadScene("Quotes");
    }
    
    public void Jokes()
    {
        SceneManager.LoadScene("Jokes");
    }
    
    public void BestF()
    {
        SceneManager.LoadScene("BestF");
    }
    

}
