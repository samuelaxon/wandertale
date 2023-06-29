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

When you rejoin Gloria, the author is hunched at her laptop, her fingers flying over the keys. You know better than to interrupt an artist's flow state, so you sit in a chair and wait. 
After a few minutes, Gloria expels a long sigh. She stands and stretches, then squeaks in surprise when she catches sight of you.
"What the...? How long have you been in here?"

*[(Lie) "I never left. I am with you always, guiding your pen with my immortal hand!"]
You see Gloria visibly quiver at your booming voice. Then she smiles. "Seriously, that is so cool."
    **["Thanks. How's the writing?"]
    The smile fades a bit. "Hard to say. <>
*["Just a few minutes. Didn't want to interrupt."]
"Thanks. It was good to feel a bit like my old writing self, even just for a little while. <>
-I might be moving in a...not totally terrible direction. Or it might still be terrible. I don't suppose you can tell me?"
*["I shall not! That knowledge is not yet for your ears, mortal!"]
"Hmph. I like your muse mode a lot more when you're being helpful." <>
*["Not yet. But I'm optimistic."]
"Cool. I like optimistic." <>
-Gloria retakes her seat. She doesn't look all that optimistic.
*["You just have to keep working. I'll make sure you get the spark."]
-"I know. I believe you. It's just..." The author rests her chin in her hand. "Every book of Seduction and the Shifters got better and better reception. Now I'm starting a new series. What if people don't like it because it's different? Or what if they think it's not different enough and they say my old stuff is better? In either case, I worry that I have nowhere to go but down."
*["What about the case where everyone loves your new book?"]
She rolls her eyes. "You don't spend much time on the internet, do you? There is no case where everyone loves anything." Gloria holds up her hands, conceding some of your point. "It would be nice if my fans and readers had a really high percentage who loved the new book. And yes, that could happen. Technically. It seems unlikely. And <>
*["Would that be the end of the world?"]
The question clearly surprises her. "I mean...well, mediocre reviews won't destroy the fabric of the universe or anything. But it's my career. It's my livelihood. It wouldn't be the end of the world, but it would feel pretty crappy. Plus, <>
-I don't want to let anyone down."
*["Mortal! You are my vessel of love stories! Your happiness is all I desire!"]
-The deity voice does have a strong impact on Gloria this time. "I know, I know." She says the words, but you're not convinced she believes them.
*["I hear the 'but' you're not saying. What is it?"]
~gloriaVesselStage = 2
~dossierChanged = 1
"But belief isn't enough to repay my husband." Gloria looks at the floor, dejected. "He supported us both when I was first starting out, while I was trying to get noticed by agents. He hated his job, but he kept it so that I could follow my passion." Gloria fingers the chain around her neck. "He gave me this necklace after my first book was published. I wear it every day. To remind myself of the debt I owe him."
    **["Does he say that you owe him?"]
    "Of course not. <>
*["You're smart and talented. You have everything it takes to rule the romance world. You'll do it."]
"I...I want to believe you. I know a lot of other people do. But only one of them matters. My husband."
    **["Between his support and mine, you can do anything."]
    ~gloriaVesselStage = 1
    ~dossierChanged = 1
    "I hope so." She looks at the floor, dejected. "Every time I publish a book, he gives me a piece of jewelry. Not cheap stuff either. Really beautiful stuff. I love that he does that for me. Now that it's a tradition, though, it's started to feel like pressure instead of a gift. But that's not his fault. <>
-It's all coming from me. I think I'm my own worst enemy here."
Although Gloria looks despondent, you know you have the final piece to unlocking her creativity.
*["Don't let your doubts stop you. Sit down and let the words flow!"]
"If I could let the words flow, I wouldn't be here." <>
*["I know it feels impossible. But you have to stay at your laptop and get the words out."]
"I guess. I can try." <>
-Time to break out the serious persuasion.
*["I must depart to complete my immortal task of inspiration! I command you write and await my return!"]
-"Eep! I mean, okay! I'll do my best!" Gloria plunks herself back in her chair and bends over her laptop once more.
*["Do not worry, mortal! You shall think of something!"]
~dossierChanged = 0
~gloriaConversationLevel++
~storyEnd = 1

    -> END
