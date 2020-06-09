using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour {
    public GameController gcScript;
    public StageControllerScript scScript;

    [Header("Health Related stuff")]
    public GameObject[] healthTiles;
    public Text playerName;
    public Image PlayerSecondary;
    public Image PlayerPrimary;

    [Header("Weapon Display stuffs")]
    public Image[] AmmoBar;
    public Text currWeaponText;
    public Image currWeaponImage;
    public Image[] miniIcons;
    public Image PlayerColorIndicator;
    public Sprite defaultSprite;
    [Header("ReticleRelatedStuff")]
    public Sprite[] reticles;
    public Image reticleHolder;
    [Header("Hint Related Stuffs")]
    public GameObject hintPanel;
    public GameObject hintVisLoc;
    public GameObject hintInvisLoc;
    public Text hintText;
    public float hintDuration;
    public float hintTime;

    //FadeWooshyWooshy stuff
    public Image fadeImage;
    public GameObject readyText;
    public void Start() {
        gcScript = GameController.instance;
        scScript = GameObject.FindObjectOfType<StageControllerScript>();
        //DisplayHint("This is a test");
        playerName.text = GameController.instance.playerData.PlayerName;

        
        //Initialize the HUD
    }
    public void UpdateUI() {
        


        currWeaponText.text = "" + scScript.getWeapon(scScript.getCurrentWeapon()).getName();
        if (scScript.getWeapon(scScript.getCurrentWeapon()).getMaxAmmo()!=0) {
            float value = scScript.getWeapon(scScript.getCurrentWeapon()).getMaxAmmo() / 20;
            for (int x = 0; x<20; x++) {
                this.AmmoBar[x].color = scScript.getWeapon(scScript.getCurrentWeapon()).weaponColor;
                if (scScript.getWeapon(scScript.getCurrentWeapon()).getCurrAmmo()>x*value) {
                    this.AmmoBar[x].gameObject.SetActive(true);
                } else {
                    this.AmmoBar[x].gameObject.SetActive(false);
                }
                
            }
        } else {
            for (int x = 0; x < 20; x++) {
                this.AmmoBar[x].color = scScript.getWeapon(scScript.getCurrentWeapon()).weaponColor;
                this.AmmoBar[x].gameObject.SetActive(true);
            }
        }

        //Output the healthbar
        for (int x = 0; x < 20; x++) {
            if (x < scScript.getPlayerHealth()) {
                this.healthTiles[x].SetActive(true);
            } else {
                this.healthTiles[x].SetActive(false);
            }
        }

        //Do the Ammo thing
        for(int x = 0; x < 5; x++) {
            if (gcScript.playerData.weaponsUnlocked[x]) {
                miniIcons[x].sprite = scScript.getWeapon(x).getIcon();
            } else {
                miniIcons[x].sprite = this.defaultSprite;
            }
            if (x==scScript.getCurrentWeapon()) {
                miniIcons[x].gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
            } else {
                miniIcons[x].gameObject.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
            }
        }


        currWeaponImage.sprite = scScript.getWeapon(scScript.getCurrentWeapon()).getIcon();
        reticleHolder.sprite = this.reticles[scScript.getCurrentWeapon()];
        PlayerColorIndicator.color = gcScript.getPrimaryColor();
        this.PlayerPrimary.color = gcScript.getPrimaryColor();
        this.PlayerSecondary.color = new Color(gcScript.getSecondaryColor().r, gcScript.getSecondaryColor().g, gcScript.getSecondaryColor().b, 1);


        //Hint related stuffs
        if (hintTime>0) {
            hintTime -= Time.deltaTime;
            hintPanel.transform.position = Vector3.Lerp(hintPanel.transform.position,hintVisLoc.transform.position,Time.deltaTime*10);
        } else {
            hintTime = 0;
            hintPanel.transform.position = Vector3.Lerp(hintPanel.transform.position, hintInvisLoc.transform.position, Time.deltaTime*10);
        }
        if (scScript.getFadeTimer()<=0) {
            readyText.SetActive(false);
        }
        
    }
    public void updateFade() {
        //stage load fade
        if (scScript.getFadeTimer() > 0) {
            if (scScript.getFadeTimer() > scScript.getMaxFadeDelay()) {
                fadeImage.color = new Color(0, 0, 0, 1 - ((scScript.getFadeTimer() - scScript.getMaxFadeDelay()) / scScript.getMaxFadeDelay()));
                readyText.SetActive(false);
            } else {
                fadeImage.color = new Color(0, 0, 0, scScript.getFadeTimer() / scScript.getMaxFadeDelay());
                readyText.SetActive(true);
            }
        } else {
            fadeImage.color = new Color(0, 0, 0, 0);
            readyText.SetActive(false);
        }
    }
    public void DisplayHint(string hintString) {
        hintText.text= hintString;
        hintTime = hintDuration;
    }
    public Sprite getNextIcon() {
        return scScript.getWeapon((scScript.getCurrentWeapon() + 1) % 5).getIcon();
    }
    public Sprite getPreviousIcon() {
        return scScript.getWeapon((scScript.getCurrentWeapon() + 4) % 5).getIcon();
    }
    public void turnOffReadyText() {
        readyText.SetActive(false);
    }
}
