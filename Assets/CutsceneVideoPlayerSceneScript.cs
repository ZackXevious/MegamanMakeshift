using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneVideoPlayerSceneScript : MonoBehaviour
{
    public VideoPlayer vidPlayer;
    // Start is called before the first frame update
    void Start()
    {
        vidPlayer.clip = GameController.instance.cutscenes[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
