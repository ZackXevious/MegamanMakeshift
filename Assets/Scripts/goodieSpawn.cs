using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodieSpawn : MonoBehaviour
{
    public GameObject[] healthpickups;
    public GameObject[] smallAmmoPickups;
    public GameObject[] largeAmmoPickups;
    List<GameObject> spawnlist= new List<GameObject>();
    public void spawnRandoms(int odds) {
        for (int x=0; x<healthpickups.Length;x++) {
            spawnlist.Add(healthpickups[x]);
        }
        if (smallAmmoPickups.Length>0) {
            for (int x = 0; x < smallAmmoPickups.Length; x++) {
                if (GameController.instance.playerData.weaponsUnlocked[x + 1]) {
                    spawnlist.Add(smallAmmoPickups[x]);
                }
            }
        }
        if (largeAmmoPickups.Length > 0) {
            for (int x = 0; x < largeAmmoPickups.Length; x++) {
                if (GameController.instance.playerData.weaponsUnlocked[x + 1]) {
                    spawnlist.Add(largeAmmoPickups[x]);
                }
            }
        }
        if (Random.Range(0,10)<odds) {
            Instantiate(spawnlist[Random.Range(0,spawnlist.Count-1)],this.transform.position,this.transform.rotation);
        }
        Destroy(this.gameObject);
    }
}
