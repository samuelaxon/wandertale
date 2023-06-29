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

Everything about the wrinkled old woman is plain and severe. She frowns at you, and as you approach, she absentmindedly grasps at the cross she wears. 

*["Who are you?"]
-"Mathilda Mason, detective. I’ve worked at this house for twenty years, long before these fancy movie people came in and turned the place into a den of sin."
*["What’s sinful about them?"]
-"This whole business with moving pictures...it's just not right. You know, those cameras they use? They suck the very soul right out of you. I'm sure of it. Never felt right having them here in this house. And now someone’s dead." 
She shakes her head. 
"Terrible. Terrible."

*["Where were you at the time of the incident?"]
-"I was with {housekeeperAlibi}."

-> questions

=== questions ===

*["What were you two doing?"]
{
-housekeeperAlibi == "Amelia":
"I was insisting that she let me do my job and spruce up the basement. But Amelia just goes on and on about chemicals and red lights."
Mathilda shakes her head. 
"Not natural for a woman to be so curious about all that science. And to not want her house clean."
-> questions

-housekeeperAlibi == "Carlos":
"We were cleaning up from breakfast."
-> questions

-housekeeperAlibi == "Edith":
"She was having coffee. I was cleaning."
-> questions

-housekeeperAlibi == "Lev":
"Artists," she spits, "Slovenly bunch, the lot of them. That Bernstein man looks like he hasn’t eaten a proper meal once in his life. I suppose it's why he's always eating when he's here. He was eating some fruit while I cleaned."
-> questions

-housekeeperAlibi == "Lulu":
"I wasn't doing anything with that floozie, we just happened to be in the same room. I was working. She probably hasn’t done an honest day’s work in her life."
-> questions

-housekeeperAlibi == "Michel":
"He was doing something about that soul-sucking motion picture. I kept my distance, said a prayer, and did my cleaning. Just as I always do."
-> questions

-housekeeperAlibi == "Rick":
"He was lounging around like a Lothario while I was just trying to do my job."
Mathilda glowers.
"I don't trust that man. Too good-looking."
-> questions
}

*["What can you tell me about the victim?"]
{
-victim == "Amelia":
"She lived here with her brother and sister. Did some sort of work on the motion pictures. She paid me on time, that's all I cared about."
-> questions

-victim == "Carlos":
"Seemed like a good enough man. Had a way around the kitchen. But I didn't know him well."
-> questions

-victim == "Edith":
"She lived here with her brother and sister. Did some sort of work on the motion pictures. She paid me on time, that's all I cared about."
-> questions

-victim == "Lev":
"Anxious fella. Some artist type who Mister Clarque hired to write his film. Never trusted him. Let me tell you, I counted the good silver every time he left the house."
-> questions

-victim == "Lulu":
"Nothing. Looked like a floozie and talked like a floozie, so I expect she was a floozie."
She glares at you.
"I don't associate with floozies."
-> questions

-victim == "Michel":
"He bought the house two years ago and moved in with his sisters. He made motion pictures." 
Mathilda shakes her head. 
"Wouldn't be surprised if he's facing eternal torment right now."
-> questions

-victim == "Rick":
She gives an indignant sniff. 
"I don’t think he’s much of an actor. He’s the same smooth-talking charmer on screen and off."
-> questions
}

*{playerVisitedDistillery == 1}["What do you know about the distillery downstairs?"]
The housekeeper sways back, as though she's been physically struck. She looks like she may faint.
"Heavens above, there’s a distillery in this house? Lord have mercy on us all, these movie people are the very devil. I should have known it was something truly terrible when they wouldn't let me have access to those rooms."
Mathilda clutches at her cross and begins a chanting prayer under her breath.
-> questions

*{playerDangerStage == "high"}["Have you seen anything strange around the house?"]
Mathilda frowns. 
"Having these godless heathens in this venerable house is strange. But I'll take it personally if you're trying to slight the quality of my work. I take great pride in taking care of this property."
-> questions

*{playerDangerStage == "critical"}["What the hell is going on with this house?"]
For the first time, Mathilda's face turns eager.
"What are those picture people doing now? I'm sure their decadent ways and their demonic cameras know no bounds."
	**["I don't mean the people. I mean the house!"]
	She looks angry enough to hit you.
	"I resent your tone, detective. This house is my charge and I have dedicated my life to its upkeep. There is nothing the slightest bit hellish about this place."
	Of anybody here, you hoped the one wearing the cross would be aware of the seething, wicking thing creeping through the halls. Your heart sinks, but you have no choice but to hurry on with the case.
	-> questions

*["Tell me again who your alibi was."]
"I was with {housekeeperAlibi}."
-> questions

*["No further questions, Miss Mason."]
~storyEnd = 1
-> END