VAR playerDangerStage = ""

VAR murderer = ""
VAR murdererGender = 0
VAR victim = ""
VAR victimGender = 0

VAR hidingSpot = ""
VAR murderWeapon = ""
VAR weaponType = 0

VAR directorAlibi = ""
VAR editorAlibi = ""
VAR processorAlibi = ""
VAR housekeeperAlibi = ""
VAR cookAlibi = ""
VAR screenwriterAlibi = ""
VAR actressAlibi = ""
VAR actorAlibi = ""

VAR playerFoundKey = 0
VAR playerFoundWeapon = 0
VAR playerFoundBody = 0
VAR playerVisitedDistillery = 0
VAR playerKnowsName = 0

VAR accuseMurdererSuccess = 0

VAR storyEnd = 0
VAR gameEnd = 0

-> start

=== start
~playerFoundKey = 1
All the shine has worn away from the metal. Clearly this is a key that has seen regular, frequent use. Perhaps it will grant you access to a hidden place in the house. You pocket the key.
*[Continue searching]
~storyEnd = 1
-> END