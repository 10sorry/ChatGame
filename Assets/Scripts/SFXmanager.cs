using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private static SFXManager instance;

    public static SFXManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SFXManager>();

                if (instance == null)
                {
                    Debug.LogError("MusicManager is not present in the scene.");
                }
            }

            return instance;
        }
        
    }
    
    [SerializeField] private AudioClip[] sfx;
    private AudioSource audioSource;
   

    
 
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

  

  
    public void StartButton()
    {
        audioSource.PlayOneShot(sfx[0]);
    }
    
    public void UIButton()
    {
        audioSource.PlayOneShot(sfx[2]);
    }

    public void ErrorButton()
    {
        audioSource.PlayOneShot(sfx[3]);
    }

}