using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    static SoundManager _instance = null;
    /// <summary>
    /// 
    /// CHANGE THE SCENE NAMES TO ACT ACCORDINGLY
    /// 
    /// </summary>
    //Music goes here
    public AudioClip mainTheme;
    //public AudioClip lvlTheme;
    public AudioClip End;


    //Sound goes here
    //Character Audio
   

    //World Audio
    //Here is where you can call sounds for the world
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;


    //Source
    public AudioSource music;
    public AudioSource SFX;
    // Use this for initialization
    void Start()
    {

        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;

            DontDestroyOnLoad(this);
        }

        MusicCaller("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name != "Start")
        {
            music.volume = 0.3f;
        }

        if (SceneManager.GetActiveScene().name != "Arena")
        {
            music.volume = 0.3f;
        }

        if (SceneManager.GetActiveScene().name == "End")
        {
            MusicCaller("EndTheme", 0.5f);
        }

        
        /*
                if (SceneManager.GetActiveScene().name == "" && !music.isPlaying)
                {
                    music.Play();
                }

                if (SceneManager.GetActiveScene().name == "")
                {
                    if (music.isPlaying)
                    {

                    }
                }
                */
    }

    public static SoundManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    ///<summary>
    ///<para>Give the name of the clip to be played (Teleport, Fire, Death, Jump).</para>
    ///</summary>
    public void SoundCaller(string clipName, float volume = 1.0f)
    {
        switch (clipName)
        {
            case "Sound3":
                playSingleSound(sound3, volume);

                break;
            case "Sound2":
                playSingleSound(sound2, volume);

                break;
            case "Sound1":
                playSingleSound(sound1, volume);

                break;
          
        }
    }

    ///<summary>
    ///<para>Give the name of the clip to be played (MainTheme, LevelMusic).</para>
    ///</summary>
    public void MusicCaller(string clipName, float volume = 1.0f)
    {
        switch (clipName)
        {
            case "MainTheme":
                playMusic(mainTheme, volume);

                break;
            case "EndTheme":
                playMusic(End, volume);

                break;
        }
    }

    private void playSingleSound(AudioClip clip, float volume = 1.0f)
    {
        // Assign volume to AudioSource volume
        SFX.volume = volume;

        // Assign AudioClip to AudioSource clip
        SFX.clip = clip;

        // Play assigned AudioClip through AudioSource on SoundManager
        SFX.Play();
    }

    private void playMusic(AudioClip clip, float volume = 1.0f)
    {
        // Assign volume to AudioSource volume
        music.volume = volume;

        // Assign AudioClip to AudioSource clip
        music.clip = clip;

        // Play assigned AudioClip through AudioSource on SoundManager
        music.Play();
    }
}

