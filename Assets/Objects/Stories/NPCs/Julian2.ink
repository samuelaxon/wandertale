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

Julian is walking around the room. It doesn't seem like he's tried writing anything else. He seems subdued, quieter than when he first arrived at Muse, Inc. He doesn't kneel or bow or anything. What a relief.

*["Greetings, my poet-servant! Share your thoughts with me!"]
He jumps. "Wow. That voice is actually a little scary. Cool, but scary. I was <>
*["Hi Julian."]
For once, he simply smiles at you. "Hey. I've been <>
-thinking about what we talked about before. About why the forest has been lodged in my head ever since I did that retreat after college. It doesn't make any sense. Why would I be fixated on something that made me doubt everything I am?"
*["Maybe because deep down, you know something that you don't want to admit."]
-"Why would I do that? It sounds like a pretty stupid thing to do."
*["I hate to tell you this, but sometimes humans do stupid things. Gods too."]
He grunts a rough laugh. "I'm starting to wonder if maybe I do more stupid things than the average human. Why else would I be so confused? I feel that I've <>
*["Not stupid. Smart. You're torn between protecting yourself and seeking artistic truth."]
"Hm. That certainly is a more appealing interpretation than that I am terribly confused. That I have <>
-lost any sense of my purpose in writing. That I don't see the point of my poetry. That I should quit and become a fisherman or a farmer or something."
*["Let me ask you a question, Julian. What do you love outside of poetry?"]
-"Excuse me?"
*["What makes you happy? What makes you feel alive?"]
-The poet's eyes spark, but he doesn't speak. You need to figure out what it is that is important to him.
*[(Lie) "Ah. Yes. I can read your thoughts clear as day. Why don't you tell me in your own words?"]
Julian seems surprised. "You can? Of course you can. You're a muse. You probably know everything."
    **["What matters is that you know. You're a clever, intuitive man, after all."]
    ~julianVesselStage = 2
    ~dossierChanged = 1
    "Well. Fine. I thought of the tabletop role-playing group I ran in college. We'd have campaigns last for hours, late into the night. It...it was great. The other poets in my classes thought it was odd to be so rooted in a fantasy, but I didn't care. I loved getting to play, to create rules or invent worlds, to accomplish or to win. I think I was a good gamemaster, too." <>
*["I won't judge. But I need to know in order to help you."]
Julian seems disappointed. "Oh. I really thought that you could just know exactly what I needed. Being a muse and all."
    **["I can help you. But you need to help yourself too by being honest."]
    ~julianVesselStage = 1
    ~dossierChanged = 1
    He sighs. "I hate being honest. It's more fun to pretend. That's why I didn't want to share what I thought. It's games. Toys. I love getting to play, to learn rules or invent worlds, to accomplish or to win." <>
-He pulls himself tall, back to his old dramatic hauteur. "But toys are so...pedestrian. I don't indulge in them any longer."
*["Why should that be a critique? Popular, beloved, common, those sound like good things to me."]
"Perhaps. I suppose the real truth is that poets, good ones, don't wish to languish in obscurity. We want to evoke reactions. We want to connect with people."
    **[Maybe there's a way you can make your poetry combine with that desire for connection."]
    "I suppose we'll see."
*["You know what else is pedestrian? Greeting cards."]
He looks truly aghast. "You...you can't possibly be suggesting that the trite verses I do for a paycheck are worthy of my talents? That...doesn't that go against everything you stand for as a muse?"
    **["My job is to inspire. I don't judge the form."]
    "I suppose that is...rather reasonable. I don't expect deities to be reasonable."
-Julian sits down. He picks up his pen, twirls it between his fingers. "You know, I think I'd like to try writing a little something. I'm not sure exactly what, but...if you don't mind..."
You stand up as the ink starts scratching over the page. 
*["I don't mind. You'll think of something."]
~dossierChanged = 0
~julianConversationLevel++
~storyEnd = 1

    -> END
