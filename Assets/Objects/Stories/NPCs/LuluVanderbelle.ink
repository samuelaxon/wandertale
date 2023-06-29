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

She is a photogenic young woman, with hair in blonde waves and blue eyes like saucers.{victim == "Lev" or victim == "Michel": Tears trail down her cheeks.} She’s fidgeting, and the bangles on her dress tinkle as she moves.

*["Who are you?"]
-"Lulu Vanderbelle, detective. I sure hope you'll catch the killer. I'm real scared."
*["I'll do my best. Do you live here?"]
-"Oh, gee no. I'm the leading lady in Mister Clarque’s new picture and his creative muse." 
She drops her voice to a whisper. 
"It's my first role on screen. And muse sounds so fancy! I'm real excited to be a star! It's my dream come true!"

*["Where were you at the time of the incident?"]
-"I was with {actressAlibi}."

-> questions

=== questions ===

*["What were you two doing?"]
{
-actressAlibi == "Amelia":
"She was reading a textbook like a square. I barely even realized she was in the room."
-> questions

-actressAlibi == "Carlos":
She rolls her eyes. 
"Please, detective. Do you think I’d throw myself at a cook? An <i>old</i> cook?"
	**["I have no investment in your romantic life. I need your alibi."]
	"Oh. I see. Of course. I was reading the society pages. He was just in the same room."
	-> questions
	
-actressAlibi == "Edith":
"We were talking about Lev. He's so smart. And so talented. An artist like him is gonna go far, so tortured and handsome."
-> questions

-actressAlibi == "Lev":
"He's a real smart one." 
Her worried expression dissolves into a dreamy one. 
"Black curls. Stormy gray eyes. Talented and brainy and soulful. He's just perfect, detective. There's something about him that just gets my motor going, ya know?"
-> questions

-actressAlibi == "Mathilda":
"The housekeeper was doing her housekeeper business. I was reading the gossip pages. I'm gonna meet all those stars one day, figured I better learn all about 'em first."
-> questions

-actressAlibi == "Michel":
"Me and Mister Clarque?" 
Her worried expression melts away into a sly grin. 
"He wanted to rehearse the love scene with me. Work out how I can make it believable on screen. Things got real...expressive." 
She giggles. 
"I should ask Lev if I can practice with him. That'd be a real hotsy-totsy rehearsal."
-> questions

-actressAlibi == "Rick":
"Mm, that Rick's a sheik, ain't he? And real sweet too. We were talking about the movie biz. How to get quiet time on set, playing to the camera, all that jazz."
She preens a little.
"Rick and me did a few test shoots with Mister Clarque already. Mister Clarque says I have star power. Ain't that sweet?"
-> questions
}

*["What can you tell me about the victim?"]
{
-victim == "Amelia":
"She was the brainy one, right? Never really figured out if she just lived here or if she helped him with the pictures like the other sister. Sorry, detective, that’s all I know."
-> questions

-victim == "Carlos":
"He was the cook. We didn't have much chit-chat. I mean, he's the cook."
-> questions

-victim == "Edith":
"She was the editor, right? The one who looked like she wanted to clock everyone in the jaw? She helped Mister Clarque edit his pictures, I think. We only talked about Hollywood biz. Sorry, detective, I didn’t know anything else about her."
-> questions

-victim == "Lev":
Her face falls. 
"He was a real dream. I thought he'd fall in love with me and I'd inspire him to write great roles for me and we'd live happily ever after." 
Lulu sighs. 
"I guess I could be Mister Clarque's muse. He already says I am. He could make me a star and he's already got a lot of dough." 
A single tear trickles down her cheek. 
"But he's not Lev."
-> questions

-victim == "Mathilda":
"She was the housekeeper. We didn't have much chit-chat. I mean, she's the housekeeper."
-> questions

-victim == "Michel":
"I was his muse. He told me so all the time. I'd never been anyone’s muse before."
She sniffles. 
"Detective, what if nobody else wants me to be their muse? How will I ever be a star? I keep trying to be Lev's muse, but I don't think it's working. Am I not as pretty as I thought?" 
She shakes her head. 
"I don't wanna go back to Sacramento. But I don't wanna die here either."
-> questions

-victim == "Rick":
"Poor Rick. I saw him in <i>The Careless Few</i> and I couldn't believe I got to really meet him. It's real rotten for all of Hollywood to lose such a star."
-> questions
}

*{playerVisitedDistillery == 1}["What do you know about the distillery downstairs?"]
"There's a distillery downstairs?" 
Lulu gives you a skeptical look. 
"Are you pulling my leg? Is this a trick? I swear, detective, I don't know what you’re talking about."
-> questions

*{playerDangerStage == "high"}["Have you seen anything strange around the house?"]
She looks worried. 
"Strange? No, nothing strange. Why? Is something wrong with the house?"
You don't want a panicked ingenue on your hands, so you don't press.
-> questions

*{playerDangerStage == "critical"}["What the hell is going on with this house?"]
She looks terrified.
"What do you mean, detective? Did...did someone else get..." Lulu gulps. "...whacked?" 
You shake your head, but the starlet is now beside herself. She looks about to cry.
"I just want to go home!" she wails.
You clearly won't get any help from Lulu on the eerie goings on.
-> questions

*["Tell me again who your alibi was."]
"I was with {actressAlibi}."
-> questions

*["No further questions, Miss Vanderbelle."]
~storyEnd = 1
-> END