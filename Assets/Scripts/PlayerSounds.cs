using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    AudioSource playersoundsource;
    public AudioClip spawnSound;
    public AudioClip leaveSound;
    public AudioClip footstep;
    public AudioClip hurtsound;
    public AudioClip jumpsound;
    public AudioClip fallsound;
    public AudioClip deathsound;
    public AudioClip healthsound;
    public AudioClip ammosound;
    public AudioClip weaponSwap;
    public bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        playersoundsource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playFootSound() {
        if (onGround) {
            playersoundsource.PlayOneShot(footstep, .75f);
        }
        
    }
    public void playJumpSound() {
        playersoundsource.PlayOneShot(jumpsound,.75f);
    }
    public void playHurtSound() {
        playersoundsource.PlayOneShot(hurtsound,.75f);
    }
    public void playLandingSound() {
        playersoundsource.PlayOneShot(fallsound, .75f);
    }
    public void playDeathSound() {
        playersoundsource.PlayOneShot(deathsound,.75f);
    }
    public void playHealSound() {
        playersoundsource.PlayOneShot(healthsound,.75f);
    }
    public void playAmmoSound() {
        playersoundsource.PlayOneShot(ammosound,.75f);
    }
    public void playSwapSound() {
        playersoundsource.PlayOneShot(weaponSwap, .30f);
    }
    public void playSpawnSound() {
        playersoundsource.PlayOneShot(spawnSound, 1);
    }
    public void playLeaveSound() {
        playersoundsource.PlayOneShot(leaveSound, 1);
    }
}
