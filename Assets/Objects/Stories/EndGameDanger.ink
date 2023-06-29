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

=== start ===

You enter the room, but everything is dark. Not just unlit, but dark like an endless void. 
Behind you, you hear a thin, reedy laugh. You whirl, and are faced with {murderer}. {murdererGender == 0:Her|His} eyes are glowing. When {murdererGender == 0:she|he} speaks, the sound is inhuman and strange.
<b>"Time is up,"</b> an otherworldly voice proclaims from {murderer}'s mouth.
Suddenly, you can't breathe. You clutch at your throat, but nothing is getting to your lungs. Your vision goes dark. You can make out the shape of {murderer} bending down, soaking up your agony. 
<b>"YOU PATHETIC FOOL."</b>
Your body fails. This is the end.
*[Give up]
~storyEnd = 1
~gameEnd = 1
-> END