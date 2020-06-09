using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenuScript : MonoBehaviour
{
    public Image fadeout;
    public float timer;
    public float MaxTimer=2f;
    public bool leaving;
    public GameObject player;
    public GameObject teleportSpawn;
    public GameObject warpParticle;
    public GameObject warpParticle2;
    public AudioClip warpSoundEffect;
    public AudioSource warpSoundSource;
    // Start is called before the first frame update
    void Start(){
        player.SetActive(true);
        leaving = false;
        Time.timeScale = 1;
        fadeout.gameObject.SetActive(true);
        timer = MaxTimer;
    }

    // Update is called once per frame
    void Update(){
        
    }
    void FixedUpdate() {
        if (leaving) {
            fadeout.gameObject.SetActive(true);
            if (timer<=0) {
                GameController.instance.goToNextScene();
            } else {
                fadeout.color = new Color(0,0,0,Mathf.Clamp(1-timer,0,1));
                timer -= Time.deltaTime;
            }
        } else {
            if (timer <= 0) {
                fadeout.gameObject.SetActive(false);
            } else {
                fadeout.color = new Color(0, 0, 0, Mathf.Clamp(timer, 0, 1));
                timer -= Time.deltaTime;
            }
        }
    }
    public void goToScene() {
        leaving = true;
        timer = MaxTimer;
        player.SetActive(false);
        ParticleSystem ps = Instantiate(warpParticle, teleportSpawn.transform).GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = GameController.instance.getPrimaryColor();
        warpSoundSource.PlayOneShot(warpSoundEffect,1);
        Instantiate(warpParticle2, teleportSpawn.transform);
    }
}
