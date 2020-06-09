using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class musicController : MonoBehaviour
{
    public AudioMixer music;
    public AudioSource songIntro;
    public AudioSource songLoop;
    // Start is called before the first frame update
    void Start()
    {
        resetMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (songIntro.isPlaying==false) {
            songIntro.gameObject.SetActive(false);
            songLoop.gameObject.SetActive(true);
        }
    }
    public void resetMusic() {
        songIntro.gameObject.SetActive(true);
        songLoop.gameObject.SetActive(false);
    }
    public void setPitch(float value) {
        music.SetFloat("MusicPitch",value);
    }
    public void setReverb(float value) {
    }
}
