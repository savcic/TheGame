using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
    static MusicPlayer instance = null; //instanta incepe cu nimic
	
    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

	void Start () {
		if (instance != null && instance != this) { //daca instanta are ceva in ea SI instanta nu este egala cu gameobjectul curent
			Destroy (gameObject); //distruge
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this; //instanta egala cu asta
			GameObject.DontDestroyOnLoad(gameObject); //nu distruge gameobjectul asta on load
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
		}
		
	}

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("MusicPlayer: loaded level " + level);
        music.Stop();
        if(level == 0)
        {
            music.clip = startClip;
        }
        if(level == 1)
        {
            music.clip = gameClip;
        }
        if(level == 2)
        {
            music.clip = endClip;
        }
        music.loop = true;
        music.Play();
    }
}
