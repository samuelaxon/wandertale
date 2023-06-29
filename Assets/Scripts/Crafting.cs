using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crafting : MonoBehaviour
{
    [HideInInspector] public GameController controller;

    public TMP_Text craftingTextPrefab;
    public Button craftingChoicePrefab;
    public GameObject craftingTextPanel;
    public GameObject craftingButtonPanel;
    public TMP_FontAsset craftingButtonTextFont;

    public int valueAddGloria = 0;
    public int valueAddLi = 0;
    public int valueAddJulian = 0;

    public string recipient;
    public string vessel;
    public string material;
    public string color;

    // public string lastGiftCrafted;

    public int scoreForGloria;
    public int scoreForJulian;
    public int scoreForLi;

    public string giftForGloria;
    public string giftForJulian;
    public string giftForLi;

    public string lastActiveStage;

    public Dictionary<string, Mob> artistIndex = new Dictionary<string, Mob>();

    [TextArea] public string pickRecipient;
    [TextArea] public string pickVessel;
    [TextArea] public string pickMaterial;
    [TextArea] public string pickColor;
    [TextArea] public string confirm;
    [TextArea] public string finish;
    [TextArea] public string confirmButtonText;
    [TextArea] public string finishButtonText;

    private void Awake()
    {
        controller = GetComponent<GameController>(); // Allows this script to access things from the GameController.
        BuildArtistIndex();
    }

    public void BuildArtistIndex()
    {
        artistIndex.Clear();

        artistIndex.Add("Gloria", controller.dossier.gloria);
        artistIndex.Add("Julian", controller.dossier.julian);
        artistIndex.Add("Li", controller.dossier.li);
    }

    public void RefreshCraftingUI(string craftingStage)
    {
        Debug.Log("Crafting.RefreshCraftingUI() was called with craftingStage " + craftingStage);

        EraseUI();

        TMP_Text craftingText = Instantiate(craftingTextPrefab);
        craftingText.fontSize = 24;
        craftingText.paragraphSpacing = 40;
        craftingText.transform.SetParent(craftingTextPanel.transform, false);

        craftingText.text = craftingStage;
        lastActiveStage = craftingStage;

        if (craftingText.text == pickRecipient)
        {
            UnpackRecipients();
        }
        else if (craftingText.text == pickVessel)
        {
            UnpackVessels();
        }
        else if (craftingText.text == pickMaterial)
        {
            UnpackMaterials();
        }
        else if (craftingText.text == pickColor)
        {
            UnpackColors();
        }
        else if (craftingText.text == confirm)
        {
            ClearCraftingValues();
            UnpackConfirm();
        }
        else if (craftingText.text == finish)
        {
            UnpackFinish();
        }

        craftingText.text = craftingStage.Replace("{r}", recipient);
    }

    private void SetConfirmText()
    {
        Debug.Log("Crafting.SetConfirmText() was called.");

        if (artistIndex.Count == 0)
        {
            Debug.Log("Crafting.SetConfirmText(): artistIndex count was 0.");

            if (recipient == "Gloria")
            {
                confirm = "You have crafted the " + giftForGloria + " for " + recipient + ". That was your last gift!";
            }
            else if (recipient == "Julian")
            {
                confirm = "You have crafted the " + giftForJulian + " for " + recipient + ". That was your last gift!";
            }
            else if (recipient == "Li")
            {
                confirm = "You have crafted the " + giftForLi + " for " + recipient + ". That was your last gift!";
            }
        }
        else
        {
            Debug.Log("Crafting.SetConfirmText(): artistIndex count was greater than 0 at " + artistIndex.Count);

            if (recipient == "Gloria")
            {
                confirm = "You have crafted the " + giftForGloria + " for " + recipient + ". Ready to craft the next gift?";
            }
            else if (recipient == "Julian")
            {
                confirm = "You have crafted the " + giftForJulian + " for " + recipient + ". Ready to craft the next gift?";
            }
            else if (recipient == "Li")
            {
                confirm = "You have crafted the " + giftForLi + " for " + recipient + ". Ready to craft the next gift?";
            }
        }
    }

    private void UnpackRecipients()
    {
        foreach (KeyValuePair<string, Mob> n in artistIndex)
        {
            Button craftingButton = Instantiate(craftingChoicePrefab);

            Image craftingButtonImage = craftingButton.GetComponent<Image>();
            craftingButton.transform.SetParent(craftingButtonPanel.transform, false);
            craftingButtonImage.enabled = craftingButtonImage.enabled;

            TMP_Text craftingButtonText = craftingButton.GetComponentInChildren<TMP_Text>();
            craftingButtonText.transform.SetParent(craftingButton.transform, false);
            craftingButtonText.font = craftingButtonTextFont;
            craftingButtonText.fontSize = 30;
            craftingButtonText.color = new Color32(13, 94, 175, 255);
            string mobNameToInclude = n.Value.name;
            craftingButtonText.text = mobNameToInclude;
            craftingButton.name = mobNameToInclude + "Button";

            craftingButton.onClick.AddListener(delegate
            {
                Debug.Log("Crafting: A crafting choice was clicked.");
                ChooseCraftingChoice(craftingButton);
            });
        }
    }

    private void UnpackVessels()
    {
        for (int i = 0; i < controller.inventory.inventory.Count; i++)
        {
            for (int r = 0; r < controller.inventory.allReagents.Count; r++)
            {
                if (controller.inventory.allReagents[r].staticName == controller.inventory.inventory[i])
                {
                    if (controller.inventory.allReagents[r].reagentType == "vessel")
                    {
                        Button craftingButton = Instantiate(craftingChoicePrefab);

                        Image craftingButtonImage = craftingButton.GetComponent<Image>();
                        craftingButton.transform.SetParent(craftingButtonPanel.transform, false);
                        craftingButtonImage.enabled = craftingButtonImage.enabled;

                        TMP_Text craftingButtonText = craftingButton.GetComponentInChildren<TMP_Text>();
                        craftingButtonText.transform.SetParent(craftingButton.transform, false);
                        craftingButtonText.font = craftingButtonTextFont;
                        craftingButtonText.fontSize = 30;
                        craftingButtonText.color = new Color32(13, 94, 175, 255);
                        craftingButtonText.text = controller.inventory.allReagents[r].staticName + ": " + controller.inventory.allReagents[r].vesselProperty + " (" + controller.inventory.allReagents[r].vesselCategory + ")";

                        craftingButton.name = controller.inventory.allReagents[r].vesselProperty + "Button";

                        craftingButton.onClick.AddListener(delegate
                        {
                            Debug.Log("Crafting: A crafting choice was clicked.");
                            ChooseCraftingChoice(craftingButton);
                        });
                    }
                }
            }
        }

        Button craftingNothingButton = Instantiate(craftingChoicePrefab);

        Image craftingNothingButtonImage = craftingNothingButton.GetComponent<Image>();
        craftingNothingButton.transform.SetParent(craftingButtonPanel.transform, false);
        craftingNothingButtonImage.enabled = craftingNothingButtonImage.enabled;

        TMP_Text craftingNothingButtonText = craftingNothingButton.GetComponentInChildren<TMP_Text>();
        craftingNothingButtonText.transform.SetParent(craftingNothingButton.transform, false);
        craftingNothingButtonText.font = craftingButtonTextFont;
        craftingNothingButtonText.fontSize = 30;
        craftingNothingButtonText.color = new Color32(13, 94, 175, 255);
        craftingNothingButtonText.text = "nothing";

        craftingNothingButton.name = "vesselNothingButton";

        craftingNothingButton.onClick.AddListener(delegate
        {
            Debug.Log("Crafting: A crafting choice was clicked.");
            ChooseCraftingChoice(craftingNothingButton);
        });
    }

    private void UnpackMaterials()
    {
        for (int i = 0; i < controller.inventory.inventory.Count; i++)
        {
            for (int r = 0; r < controller.inventory.allReagents.Count; r++)
            {
                if (controller.inventory.allReagents[r].staticName == controller.inventory.inventory[i])
                {
                    if (controller.inventory.allReagents[r].reagentType == "material")
                    {
                        Button craftingButton = Instantiate(craftingChoicePrefab);

                        Image craftingButtonImage = craftingButton.GetComponent<Image>();
                        craftingButton.transform.SetParent(craftingButtonPanel.transform, false);
                        craftingButtonImage.enabled = craftingButtonImage.enabled;

                        TMP_Text craftingButtonText = craftingButton.GetComponentInChildren<TMP_Text>();
                        craftingButtonText.transform.SetParent(craftingButton.transform, false);
                        craftingButtonText.font = craftingButtonTextFont;
                        craftingButtonText.fontSize = 30;
                        craftingButtonText.color = new Color32(13, 94, 175, 255);
                        craftingButtonText.text = controller.inventory.allReagents[r].staticName + ": " + controller.inventory.allReagents[r].materialProperty + " (" + controller.inventory.allReagents[r].materialCategory + ")";

                        craftingButton.name = controller.inventory.allReagents[r].materialProperty + "Button";

                        craftingButton.onClick.AddListener(delegate
                        {
                            Debug.Log("Crafting: A crafting choice was clicked.");
                            ChooseCraftingChoice(craftingButton);
                        });
                    }
                }
            }
        }

        Button craftingNothingButton = Instantiate(craftingChoicePrefab);

        Image craftingNothingButtonImage = craftingNothingButton.GetComponent<Image>();
        craftingNothingButton.transform.SetParent(craftingButtonPanel.transform, false);
        craftingNothingButtonImage.enabled = craftingNothingButtonImage.enabled;

        TMP_Text craftingNothingButtonText = craftingNothingButton.GetComponentInChildren<TMP_Text>();
        craftingNothingButtonText.transform.SetParent(craftingNothingButton.transform, false);
        craftingNothingButtonText.font = craftingButtonTextFont;
        craftingNothingButtonText.fontSize = 30;
        craftingNothingButtonText.color = new Color32(13, 94, 175, 255);
        craftingNothingButtonText.text = "nothing";

        craftingNothingButton.name = "materialNothingButton";

        craftingNothingButton.onClick.AddListener(delegate
        {
            Debug.Log("Crafting: A crafting choice was clicked.");
            ChooseCraftingChoice(craftingNothingButton);
        });
    }

    private void UnpackColors()
    {
        for (int i = 0; i < controller.inventory.inventory.Count; i++)
        {
            for (int r = 0; r < controller.inventory.allReagents.Count; r++)
            {
                if (controller.inventory.allReagents[r].staticName == controller.inventory.inventory[i])
                {
                    if (controller.inventory.allReagents[r].reagentType == "color")
                    {
                        Button craftingButton = Instantiate(craftingChoicePrefab);

                        Image craftingButtonImage = craftingButton.GetComponent<Image>();
                        craftingButton.transform.SetParent(craftingButtonPanel.transform, false);
                        craftingButtonImage.enabled = craftingButtonImage.enabled;

                        TMP_Text craftingButtonText = craftingButton.GetComponentInChildren<TMP_Text>();
                        craftingButtonText.transform.SetParent(craftingButton.transform, false);
                        craftingButtonText.font = craftingButtonTextFont;
                        craftingButtonText.fontSize = 30;
                        craftingButtonText.color = new Color32(13, 94, 175, 255);
                        craftingButtonText.text = controller.inventory.allReagents[r].staticName + ": " + controller.inventory.allReagents[r].colorProperty + " (" + controller.inventory.allReagents[r].colorCategory + ")";

                        craftingButton.name = controller.inventory.allReagents[r].colorProperty + "Button";

                        craftingButton.onClick.AddListener(delegate
                        {
                            Debug.Log("Crafting: A crafting choice was clicked.");
                            ChooseCraftingChoice(craftingButton);
                        });
                    }
                }
            }
        }

        Button craftingNothingButton = Instantiate(craftingChoicePrefab);

        Image craftingNothingButtonImage = craftingNothingButton.GetComponent<Image>();
        craftingNothingButton.transform.SetParent(craftingButtonPanel.transform, false);
        craftingNothingButtonImage.enabled = craftingNothingButtonImage.enabled;

        TMP_Text craftingNothingButtonText = craftingNothingButton.GetComponentInChildren<TMP_Text>();
        craftingNothingButtonText.transform.SetParent(craftingNothingButton.transform, false);
        craftingNothingButtonText.font = craftingButtonTextFont;
        craftingNothingButtonText.fontSize = 30;
        craftingNothingButtonText.color = new Color32(13, 94, 175, 255);
        craftingNothingButtonText.text = "nothing";

        craftingNothingButton.name = "colorNothingButton";

        craftingNothingButton.onClick.AddListener(delegate
        {
            Debug.Log("Crafting: A crafting choice was clicked.");
            ChooseCraftingChoice(craftingNothingButton);
        });
    }

    private void UnpackConfirm()
    {
        Button craftingButton = Instantiate(craftingChoicePrefab);

        Image craftingButtonImage = craftingButton.GetComponent<Image>();
        craftingButton.transform.SetParent(craftingButtonPanel.transform, false);
        craftingButtonImage.enabled = craftingButtonImage.enabled;

        TMP_Text craftingButtonText = craftingButton.GetComponentInChildren<TMP_Text>();
        craftingButtonText.transform.SetParent(craftingButton.transform, false);
        craftingButtonText.font = craftingButtonTextFont;
        craftingButtonText.fontSize = 30;
        craftingButtonText.color = new Color32(13, 94, 175, 255);

        if (artistIndex.Count == 0)
        {
            craftingButtonText.text = "okay";
        }
        else
        {
            craftingButtonText.text = confirmButtonText;
        }

        craftingButton.name = "confirmButton";

        craftingButton.onClick.AddListener(delegate
        {
            Debug.Log("Crafting: A crafting choice was clicked.");
            ChooseCraftingChoice(craftingButton);
        });
    }

    private void UnpackFinish()
    {
        Button craftingButton = Instantiate(craftingChoicePrefab);

        Image craftingButtonImage = craftingButton.GetComponent<Image>();
        craftingButton.transform.SetParent(craftingButtonPanel.transform, false);
        craftingButtonImage.enabled = craftingButtonImage.enabled;

        TMP_Text craftingButtonText = craftingButton.GetComponentInChildren<TMP_Text>();
        craftingButtonText.transform.SetParent(craftingButton.transform, false);
        craftingButtonText.font = craftingButtonTextFont;
        craftingButtonText.fontSize = 30;
        craftingButtonText.color = new Color32(13, 94, 175, 255);

        craftingButtonText.text = finishButtonText;

        craftingButton.name = "finishButton";

        craftingButton.onClick.AddListener(delegate
        {
            Debug.Log("Crafting: A crafting choice was clicked.");
            ChooseCraftingChoice(craftingButton);
        });
    }

    void EraseUI()
    {
        Debug.Log("Crafting.EraseUI() was called.");

        for (int i = 0; i < craftingTextPanel.transform.childCount; i++)
        {
            Destroy(craftingTextPanel.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < craftingButtonPanel.transform.childCount; i++)
        {
            Destroy(craftingButtonPanel.transform.GetChild(i).gameObject);
        }
    }

    void ProduceCraftingItem()
    {
        if (color != "nothing" && material != "nothing" && vessel != "nothing")
        {
            if (recipient == "Gloria")
            {
                giftForGloria = color + " " + material + " " + vessel;
                scoreForGloria = valueAddGloria;
                controller.inventory.objectToAdd = giftForGloria + " (for " + "gloria)";
                controller.inventory.CollectStaticFromCrafting();
            }
            else if (recipient == "Julian")
            {
                giftForJulian = color + " " + material + " " + vessel;
                scoreForJulian = valueAddJulian;
                controller.inventory.objectToAdd = giftForJulian + " (for " + "julian)";
                controller.inventory.CollectStaticFromCrafting();
            }
            else if (recipient == "Li")
            {
                giftForLi = color + " " + material + " " + vessel;
                scoreForLi = valueAddLi;
                controller.inventory.objectToAdd = giftForLi + " (for " + "li)";
                controller.inventory.CollectStaticFromCrafting();
            }
        }
        else
        {
            if (recipient == "Gloria")
            {
                giftForGloria = "empty token";
                scoreForGloria = 0;
                controller.inventory.objectToAdd = giftForGloria + " (for " + "gloria)";
                controller.inventory.CollectStaticFromCrafting();
            }
            else if (recipient == "Julian")
            {
                giftForJulian = "empty token";
                scoreForJulian = 0;
                controller.inventory.objectToAdd = giftForJulian + " (for " + "julian)";
                controller.inventory.CollectStaticFromCrafting();
            }
            else if (recipient == "Li")
            {
                giftForLi = "empty token";
                scoreForLi = 0;
                controller.inventory.objectToAdd = giftForLi + " (for " + "li)";
                controller.inventory.CollectStaticFromCrafting();
            }
        }
    }

    void ClearCraftingValues()
    {
        recipient = null;
        vessel = null;
        material = null;
        color = null;
        valueAddGloria = 0;
        valueAddJulian = 0;
        valueAddLi = 0;
    }

    private void ChooseCraftingChoice(Button button)
    {
        // Recipients
        if (button.name == "GloriaButton")
        {
            controller.crafting.recipient = "Gloria";
            controller.crafting.artistIndex.Remove(controller.crafting.recipient);
            controller.crafting.RefreshCraftingUI(controller.crafting.pickVessel);
        }
        else if (button.name == "JulianButton")
        {
            controller.crafting.recipient = "Julian";
            controller.crafting.artistIndex.Remove(controller.crafting.recipient);
            controller.crafting.RefreshCraftingUI(controller.crafting.pickVessel);
        }
        else if (button.name == "LiButton")
        {
            controller.crafting.recipient = "Li";
            controller.crafting.artistIndex.Remove(controller.crafting.recipient);
            controller.crafting.RefreshCraftingUI(controller.crafting.pickVessel);
        }
        // Vessels
        else if (button.name == "watchButton")
        {
            Debug.Log("557: is this working");
            vessel = "watch";
            string vesselToRemove = "leather watch";
            controller.crafting.valueAddGloria += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);

            for (int v = 0; v < controller.inventory.inventory.Count; v++)
            {
                if (controller.inventory.inventory[v] == vesselToRemove)
                {
                    controller.inventory.inventory.RemoveAt(v);
                }
            }
        }
        else if (button.name == "ringButton")
        {
            vessel = "ring";
            string vesselToRemove = "cerulean ring";
            controller.crafting.valueAddGloria += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);

            for (int v = 0; v < controller.inventory.inventory.Count; v++)
            {
                if (controller.inventory.inventory[v] == vesselToRemove)
                {
                    controller.inventory.inventory.RemoveAt(v);
                }
            }
        }
        else if (button.name == "necklaceButton")
        {
            vessel = "necklace";
            string vesselToRemove = "shell necklace";
            controller.crafting.valueAddGloria += 2;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);

            for (int v = 0; v < controller.inventory.inventory.Count; v++)
            {
                if (controller.inventory.inventory[v] == vesselToRemove)
                {
                    controller.inventory.inventory.RemoveAt(v);
                }
            }
        }
        else if (button.name == "chess setButton")
        {
            vessel = "chess set";
            string vesselToRemove = "marble chess set";
            controller.crafting.valueAddJulian += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);

            for (int v = 0; v < controller.inventory.inventory.Count; v++)
            {
                if (controller.inventory.inventory[v] == vesselToRemove)
                {
                    controller.inventory.inventory.RemoveAt(v);
                }
            }
        }
        else if (button.name == "dollButton")
        {
            vessel = "doll";
            string vesselToRemove = "silk doll";
            controller.crafting.valueAddJulian += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);

            for (int v = 0; v < controller.inventory.inventory.Count; v++)
            {
                if (controller.inventory.inventory[v] == vesselToRemove)
                {
                    controller.inventory.inventory.RemoveAt(v);
                }
            }
        }
        else if (button.name == "diceButton")
        {
            vessel = "dice";
            string vesselToRemove = "emerald dice";
            controller.crafting.valueAddJulian += 2;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);

            for (int v = 0; v < controller.inventory.inventory.Count; v++)
            {
                if (controller.inventory.inventory[v] == vesselToRemove)
                {
                    controller.inventory.inventory.RemoveAt(v);
                }
            }
        }
        else if (button.name == "fluteButton")
        {
            vessel = "flute";
            string vesselToRemove = "glass flute";
            controller.crafting.valueAddLi += 2;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);

            for (int v = 0; v < controller.inventory.inventory.Count; v++)
            {
                if (controller.inventory.inventory[v] == vesselToRemove)
                {
                    controller.inventory.inventory.RemoveAt(v);
                }
            }
        }
        else if (button.name == "guitarButton")
        {
            vessel = "guitar";
            string vesselToRemove = "crimson guitar";
            controller.crafting.valueAddLi += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);

            for (int v = 0; v < controller.inventory.inventory.Count; v++)
            {
                if (controller.inventory.inventory[v] == vesselToRemove)
                {
                    controller.inventory.inventory.RemoveAt(v);
                }
            }
        }
        else if (button.name == "drumButton")
        {
            vessel = "drum";
            string vesselToRemove = "steel drum";
            controller.crafting.valueAddLi += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);

            for (int v = 0; v < controller.inventory.inventory.Count; v++)
            {
                if (controller.inventory.inventory[v] == vesselToRemove)
                {
                    controller.inventory.inventory.RemoveAt(v);
                }
            }
        }
        else if (button.name == "vesselNothingButton")
        {
            vessel = "nothing";
            controller.crafting.RefreshCraftingUI(controller.crafting.pickMaterial);
        }
        // Materials
        else if (button.name == "cedarButton")
        {
            material = "cedar";
            string materialToRemove = "cedar box";
            controller.crafting.valueAddJulian += 2;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickColor);

            for (int m = 0; m < controller.inventory.inventory.Count; m++)
            {
                if (controller.inventory.inventory[m] == materialToRemove)
                {
                    controller.inventory.inventory.RemoveAt(m);
                }
            }
        }
        else if (button.name == "birchButton")
        {
            material = "birch";
            string materialToRemove = "birch ukelele";
            controller.crafting.valueAddJulian += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickColor);

            for (int m = 0; m < controller.inventory.inventory.Count; m++)
            {
                if (controller.inventory.inventory[m] == materialToRemove)
                {
                    controller.inventory.inventory.RemoveAt(m);
                }
            }
        }
        else if (button.name == "oakButton")
        {
            material = "oak";
            string materialToRemove = "oak rocking horse";
            controller.crafting.valueAddJulian += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickColor);

            for (int m = 0; m < controller.inventory.inventory.Count; m++)
            {
                if (controller.inventory.inventory[m] == materialToRemove)
                {
                    controller.inventory.inventory.RemoveAt(m);
                }
            }
        }
        else if (button.name == "goldButton")
        {
            material = "gold";
            string materialToRemove = "gold earrings";
            controller.crafting.valueAddGloria += 1;
            controller.crafting.valueAddLi += 2;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickColor);

            for (int m = 0; m < controller.inventory.inventory.Count; m++)
            {
                if (controller.inventory.inventory[m] == materialToRemove)
                {
                    controller.inventory.inventory.RemoveAt(m);
                }
            }
        }
        else if (button.name == "silverButton")
        {
            material = "silver";
            string materialToRemove = "silver knife";
            controller.crafting.valueAddGloria += 2;
            controller.crafting.valueAddLi += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickColor);

            for (int m = 0; m < controller.inventory.inventory.Count; m++)
            {
                if (controller.inventory.inventory[m] == materialToRemove)
                {
                    controller.inventory.inventory.RemoveAt(m);
                }
            }
        }
        else if (button.name == "brassButton")
        {
            material = "brass";
            string materialToRemove = "brass trumpet";
            controller.crafting.valueAddGloria += 1;
            controller.crafting.valueAddLi += 1;
            controller.crafting.RefreshCraftingUI(controller.crafting.pickColor);

            for (int m = 0; m < controller.inventory.inventory.Count; m++)
            {
                if (controller.inventory.inventory[m] == materialToRemove)
                {
                    controller.inventory.inventory.RemoveAt(m);
                }
            }
        }
        else if (button.name == "materialNothingButton")
        {
            material = "nothing";
            controller.crafting.RefreshCraftingUI(controller.crafting.pickColor);
        }
        // Colors
        else if (button.name == "navyButton")
        {
            color = "navy";
            string colorToRemove = "navy scarf";
            controller.crafting.valueAddGloria += 1;
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);

            for (int c = 0; c < controller.inventory.inventory.Count; c++)
            {
                if (controller.inventory.inventory[c] == colorToRemove)
                {
                    controller.inventory.inventory.RemoveAt(c);
                }
            }
        }
        else if (button.name == "cyanButton")
        {
            color = "cyan";
            string colorToRemove = "cyan stone";
            controller.crafting.valueAddGloria += 1;
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);

            for (int c = 0; c < controller.inventory.inventory.Count; c++)
            {
                if (controller.inventory.inventory[c] == colorToRemove)
                {
                    controller.inventory.inventory.RemoveAt(c);
                }
            }
        }
        else if (button.name == "azureButton")
        {
            color = "azure";
            string colorToRemove = "azure horn";
            controller.crafting.valueAddGloria += 2;
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);

            for (int c = 0; c < controller.inventory.inventory.Count; c++)
            {
                if (controller.inventory.inventory[c] == colorToRemove)
                {
                    controller.inventory.inventory.RemoveAt(c);
                }
            }
        }
        else if (button.name == "cherryButton")
        {
            color = "cherry";
            string colorToRemove = "cherry harmonica";
            controller.crafting.valueAddLi += 1;
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);

            for (int c = 0; c < controller.inventory.inventory.Count; c++)
            {
                if (controller.inventory.inventory[c] == colorToRemove)
                {
                    controller.inventory.inventory.RemoveAt(c);
                }
            }
        }
        else if (button.name == "vermilionButton")
        {
            color = "vermilion";
            string colorToRemove = "vermilion statue";
            controller.crafting.valueAddLi += 2;
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);

            for (int c = 0; c < controller.inventory.inventory.Count; c++)
            {
                if (controller.inventory.inventory[c] == colorToRemove)
                {
                    controller.inventory.inventory.RemoveAt(c);
                }
            }
        }
        else if (button.name == "brickButton")
        {
            color = "brick";
            string colorToRemove = "brick leather";
            controller.crafting.valueAddLi += 1;
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);

            for (int c = 0; c < controller.inventory.inventory.Count; c++)
            {
                if (controller.inventory.inventory[c] == colorToRemove)
                {
                    controller.inventory.inventory.RemoveAt(c);
                }
            }
        }
        else if (button.name == "jadeButton")
        {
            color = "jade";
            string colorToRemove = "jade  bracelet";
            controller.crafting.valueAddJulian += 1;
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);

            for (int c = 0; c < controller.inventory.inventory.Count; c++)
            {
                if (controller.inventory.inventory[c] == colorToRemove)
                {
                    controller.inventory.inventory.RemoveAt(c);
                }
            }
        }
        else if (button.name == "limeButton")
        {
            color = "lime";
            string colorToRemove = "lime jelly";
            controller.crafting.valueAddJulian += 1;
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);

            for (int c = 0; c < controller.inventory.inventory.Count; c++)
            {
                if (controller.inventory.inventory[c] == colorToRemove)
                {
                    controller.inventory.inventory.RemoveAt(c);
                }
            }
        }
        else if (button.name == "oliveButton")
        {
            color = "olive";
            string colorToRemove = "olive jacket";
            controller.crafting.valueAddJulian += 2;
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);

            for (int c = 0; c < controller.inventory.inventory.Count; c++)
            {
                if (controller.inventory.inventory[c] == colorToRemove)
                {
                    controller.inventory.inventory.RemoveAt(c);
                }
            }
        }
        else if (button.name == "colorNothingButton")
        {
            color = "nothing";
            ProduceCraftingItem();
            SetConfirmText();
            controller.crafting.RefreshCraftingUI(controller.crafting.confirm);
        }
        // Other buttons
        else if (button.name == "confirmButton")
        {
            if (artistIndex.Count == 0)
            {
                controller.crafting.RefreshCraftingUI(controller.crafting.finish);
            }
            else
            {
                controller.crafting.RefreshCraftingUI(controller.crafting.pickRecipient);
            }
        }
        else if (button.name == "finishButton")
        {
            
            EraseUI();
            controller.dossier.gloria.mobState = 4;
            controller.dossier.julian.mobState = 4;
            controller.dossier.li.mobState = 4;

            controller.roomNavigation.currentRoom = controller.variableTracker.landingPage;
            
            controller.CanvasModeSwitch("room");
        }
    }
}