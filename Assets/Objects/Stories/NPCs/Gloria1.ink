VAR storyEnd = 0
VAR gameEnd = 0

VAR gloriaProjectKnown = 0
VAR julianProjectKnown = 0
VAR liProjectKnown = 0
VAR gloriaColorStage = 0
VAR gloriaMaterialStage = 0
VAR gloriaVesselStage = 0
VAR julianColorStage = 0
VAR julianMaterialStage = 0
VAR julianVesselStage = 0
VAR liColorStage = 0
VAR liMaterialStage = 0
VAR liVesselStage = 0

VAR dossierChanged = 0
VAR playScrySound = 0

VAR gloriaConversationLevel = 0
VAR julianConversationLevel = 0
VAR liConversationLevel = 0
VAR mnemosyneConversationLevel = 0
VAR gloriaInspirationLevel = 0
VAR julianInspirationLevel = 0
VAR liInspirationLevel = 0

VAR objectToAdd = ""
VAR tookItem = 0

VAR giftForGloria = ""
VAR giftForJulian = ""
VAR giftForLi = ""

-> part_one

=== part_one ===

Gloria is sitting at her laptop with her arms crossed. "You're back. Good. No disrespect, but I'm not sure this whole inspiration thing is working yet. I wrote down a couple character concepts, but they all turned into people I already wrote in my Seduction and the Shifters books."

*["Tell me more about that series. What happens?"]
-The author grins. "Oh, it's so much fun. I love the escapism of romances, so when I started to write my own, I decided to embrace the most over-the-top concepts. So I came up with a shifter universe set in New Orleans."
*["Um...shifters?"]
"People who can turn into animals," Gloria explains. "It's a very popular subgenre of fantasy romance."
-> part_two
*["Ooh, sounds spicy. In every sense. No wonder you've been successful."]
"Thanks. It's a very specific niche, but a lot of readers have liked seeing a different take on the subgenre."
-> part_two

=== part_two ====

*["Who's your favorite hero you've written?"]
"Definitely Andre. He's a club owner who can shift into an alligator. He has to stop a weasel shifter from trying to break up his house band and take over his prime location on Bourbon Street. He needs to team up with the only shifter private investigator in town. Who happens to be a very attractive woman." Gloria winks. "You can guess how that turns out." 
    **["What do you like about Andre?"]
    "He's smart and he's got his life in order. A self-made man. He's on top of his business but he still knows how to have a good time. His struggle is in trusting and being vulnerable with other people." Gloria gives you a small smile. "He may have been inspired by someone I know."
    -> part_two
*["Who's your favorite heroine you've written?"]
"Hm. That's a tough question. I love all my ladies so much." Gloria takes the question seriously, her brow furrowing as she weighs her options. "If you're making me choose just one, I think it's Lola. She was...she was special."
    **["How so?"]
    "I'd decided to write older protagonists. Lola's fifty-three."
        ***["Wow. And people wanted to read that?"]
        ***[Say nothing]
        Gloria glares. "You know, it's easy to forget that you're an immortal until you do that whole silence thing. It's freaky. And not in the good way."
            ****["Sorry."]
        ---"What's wrong with showing older people finding love? Romance and sex aren't just for twentysomethings, you know."
        ***["Oh, I am well aware. I just didn't realize mortals were also aware of it."]
        ***["Nothing's wrong. I think it's wonderful."]
        ---"Good. I confess, it wasn't my strongest seller, but the reviews called that book my best. Well, my best at the time. It was the fourth in a five-book series."
        -> part_two
* -> part_three

=== part_three

You're getting a sense of place and strength in Gloria's own writing, and several titles for your to-be-read pile, but nothing to spark a fresh inspiration for her.

*["What about other authors? Who do you like?"]
"Sissy Martins," she replies without hesitation. "Now, always, and forever. The woman writes the most amazing stuff." 
    **["What does she write?"]
    "My favorite is Fangs of Fate. <>
*["What kinds of books do you read in your free time?"]
"I'm all about the vampires and werewolves. My favorites are like a soap opera on steroids. They're the most over-the-top, life-or-death, in-your-face books and I love them so much." 
    **[Wow."]
    "Wow is right. My favorite book of all time is Fangs of Fate, by Sissy Martins. <>
-It's about a vampire coven trying to survive being hunted. It's supernatural and it's exciting and it's super swoony. I so want the series to be optioned into a TV series."
*["I bet you could write something just as amazing."]
~gloriaMaterialStage = 1
~dossierChanged = 1
Gloria laughs. "I wouldn't try to compete with Sissy. She can write action in a way I only dream of. There's something about her books, the way the weaponry is all described. It's so metal. Like, hardcore heavy metal, but there's also just metallic stuff everywhere. It gives her work an edge."
*["What inspires you about her work?"]
~gloriaMaterialStage = 2
~dossierChanged = 1
"Sissy can write action in a way I only dream of. There's something about her books, the way the weaponry is all described. You can feel the cold metal of every knife, every gun. There's a scene where she describes loading silver bullets into a pistol and I literally got chills."
-The writer leans back in her chair. "I've tried to match what she does in my own action scenes. Just doesn't ever quite land right." Then Gloria turns to you, looking mischievious. "Although. I have a muse right here. You gonna help me be as good as Sissy?"
*["That's what I do. I think I'm getting a sense of how."]
"Nice. I really hope you can. You know, talking about Fangs of Fate is making me excited to keep trying. Maybe I can get something down on the page. <>
*["I shall inspire you to heights this Sissy Martins could not even fathom, mortal!"]
Gloria blinks at you for a second. "Wow," she murmurs in awe. "That was cool. You really can turn on the immortal goddess thing when you want to, huh?"
    **["Sure can."]
    "Well. I think it's working, because I just had a thought I want to get down. <>
-Mind if I take a couple minutes to brainstorm?"
*["Go right ahead. I'll leave you to it."]
-"Thanks. Boy, I really hope this idea sticks." Gloria scoots up to her laptop and begins to type. You leave her to it, offering a quiet farewell.
*["You'll come up with something."]
~dossierChanged = 0
~gloriaConversationLevel++
~storyEnd = 1

    -> END
