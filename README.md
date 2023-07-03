# wandertale
Wandertale is a starting point for building DOS-style room-based and branching narrative text games using Ink and Unity.

Most content creation can be done via dragon and drop and text fields in the Unity editor with objects representing rooms, mobs, and statics. For example, you can easily set the number of exits on one room object and drag other room objects into the field for each exit—same goes for NPCs, monsters, items, and so on.

There is also a basic inventory system and an additional canvas for branching dialogue. Dialogues are scripts made using the Ink scripting language.

To share variables and states between the Unity game and Ink scripts, use VariableTracker.cs. Code is heavily commented to make it relatively easy to pick and up use this but there's not much in the way of documentation, as I made Wandertale as something I can use in my own projects—mostly jam games, for jams like DOS Game Jam or InkJam.
