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

Li is still in her chair, but this time she's sitting erect, with perfect, graceful posture and her hair tucked behind her ears. It seems like she has taken the break to get serious and prepare to share something important. At least, that's what you hope.

*["Hey, Li. Ready to talk?"]
-"Ugh. As ready as I'll ever be." She still seems nervous as you take the seat next to her. "You're not going to laugh at me, right?"
*["Of course not."]
~liProjectKnown = 1
"Good." She takes a deep breath. "Thanks. <>
*["Only if you tell a joke."]
~liProjectKnown = 1
She snorts. "I'm not much of a comedian. <>
-Okay, here goes. I want to ask someone out and I have no idea how." You wait to see if she has more to say, but that seems to be the whole of it. Li groans. "Seriously, this is pathetic. Who needs divine help to talk to a crush?"
*["Honey, I have helped make so many declarations of passion over the eons, you have no idea."]
-"Oh. I guess that makes sense. But nobody writes poetry to people they like any more."
*["Are you implying that I don't keep up with the times?"]
"Um. Maybe? How good are you with emojis?"
    **[:heart:]
    "Fair." <>
    **[:100:]
    "Fair." <>
    **[:poop:]
    "Um. Sure." <>
    --Li slumps a little. <>
*[Say nothing]
You only raise an eyebrow at the girl. Li meets your gaze at first, but eventually squirms. <>
-"I'm just really nervous. This whole feelings thing is really hard. I feel like a dork every time I try to do it."
*["Why don't you tell me a bit about this person you like?"]
-For the first time in your entire day with her, Li gives you a broad smile. "Nora. She's...oh my god, she's perfect. She's pretty and nice and smart and funny." The smile disappears as quickly as it appeared. "Which is why she'd never go out with a doof like me."
*["You're not a doof."]
This time Li is the one to raise an eyebrow at you. 
    **["Well. It's more that everyone is a doof. Some just hide it really well."]
    "Then Nora is the best at hiding it. One more thing she's good at. <>
*["You won't know until you ask."]
"Which is my problem. <>
-How do I tell the most amazing girl on the planet that I want to hang out with her and kiss her and stuff?"
*["It depends on the girl, of course."]
-Li groans. "Why do adults always give that kind of advice?" 
You're amused to be dubbed an adult, but hopefully it means Li is starting to at least see you as relatable and not as an all-powerful goddess. 
-> part_two

=== part_two
*["What does Nora look like?"]
"She's got red hair and tons of freckles. Green eyes. And she's really stylish."
    **["Tell me more."]
    ~liMaterialStage = 1
    ~dossierChanged = 1
    "She wears a watch. An old-school one with the metal links that look almost like liquid. It's really cool. Like her. Strong and shiny and totally unique."
    -> part_two
    **[Say nothing]
    ~liMaterialStage = 2
    ~dossierChanged = 1
    Li looks thoughtful. "I think that's what I like most about her. She doesn't act like anyone else at school. I mean, she wears a watch every day. A real gold watch. Who does that? Everyone just uses their phones. Or they'd look like pretentious hipsters if they wore a watch. But it's just who Nora is. She's like gold." Li stops and snorts. "God, I sound like an idiot, don't I?"
    -> part_two
*["What does she like to do?"]
"She's an artist. I've seen her sketching in her notebooks during class or at the bookstore. She's so talented." 
    **["Bookstore?"]
    "Yeah. Sometimes, a bunch of us go to the indie bookstore and have frappes. One time it was just me and Nora at the table and..." Li blushes and stops. 
        ***["...and?"]
        "Oh. Nothing. It was nothing." A second later, <>
        ***[Say nothing]
        For about a nanosecond, she stays silent. Then, <>
        ---too excited to contain herself, Li leans forward and whispers to you. "She held my hand. For like, two seconds. It was amazing!"
        Ah, young love. Still makes you smile.
        -> part_two
* -> part_three

=== part_three ===

You listen to Li chatter, yes, actually chatter about Nora for a while longer. But duty calls and you need to acquire the final element for her amulet. 
*["Okay, Li. Write a couple ways you could ask Nora to the bookstore with you."]
-"Oh. You're leaving? I thought you were going to help me?"
*["I will. But the words still have to come from you."]
-"I guess that makes sense. Okay. I'll try." She looks at you with a little reproach. "You really aren't going to tell me anything about how to start?"
*["Nope. Don't worry, you'll think of something."]
~dossierChanged = 0
~liConversationLevel++
~storyEnd = 1


    -> END
