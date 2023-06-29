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

You're at a swanky house in the hills of Los Angeles with a slim case file and a bad feeling in your gut. A bunch of Hollywood types were schmoozing here this morning when the mansion was rattled by a blood-curdling scream. After that, {victim} could not be found. {victimGender == 0:She|He} is missing, and presumed dead. Your assignment is to piece together what happened. 

Interrogate the suspects: Ask for alibis. Someone’s story won’t check out and that's your criminal.
Confirm that it's murder: Find the murder weapon and the victim’s body somewhere in the mansion. 
Solve the case: When you think you have the killer, make your accusation. It's best to have proof of the murder, but you better make it quick. A desperate killer just might strike again...

*[Investigate]
~storyEnd = 1
-> END
