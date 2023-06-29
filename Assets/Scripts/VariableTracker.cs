using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

public class VariableTracker : MonoBehaviour
{
    // Scripts
    public GameController controller;

    // Mobs
    public Mob director;
    public Mob editor;
    public Mob processor;
    public Mob housekeeper;
    public Mob cook;
    public Mob screenwriter;
    public Mob actress;
    public Mob actor;

    // Game states
    public int playerFoundKey;
    public int playerFoundWeapon;
    public int playerFoundBody;
    public int playerVisitedHiddenHallway;
    public int playerVisitedDistillery;
    public int playerKnowsName;
    public List<string> foundStatics = new List<string>(); // The start of a plan to make the murder weapon and hiding place disappear when found.

    private bool weaponSoundPlayed;
    private bool bodySoundPlayed;

    // Danger variables
    public int playerDangerLevel;
    public string playerDangerStage;

    public int dangerLow;
    public int dangerMedium;
    public int dangerHigh;
    public int dangerCritical;
    public int dangerEnd;

    public int exitDangerChange;
    public int storyDangerChange;

    public string priorDangerStage;

    public int dangerLevelTextThreshold;

    // Randomized variables
    public string murderer;
    public string victim;
    public string hidingSpot;
    public string murderWeapon;
    public int weaponType;
    public int victimGender;
    public int murdererGender;
    public string directorAlibi;
    public string editorAlibi;
    public string processorAlibi;
    public string housekeeperAlibi;
    public string cookAlibi;
    public string screenwriterAlibi;
    public string actressAlibi;
    public string actorAlibi;

    // Ink story variables
    public int storyEnd = 0;
    public int gameEnd = 0;
    public int accuseMurdererSuccess;
    public List<TextAsset> masterStoryList = new List<TextAsset>();
    [HideInInspector] public Dictionary<string, TextAsset> masterStoryDictionary = new Dictionary<string, TextAsset>();

    // UI variables
    public GameObject mapLocked;
    public GameObject mapUnlocked;

    private void Awake()
    {
        AddToMasterStoryList();

        playerDangerLevel = 0;
        playerDangerStage = "low";
        priorDangerStage = "low";

        weaponSoundPlayed = false;
        bodySoundPlayed = false;
    }

    // Activates the map.
    public void ActivateMap()
    {
        mapLocked.SetActive(true);
    }

    // Checks if the player found weapon/body and if discovery sound has already played. If they found it but the sound hasn't played, calls function to play sound.
    public void CheckToPlayDiscoveryAudio()
    {
        int foundWeaponThisStory = 0;
        int foundBodyThisStory = 0;

        foundWeaponThisStory = (int)controller.inkController.story.variablesState["playerFoundWeapon"];
        foundBodyThisStory = (int)controller.inkController.story.variablesState["playerFoundBody"];

        if (foundWeaponThisStory == 1 && weaponSoundPlayed == false)
        {
            Debug.Log("VariableTracker/CheckToPlayDiscoveryAudio(): Playing discovery sound for weapon.");
            controller.sfxController.PlaySFX("discovery");
            weaponSoundPlayed = true;
        }
        else if (foundBodyThisStory == 1 && bodySoundPlayed == false)
        {
            Debug.Log("VariableTracker/CheckToPlayDiscoveryAudio(): Playing discovery sound for body.");
            controller.sfxController.PlaySFX("discovery");
            bodySoundPlayed = true;
        }
        else
        {
            Debug.Log("VariableTracker/CheckToPlayDiscoveryAudio(): Object was not weapon or body, so no sound was played.");
        }
    }

    // Adds the key, weapon, or hiding place to a list that RoomNavigation can check to exclude these items from being displayed once the player has found them.
    public void UpdateFoundStatics()
    {
        if (playerFoundWeapon == 1 && !foundStatics.Contains(murderWeapon))
        {
            Debug.Log("VariableTracker/UpdateFoundStatics(): Added static " + murderWeapon + " to foundStatics because playerFoundWeapon was " + playerFoundWeapon);
            foundStatics.Add(murderWeapon);
        }

        if (playerFoundBody == 1 && !foundStatics.Contains(hidingSpot))
        {
            Debug.Log("VariableTracker/UpdateFoundStatics(): Added static " + hidingSpot + " to foundStatics because playerFoundBody was " + playerFoundWeapon);
            foundStatics.Add(hidingSpot);
        }

        if (playerFoundKey == 1 && !foundStatics.Contains("key"))
        {
            Debug.Log("VariableTracker/UpdateFoundStatics(): Added static key to foundStatics because playerFoundWeapon was " + playerFoundWeapon);
            foundStatics.Add("key");
        }
    }

    // Removes statics we are done with already from the room as needed.
    public void RemoveFoundStaticsFromRoom()
    {
        for (int k = 0; k < controller.roomNavigation.currentRoom.statics.Count; k++)
        {
            Debug.Log("VariableTracker/RemoveFoundStaticsFromRoom(): Assessing static in room " + controller.roomNavigation.currentRoom.statics[k].staticName);

            for (int l = 0; l < foundStatics.Count; l++)
            {
                Debug.Log("VariableTracker/RemoveFoundStaticsFromRoom(): Assessing foundStatics entry + " + foundStatics[l] + " with static in room " + controller.roomNavigation.currentRoom.statics[k].staticName);

                if (foundStatics[l].Contains(controller.roomNavigation.currentRoom.statics[k].staticName))
                {
                    Debug.Log("VariableTracker/RemoveFoundStaticsFromRoom(): Removing static " + controller.roomNavigation.currentRoom.statics[k].staticName + " from room " + controller.roomNavigation.currentRoom.name + " because the player already found it.");
                    controller.roomNavigation.currentRoom.statics.RemoveAt(k);
                }
            }
        }
    }

    // Adds universal stories (not room or mob/item specific) to a dictionary for reference by various functions—this is used for game over, accuse, and help.
    private void AddToMasterStoryList()
    {
        Debug.Log("VariableTracker/AddToMasterStoryList() was called.");

        for (int storyToAdd = 0; storyToAdd < masterStoryList.Count; storyToAdd++)
        {
            Debug.Log("VariableTracker/AddToMasterStoryList(): Adding story " + masterStoryList[storyToAdd].name + " to master story list.");

            masterStoryDictionary.Add(masterStoryList[storyToAdd].name, masterStoryList[storyToAdd]);
        }
    }

    //  TEMP
    public void DebugBody()
    {
        if (playerFoundBody == 0)
        {
            Debug.Log("555: playerFoundBody is 0.");
        }
        else if (playerFoundBody == 1)
        {
            Debug.Log("555: playerFoundBody is 1.");
        }
    } 

    // Handles changes to the player's danger level, giving Ink necessary info about danger level, and some other features related to the danger level.
    public void UpdateDangerLevel(string updateReason)
    {
        Debug.Log("VariableTracker/UpdateDangerLevel() was called with parameter " + updateReason);

        if (updateReason == "exit")
        {
            Debug.Log("VariableTracker/UpdateDangerLevel(): Increased player danger level by " + exitDangerChange);
            playerDangerLevel += exitDangerChange;
        }
        else if (updateReason == "story")
        {
            Debug.Log("VariableTracker/UpdateDangerLevel(): Increased player danger level by " + storyDangerChange);
            playerDangerLevel += storyDangerChange;
        }
        else if (updateReason == "check")
        {
            if (playerDangerLevel >= dangerEnd && controller.canvasState == "room")
            {
                Debug.Log("VariableTracker/UpdateDangerLevel(): Checking, danger level is " + playerDangerLevel);
                Debug.Log("VariableTracker/UpdateDangerLevel(): Loading game over story because playerDangerLevel reached threshold at " + playerDangerLevel);

                controller.CanvasModeSwitch("story");
                controller.inkController.LoadStory("EndGameDanger");
            }
        }

        if (playerDangerLevel >= dangerEnd)
        {
            Debug.Log("VariableTracker/UpdateDangerLevel(): Setting player danger stage to end at danger level " + playerDangerLevel);

            playerDangerStage = "end";
        }
        else if (playerDangerLevel >= dangerCritical)
        {
            Debug.Log("VariableTracker/UpdateDangerLevel(): Setting player danger stage to critical at danger level " + playerDangerLevel);

            playerDangerStage = "critical";
        }
        else if (playerDangerLevel >= dangerHigh)
        {
            Debug.Log("VariableTracker/UpdateDangerLevel(): Setting player danger stage to high at danger level " + playerDangerLevel);

            playerDangerStage = "high";
        }
        else if (playerDangerLevel >= dangerMedium)
        {
            Debug.Log("VariableTracker/UpdateDangerLevel(): Setting player danger stage to medium at danger level " + playerDangerLevel);

            playerDangerStage = "medium";
        }
        else
        {
            Debug.Log("VariableTracker/UpdateDangerLevel(): Setting player danger stage to low at danger level " + playerDangerLevel);

            playerDangerStage = "low";
        }
    }

    // Takes alibis generated by randomizer in ObjectController and assigns them to variables Ink can work with.
    public void AssignInkAlibis()
    {
        Debug.Log("VariableTracker/AssignInkAlibis() was called.");

        directorAlibi = director.alibi;
        editorAlibi = editor.alibi;
        processorAlibi = processor.alibi;
        housekeeperAlibi = housekeeper.alibi;
        cookAlibi = cook.alibi;
        screenwriterAlibi = screenwriter.alibi;
        actressAlibi = actress.alibi;
        actorAlibi = actor.alibi;
    }

    // Records variables from a story as it ends, so they can be remembered for use in another story.
    public void UpdateVariablesFromStoryEnd()
    {
        Debug.Log("VariableTracker/UpdateVariablesFromStoryEnd() was called.");

        playerFoundKey = (int)controller.inkController.story.variablesState["playerFoundKey"];
        playerFoundWeapon = (int)controller.inkController.story.variablesState["playerFoundWeapon"];
        playerFoundBody = (int)controller.inkController.story.variablesState["playerFoundBody"];
        playerVisitedDistillery = (int)controller.inkController.story.variablesState["playerVisitedDistillery"];
        playerKnowsName = (int)controller.inkController.story.variablesState["playerKnowsName"];

        accuseMurdererSuccess = (int)controller.inkController.story.variablesState["accuseMurdererSuccess"];

        storyEnd = (int)controller.inkController.story.variablesState["storyEnd"];
        gameEnd = (int)controller.inkController.story.variablesState["gameEnd"];
    }

    // Tells a new story all the variables it needs to know as soon as it's launched.
    public void SendNewVariablesToStory()
    {
        Debug.Log("VariableTracker/SendNewVariablesToStory() was called.");

        controller.inkController.story.variablesState["playerDangerStage"] = playerDangerStage;

        controller.inkController.story.variablesState["murderer"] = murderer;
        controller.inkController.story.variablesState["murdererGender"] = murdererGender;

        controller.inkController.story.variablesState["victim"] = victim;
        controller.inkController.story.variablesState["victimGender"] = victimGender;

        controller.inkController.story.variablesState["directorAlibi"] = directorAlibi;
        controller.inkController.story.variablesState["editorAlibi"] = editorAlibi;
        controller.inkController.story.variablesState["processorAlibi"] = processorAlibi;
        controller.inkController.story.variablesState["housekeeperAlibi"] = housekeeperAlibi;
        controller.inkController.story.variablesState["cookAlibi"] = cookAlibi;
        controller.inkController.story.variablesState["screenwriterAlibi"] = screenwriterAlibi;
        controller.inkController.story.variablesState["actressAlibi"] = actressAlibi;
        controller.inkController.story.variablesState["actorAlibi"] = actorAlibi;

        controller.inkController.story.variablesState["hidingSpot"] = hidingSpot;
        controller.inkController.story.variablesState["murderWeapon"] = murderWeapon;
        controller.inkController.story.variablesState["weaponType"] = weaponType;

        controller.inkController.story.variablesState["playerFoundKey"] = playerFoundKey;
        controller.inkController.story.variablesState["playerFoundWeapon"] = playerFoundWeapon;
        controller.inkController.story.variablesState["playerFoundBody"] = playerFoundBody;
        controller.inkController.story.variablesState["playerVisitedDistillery"] = playerVisitedDistillery;
        controller.inkController.story.variablesState["playerKnowsName"] = playerKnowsName;

        controller.inkController.story.variablesState["accuseMurdererSuccess"] = accuseMurdererSuccess;
        controller.inkController.story.variablesState["gameEnd"] = gameEnd;
    }
}