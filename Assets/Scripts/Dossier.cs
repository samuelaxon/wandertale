using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class Dossier : MonoBehaviour
{
    [HideInInspector] public GameController controller;

    public TMP_Text gloriaProjectHintText;
    public TMP_Text gloriaColorHintText;
    public TMP_Text gloriaMaterialHintText;
    public TMP_Text gloriaVesselHintText;

    public TMP_Text julianProjectHintText;
    public TMP_Text julianColorHintText;
    public TMP_Text julianMaterialHintText;
    public TMP_Text julianVesselHintText;

    public TMP_Text liProjectHintText;
    public TMP_Text liColorHintText;
    public TMP_Text liMaterialHintText;
    public TMP_Text liVesselHintText;

    public Mob gloria;
    public Mob julian;
    public Mob li;
    public Mob mnemosyne;

    public List<Mob> allArtists = new List<Mob>();

    public List<string> gloriaProjectHints = new List<string>();
    public List<string> gloriaColorHints = new List<string>();
    public List<string> gloriaMaterialHints = new List<string>();
    public List<string> gloriaVesselHints = new List<string>();

    public List<string> julianProjectHints = new List<string>();
    public List<string> julianColorHints = new List<string>();
    public List<string> julianMaterialHints = new List<string>();
    public List<string> julianVesselHints = new List<string>();

    public List<string> liProjectHints = new List<string>();
    public List<string> liColorHints = new List<string>();
    public List<string> liMaterialHints = new List<string>();
    public List<string> liVesselHints = new List<string>();

    private void Awake()
    {
        controller = GetComponent<GameController>(); // Allows this script to access things from the GameController.
    }

    public void UpdateHintsFromInk()
    {
        // Gloria hint stages from Ink
        gloria.projectHintStage = (int)controller.inkController.story.variablesState["gloriaProjectKnown"];
        gloria.colorHintStage = (int)controller.inkController.story.variablesState["gloriaColorStage"];
        gloria.materialHintStage = (int)controller.inkController.story.variablesState["gloriaMaterialStage"];
        gloria.vesselHintStage = (int)controller.inkController.story.variablesState["gloriaVesselStage"];

        // Julian hint stages from Ink
        julian.projectHintStage = (int)controller.inkController.story.variablesState["julianProjectKnown"];
        julian.colorHintStage = (int)controller.inkController.story.variablesState["julianColorStage"];
        julian.materialHintStage = (int)controller.inkController.story.variablesState["julianMaterialStage"];
        julian.vesselHintStage = (int)controller.inkController.story.variablesState["julianVesselStage"];

        // Li hint stages from Ink
        li.projectHintStage = (int)controller.inkController.story.variablesState["liProjectKnown"];
        li.colorHintStage = (int)controller.inkController.story.variablesState["liColorStage"];
        li.materialHintStage = (int)controller.inkController.story.variablesState["liMaterialStage"];
        li.vesselHintStage = (int)controller.inkController.story.variablesState["liVesselStage"];
    }

    public void UpdateDossier()
    {
        // Gloria hint stage updates
        gloriaProjectHintText.text = gloriaProjectHints[julian.projectHintStage];
        gloriaColorHintText.text = gloriaColorHints[gloria.colorHintStage];
        gloriaMaterialHintText.text = gloriaMaterialHints[gloria.materialHintStage];
        gloriaVesselHintText.text = gloriaVesselHints[gloria.vesselHintStage];

        // Julian hint stage updates
        julianProjectHintText.text = julianProjectHints[julian.projectHintStage];
        julianColorHintText.text = julianColorHints[julian.colorHintStage];
        julianMaterialHintText.text = julianMaterialHints[julian.materialHintStage];
        julianVesselHintText.text = julianVesselHints[julian.vesselHintStage];

        // Li hint stage updates
        liProjectHintText.text = liProjectHints[li.projectHintStage];
        liColorHintText.text = liColorHints[li.colorHintStage];
        liMaterialHintText.text = liMaterialHints[li.materialHintStage];
        liVesselHintText.text = liVesselHints[li.vesselHintStage];
    }
}