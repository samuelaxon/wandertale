
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

LIST excludeVictim = Amelia, Carlos, Edith, Lev, Lulu, Mathilda, Michel, Rick

{
    -victim == "Amelia":
    ~excludeVictim += Amelia
    
    -victim == "Carlos":
    ~excludeVictim += Carlos
    
    -victim == "Edith":
    ~excludeVictim += Edith
    
    -victim == "Lev":
    ~excludeVictim += Lev
    
    -victim == "Lulu":
    ~excludeVictim += Lulu
    
    -victim == "Mathilda":
    ~excludeVictim += Mathilda
    
    -victim == "Michel":
    ~excludeVictim += Michel
    
    -victim == "Rick":
    ~excludeVictim += Rick
}

You call everyone in the house together to make your announcement.{playerFoundBody == 1: You know that {victim} is dead by foul play.}{playerFoundWeapon == 1: You found the {murderWeapon} used to commit the deed.}{playerFoundBody == 0 and playerFoundWeapon == 0: You don't have any evidence, so this attempt to close the case is on shaky ground. But time is short.} All that remains is to identify the killer.

"I've finished my investigation," you proclaim to the group. "I believe the killer is..."

*{excludeVictim != Amelia}["Amelia"]
{
    -murderer == "Amelia":
    ~ accuseMurdererSuccess = 1
    Amelia shakes her head in disbelief.
    -> accuse_amelia

    -else:
    The moment her name leaves your mouth, you feel a lead weight in your gut.
    Amelia's eyes narrow. 
    "Me? It wasn't me, detective. I had an alibi.{victim == "Edith" or victim == "Rick" or victim == "Carlos": You really think I would murder someone I cared about?} I wouldn't kill someone, even if I hated them. I'm not an idiot."
    -> bad_ending
}

*{excludeVictim != Carlos}["Carlos"]
{
    -murderer == "Carlos":
    ~ accuseMurdererSuccess = 1
    Carlos looks as though he's been slapped.
    -> accuse_carlos
    
    -else:
    The moment his name leaves your mouth, you feel a lead weight in your gut.
    Carlos looks as though he's been slapped.
    "I told you where I was, detective. You can confirm my alibi again now. It wasn't me."
    -> bad_ending
}

*{excludeVictim != Edith}["Edith"]
{
    -murderer == "Edith":
    ~ accuseMurdererSuccess = 1
    Edith surges toward you in a fury.
    -> accuse_edith
    
    -else:
    The moment her name leaves your mouth, you feel a lead weight in your gut.
    Edith rolls her eyes.
    "The coppers really sent us their best, didn't they? It wasn't me. I told ya my alibi.{victim == "Amelia": My sister was the person I loved most in the whole world. Why the hell would I kill her?}{victim == "Michel": I'm not sad he's gone, but even my own lousy brother wouldn't drive me to murder."}
    -> bad_ending
}

*{excludeVictim != Lev}["Lev"]
{
    -murderer == "Lev":
    ~ accuseMurdererSuccess = 1
    Lev laughs without joy or humor.
    -> accuse_lev
    
    -else:
    The moment his name leaves your mouth, you feel a lead weight in your gut.
    Lev laughs without joy or humor.
    "I can see why you'd think it was me. The starving artist, desperate for a break. But I ain't your guy."
    -> bad_ending
}

*{excludeVictim != Lulu}["Lulu"]
{
    -murderer == "Lulu":
    ~ accuseMurdererSuccess = 1
    Lulu's blue eyes well with tears.
    -> accuse_lulu
    
    -else:
    The moment her name leaves your mouth, you feel a lead weight in your gut.
    Lulu's blue eyes well with tears.
    "But I didn't do it!" she sobs. "{victim == "Lev":I loved Lev! I wanted him to marry me! }{victim == "Michel":I was his muse! He was gonna be my big break! }I know lotsa dames think they can get famous by murder, but I'm a nice girl, I swear!"
    -> bad_ending
}

*{excludeVictim != Mathilda}["Mathilda"]
{
    -murderer == "Mathilda":
    ~ accuseMurdererSuccess = 1
    -> accuse_mathilda
    
    -else:
    The moment her name leaves your mouth, you feel a lead weight in your gut.
    The housekeeper draws her hunched body up to its full height and fixes you with a glare of steel.
    "I'm a God-fearing woman, detective. May He have mercy on your soul, accusing His child of such a horrid sin."
    -> bad_ending
}

*{excludeVictim != Michel}["Michel"]
{
    -murderer == "Michel":
    ~ accuseMurdererSuccess = 1
    -> accuse_michel
    
    -else:
    The moment his name leaves your mouth, you feel a lead weight in your gut.
    The haughty director clutches his chest.
    "Moi?" Michel gasps. "Detective, this is an outrage. I will not tolerate such slander. Ze truth must be told! It was not I!"
    -> bad_ending
}

*{excludeVictim != Rick}["Rick"]
{
    -murderer == "Rick":
    ~ accuseMurdererSuccess = 1
    The actor shakes his head with a sad smile.
    -> accuse_rick
    
    -else:
    The moment his name leaves your mouth, you feel a lead weight in your gut.
    Rick shakes his head, again with that sad smile.
    "Detective, I have plenty of vices. But murder isn't and never will be one of them. You fingered the wrong guy."
    -> bad_ending
}

= accuse_amelia
{
    -victim == "Carlos":
    "But, Carlos was my friend. I cared about him. I would never..."
    
    -victim == "Edith":
    "My own sister? I love Edith. I wouldn't have...I couldn't have..."
    
    -victim == "Michel":
    "What? I had my issues with him, sure, but I wouldn't kill my own brother. I would never..."
    
    -victim == "Rick":
    "No. Rick was my friend, he was...I cared about him. I would never..."
    
    -else:
    "I'm not a murderer. Even if I hated them, I wouldn't..."
    
}
-> determine_ending

= accuse_carlos
{
    -victim == "Amelia":
    "She was like a daughter to me, I couldn't have..."
    
    -victim == "Edith":
    "She was like a daughter to me, I couldn't have..."
    
    -victim == "Rick":
    "Ricardo era mi primo. Mi amigo. Mi familia. No es posible..."
    
    -else: 
    "Please, detective, you must be wrong. I would never do such a thing. I swear."
}
-> determine_ending

= accuse_edith
{
    -victim == "Amelia":
    "You really think I'd kill my own sister? The person I love most in this whole stupid world? Are you insane? Are you..."
    
    -victim == "Carlos":
    "You really think I'd kill Carlos? Someone who believed in me, who helped me? Are you insane? Are you..."

    -victim == "Lev":
    "You really think I'd risk my neck to kill that hack? What the hell for? Are you insane? Are you..."

    -victim == "Lulu":
    "You really think I'd risk my neck to kill that ditzy dope? What the hell for? Are you insane? Are you..."

    -victim == "Mathilda":
    "You really think I'd kill my housekeeper? What the hell for? Are you insane? Are you..."

    -victim == "Michel":
    "You really think I'd kill my brother? Sure, I hated him, but I'm not a murderer."

    -victim == "Rick":
    "You really think I'd kill Rick? Someone who believed in me, who helped me? Who was a real friend to me? Are you insane? Are you..."
}
-> determine_ending

= accuse_lev
{
    -victim == "Lulu":
    "I can see why you'd think it was me. The starving artist, desperate for a break. But I ain't your guy. I just wanna write, I don't wanna hurt nobody. 'Specially not Miss Vanderbelle. She was a sweet dame and so pretty. Why would I..."

    -victim == "Michel":
    "I can see why you'd think it was me. The starving artist, desperate for a break. But I ain't your guy. I just wanna write, I don't wanna hurt nobody. 'Specially not Mister Clarque. He wanted to help me! Why would I..."
    
    -else: 
    "I can see why you'd think it was me. The starving artist, desperate for a break. But I ain't your guy. I just wanna write, I don't wanna hurt nobody."
}
-> determine_ending

= accuse_lulu
{
    -victim == "Lev":
    "But I didn't do it!" she sobs. "I loved Lev! I wanted him to marry me!"

    -victim == "Michel":
    "But I didn't do it!" she sobs. "I was his muse! He was gonna be my big break!"
    
    -else:
    "But I didn't do it!" she sobs. "I know lotsa dames think they can get famous by murder, but I'm a nice girl, I swear!"
}
-> determine_ending

= accuse_mathilda
The housekeeper draws her hunched body up to its full height and fixes you with a glare of steel.
    "I'm a God-fearing woman, detective. May He have mercy on your soul, accusing His child of such a horrid sin. Please, Lord..."
-> determine_ending

= accuse_michel
"Moi?" Michel gasps. "Detective, this is an outrage. I will not tolerate such slander. Ze truth must be told! It was not..."
-> determine_ending

= accuse_rick
{
    -victim == "Amelia":
    "Detective, I have plenty of vices. But murder my friend? My lover? It's...it's not possible..."
    
    -victim == "Carlos":
    "Detective, I have plenty of vices. But murder my own cousin? I couldn't have. It's...it's not possible..."

    -victim == "Edith":
    "Detective, I have plenty of vices. But murder my friend? It's...it's not possible..."
    
    -else: 
    "Detective, I have plenty of vices. But murder isn't one of them. It's not possible..."
}
-> determine_ending

=== determine_ending
{
    -playerFoundWeapon == 1 and playerFoundBody == 1:
        -> good_ending
        
    -else:
        -> middling_ending
}


=== good_ending

{murdererGender == 0:Her|His} face goes pale with horror. Then, {murdererGender == 0:her|his} eyes roll back and {murdererGender == 0:her|his} whole body shakes.
{playerDangerStage == "medium":The hairs on the back of your neck stand up. You'd tried to shrug off the peculiar things you'd seen in the house, but now you can't deny the presence of something strange and horrible. And it has {murderer} in its grip.}
{playerDangerStage == "high" or playerDangerStage == "critical":You feel it everywhere. IT. Whatever this strange, horrible being is that has possessed this house, it now has {murderer} in its grip.}
*[Confront the evil presence]
-"I know what you did!" you shout. "It wasn't really {murderer}! You killed {victim} with the {murderWeapon}. I found {victimGender == 0:her|his} body and the weapon. I know the truth!"
You hear a whisper. It's so faint you barely understand the words, even though the terrifying voice sounds right at your ear. 
<b>"Curse you,"</b> it says.
You feel the malevolent presence in the house dissapate. You heave a deep breath, and for once the air feels fresh. It makes no sense, but somehow, the truth was enough to rob the being of its power. 
You claimed to know the truth, but you can't comprehend what has actually happened here. No one does. The others all look shocked and dazed, except for {murderer}, who has fallen to {murdererGender == 0:her|his} knees and is crying softly. But you do know that prolonged questioning will only further traumatize {murderer} and it won't revive {victim}.
You're ready to return to headquarters, shaken but alive. 
*[Leave the mansion]
~storyEnd = 1
~gameEnd = 1
->END

=== middling_ending

{murdererGender == 0:Her|His} face goes pale with horror. Then, {murdererGender == 0:her|his} eyes roll back and {murdererGender == 0:her|his} whole body shakes. 
{playerDangerStage == "medium":The hairs on the back of your neck stand up. You'd tried to shrug off the peculiar things you'd seen in the house, but you can't deny the presence of something strange and horrible. And now that same being has {murderer} in its grip, just like it did when {murdererGender == 0:she|he} unknowingly killed {victim}.}
{playerDangerStage == "high" or playerDangerStage == "critical":You feel it everywhere. IT. Whatever this strange, horrible being is that has possessed this house, it now has {murderer} in its grip. Just like it did when {murdererGender == 0:she|he} unknowingly killed {victim}.}
*[Confront the presence]
-"I'm not afraid of you," you shout. "Whatever you are." 
You hear an otherworldly voice. The sound is everywhere, frightening and thick in the air of the room.
<b>"Don't be a fool,"</b> it says. <b>"You all fear what you cannot control."</b>
{murderer} suddenly convulses, then collapses in a heap. You run forward and grab {murdererGender == 0:her|his} wrist. There is no pulse.
<b>"And I control everything,"</b> the voice taunts you in a whisper.
And with that, you feel the malevolent presence disappear from the house. You can't tell if the others heard the whispers of that thing. They are crying, praying, fainting all around you. You don't even know what to say to bring order to the situation.
You are exhausted. Your legs give out and you sit down hard on the floor. It seems your case is closed with {murderer}'s untimely end. But the evil presence escaped. You don't know how you could possibly know it, but you're certain of this. And you're just as certain that some day, somewhere, it will kill again...
*[Leave the mansion]
~storyEnd = 1
~gameEnd = 1
->END

=== bad_ending

How could this be? After so many years, your nose for guilt has never steered you wrong.
Before you can gather your thoughts and your dignity, the whole mansion rattles with a scream. It's an unholy noise, loud as a bomb and unending, a shriek no human body could make.
{playerDangerStage == "medium":You'd tried to shrug off the peculiar things you'd seen in the house, but now you can't deny the presence of something strange and horrible in this house. And it is angry.}
{playerDangerStage == "high" or playerDangerStage == "critical":You know what it is. Whatever this strange, horrible being is that has possessed this house, it is here. And it is angry.}
*[Confront the evil presence]
-You open your mouth to address the screaming thing, but no sound emerges. Suddenly, you can't breathe. You clutch at your throat, but nothing is getting to your lungs. The other people in the room are also in distress, falling to the floor with gasps and croaks. 
The scream gradually takes the shape of a word. As your vision goes dark, you just barely recognize the voice that's ringing in your ears, laughing as the people around you go deathly still.
<b>"FOOLS."</b>
Your body fails. This is the end.
* [Give up]
~storyEnd = 1
~gameEnd = 1
->END