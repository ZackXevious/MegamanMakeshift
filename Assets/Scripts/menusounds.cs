using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menusounds : MonoBehaviour
{
    AudioSource menuSoundSource;
    public AudioClip select;
    public AudioClip confirm;
    public AudioClip back;
    // Start is called before the first frame update
    void Start()
    {
        menuSoundSource = this.GetComponent<AudioSource>();
    }

    public void playSelectSound() {
        menuSoundSource.PlayOneShot(select,.75f);
    }
    public void playConfirmSound() {
        menuSoundSource.PlayOneShot(confirm,.75f);
    }
    public void playBackSound() {
        menuSoundSource.PlayOneShot(back,.75f);
    }
}
