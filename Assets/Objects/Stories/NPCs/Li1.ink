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

You're pretty sure that Li hasn't moved since you were here last time.

*["Hey."]
This time, you don't even get a complete word in response. Li makes a noise somewhere between a grunt and a hum. <>
*["Did you try writing...whatever it is you need help writing?"]
Li returns to her signature move: the shrug. <>
-You might be here awhile. You settle into your own chair.
*["I'm powerful, but I can't read minds, you know."]
"That's good. Mind-reading would probably suck."
You're flabbergasted to get not one, but two complete sentences from the teen. <>
*["Look, these consultations aren't cheap. Why blow your money and not talk to me?"]
Li looks directly at you. You can tell she's struggling with this whole process. "I told you, it's embarrassing."
You're flabbergasted to get a complete sentence from the teen. <>
-It's a start.
*["How did you hear about Muse, Inc anyway? We don't get many clients your age."]
-"Because people my age are stupid." Li reconsiders. "Mostly."
Your mind is going in circles. Time is short and you haven't really gotten any insight about something to inspire Li. She seems almost unwilling to get the consultation she paid for.
The girl slouches farther in her chair and ventures a few words. "I have a...friend. Who came here. She said it was exactly what she needed."
*["Who did your friend see?"]
Li looks confused. "Why does that matter?"
    **["I ask the questions, mortal! Now answer me!"]
    ~liVesselStage = 1
    ~dossierChanged = 1
    At least the deity act makes Li bark out a laugh. "Right. Yes ma'am." <>
    **["I'm just trying to learn about you. It's how I'll help you."]
    ~liVesselStage = 1
    ~dossierChanged = 1
    The girl sighs. "It's hard to just open up your soul to a stranger. Especially a goddess." <>
    --She stares up to the ceiling this time. "My friend saw Euterpe. We're both musicians." Li doesn't appear willing to offer any additional information, but it's good enough.
        -> part_two
        
*[Say nothing]
For a moment you both fall quiet. You watch Li, and Li stares doggedly at the floor.
"She had a meeting with Euterpe. Helped her reach a new level in her music."
    **["So you're friends with a musician. Are you a musician too?"]
    Li suddenly blushes. Finally, you've gotten a real reaction from the taciturn girl. 
        ***["You are, aren't you! What do you play?"]
        ~liVesselStage = 1
        ~dossierChanged = 1
        "Fine!" Li jumps out of her chair and starts moving agitatedly around the room. "Yes. I want to be a musician. It's dorky and stupid and I don't want people to know. I hate that I even had to tell you."
        You're surprised by the intensity of her reaction, but relieved to finally make some progress. <>
        ***["You can tell me, Li. Please?"]
        ~liVesselStage = 1
        ~dossierChanged = 1
        You barely hear the murmured word, but your keen ears don't lie. <>
        ---Li is a musician. This is important to her, but for some reason she's hesitant to talk about it.
        -> part_two
        
    **[Say nothing]
    The silence stretches on, but you commit to the approach. Li will have to be the one to speak first. You are immortal after all. You have nothing but time. 
    "She's not my friend, exactly," Li finally says. "The one who saw Euterpe. She's...she's my teacher."
        ***[Say nothing]
        ~liVesselStage = 2
        ~dossierChanged = 1
        Again, Li sinks into silence, but you match her. You have no idea how long it takes, but eventually, the girl lets out a long, heavy sigh. She leans her elbows on her knees.
        "I want to be a concert flutist. It's so dorky and stupid and everyone will think I'm dumb for liking classical music so much. It's my dream and it's a huge secret." She looks up at you, anxious. "Don't tell anyone? My parents or my friends or...anyone. Please?"
            ****["I won't. Artist-muse privilege. It's a thing."]
            The teenager laughs, but you hear the shakiness in her voice. It took a lot for her to share this, and music is clearly essential to her. -> part_two
    
=== part_two ===

*["Thanks for telling me this. It's going to help me to help you."]
-Li seems to be completely done with any form of verbal communication. You might as well leave her to her thoughts for awhile.
*["I'm gonna head out for a bit. But when I come back, can we please talk about why you're here?"]
-Li looks pained. "Do we have to?"
*["Yup. But if you can be brave, I can get you the inspiration you need. Promise."]
-She grimaces, but nods. You stand to leave. Your instinct is to give the poor kid a hug, but Li doesn't seem like the type to enjoy casual touch from fellow mortals, much less goddesses. So instead you just bid her farewell.
*["It's going to be okay. Don't worry. We'll think of something."]
~dossierChanged = 0
~liConversationLevel++
~storyEnd = 1

    -> END
