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

Julian is back to his old pose: collapsed and dissheveled in his chair. He gives you a look of wonderment when you walk in.

"I can't believe it. You really changed my mind."

*["What do you mean?"]
-He looks back down at the page. "I wrote a Valentine's Day poem. The sort of thing I do for work. And I don't hate it."
*["Of course you don't. You're a good poet."]
Julian turns and stares at you. For the first time, he looks at you like an individual, someone with ideas and opinions rather than an abstracted deity. "Do you really think that I'm good?"
    **["I do."]
    He smiles, a real one. "Thank you. Truly." <>
    **["I don't."]
    He frowns, but takes your words in stride. "Ah. I see. Well. Perhaps after our conversation today, I can start earning your admiration." <>
    **["It doesn't matter what I think."]
    He shakes his head. "Hah. A non-answer if I've ever heard one. But I suppose you're not wrong." <>
*["You're welcome."]
He laughs. "You know, I thought you were being mean-spirited any time you were direct with me. Now I'm thinking maybe you just have an odd sense of humor."
    **["Please, I'm hilarious."]
    "You know what, I think you just might be," he says with a grin. <> 
    
-He folds up his scribblings and puts them in his pocket. "This whole day has certainly not been what I expected. In a good sense, I think."
*["Agreed."]
-You decide to sneak the {giftForJulian} into his pocket too.{giftForJulian == "empty token": Even though the object has no spark of inspiration, Julian might appreciate a memento of your time and conversation with him.} Hopefully when he finds the amulet, he'll feel that sense of true purpose once more.
At the door to Muse, Inc, Julian does make you one last, deep bow. "Thank you for your assistance today, Erato. I hope I may return for another appointment should I need your services again."
And with that, the poet departs.

*[Return to the office]
~julianConversationLevel++
~storyEnd = 1

    -> END
