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

He's a young man with a bony frame and sunken, shadowed eyes. He's wearing a suit several years out of style in a fabric that might have once been navy but has faded to a grayish hue. Even before you approach, he seems uncomfortable and out of place. As you draw near, his anxiety doubles.

*["Who are you?"]
-"Me? I'm Lev."
You roll your eyes.
*["Lev...?"]
-"Oh, uh, Lev Bernstein. I'm just a poet. Well, um, I guess maybe I'm also a screenwriter now. Mister Clarque saw one of my pieces in a magazine and said he wanted to hire me. Um, me and my 'tragic soul,' he said." 
The young man peers at your face, looking for reassurance.
"I don't know if I got a tragic soul, but that sounds like a good thing for a poet, right?"

*["Where were you at the time of the incident?"]
-"I was with {screenwriterAlibi}."

-> questions

=== questions ===

*["What were you two doing?"]
{
-screenwriterAlibi == "Amelia":
"Oh. Um. I hoped she could get me something from the kitchen." He shrugs, looking sheepish. "I couldn't find the cook, and, well, the housekeeper gives me the heebie jeebies." 
Lev drops his voice to a stage whisper. 
"She's terrifying!"
-> questions

-screenwriterAlibi == "Carlos":
"I got here after breakfast, so I was asking if he could help me out with a snack."
-> questions

-screenwriterAlibi == "Edith":
"I know she edits the pictures, so I was asking her how that works. Figured I oughta know how I can make her work easier."
-> questions

-screenwriterAlibi == "Lulu":
"We, um, were just talking. About the picture. Miss Vanderbelle was asking if I had a muse. And she was laughing at everything I said." 
He sighs. 
"Doesn’t seem like she thinks much of me. But I'm used to that. Most people for most of my life have agreed with her."
-> questions

-screenwriterAlibi == "Mathilda":
"Nothing!" he exclaims. 
You raise an eyebrow. Lev looks over his shoulder, making sure the housekeeper isn't behind him. 
"She’s a creepy old witch," he says. "Every time I see her, she's muttering like a crazy lady. Today was the first time we were the only two in the room. Seemed like she was cleaning, but she mighta been putting some hex on me."
-> questions

-screenwriterAlibi == "Michel":
"We had a writing session today. <i>Temptation Lane</i> is based on one of my poems. I never wrote dialogue before, so Mister Clarque wanted to give me notes on what they did in test shoots."
He wrings his hands.
"Can I be straight with ya, detective? I'm still worried about the motion picture thing."
	**["Why's that?"]
	Lev sighs. 
	"I ain't ever had scratch like I could get from this gig, so I told myself it was all applesauce long as I got paid, that I'd be fine. But now {victim} is dead? Maybe those folks who said cameras steal your soul were right. I just don't know. And I don't wanna find out the hard way."
	-> questions

-screenwriterAlibi == "Rick":
"He had questions about his character in <i>Temptation Lane</i>, the seducer. Said he wasn't clear on the motivations."
Lev pauses.
"Mister Santiago's...a little intimidating, detective. Ya get the sense that he sees a lot more than he lets on."
-> questions
}

*["What can you tell me about the victim?"]
{
-victim == "Amelia":
"Just that she's Mister Clarque's sister and worked on the pictures with him. But I only had some meetings with her and the rest of the crew."
His pale face blushes. 
"She, um, didn’t seem to have much appreciation for poetry. Least not mine."
-> questions

-victim == "Carlos":
"Nothing, really. Sometimes he'd help me out with some chow. But I didn't really go to the kitchen much."
-> questions

-victim == "Edith":
"Just that she’s Mister Clarque's sister and worked on the pictures with him. But I only had some meetings with her and the rest of the crew. We didn't talk much."
His pale face blushes. 
"She, um, didn’t seem to have much appreciation for poetry. Least not mine."
-> questions

-victim == "Lulu":
"Aw, poor Miss Vanderbelle. She spent a lot of time talking to me. I dunno why. Made me nervous, a pretty sheba like her hanging around a bum like me."
	**["What did she talk about?"]
	"She was excited to be in Hollywood. Wanted to be an actress from the first time she saw a photo of Mae West. Figured she could shimmy just as good as any taxi dancer." 
	His cheeks go crimson. 
	"Her words, not mine! She'd only been here a couple a months. Took a bus from Sacramento, met Mister Clarque at an open call, and he cast her on the spot." 
	He looks pensive for a moment. 
	"And ya should know, detective. Her name's not really Lulu. She's Leah Barton from Sacramento. So ya can tell her family." 
	Lev shakes his head. 
	"Her parents didn't want her to come here. Thought LA was full of vices and vagabonds. But she wouldn't hear it. Guess their fears were founded."
	-> questions
	
-victim == "Mathilda":
"Nothing, really. Sometimes I'd see her around the house, but I don't think she ever talked to me. She was real scary."
-> questions

-victim == "Michel":
"You don't know about him? Mister Clarque is real famous. I couldn't believe it when my editor said he wanted to meet me. He makes movies just like I want to write poems. Well, um, made movies. Guess it's no more Hollywood life for me."
Lev wraps his arms around his scrawny body. 
"Although maybe it's for the best. I was always kinda nervous about those film cameras."
	**["Why is that?"]
	"It's probably just superstition. But...have you ever heard that a camera can steal your soul?"
	He shakes his head. 
	"Sounds crazy, sure, but with this hinky murder stuff...maybe Mister Clarque brought something supernatural-like down on himself. I dunno. I sure hope ya figure it out, detective."
	-> questions
	
-victim == "Rick":
"Real 'life of the party' kinda fella. Always joking and smiling. Popular with the ladies. A real sheik. Brilliant in <i>The Careless Few</i>." 
Lev shrugs. 
"We talked a few times, but I didn’t know him well."
-> questions
}

*{playerVisitedDistillery == 1}["Did you know about the distillery downstairs?"]
Lev's eyes practically pop out of his head. 
"The what? Look, detective, I'm not your guy. Sure, I write about flappers and jelly beans and all that scandalous stuff, but it's always about how sad they are. I wouldn't do nothing illegal. I swear!"
-> questions

*{playerDangerStage == "high"}["Have you seen anything strange around the house?"]
Lev shakes his head.
"Just obscene amounts of dough on display."
-> questions

*{playerDangerStage == "critical"}["What the hell is going on with this house?"]
"I know right?" 
Lev waves a hand at the space. 
"My crummy apartment is barely bigger than this room. And who has their own private theater?" 
He shakes his head in disbelief. 
"That's show biz, I guess. Sell your soul, buy the world."
Since he's only baffled by the opulence, you realize he must not be seeing the same house you've started seeing. It doesn't seem possible.
-> questions

*["Tell me again who your alibi was."]
"I was with {screenwriterAlibi}."
-> questions

*["No further questions, Mister Bernstein."]
~storyEnd = 1
-> END