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
{
-murderWeapon == "candelabra":
~playerFoundWeapon = 1
As you pick up the ornate candlestick, all the hairs on your arms stand up. You've been trained in observation and analysis, but there's no protocol from headquarters for the prickling feeling you have. 

There are no tapers in the candelabra. Perhaps it's only used at night. Or maybe it's only for show. Or maybe it's been used for sinister purposes. You spy blood, crusted dark brown on the metal.
-> success

-else:
There are no tapers in the candelabra. Perhaps it's only used at night. Or maybe it's only for show. Seems like an antique, a relic of bygone days.
*[Continue searching]
~storyEnd = 1
-> END
}

=== success

{
    -playerFoundBody == 1:
    That's two pieces of evidence now that have made your hair stand on end. {playerDangerStage == "high" or playerDangerStage == "critical":The sudden death, the bizarre house? There's no denying it: this is unlike any other case you've solved before. Whatever happened in this mansion wasn't just sinister. It was surreal. Maybe even supernatural.|You've seen ugly murder cases before, but they didn't turn your stomach like this. Something else is going on, even if you don't understand what.} The only question left, the last fact you can arm yourself with, is determining who perpetrated this act. You'd better hurry and make your accusation.
    
    -else:
    {playerDangerStage == "high" or playerDangerStage == "critical":You have a bad feeling about this case. There's definitely something strange at play, something bad in the air. You don't have a clue yet what it is,|You can't put your finger on it, but there's something odd about this case. Something strange in the air. You want to dismiss the idea out of hand,} but you've learned to trust your gut. And your gut is saying to stay sharp and watch your back. Maybe if you have another concrete fact, like the dead body, you'll better understand the truth.
}
*[Continue searching]
~storyEnd = 1
-> END