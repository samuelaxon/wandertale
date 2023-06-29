using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectController : MonoBehaviour
{
    public GameController controller;

    public List<Room> unlockedRooms;
    public List<Room> allRooms;
    public List<Room> lockedRooms;
    public Static key;
    public List<Mob> mobs = new List<Mob>();
    public List<Mob> mobsMinusVictim = new List<Mob>();
    public List<Mob> mobsMinusVictimAndMurderer = new List<Mob>();
    public List<Static> items = new List<Static>();
    public List<Static> hidingSpots = new List<Static>();

    List<string> allMobNames = new List<string>();
    List<string> mobsToAlibize = new List<string>();

    Dictionary<string, string> alibiKeyToValue = new Dictionary<string, string>(); // We have two dictonaries here that are set up to mirror one another since reverse lookup is impractical with one dictionary.
    Dictionary<string, string> alibiValueToKey = new Dictionary<string, string>();

    private void Awake()
    {
        Debug.Log("ObjectController/Awake() was called.");
        controller = GetComponent<GameController>();
    }

    // Runs all randomizer functions at the start of a new game.
    public void MasterRandomizer()
    {
        Debug.Log("ObjectController/MasterRandomizer() was called.");

        PickVictimAndMurderer();
        PickWeaponAndSpot();
        MobRandomizer();
        StaticRandomizer();
    }

    // Randomly picks a victim and murderer from the available pool of mobs for each playthrough, and records their genders and names in VariableTracker for use elsewhere.
    private void PickVictimAndMurderer()
    {
        List<Mob> mobsToPickFrom = new List<Mob>(mobs);

        int victimSelectionKey = Random.Range(0, mobsToPickFrom.Count);

        controller.variableTracker.victim = mobsToPickFrom[victimSelectionKey].mobName;

        controller.variableTracker.victimGender = mobsToPickFrom[victimSelectionKey].gender;

        mobsToPickFrom.RemoveAt(victimSelectionKey);

        int murdererSelectionKey = Random.Range(0, mobsToPickFrom.Count);

        controller.variableTracker.murderer = mobsToPickFrom[murdererSelectionKey].mobName;
        controller.variableTracker.murdererGender = mobsToPickFrom[murdererSelectionKey].gender;

        mobsMinusVictim = new List<Mob>(mobsToPickFrom);

        mobsToPickFrom.RemoveAt(murdererSelectionKey);

        mobsMinusVictimAndMurderer = new List<Mob>(mobsToPickFrom);

        AlibiRandomizer();
    }

    // Randomly sorts mobs that are not the murderer or victim into alibi pairings, and assigns a false alibi to the murderer.
    private void AlibiRandomizer()
    {
        Debug.Log("ObjectController/AlibiRandomizer() was called.");

        for (int mobToStringify = 0; mobToStringify < mobsMinusVictimAndMurderer.Count; mobToStringify++)
        {
            Debug.Log("ObjectController/AlibiRandomizer(): Stringifying mob " + mobsMinusVictimAndMurderer[mobToStringify].mobName);
            mobsToAlibize.Add(mobsMinusVictimAndMurderer[mobToStringify].mobName);
        }

        for (int z = 0; z < mobsToAlibize.Count; z++)
        {
            Debug.Log("ObjectController/AlibiRandomizer(): mobsToAlibize contains " + mobsToAlibize[z] + " at index " + z);
        }

        if (mobsToAlibize != null)
        {
            Debug.Log("ObjectController/AlibiRandomizer(): mobsMinusVictimAndMurderer was not null, so AlibiRandomizer() began operations.");

            for (int mobToAssign = 0; mobToAssign < mobsToAlibize.Count; mobToAssign++)
            {
                if (alibiKeyToValue.ContainsValue(mobsToAlibize[mobToAssign]) || alibiKeyToValue.ContainsKey(mobsToAlibize[mobToAssign]))
                {
                    Debug.Log("ObjectController/AlibiRandomizer(): alibiKeyToValue already contained mob " + mobsToAlibize[mobToAssign] + " skipping.");
                    continue;
                }
                else
                {
                    Debug.Log("ObjectController/AlibiRandomizer(): Addressing mob " + mobsToAlibize[mobToAssign] + " at index " + mobToAssign);

                    int sortedMobAlibi = AlibiNumberPicker(mobToAssign);

                    Debug.Log("ObjectController/AlibiRandomizer(): Number received from AlibiNumberPicker() is " + sortedMobAlibi);

                    Debug.Log("ObjectController/AlibiRandomizer(): Pairing " + mobsToAlibize[mobToAssign] + " with " + mobsToAlibize[sortedMobAlibi]);

                    Debug.Log("ObjectController/AlibiRandomizer(): In alibiKeyToValue, adding key " + mobsToAlibize[mobToAssign] + " with value " + mobsToAlibize[sortedMobAlibi]);
                    alibiKeyToValue.Add(mobsToAlibize[mobToAssign], mobsToAlibize[sortedMobAlibi]);

                    Debug.Log("ObjectController/AlibiRandomizer(): In alibiValueToKey, adding key " + mobsToAlibize[sortedMobAlibi] + " with value " + mobsToAlibize[mobToAssign]);
                    alibiValueToKey.Add(mobsToAlibize[sortedMobAlibi], mobsToAlibize[mobToAssign]);
                }
            }
        }
        else
        {
            Debug.Log("ObjectController/AlibiRandomizer(): mobsMinusVictimAndMurderer was null, so AlibiRandomizer() could not select alibis.");
        }

        // Below, we are just reporting what it is in the two lists to make sure everything is correct when debugging.
        foreach (KeyValuePair<string, string> kvp in alibiKeyToValue)
        {
            Debug.Log("ObjectController/AlibiRandomizer(): In alibiKeyToValue, key is " + kvp.Key + " and value is " + kvp.Value);
        }

        foreach (KeyValuePair<string, string> pvk in alibiValueToKey)
        {
            Debug.Log("ObjectController/AlibiRandomizer(): In alibiValueToKey, key is " + pvk.Key + " and value is " + pvk.Value);
        }

        AlibiAssigner();
    }

    // Randomly generates numbers for use by AlibiRandomizer() to pick alibis.
    int AlibiNumberPicker(int mobToExclude)
    {
        Debug.Log("ObjectController/AlibiNumberPicker() was called with mobToExclude " + mobToExclude + " and countSize " + mobsToAlibize.Count);

        int alibiPickedNumber = Random.Range(0, mobsToAlibize.Count);
        Debug.Log("ObjectController/AlibiNumberPicker(): Randomly picked alibiPickedNumber " + alibiPickedNumber);

        if (alibiPickedNumber == mobToExclude || alibiKeyToValue.ContainsKey(mobsToAlibize[alibiPickedNumber]) || alibiKeyToValue.ContainsValue(mobsToAlibize[alibiPickedNumber]))
        {
            Debug.Log("ObjectController/AlibiNumberPicker(): alibiPickedNumber was equal to mobToExclude, or alibiValueToKey contained the randomly picked mob, so calling AlibiNumberPicker() again.");
            alibiPickedNumber = AlibiNumberPicker(mobToExclude);
        }
        else
        {
            Debug.Log("ObjectController/AlibiNumberPicker(): Took mobToExclude " + mobToExclude + " and countSize " + mobsToAlibize.Count + " to return number " + alibiPickedNumber);
        }

        return alibiPickedNumber;
    }

    // Takes the alibi assignments from AlibiRandomizer() and changes all necessary variables accordingly for use in other parts of the application.
    private void AlibiAssigner()
    {
        // Populates a List with the name strings associated with every mob.
        for (int mobToStringify = 0; mobToStringify < mobs.Count; mobToStringify++)
        {
            Debug.Log("ObjectController/AlibiAssigner(): Stringifying mob " + mobs[mobToStringify].mobName);
            allMobNames.Add(mobs[mobToStringify].mobName);
        }

        // Report which strings ended up in the list of mob name strings to make sure it worked.
        for (int z = 0; z < allMobNames.Count; z++)
        {
            Debug.Log("ObjectController/AlibiAssigner(): allMobNames contains " + allMobNames[z] + " at index " + z);
        }

        // Sets the alibi string on each Mob object to match the string assigned to that NPC.
        for (int mobToAddress = 0; mobToAddress < mobsMinusVictimAndMurderer.Count; mobToAddress++)
        {
            for (int alibiKey = 0; alibiKey < alibiKeyToValue.Keys.Count; alibiKey++)
            {
                foreach (KeyValuePair<string, string> entry in alibiKeyToValue)
                {
                    if (mobsMinusVictimAndMurderer[mobToAddress].mobName == entry.Key)
                    {
                        mobsMinusVictimAndMurderer[mobToAddress].alibi = entry.Value;
                    }
                }
            }

            for (int alibiKey = 0; alibiKey < alibiValueToKey.Keys.Count; alibiKey++)
            {
                foreach (KeyValuePair<string, string> entry in alibiValueToKey)
                {
                    if (mobsMinusVictimAndMurderer[mobToAddress].mobName == entry.Key)
                    {
                        mobsMinusVictimAndMurderer[mobToAddress].alibi = entry.Value;
                    }
                }
            }
        }

        // Reports back the alibi string values assigned to Mob objects to make sure they are correct.
        for (int mobToCheckAlibi = 0; mobToCheckAlibi < mobsMinusVictimAndMurderer.Count; mobToCheckAlibi++)
        {
            Debug.Log("ObjectController/Assigner(): Alibi string for Mob object " + mobsMinusVictimAndMurderer[mobToCheckAlibi].mobName + " is set to " + mobsMinusVictimAndMurderer[mobToCheckAlibi].alibi);
        }

        // Assign's the alibi string value to the Mob object selected as the murderer.
        for (int mobToCheckMurderer = 0; mobToCheckMurderer < mobs.Count; mobToCheckMurderer++)
        {
            if (mobs[mobToCheckMurderer].mobName == controller.variableTracker.murderer)
            {
                Debug.Log("ObjectController/AlibiAssigner(): Mob " + mobs[mobToCheckMurderer].mobName + " matched murderer " + controller.variableTracker.murderer);

                int murdererAlibiKeyInt = Random.Range(0, mobsMinusVictimAndMurderer.Count);

                mobs[mobToCheckMurderer].alibi = mobsMinusVictimAndMurderer[murdererAlibiKeyInt].mobName;

                Debug.Log("ObjectController/AlibiAssigner(): Murderer mob " + mobs[mobToCheckMurderer].mobName + " alibi string was set to " + mobs[mobToCheckMurderer].alibi);
            }
        }

        // Calls a function in VariableTracker to convert all these alibis into something Ink can deal with.
        controller.variableTracker.AssignInkAlibis();
    }

    // Randomly picks a weapon static as the murder weapon, as well as a hiding spot for the body. Also records the weapon type for passthrough to Ink via VariableTracker.
    private void PickWeaponAndSpot()
    {
        Debug.Log("ObjectController/PickWeaponAndSpot() was called.");

        List<Static> itemsToPickFrom = new List<Static>(items);

        // Removes the key from the list of items that can become the murder weapon.
        for (int k = 0; k <itemsToPickFrom.Count; k++)
        {
            if (itemsToPickFrom[k].staticName == "key")
            {
                Debug.Log("ObjectController/PickWeaponAndSpot(): Located item with name " + itemsToPickFrom[k].staticName + " at itemsToPickFrom index " + k + " and removing from list.");
                itemsToPickFrom.RemoveAt(k);
            }
        }

        int itemSelectionKey = Random.Range(0, itemsToPickFrom.Count);
        controller.variableTracker.murderWeapon = itemsToPickFrom[itemSelectionKey].staticName;
        controller.variableTracker.weaponType = itemsToPickFrom[itemSelectionKey].weaponType;
        Debug.Log("ObjectController/PickWeaponAndSpot(): Murder weapon selected: " + itemsToPickFrom[itemSelectionKey].staticName + " of type " + itemsToPickFrom[itemSelectionKey].weaponType);

        int spotSelectionKey = Random.Range(0, hidingSpots.Count);
        controller.variableTracker.hidingSpot = hidingSpots[spotSelectionKey].staticName;
        Debug.Log("ObjectController/PickWeaponAndSpot(): Hiding spot selected: " + hidingSpots[spotSelectionKey].staticName);
    }

    // Called at game start (or any special case) to randomize the locations of all mobs based on a set of rules defined here.
    private void MobRandomizer()
    {
        Debug.Log("ObjectController/MobRandomizer() was called.");

        List<Mob> mobsToPickFrom = new List<Mob>(mobsMinusVictim);

        for (int i = 0; i < unlockedRooms.Count; i++)
        {
            Debug.Log("ObjectController/MobRandomizer(): Loop is addressing room " + unlockedRooms[i].name);

            if (mobsToPickFrom.Count > 0)
            {
                int sortedMobValue = Random.Range(0, mobsToPickFrom.Count);
                Debug.Log("ObjectController/MobRandomizer(): sortedMobValue is " + sortedMobValue);

                Debug.Log("ObjectController/MobRandomizer(): Mob sorted to " + unlockedRooms[i].name + " is " + mobsToPickFrom[sortedMobValue].name);

                unlockedRooms[i].mobs.Add(mobsToPickFrom[sortedMobValue]);

                // Sets the mob state based on the current room.
                for (int mobState = 0; mobState < mobsToPickFrom[sortedMobValue].mobStories.Count; mobState++)
                {
                    if (unlockedRooms[i] == mobsToPickFrom[sortedMobValue].mobStories[mobState].roomAssignment)
                    {
                        mobsToPickFrom[sortedMobValue].mobState = mobState;

                        Debug.Log("ObjectController/MobRandomizer(): Set state for mob " + mobsToPickFrom[sortedMobValue].name + " to " + mobsToPickFrom[sortedMobValue].mobState + " from room " + unlockedRooms[i]);
                    }
                }

                for (int m = 0; m < unlockedRooms[i].mobs.Count; m++)
                {
                    Debug.Log("ObjectController.MobRandomizer(): Mobs list in room " + unlockedRooms[i].name + " now includes " + unlockedRooms[i].mobs[m].name);
                }

                mobsToPickFrom.RemoveAt(sortedMobValue);
            }
            else
            {
                Debug.Log("ObjectController.MobRandomizer(): All mobs from mobsMinusVictim have been assigned to rooms, so no mob will be assigned to " + unlockedRooms[i].name);
            }
        }

        Debug.Log("ObjectController.MobRandomizer() finished.");
    }

    // Called at game start (or any special case) to randomize the locations of desired static items based on a set of rules defined here.
    private void StaticRandomizer()
    {
        Debug.Log("ObjectController/StaticRandomizer() was called.");

        List<Static> itemsToPickFrom = new List<Static>(items);
        List<Room> roomsToPlaceIn = new List<Room>(allRooms);

        while (itemsToPickFrom.Count > 0 && roomsToPlaceIn.Count > 0)
        {
            Debug.Log("ObjectController/StaticRandomizer(): While loop found that itemsToPickFrom and roomsToPlaceIn have values greater than 0.");
            Debug.Log("ObjectController/StaticRandomizer(): itemsToPickFrom count equals " + itemsToPickFrom.Count + " and roomsToPlaceIn Count equals" + roomsToPlaceIn.Count);

            for (int s = 0; s < itemsToPickFrom.Count; s++)
            {
                Debug.Log("ObjectController/StaticRandomizer(): For loops is addressing item " + itemsToPickFrom[s].name);

                int sortedRoomValue = Random.Range(0, roomsToPlaceIn.Count);

                Debug.Log("ObjectController/StaticRandomizer(): Room randomly selected for sorting is: " + roomsToPlaceIn[sortedRoomValue]);

                if (lockedRooms.Contains(roomsToPlaceIn[sortedRoomValue]) && itemsToPickFrom[s] == key)
                {
                    Debug.Log("ObjectController/StaticRandomizer(): " + itemsToPickFrom[s].name + " is the key and was placed in locked room" + roomsToPlaceIn[sortedRoomValue]);

                    for (int r = 0; r < roomsToPlaceIn.Count; r++)
                        {
                            Debug.Log("ObjectController/StaticRandomizer(): Item removal is addressing room " + roomsToPlaceIn[r].name);

                            for (int x = 0; x < roomsToPlaceIn[r].statics.Count; x++)
                            {
                                Debug.Log("ObjectController/StaticRandomizer(): Item removal check is addressing item " + roomsToPlaceIn[r].statics[x].name + " in room " + roomsToPlaceIn[r]);
                                
                                if (items.Contains(roomsToPlaceIn[r].statics[x]))
                                {
                                    Debug.Log("ObjectController/StaticRandomizer(): Removing item " + roomsToPlaceIn[r].statics[x].name + " from room " + roomsToPlaceIn[r].name);
                                    
                                    roomsToPlaceIn[r].statics.Remove(roomsToPlaceIn[r].statics[x]);
                                }
                            }
                        }

                    Debug.Log("ObjectController/StaticRandomizer(): For loop will now break.");

                    break;
                }
                else
                {
                    Debug.Log("ObjectController/StaticRandomizer(): The key was not placed in a locked room this iteration.");

                    roomsToPlaceIn[sortedRoomValue].statics.Add(itemsToPickFrom[s]);

                    Debug.Log("ObjectController/StaticRandomizer(): Placed static " + itemsToPickFrom[s].name + " in room " + roomsToPlaceIn[sortedRoomValue].name);
                    Debug.Log("ObjectController/StaticRandomizer(): Removing room " + roomsToPlaceIn[sortedRoomValue].name + " from roomsToPlaceIn.");

                    roomsToPlaceIn.Remove(roomsToPlaceIn[sortedRoomValue]);
                }
            }
        }

        Debug.Log("ObjectController/StaticRandomizer() finished.");
    }
}