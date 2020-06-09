using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScreenScript : MonoBehaviour
{
    public GameObject loadingIcon;
    public GameObject StorySpawn;
    public GameObject StoryPlayer;
    public GameObject currStoryPlayer;
    bool isloading;
    // Start is called before the first frame update
    void Start()
    {
        begin();
        //loadingIcon.SetActive(false);
        //isloading = false;
    }
    void FixedUpdate() {
        /*
        if (GameController.instance.stageNumber >= 0) {
            Debug.Log("Loading stage");
            if (GameController.instance.stageNumber == 0 && !GameController.instance.playerData.stagesCompleted[0] == false && GameController.instance.playerData.CutscenesUnlocked[0] == false) {
                Debug.Log("Intro cutscene");
                currStoryPlayer = Instantiate(StoryPlayer, StorySpawn.transform);
                currStoryPlayer.GetComponent<StoryPanel>().setMessageNumber(0);
                GameController.instance.playerData.CutscenesUnlocked[0] = true;
            } else if (GameController.instance.stageNumber == 5 && !GameController.instance.playerData.stagesCompleted[5] && GameController.instance.playerData.CutscenesUnlocked[5] == false) {
                Debug.Log("Final Boss cutscene");
                currStoryPlayer = Instantiate(StoryPlayer, StorySpawn.transform);
                currStoryPlayer.GetComponent<StoryPanel>().setMessageNumber(5);
                GameController.instance.playerData.CutscenesUnlocked[5] = true;
            } else {
                Debug.Log("loading");
                if (!isloading) {
                    this.begin();
                }
            }
        } else {
            if (GameController.instance.playerData.stagesCompleted[0] == true && GameController.instance.playerData.CutscenesUnlocked[1] == false) {
                currStoryPlayer = Instantiate(StoryPlayer, StorySpawn.transform);
                currStoryPlayer.GetComponent<StoryPanel>().setMessageNumber(1);
                GameController.instance.playerData.CutscenesUnlocked[1] = true;
                Debug.Log("Post Tutorial cutscene");
            } else if (GameController.instance.playerData.stagesCompleted[6] == true && GameController.instance.playerData.CutscenesUnlocked[7] == false) {
                Debug.Log("Final cutscene");
                currStoryPlayer = Instantiate(StoryPlayer, StorySpawn.transform);
                currStoryPlayer.GetComponent<StoryPanel>().setMessageNumber(7);
                GameController.instance.playerData.CutscenesUnlocked[7] = true;
            } else {
                Debug.Log("loading");
                if (!isloading) {
                    this.begin();
                }
                
            }
        }*/
    }
    public void begin() {
        isloading = true;
        loadingIcon.SetActive(true);
        StartCoroutine(LoadLevel());
        
    }
    IEnumerator LoadLevel() {
        AsyncOperation loadLevel;
        if (GameController.instance.stageNumber>=0) {
            loadLevel = SceneManager.LoadSceneAsync(GameController.instance.SceneNames[GameController.instance.stageNumber]);
        } else {
            if (GameController.instance.stageNumber ==-1) {
                loadLevel = SceneManager.LoadSceneAsync("PlayerMenu");
            } else {

            }
        }
        yield return new WaitForEndOfFrame();
        
    }
}
