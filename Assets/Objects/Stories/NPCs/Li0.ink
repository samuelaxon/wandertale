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

Li is sitting in the corner, her face barely visible behind a curtain of black hair. She doesn't move when you arrive. She doesn't say anything either.

*["Hi. I'm Erato."]
She doesn't move, but you hear a muttered "hey" from the teenager. A few moments pass, and it seems the girl has nothing else to say.
    **["What's your name?"]
    Thanks to the client paperwork, you already know that Li Ryan-Jiang is a sixteen-year-old Chinese Canadian from Toronto, but it seems worth hearing how she sees herself. But all you get is another lone syllable. "Li."
        ***["Okay. Why don't you tell me what brings you to Muse, Inc, Li?"]
        -> part_two
*["Mortal! I am the muse Erato! Acknowledge me!"]
That gets the girl to look your way. Her expression reveals a skeptic rather than a supplicant. Classic teenager.
"Are you for real?" she asks. "With the whole intimidation thing?"
    **["It depends on whether you displease me, child!"]
    You didn't think it was possible, but Li curls even deeper into the corner.
    "Um," she stammers, "Look, I don't really need any divine help, it's not that big a deal, I'll just go."
        ***["It's fine. I'm just teasing. What brings you to Muse, Inc?"]
        -> part_two
    **["Nah, not really. But some people like the whole charade."]
    "Huh." Li looks back to the floor. "Whatever."
        ***["What brings you to Muse, Inc?"]
        -> part_two

=== part_two ===

Li finally stands up. She's petite even for a teenager, but she covers a lot of ground as she paces the room, nervous energy propelling her feet. After she makes two complete circuits, Li slouches back into her chair.

"It's stupid," is all she says.

*["How about you just tell me about yourself first?"]
-She shrugs. "I dunno. Sure. I don't see how I'm that interesting to a goddess."
*["I wouldn't ask if I wasn't interested."]
-> part_three

=== part_three === 

Again, the teenager only shrugs. Once more, her eyes turn floor-ward. 
*["Are you a writer?"]
She shakes her head no.
-> part_three
*["Do you have a favorite book?"]
Li makes a noncommital noise, but gives no real answer.
-> part_three
*["Do you have a favorite author?"]
She offers no response to your question.
-> part_three
* -> part_four

=== part_four ===

*["Isn't there anything you can tell me? Anything about yourself at all?"]
She seems to be thinking about whether or not to venture a tidbit about herself. 
    **["Your favorite color, maybe?"]
    ~liColorStage = 1
    ~dossierChanged = 1
    "I like the color red. <>
    **[Say nothing]
    ~liColorStage = 2
    ~dossierChanged = 1
    "I like the color red. Especially the one made from cinnabar. You know. Vermilion. <>
    --Is that worth anything?"
    -> part_five
    
=== part_five ===    
*["Sure. It's a start at least."]
-Li swings her feet up and crosses her legs on the chair. "Cool."
This has been one of the most confusing attempts to inspire you've ever had.
*["Well. Why don't you hang out here for a bit?"]
-"Are you coming back?" the girl asks. "What should I do?" 
*["I'll come back. And don't worry, you'll think of something."]
~dossierChanged = 0
~liConversationLevel++
~storyEnd = 1

    -> END
