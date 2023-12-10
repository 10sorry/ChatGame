using System;
using UnityEngine;

public class StartUP : MonoBehaviour
{
    private static StartUP instance;

    public static StartUP Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StartUP>();

                if (instance == null)
                {
                    Debug.LogError("MusicManager is not present in the scene.");
                }
            }

            return instance;
        }
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
    
   

}