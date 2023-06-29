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

He's a handsome man, with dark eyebrows and a slim mustache. He's dressed to the nines, a cream-colored suit setting off the glow of his brown skin. You'd guess he's in his mid-thirties, but it's the most uncertain you've ever been about a suspect's age. {victim == "Carlos":He barely acknowledges you as you approach. His face is one of a man bereft.}{victim == "Amelia" or victim == "Edith":He is clearly upset, worry and sadness deepening the few lines you can detect on his face.}{victim == "Lev" or victim == "Lulu" or victim == "Mathilda" or victim == "Michel":He is clearly upset, but manages to flash a faint grin as you approach.}

*["Who are you?"]
-"You don't recognize me? Ah, I imagine your hard work keeping the streets of LA safe must leave you little time to get to the pictures. Rick Santiago, at your service."
He gives you a small bow.
"I'm an actor."

*["Where were you at the time of the incident?"]
-"I was with {actorAlibi}."

-> questions

=== questions

*["What were you two doing?"]

{
-actorAlibi == "Amelia":
"We were..."
You notice him hesitate for a moment, before resignation settles on the actor's shoulders. 
"Detective, normally I would never kiss and tell. But you're an officer of the law and you demand the truth. Amelia and I have...an understanding. Just a dalliance, a little fun on the side. Nothing serious."
    **["The young lady better be completely aware of your intentions, Mister Santiago."]
    Rick arches an eyebrow. 
    "My womanizing ways are well known to everyone in Hollywood, detective. Other than you, apparently. Amelia is not a romantic. She knows the score. And despite your skepticism, she is my friend first. I will not jeopardize her future."
    He gives you a pointed look.
    "I trust you will be be equally discreet with this information."
-> questions

-actorAlibi == "Carlos":
"Just chatting. We always make time to visit when I’m at the Clarque house. He's my cousin, you know. I got him the job here."
-> questions

-actorAlibi == "Edith":
"We were talking industry business. You might not realize it, but she's quite the talent. Incredible eye, strong artistic sensibilities."
-> questions

-actorAlibi == "Lev" or actorAlibi == "Lulu" or actorAlibi == "Michel":
"We were discussing the film. There's so much to finalize in the early days of production. Character motivations. Chemistry. Mood. It takes a lot of work from everyone to make magic on screen."
-> questions

-actorAlibi == "Mathilda":
"She was glowering at me while she cleaned. I was just reading the latest copy of the script, trying to develop my character." 
Rick's mouth stretches into a grin.
"Despite the rumors, I'm not just a handsome face, detective. I work at the actor's craft."
-> questions
}

*[“What can you tell me about the victim?”]
{
    -victim == "Amelia":
    "She was serious. Focused. Patient. Sharp as a sword. A real clever dame."
    Rick briefly pauses. You can tell he is considering how much to reveal. 
    "She was surprising. I don’t think I'd ever met anyone quite like her," is all he finally says.
    -> questions
    
    -victim == "Carlos":
    "He was my cousin, mi familia. I'm devastated. Who possibly could have had a motive to kill him?"
    Rick fixes you with a look filled with equal parts of sorrow and rage. 
    "You must bring justice to the fiend, detective."
    -> questions
    
    -victim == "Edith":
    "Edith was tough. That's the highest compliment I'd ever give a person, man or woman. The world tried so hard so many times to crush her. And she didn't let it happen."
    He sighs. 
    "Edith could have been a director in her own right. What a sad thing that she'll never get the chance."
    -> questions
    
    -victim == "Lev":
    "He was a nervous young fellow who wrote poems about moral decay. Seemed to have a real rapport with Michel, but I never really thought much of his work. All hot air to me."
    Rick shrugs.
    "But maybe I'm just not that deep, detective. Give me a comedy over a tragedy any day."
    -> questions
    
    -victim == "Lulu":
    "Lulu was new to Hollywood. I don't believe she was hired for her talent, but I've carried less skilled scene partners. I suppose we'll never know if she would have achieved the stardom she craved."
    -> questions
    
    -victim == "Mathilda":
    "Barely knew her. Seen her around the house, of course, she's worked here for as long as I've known Michel. She always seemed like a bit of a lemon, you know? Sour. I caught her frowning and muttering at me countless times. But she did the same to everyone."
    -> questions
    
    -victim == "Michel":
    "I worked with him on <i>The Careless Few</i>, his first picture. He was pretty taken with his own worth. A big ego even for Hollywood standards. I wasn't that excited to join him for another project, at least not on a personal level. But I assumed success would breed more success."
    He shrugs.
    "I confess, detective, I am not sorry that this picture will not be made. There were warning signs about <i>Temptation Lane</i>. An unproven writer. An ingenue cast for the director's pleasure. Perhaps we were simply lucky that first time."
    -> questions
}
    
*{playerVisitedDistillery == 1}["What do you know about the distillery downstairs?"]
Rick gives a rueful laugh. 
"Ah, you found that, did you? Clever detective. Yes, I knew. How do you think they got the merchandise out? I know every speakeasy and every secret party happening in this city. I'm essential to the operation."
His expression turns serious. 
"Could that little operation be why someone attacked {victim}? I can't imagine the temperance crowd turning to murder over a discreet bootlegging business. I hope you're more concerned about bringing a murderer to justice than chasing a vice charge."
-> questions

*{playerDangerStage == "high"}["Have you seen anything strange around the house?"]
"Strange? Not unless the sour housekeeper counts. She's an odd one, no question."
-> questions

*{playerDangerStage == "critical"}["What the hell is going on with this house?"]
Rick's brow furrows.
"What do you mean, detective? It's just a house."
It doesn't seem possible that the actor wouldn't see what was happening around him. His oblivious answer only ratchets up the tension in your body.
-> questions

*["Tell me again who your alibi was."]
"I was with {actorAlibi}."
-> questions

*["No further questions, Mr. Santiago."]
~storyEnd = 1
-> END
