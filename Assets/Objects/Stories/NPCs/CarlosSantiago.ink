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

He's a middle-aged man, gray streaking his hair and bushy mustache. He wipes his hands on his apron as you approach. {victim == "Rick" or victim == "Amelia" or victim == "Edith":There are tears in his eyes.}{victim == "Lev" or victim == "Lulu" or victim == "Mathilda" or victim == "Michel":His expression is somber.}

*["Who are you?"]
-"Carlos Santiago. I cook for the Clark girls and their brother."

*["Where were you at the time of the incident?"]
-"I was with {cookAlibi}."

-> questions 

=== questions ===

*["What were you two doing?"]
{
-cookAlibi == "Amelia":
"Miss Amelia helps me in the kitchen sometimes. She's a curious young lady, and likes to know how things work. She finds flavor fascinating."
-> questions

-cookAlibi == "Edith":
"She was making a meal request." 
Carlos gives you a sad smile. 
"Don't be fooled by her anger, detective. I could see you thinking she is suspicious. Edith is a sensitive young woman. She just wants to be appreciated."
-> questions

-cookAlibi == "Lev":
"That young man has an appetite with no end. Every time I see him, he asks me for food. That's what happened earlier today when we were together."
-> questions

-cookAlibi == "Lulu":
"I don’t think Miss Vanderbelle has ever spoken to me. She seems to only have eyes for Mister Clarque and Mister Bernstein." 
Carlos gives you a wry look. 
"I think she considers herself above the help, detective."
-> questions

-cookAlibi == "Mathilda":
He sighs. 
"Miss Mason is...a difficult colleague. She does not want to be friends. We were in the same room, but not doing anything together when...when I heard that scream." 
Carlos' eyes go wide. He leans closer to you. 
"I will never forget that sound, detective. It was not of this world."
-> questions

-cookAlibi == "Michel":
"I needed a little extra for the grocery bills this week. He approves all the finances." 
Carlos pauses. 
"Although he doesn’t know much about them."
	**["Mister Clarque isn’t good with money?"]
	"Not exactly. He has plenty of it. In that sense, he is good with money. But his sisters are the ones who actually manage the budget. For the films and for the family."
	-> questions
	
-cookAlibi == "Rick":
"Just catching up. We always chat when he's at the house."
	**["Do you have regular chats with a lot of Hollywood’s A-list?"]
	"He's not a movie star to me, detective. Ricardo is my cousin." 
	Carlos' face glows with pride. 
	"The world knows him as the leading man, the handsome charmer, but I've known him since he was born. I know things the gossip magazines would pay a fortune for." 
	He mimes zipping his lips shut. 
	"I'll never tell of course. La familia es la mas importante."
	-> questions
}

*["What can you tell me about the victim?"]
{
-victim == "Amelia":
"Miss Clark was a clever young woman. She was curious about how everything worked." 
He wipes away a tear. 
"I never married, detective. But spending time with Miss Clark made me realize what fatherhood must be like. I grieve her loss deeply."
-> questions

-victim == "Edith":
"Ah detective," Carlos shakes his head with a joyless smile. "I assume you will ask everyone here about her, but I doubt you will get any understanding of who Edith Clark was. In my observation, she learned very young to become a shield for herself and her sister. Very few people gave her respect, and even fewer offered affection. I did my best to do both. I hope she could see that before...before the end."
-> questions

-victim == "Lev":
Carlos' brow furrowed. 
"I didn’t know the young writer. But every time I saw him, he was asking me for food. It didn't seem like he had the means to provide for himself without the job from Mister Clarque."
-> questions

-victim == "Lulu":
"The young actress didn’t really speak to me." 
He gives you a wry look. 
"Saw herself as above the help, I imagine."
-> questions

-victim == "Mathilda":
"Miss Mason kept to herself. She was attached to her work and to her faith. I never learned why she didn’t want to make friends. A shame we’ll never have the chance now."
-> questions

-victim == "Michel":
"I suppose he was a fine employer. I was paid well and on time."
-> questions

-victim == "Rick":
"Pobrecito Ricardo." 
Carlos looks away. You can tell he's desperately wiping away tears, trying to compose himself. 
"He was my cousin. We were so proud of him, breaking into Hollywood and becoming such a star. Even once he was famous, he always looked out for us. He got me this job. And did the same for other cousins and nieces and nephews. He's the best man I ever knew." 
He shakes his head. 
"La familia will never be the same. We will mourn him forever."
-> questions
}

*{playerVisitedDistillery == 1}["What do you know about the distillery downstairs?"]
"Ay. I suppose it's your job to find what people want to hide. I know about it. I help them with flavors. Make it gin you'd actually like to drink." 
He puffs up his chest. 
"It's too bad you can't try some, detective. Best booze you'll ever taste."
-> questions

*{playerDangerStage == "high"}["Have you seen anything strange around the house?"]
He shakes his head. "No, can't say I have."
-> questions

*{playerDangerStage == "critical"}["What the hell is going on with this house?"]
He gives you a concerned look.
"You don't look so good, detective. Can I get you some water before you continue investigating?"
You're pretty sure holy water will be needed here, but that doesn't seem like what the kindly cook is offering.
-> questions

*["Tell me again who your alibi was."]
"I was with {cookAlibi}."
-> questions

*["No further questions, Mister Santiago."]
~storyEnd = 1
-> END