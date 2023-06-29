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

She is wearing a dress with a conservative cut and color. But a floral fascinator in her brown hair and a glittering lariat around her neck show some artistic flair. {victim == "Amelia":The woman has red eyes and has clearly been crying. Exhaustion weighs heavy all around her.}{victim == "Rick" or victim == "Carlos":She looks like a woman about to snap, either from rage or sorrow. Maybe both.}{victim == "Lev" or victim == "Lulu" or victim == "Michel" or victim == "Mathilda":The woman has a hard face, one that clearly frowns on the regular. She looks tired and tense.}

*["Who are you?"]
-"I'm Edith Clark. I live here. And I’m the editor for Clarque Films. And I keep the books."
*["That’s a lot of work."]
-She glares at you. 
"Brilliant deduction, detective. Of course it's a lot of work. Do ya have any real questions for me?"

*["Where were you at the time of the incident?"]
-"I was with {editorAlibi}."

-> questions

=== questions

*["What were you two doing?"]
{
-editorAlibi == "Amelia":
"Working. We run the household and Clarque Films together, so there's always something for us to do."
-> questions

-editorAlibi == "Carlos":
"We were talking about the week’s meal plans."
Her hard face softens ever so slightly. 
"I was asking him to make pozole again. It's my favorite thing he cooks."
-> questions

-editorAlibi == "Lev":
"Talking about the film. I don't think much of his poetry, but he had the brains to ask me about what I do. Maybe he's not all bad."
-> questions

-editorAlibi == "Lulu":
"I was trying not to fall asleep while that dumb Dora babbled about the picture and how talented Lev Bernstein is. It was a chore, I tell ya."
-> questions

-editorAlibi == "Mathilda":
"I was finishing my coffee and she was working. We weren't talking or anything. But we both jumped about a foot when we heard that noise."
Edith shivers.
"What a shriek. I'm not a religious woman, but I pray I never hear anything like that ever again."
-> questions

-editorAlibi == "Michel":
"Arguing. That's all Michael and I ever do."
	**{playerKnowsName == 0}["Wait, Michael? I thought the director's name was Michel."]
	"Yeah. The famous motion picture man is really Michael Clark, not Michel Clarque. What a turkey. Can't believe he thought anyone would believe he was French. Guess Hollywood's full of patsies."
	    ***["What were you arguing about?"]
	    "You name it, we fight about it. Today his harebrained idea is to sign with a studio for the new picture. Replace me and Amelia."
        Edith shakes her head with a cold smile. "He'll fail if he does. Get revealed as a phony. And even though it'll be his own rotten fault, somehow I'll pay the price for it. Mark my words."
        ~playerKnowsName = 1
        -> questions
    **{playerKnowsName == 1}**["What were you arguing about?"]
	    "You name it, we fight about it. Today his harebrained idea is to sign with a studio for the new picture. Replace me and Amelia."
        Edith shakes her head with a cold smile. "He'll fail if he does. Get revealed as a phony. And even though it'll be his own rotten fault, somehow I'll pay the price for it. Mark my words."
        -> questions
        
-editorAlibi == "Rick":
"We were talking about the <i>The Careless Few</i>. He wanted to know how I approached editing some of the more emotional scenes." 
She gives a small smile.
"Folks know him for his looks, but he really is a good actor. He wants to do the best job he can."
-> questions
}

*["What can you tell me about the victim?"]
{
-victim == "Amelia":
"God. My poor Amelia. Smartest person I ever met. I was so proud of her, solving all the tricks with film that our brother was too dumb to figure out. I just..." 
Edith trails off. You can see tears welling in her red eyes, but she scrubs them away.
"She was my little sister," she whispers. "I just wanted us to have a good life together. And I failed her."
-> questions

-victim == "Carlos":
Edith’s face falls.
"Carlos was a swell guy and a great cook. Sure, he could do the swanky French dishes my brother wanted for his industry pals, but his gift was family recipes. He made Amelia and I feel like a part of that family. We...we never really had that before."
She meets your eyes. 
"You make the monster who killed him pay. Carlos should still be alive."
-> questions

-victim == "Lev":
"Psh, ya think that turkey would talk to me? If he did, it was only to try and score some chow. He always looked like a monster was watching him. Real nervous, anxious fella."
-> questions

-victim == "Lulu":
"Didn't really know her. Most of her time at the house she was busy making eyes at Lev or ignoring Michael while he made eyes at her. It was kinda funny. Not that she's dead, but that they were all such dopes. Not the brightest buncha kids."
    **{playerKnowsName == 0}["Wait, Michael? I thought the director's name was Michel."]
	"Yeah. The famous motion picture man is really Michael Clark, not Michel Clarque. What a turkey. Can't believe he thought anyone would believe he was French. Guess Hollywood's full of patsies."
	~playerKnowsName = 1
-> questions

-victim == "Mathilda":
"She was our housekeeper. I think she might be as old as the house. Her ghost'll probably haunt the place forever now."
	**["Do you really believe that?"]
	Edith casts a worried glance over her shoulder.
	"I might."
	She continues, her voice raised, as if the specter of Mathilda Mason might be listening in.
	"She was the best housekeeper in all of California and we never gave this house the respect it deserves."
	-> questions

-victim == "Michel":
"He was a hack. Everyone thought he was so smart, so sensitive after <i>The Careless Few.</i>"
She taps her chest.
"That was my movie. His first cut was so sappy you could turn it into maple syrup and put it on flapjacks. <i>I</i> made it great. <i>I</i> gave it soul. But I got no credit and no respect from that rat."
	**["You don’t seem sad about his disappearance and likely death."]
	Edith grins, a brittle, battered smile.
	"Ya want the truth, detective? I'm not sad. He was the only son, so he got everything he wanted when we were little. Then he got control of all the family money when our parents died. Then I had to give up my dreams to help his or he'd wreck Amelia's life. He always made me feel like a shadow. Now that he's gone, maybe I can really live."
	-> questions
	
-victim == "Rick":
She barks out a sharp laugh.
"What can ya say about Rick? He's larger than life. Or was, I guess."
For a moment, Edith takes a long, shuddery breath and blinks hard.
"It sounds weird for a nobody like me to say about Hollywood’s biggest star, but we were actually friends. He could make friends with a tree stump. I...I liked him. A lot. I can't believe he's gone."
-> questions
}

*{playerVisitedDistillery == 1}["What do you know about the distillery downstairs?"]
All the color drains from Edith's face for a moment. Then, she flushes with rage.
"Damn it, of course Amelia would leave her basement key lying around while a cop is here. Yes, we have a distillery. And it was my idea. Everything that happens in this house is my idea."
	**["Why did you do it?"]
	"Because Michael doesn't pay us a nickel for everything Amelia and I do. I won't be dependent on that turkey forever. I handle the finances for Clarque Films and I hate it. All that money, all for him. At least when I run our bootlegging biz, it supports the people actually doing the work. So go ahead and arrest us, detective, but Michael's just as big a crook."
	-> questions
	
*{playerDangerStage == "high"}["Have you seen anything strange around the house?"]
She narrows her eyes. 
"No." 
You wait for her to elaborate, but that seems to be all she has to say.
-> questions

*{playerDangerStage == "critical"}["What the hell is going on with this house?"]
"What are you talking about?"
She narrows her eyes. 
"Feelin' up for all this, detective? Ya look green around the gills. I thought the brass in this town had to be tough."
If Edith could see what you were seeing in the room, she'd look green too. That she doesn't makes your stomach clench even tighter.
-> questions

*["Tell me again who your alibi was."]
"I was with {editorAlibi}."
-> questions

*["No further questions, Miss Clark."]
~storyEnd = 1
-> END