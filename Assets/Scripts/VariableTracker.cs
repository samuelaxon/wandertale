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

    private bool weaponSoundPlayed;
    private bool bodySoundPlayed;

    public Room landingPage;

    // Ink story variables
    public int storyEnd = 0;
    public int gameEnd = 0;
    public int tookItem = 0;

    // Event cue variables
    public int dossierChanged = 0;
    public int playScrySound = 0;

    public List<TextAsset> masterStoryList = new List<TextAsset>();
    [HideInInspector] public Dictionary<string, TextAsset> masterStoryDictionary = new Dictionary<string, TextAsset>();

    private void Awake()
    {
        AddToMasterStoryList();

        weaponSoundPlayed = false;
        bodySoundPlayed = false;
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
            // controller.sfxController.PlaySFX("discovery");
            weaponSoundPlayed = true;
        }
        else if (foundBodyThisStory == 1 && bodySoundPlayed == false)
        {
            Debug.Log("VariableTracker/CheckToPlayDiscoveryAudio(): Playing discovery sound for body.");
            // controller.sfxController.PlaySFX("discovery");
            bodySoundPlayed = true;
        }
        else
        {
            Debug.Log("VariableTracker/CheckToPlayDiscoveryAudio(): Object was not weapon or body, so no sound was played.");
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


    // Records variables from a story as it ends, so they can be remembered for use in another story.
    public void UpdateVariablesFromStoryEnd()
    {
        Debug.Log("VariableTracker/UpdateVariablesFromStoryEnd() was called.");

        // NPC conversation levels
        controller.dossier.gloria.mobState = (int)controller.inkController.story.variablesState["gloriaConversationLevel"];
        controller.dossier.julian.mobState = (int)controller.inkController.story.variablesState["julianConversationLevel"];
        controller.dossier.li.mobState = (int)controller.inkController.story.variablesState["liConversationLevel"];
        controller.dossier.mnemosyne.mobState = (int)controller.inkController.story.variablesState["mnemosyneConversationLevel"];

        // Dossier tracking variables
        controller.dossier.gloria.projectHintStage = (int)controller.inkController.story.variablesState["gloriaProjectKnown"];
        controller.dossier.julian.projectHintStage = (int)controller.inkController.story.variablesState["julianProjectKnown"];
        controller.dossier.li.projectHintStage = (int)controller.inkController.story.variablesState["liProjectKnown"];
        controller.dossier.gloria.colorHintStage = (int)controller.inkController.story.variablesState["gloriaColorStage"];
        controller.dossier.julian.colorHintStage = (int)controller.inkController.story.variablesState["julianColorStage"];
        controller.dossier.li.colorHintStage = (int)controller.inkController.story.variablesState["liColorStage"];
        controller.dossier.gloria.materialHintStage = (int)controller.inkController.story.variablesState["gloriaMaterialStage"];
        controller.dossier.julian.materialHintStage = (int)controller.inkController.story.variablesState["julianMaterialStage"];
        controller.dossier.li.materialHintStage = (int)controller.inkController.story.variablesState["liMaterialStage"];
        controller.dossier.gloria.vesselHintStage = (int)controller.inkController.story.variablesState["gloriaVesselStage"];
        controller.dossier.julian.vesselHintStage = (int)controller.inkController.story.variablesState["julianVesselStage"];
        controller.dossier.li.vesselHintStage = (int)controller.inkController.story.variablesState["liVesselStage"];

        // Game states
        tookItem = (int)controller.inkController.story.variablesState["tookItem"];
        storyEnd = (int)controller.inkController.story.variablesState["storyEnd"];
        gameEnd = (int)controller.inkController.story.variablesState["gameEnd"];
    }

    // Tells a new story all the variables it needs to know as soon as it's launched.
    public void SendNewVariablesToStory()
    {
        Debug.Log("VariableTracker/SendNewVariablesToStory() was called.");

        // NPC conversation levels
        controller.inkController.story.variablesState["gloriaConversationLevel"] = controller.dossier.gloria.mobState;
        controller.inkController.story.variablesState["julianConversationLevel"] = controller.dossier.julian.mobState;
        controller.inkController.story.variablesState["liConversationLevel"] = controller.dossier.li.mobState;
        controller.inkController.story.variablesState["mnemosyneConversationLevel"] = controller.dossier.mnemosyne.mobState;

        // Dossier tracking variables
        controller.inkController.story.variablesState["gloriaProjectKnown"] = controller.dossier.gloria.projectHintStage;
        controller.inkController.story.variablesState["julianProjectKnown"] = controller.dossier.julian.projectHintStage;
        controller.inkController.story.variablesState["liProjectKnown"] = controller.dossier.li.projectHintStage;
        controller.inkController.story.variablesState["gloriaColorStage"] = controller.dossier.gloria.colorHintStage;
        controller.inkController.story.variablesState["julianColorStage"] = controller.dossier.julian.colorHintStage;
        controller.inkController.story.variablesState["liColorStage"] = controller.dossier.li.colorHintStage;
        controller.inkController.story.variablesState["gloriaMaterialStage"] = controller.dossier.gloria.materialHintStage;
        controller.inkController.story.variablesState["julianMaterialStage"] = controller.dossier.julian.materialHintStage;
        controller.inkController.story.variablesState["liMaterialStage"] = controller.dossier.li.materialHintStage;
        controller.inkController.story.variablesState["gloriaVesselStage"] = controller.dossier.gloria.vesselHintStage;
        controller.inkController.story.variablesState["julianVesselStage"] = controller.dossier.julian.vesselHintStage;
        controller.inkController.story.variablesState["liVesselStage"] = controller.dossier.li.vesselHintStage;

        // Gift tracking
        controller.inkController.story.variablesState["giftForGloria"] = controller.crafting.giftForGloria;
        controller.inkController.story.variablesState["giftForJulian"] = controller.crafting.giftForJulian;
        controller.inkController.story.variablesState["giftForLi"] = controller.crafting.giftForLi;
        controller.inkController.story.variablesState["gloriaInspirationLevel"] = controller.crafting.scoreForGloria;
        controller.inkController.story.variablesState["julianInspirationLevel"] = controller.crafting.scoreForJulian;
        controller.inkController.story.variablesState["liInspirationLevel"] = controller.crafting.scoreForLi;
    }
}