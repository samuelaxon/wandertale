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

The woman is in her late twenties. {victim == "Edith":She appears to be in shock, red-rimmed eyes staring sightlessly ahead.}{victim == "Rick" or victim == "Michel" or victim == "Carlos":She looks perplexed, as if struggling to make sense of the world around her.}{victim == "Lev" or victim == "Lulu" or victim == "Mathilda":She has a serious expression, her thoughts clearly preoccupied.} Her dress is plain. No extra baubles or beads, and her hair has been severely swept back from her face. Your arrival jolts her back to reality.

*["Who are you?"]
-"My name is Amelia Clark."
She doesn't seem inclined to offer more information unprompted.

-> questions_1

=== questions_1 ===
	
*["Do you live here?"]
"Yes, with my two older siblings."
-> questions_1
*["What do you do?"]
"I'm a scientist. I develop the film and stills for my brother’s movie pictures."
-> questions_1
* ->
-Time to move on to the heart of things.
*["Where were you at the time of the incident?"]
-"I was with {processorAlibi}."

-> questions_2

=== questions_2 ===

*["What were you two doing?"]

{
-processorAlibi == "Carlos":
"We were talking about spices. I help him in the kitchen sometimes."
    **["That's unusual."]
    "Not really. I did all of our cooking before we hired Carlos. Cooking is a lot like chemistry and I adore chemistry."
    -> questions_2
    
-processorAlibi == "Edith":
"What, it’s suspicious for a gal to spend time with her sister?"
    **["Please answer the question, Miss Clark."]
    "We were working. Edith and I manage everything for our brother. Lots of work."
    You're not thrilled with her cagey answer, but at least it's an alibi.
    -> questions_2
    
-processorAlibi == "Lev":
"He wanted food."
Amelia shakes her head.
"Like I’m just a maid in my own house. Pretty sure that hack's going to eat his weight on our dime before the picture's done."
-> questions_2

-processorAlibi == "Lulu":
She laughs. 
"You think that girl would give me the time of day? If she's not hanging off the writer fella, she's buried in some gossip rag. I was reading a chemistry book in the same room."
-> questions_2

-processorAlibi == "Mathilda":
"I was explaining to her, for the hundredth time, why she can't come into my dark room. She wants to clean, I want to not ruin all my negatives."
-> questions_2

-processorAlibi == "Michel":
"I was trying to convince Michael not to move the new picture to a studio. He wants to close up my dark room and have 'the professionals' develop film for him." 
She fumes. 
"Like they could do a better job than me. What a laugh."
    **{playerKnowsName == 0}["Michael? I thought the director's name was Michel."]
    She looks at you as though you're simple-minded. 
    "And yet my name is Clark and I am not French. You really didn't notice that Clarque and Clark are the same name? It's all an act. I assumed any half-decent detective would know a fake accent from a real one."
        ***["Why is he using a false name?"]
        "To seem more cultured and cosmopolitan when he wanted to break into Hollywood." 
        She sighs.
        "I don't think he considered the consequences of his little charade working. But being thoughtless is nothing new for him."
        ~playerKnowsName = 1
        -> questions_2
    **{playerKnowsName == 1} -> questions_2

-processorAlibi == "Rick":
"We were...um..." 
Her face flushes crimson. 
"We were talking about the movie. Yes. Just talking. That's all."
    **["Miss Clark, I advise you to be completely truthful about your alibi."]
    Amelia grabs your arm.
    "Nobody’s supposed to know," she hisses. "We're just two friends with...you know...a shared hobby. Please don’t tell anyone. Especially not my sister."
    -> questions_2
}

*["What can you tell me about the victim?"]
{
-victim == "Carlos":
"He worked for our family for years. He had a gift with flavors. And he was the kindest man I think I've ever met."
Amelia sniffles.
"I learned a lot from him," she says softly.
-> questions_2

-victim == "Edith":
"She was my older sister. We were always close. She was angry about a lot of things, but she had good reason to be. She didn't deserve whatever has happened to her."
    **["What was she angry about?"]
    "Our brother, mostly. He got famous off of our work. All that stuff about his keen eye and artistry? That's all editing. All Edith. If he'd been on his own, nobody in Hollywood would care about him. But he treats her like a dog."
    Her eyes dim.
    "Treated. I know she's probably dead. I heard that noise."
    Amelia shivers.
    "I have no idea what happened to her, but it must have been horrible. I just...I don't understand why."
    -> questions_2
    
-victim == "Lev":
"That writer? Seemed like a flat tire. I didn't really get what my brother saw in his poetry. But it's a shame something happened to him."
-> questions_2

-victim == "Lulu":
"Nothing. That chippy was too busy making eyes at the fellas to pay any attention to me."
-> questions_2

-victim == "Mathilda":
"She worked for our family. Always professional. She was a bit of a grouch, but she never did anything wrong. She was just an old lady. I can't believe someone would hurt her."
-> questions_2

-victim == "Michel":
"He was my older brother. Michael wasn't exactly a great sibling, but he's still family. I never would have wanted him dead. I just wanted him...fair."
    **{playerKnowsName == 0}["Michael? I thought the director's name was Michel?"]
    She looks at you as though you're simple-minded. 
    "And yet my name is Clark and I am not French. You really didn't notice that Clarque and Clark are the same name? It's all an act. I assumed any half-decent detective would know a fake accent from a real one."
        ***["Why is he using a false name?"]
        "To seem more cultured and cosmopolitan when he wanted to break into Hollywood." 
        She sighs.
        "I don't think he considered the consequences of his little charade working. But being thoughtless is nothing new for him."
        ~playerKnowsName = 1
        -> questions_2
    **{playerKnowsName == 1}["How was he unfair?"]
    "Edith never got to be an artist because Michael bullied her into doing his editing work. If I hadn't convinced him I could help out with development, he would have barred my studying chemistry. Everything had to be about him, all the time. As I said, not a great sibling."
    -> questions_2
    
-victim == "Rick":
"He was charming. Handsome. Good kisser."
She blushes.
"I mean, I'd just heard that. You know, in the...um...gossip pages. He came here a lot because he the lead for <i>The Careless Few</i>. But he was a real friend to me and my sister Edith."
-> questions_2
}

*{playerVisitedDistillery == 1}["What do you know about the distillery downstairs?"]
"Oh horsefeathers!" Amelia curses, then quickly tries to cover the blunder. "I mean, what? No! What are you talking about?"
	**["The distillery. It's right next to your dark room and full of chemistry equipment. Something tells me you’re involved."]
	"I...I...fine. Yes. Michael never gave us a cut of his movie money, so we were totally dependent on him. The distillery was a way to run our own business, take care of ourselves. I do the actual brewing and distilling. And like all chemistry, I'm real good at it."
	    ***{playerKnowsName == 0}["Michael? I thought the director's name was Michel?"]
	    She looks at you as though you're simple-minded. 
        "And yet my name is Clark and I am not French. You really didn't notice that Clarque and Clark are the same name? It's all an act. I assumed any half-decent detective would know a fake accent from a real one."
        ~playerKnowsName = 1
        -> questions_2
        ***{playerKnowsName == 1} 
        -> questions_2

*{playerDangerStage == "high"}["Have you seen anything strange around the house?"]
"Of course not," she says quickly. 
You raise an eyebrow at her hasty response. But Amelia recovers, taking a deep breath. 
"It's a house full of Hollywood types," she sighs. "Nothing is strange with this crowd."
-> questions_2

*{playerDangerStage == "critical"}["What the hell is going on with this house?"]
"I don't know what you mean," she says quickly. 
You raise an eyebrow at her hasty response. But Amelia recovers, taking a deep breath. 
"I guess we're a strange crowd to an outsider. This is just what a normal day is like here." Her expression darkens. "Other than the potential murder."
You wish the woman of science could have reassured you, offered a logical explanation for the occult presence you're seeing. But no. You're still in this alone.
-> questions_2

*["Tell me again who your alibi was."]
"I was with {processorAlibi}."
-> questions_2

*["No further questions, Miss Clark."]
~storyEnd = 1
-> END