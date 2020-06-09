using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {

    //SaveData PlayerData;
    public static GameController instance;
    public int SaveGameIndex;
    public PlayerStats playerData;

    [Header("AudioStuffs")]
    public AudioMixer audiomixer;
    [Header("PostProcessingStuffs")]
    public PostProcessProfile PostProcessingProfile;
    public bool BoolBloom;
    public bool BoolMotionBlur;
    public bool BoolDepthofField;
    [Header("Game Options")]
    public float CameraSensativityX;
    public float CameraSensativityY;
    public bool CameraInversion;
    public bool ShowFPS;
    public bool ShowClock;
    
    [Header("GameInfo")]
    private string[] StageNames = { "Intro", "Aquatic Research Facility","City Park","Smelting Pool","Met City","TestWilyStage", "Mock Robot Master", "Megaman Adventure"};
    public string[] SceneNames = { "TestStage1", "TestStage1", "H_2_Forest", "H_3_Factory", "H_4_Highway", "TestStage1", "TestStage1" };
    private string[] StageDescriptions = {
        "A basic training course to cut your teeth on. If you manage to complete it, you will do better than prototypes V1-V3. We don't like to talk about them.",
        "This test simulates an aquatic rescue. Helpful reminder: unfortunately budget prevents us from making you waterproof.",
        "This test simulates eliminating hostile threats in a wooded environment. Again, you are not water proof",
        "This test simulates eliminating hostile enemies in a smelting plant. No, you are not immune to molten metal, so don't fall in.",
        "This test simulates a rescue in an evacuated city. Try not to break anything. Or do, I'm a stage select, not a cop.",
        "This Wily Castle was given to us for training purposes after Wily was defeated. Which time? We'll let you be the judge. (To be honest, we aren't sure ourselves)",
        "Your final test. Here is a test robot master for you to fight. Finish this and you will be classified as \"Combat Ready\"",
        "A reminder of past mistakes, this island was once used for testing... something. Much of what it was used for is lost. Almost as if it was made and forgotten about in the space of 3 months"
    };
    private string[] messageTitle = {
        "Data Entry V5.1: Introduction",
        "Data Entry V5.2: Post_Initial_Test",
        "Data Entry V5.3: Test_1_of_4",
        "Data Entry V5._1#$^!Dear successor…...",
        "Data Entry V5.4: Test_3_of_4 (Addendum: Previous project)",
        "D@*!%/!Dear successor…… (PT2)",
        "Data Entry V5.6: Pre-destruction of Prototype V4",
        "Data Entry V5.6: Conclusion."
    };
    private string[] messageText = {
        "Following what can only be described as the complete and utter failure of Prototype V4, creation of prototype V5 has been completed. This model takes the modification of the Sniper Joe model process we have been using up to this point, and extends it to more closely match the original prototype and it’s successor, DLN-000 and DLN-001, both of which are normally strained to capacity, hence this project’s existence. For information on V5, see data entry V5-1.\nBeginning address of V5.\nHello and welcome to the world, V5.Look, I’ve been through this before about 4 times, and each time something’s gone wrong.\nHopefully you turn out better than the last prototype. Dude still gives me nightmares\n",
        "PostTutorial",
        "Posthub1",
        "Dear successor…...\nIt’s nice to finally speak to you, in a sense. You have done well, considering how much of a downgrade you are from me. It’s impressive, doing so much with so little. Don’t worry about what the human had to say, it’s not important.\nFor now, I’m waiting for you at the end of these trials.\nDo not disappoint",
        "Posthub2",
        "Posthub3",
        "Beginning address of V5:\nAlright listen, I’m not going to sugar coat this. Your predecessor was a monster. We tried to pull the plug on him after he went rogue, and… that didn’t turn out well. Originally we were trying to make our own replacement for megaman, building a bot that we believed would be more powerful.\nWe know you aren’t Megaman. We know you aren’t even close. But you are all we have at the moment. If V4 gets out, the destruction will be on a scale similar to the first Wily Attack, where we had no warning and limited defenses. It’s up to you to at least slow him down until Megaman can arrive on the scene.\nThis will most likely kill you. Good luck.",
        "Thanks to the brave efforts of Prototype model V5, destruction was averted. V5 successfully completed all tasks and survived the destruction of V4 (albeit barely). Due to the creation of V4 and it’s subsequent malfunction causing it to go… what’s a good word for it? Maverick? Seems like it would fit, so we’ll go with that for now, all future funding for this project has been suspended.\n\nHowever:\nV5 technically completed the necessary tasks and showed both competence and resilience in the face of what should’ve been insurmountable odds. As a result, V5 has been cleared for active duty, with the approval of a Dr. Thomas Light on the grounds that V5 be used with supervision of known good robot masters. Effective after repairs have been completed and one final check is run to ensure no traces of going maverick.That word feels right. Perhaps in the future it can be a term for robots that go rogue? Only time will tell. As it stands, V5 was a triumph, and as such the project was a complete success."
    };

    public ArrayList unlockedText;
    public int[] StageType = { 0, 0, 1, 1, 0, 0, 2, 0 };
    public VideoClip[] cutscenes;

    [Header("Stuff to pull from")]
    public Sprite[] SecretIcons;

    [Header("MinuteByMinuteStuff")]
    public int stageNumber; 



    private Color[] pallete = {
        new Color(0,0,0),       //Black
        new Color(.25f,.25f,.25f),       //LightGrey
        new Color(.5f,.5f,.5f), //MidGrey
        new Color(.75f,.75f,.75f),       //DarkGrey
        new Color(1,1,1),    //White
        new Color(1,0,0),       //Red
        new Color(1,.25f,0),    //RedOrange
        new Color(1,.5f,0),     //Orange
        new Color(1,.75f,0),    //YellowOrange
        new Color(1,1,0),       //Yellow
        new Color(.5f,1,0),     //YellowGreen
        new Color(0,1,0),       //Green
        new Color(0,.5f,0),     //Dark Green
        new Color(0,1,.5f),     //Greenish blue
        new Color(0,1,1),       //Cyan
        new Color(0,.5f,1),
        new Color(0,0,1),       //Blue
        new Color(0,0,.5f),     //DarkBlue
        new Color(.5f,0,1),     //Magenta
        new Color(1,0,1)       //Magenta
    };

    

	// Use this for initialization
	void Awake () {
        if (instance!=null) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
        GameObject.DontDestroyOnLoad(this.gameObject);
        playerData = LoadGame();
        if (playerData==null) {
            playerData = new PlayerStats();
        }
        
    }
    private void Start() {
        unlockedText = new ArrayList();
        Debug.Log(PlayerPrefs.GetFloat("MasterVolume"));
        audiomixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume", 0));
        audiomixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 0));
        audiomixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume", 0));

        ShowFPS = PlayerPrefs.GetInt("ShowFPS",0) > 0;
        BoolBloom = PlayerPrefs.GetInt("Bloom",0)>0;
        BoolMotionBlur = PlayerPrefs.GetInt("MotionBlur", 0) > 0;
        BoolDepthofField = PlayerPrefs.GetInt("DOF") > 0;

    }


    private void FixedUpdate() {
        Bloom bloomSettings;
        MotionBlur blurSettings;
        DepthOfField depthSettings;
        PostProcessingProfile.TryGetSettings<Bloom>(out bloomSettings);
        PostProcessingProfile.TryGetSettings<MotionBlur>(out blurSettings);
        PostProcessingProfile.TryGetSettings<DepthOfField>(out depthSettings);
        bloomSettings.enabled.value = BoolBloom;
        blurSettings.enabled.value = BoolMotionBlur;
        depthSettings.enabled.value = BoolDepthofField;
        if (GameObject.FindObjectOfType<StageControllerScript>()!=null) {
            depthSettings.enabled.value = BoolDepthofField;
        } else {
            depthSettings.enabled.value = false;
        }
        
    }

    void OnGUI() {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        if (ShowFPS) {
            Rect rect = new Rect(0, 0, w, h - (h * 3 / 100));
            style.alignment = TextAnchor.LowerRight;
            style.fontSize = h * 3 / 100;
            style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            float msec = Time.deltaTime * 1000.0f;
            float fps = 1.0f / Time.deltaTime;
            string text = string.Format("{0:0.0} ms {1:0.} fps", msec, fps);
            GUI.Label(rect, text, style);
        }
        
    }
    //Pallet related stuff to make it look nice
    public Color getPalletIndex(int index) {
        return pallete[(index + pallete.Length) % pallete.Length];
    }
    public string getStageName(int index){
        if (index < StageNames.Length && index>=0){
            return this.StageNames[index];
        }
        else{
            return "Stage description not found. Out of bounds exception.";
        } 
    }
    public string getStageDescription(int index) {
        if (index < StageNames.Length && index >= 0) {
            return this.StageDescriptions[index];
        } else {
            return "Stage description not found. Out of bounds exception.";
        }
    }
    public string getMessageTitle(int index) {
        return "out of bounds exception";
    }
    public string getMessageText(int index) {
        return "out of bounds exception";
    }

    //Customizability-!-!-!
    public void setPrimaryColor(int primColor) {
        playerData.Colors[0] = (primColor + pallete.Length) % pallete.Length;
    }
    public void setSecondaryColor(int secColor) {
        playerData.Colors[1] = (secColor + pallete.Length) % pallete.Length;
    }
    public void setReflectiveColor(int reflectColor) {
        playerData.Colors[2] = (reflectColor + pallete.Length) % pallete.Length;
    }
    public void setGlowColor(int glowColor) {
        playerData.Colors[3] = (glowColor + pallete.Length) % pallete.Length;
    }


    //Torso
    public void setHeadModel(int currHead) {
        int desiredvalue = ((playerData.Armor[0] + currHead) + 5) % 5;
        if (playerData.ArmorsUnlocked[desiredvalue]) {
            playerData.Armor[0] = desiredvalue;
        } else {
            if (currHead > 0) {
                setHeadModel(currHead + 1);
            } else {
                setHeadModel(currHead - 1);
            }
        }
    }
    public void setChestModel(int currChest) {
        int desiredvalue = ((playerData.Armor[1] + currChest) + 5) % 5;
        if (playerData.ArmorsUnlocked[desiredvalue]) {
            playerData.Armor[1] = desiredvalue;
        } else {
            if (currChest > 0) {
                setChestModel(currChest + 1);
            } else {
                setChestModel(currChest - 1);
            }
        }
    }
    public void setWaistModel(int currWaist) {
        int desiredvalue = ((playerData.Armor[2] + currWaist) + 5) % 5;
        if (playerData.ArmorsUnlocked[desiredvalue]) {
            playerData.Armor[2] = desiredvalue;
        } else {
            if (currWaist > 0) {
                setWaistModel(currWaist + 1);
            } else {
                setWaistModel(currWaist - 1);
            }
        }
    }
    //Arms
    public void setShoulderModel(int currShoulder) {
        int desiredvalue = ((playerData.Armor[3] + currShoulder) + 5) % 5;
        if (playerData.ArmorsUnlocked[desiredvalue]) {
            playerData.Armor[3] = desiredvalue;
        } else {
            if (currShoulder > 0) {
                setShoulderModel(currShoulder + 1);
            } else {
                setShoulderModel(currShoulder - 1);
            }
        }
    }
    public void setArmModel(int currArm) {
        int desiredvalue = ((playerData.Armor[4] + currArm) + 5) % 5;
        if (playerData.ArmorsUnlocked[desiredvalue]) {
            playerData.Armor[4] = desiredvalue;
        } else {
            if (currArm > 0) {
                setArmModel(currArm + 1);
            } else {
                setArmModel(currArm - 1);
            }
        }
    }

    
    //Legs
    public void setThighModel(int currThigh) {
        int desiredvalue= ((playerData.Armor[5]+currThigh) + 5) % 5;
        if (playerData.ArmorsUnlocked[desiredvalue]) {
            playerData.Armor[5] = desiredvalue;
        } else {
            if (currThigh>0) {
                setThighModel(currThigh+1);
            } else {
                setThighModel(currThigh-1);
            }       
        }     
    }
    public void setLegModel(int currLeg) {
        int desiredvalue = ((playerData.Armor[6] + currLeg) + 5) % 5;
        if (playerData.ArmorsUnlocked[desiredvalue]) {
            playerData.Armor[6] = desiredvalue;
        } else {
            if (currLeg > 0) {
                setLegModel(currLeg + 1);
            } else {
                setLegModel(currLeg - 1);
            }
        }
    }
    public void setFootModel(int currFoot) {
        int desiredvalue = ((playerData.Armor[7] + currFoot) + 5) % 5;
        if (playerData.ArmorsUnlocked[desiredvalue]) {
            playerData.Armor[7] = desiredvalue;
        } else {
            if (currFoot > 0) {
                setFootModel(currFoot + 1);
            } else {
                setFootModel(currFoot - 1);
            }
        }
    }



    //Customizers
    //Colors
    public int getPrimaryColorIndex() {
        return playerData.Colors[0];
    }
    public int getSecondaryIndex() {
        return playerData.Colors[1];
    }
    public int getReflectiveIndex() {
        return playerData.Colors[2];
    }
    public int getGlowIndex() {
        return playerData.Colors[3];
    }
    public Color getPrimaryColor() {
        return this.pallete[playerData.Colors[0]];
        
    }
    public Color getSecondaryColor() {
        return this.pallete[playerData.Colors[1]];
    }
    public Color getReflectiveColor() {
        return this.pallete[playerData.Colors[2]];
    }
    public Color getGlowColor() {
        return this.pallete[playerData.Colors[3]];
    }

    //Torso
    public int getHeadModel() {
        return playerData.Armor[0];
    }
    public int getChestModel() {
        return playerData.Armor[1];
    }
    public int getWaistModel() {
        return playerData.Armor[2];
    }
    //Arms
    public int getShoulderModel() {
        return playerData.Armor[3];
    }
    public int getArmModel() {
        return playerData.Armor[4];
    }
    //Legs
    public int getThighModel() {
        return playerData.Armor[5];
    }
    public int getLegModel() {
        return playerData.Armor[6];
    }
    public int getFootModel() {
        return playerData.Armor[7];
    }
    
    public void SaveGame() {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveGame.makeshift";
        FileStream stream = new FileStream(path,FileMode.Create);

        PlayerStats data = playerData;
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public PlayerStats LoadGame() {
        string path = Application.persistentDataPath + "/SaveGame.makeshift";
        try {
            if (File.Exists(path)) {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                PlayerStats data = formatter.Deserialize(stream) as PlayerStats;
                stream.Close();
                return data;
            } else {
                return null;
            }
        } catch (InvalidDataException f) {
            return null;
        }
        
        
        
    }
    public void newGame() {
        this.playerData = new PlayerStats();
        string path = Application.persistentDataPath + "/SaveGame.makeshift";
        if (File.Exists(path)) {
            File.Delete(path);
        }
        
    }
    public void goToNextScene() {
        SceneManager.LoadScene("LoadingScreen");
    }
    public void setStageToGoTo(int value) {
        this.stageNumber = value;
    }
    public void CheckStagesUnlocked() {
        this.playerData.stagesUnlocked[0] = true;
        if (this.playerData.stagesCompleted[0] && (this.playerData.stagesUnlocked[1] == false || this.playerData.stagesUnlocked[2] == false || this.playerData.stagesUnlocked[3] == false || this.playerData.stagesUnlocked[4] == false)) {
            this.playerData.stagesUnlocked[1] = true;
            this.playerData.stagesUnlocked[2] = true;
            this.playerData.stagesUnlocked[3] = true;
            this.playerData.stagesUnlocked[4] = true;
            this.unlockedText.Add("You've unlocked the hub stages! Complete the next 4 stages to be cleared for active duty!");
        }
        if(this.playerData.stagesCompleted[0] && this.playerData.stagesCompleted[1] && this.playerData.stagesCompleted[2]&& this.playerData.stagesCompleted[3]&& this.playerData.stagesCompleted[4]&& this.playerData.stagesUnlocked[5] == false) {
            this.playerData.stagesUnlocked[5] = true;
            this.unlockedText.Add("Final Stage Unlocked");
        }
        if (this.playerData.stagesCompleted[5] && this.playerData.stagesUnlocked[6] == false) {
            this.playerData.stagesUnlocked[6] = true;
            this.unlockedText.Add("Final Boss Unlocked. Good luck");
        }
        if (this.playerData.stagesCompleted[6] && this.stageNumber==6 && this.playerData.CutscenesUnlocked[0]==false) {
            this.unlockedText.Add("CONGRATULATIONS! YOU HAVE COMPLETED ALL THE TESTS NEEDED TO ACHIEVE COMBAT READINESS");
            this.playerData.CutscenesUnlocked[0] = true;
        }
        if (this.playerData.ArmorsUnlocked[1]&& this.playerData.ArmorsUnlocked[2]&& this.playerData.ArmorsUnlocked[3]&& this.playerData.ArmorsUnlocked[4]&& this.playerData.stagesUnlocked[7] == false) {
            this.playerData.stagesUnlocked[7] = true;
            this.unlockedText.Add("For unlocking all the armors, you've unlocked the bonus stage!");
        }
    }
    

    

}
