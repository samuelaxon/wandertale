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

You pick up the shell necklace. You can scry it to learn its properties.

*[Scry]
~playScrySound = 1

-The necklace has a pearlescent shell pendant hanging from a chain. It would lie right above your heart if you wore it.

<b>vessel:</b> necklace (jewelry)

*[Leave this reagent and keep exploring]
~playScrySound = 0
~storyEnd = 1
-> END

*[Take this reagent and return to Muse, Inc]
~objectToAdd = "shell necklace"
~tookItem = 1
~playScrySound = 0
~storyEnd = 1
-> END