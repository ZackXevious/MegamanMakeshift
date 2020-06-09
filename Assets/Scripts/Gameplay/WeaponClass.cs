using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponClass{
    public string name;
    public int maxAmmo;
    public int currAmmo;
    public float shotDelay;
    public Sprite icon;
    public Color weaponColor;
    public bool isUnlocked;

    public WeaponClass(string weapName,int weapMaxAmmo, float weapDelay, bool unlocked) {
        this.name = weapName;
        this.maxAmmo = weapMaxAmmo;
        this.currAmmo = weapMaxAmmo;
        this.shotDelay = weapDelay;
        this.isUnlocked = unlocked;
    }
    public string getName() {
        return name;
    }
    public int getCurrAmmo() {
        return this.currAmmo;
    }
    public float getShotDelay() {
        return this.shotDelay;
    }
    public int getMaxAmmo() {
        return this.maxAmmo;
    }
    public Sprite getIcon() {
        return this.icon;
    }
    public Color getColor() {
        return this.weaponColor;
    }

    //Setters------------------
    public void setCurrAmmo(int weapCurrAmmo) {
        this.currAmmo = weapCurrAmmo;
    }
    public void setIcon(Sprite weapIcon) {
        this.icon = weapIcon;
    }
    public void setColor(Color weapColor) {
        this.weaponColor = weapColor;
    }
            
        
}
