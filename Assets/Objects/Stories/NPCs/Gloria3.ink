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



Once again, you've caught Gloria in the middle of working. Clearly the writer just needs a regular dose of some goddess-delivered commands to keep her focused. 
{
    -giftForGloria == "empty token":
    -> part_two
    
    -else:
    -> part_one
}

=== part_one ===

*["I have something for you."]
-Gloria jumps. "Huh? Something for me?"
*["It is a token of my favor! Take it with pride!"]
She giggles even as she cowers a little. "I don't know that I can ever get used to that." Gloria accepts the {giftForGloria} from you. "I'll think of your big old muse voice when I look at it. I think it might help. Thank you. <>
*["Yep. Something to help you stay inspired, even when you're not at Muse, Inc."]
Gloria accepts the {giftForGloria} from you. "Thank you. <>
-Not just for this gift, but for everything. It's hard to find your compass when you're so deep in the business. You have a nice way of making things feel less complicated. Like it's obvious what's important. I really appreciate your help, Erato."
*["My pleasure. Let me walk you out."]
-You and Gloria head out to the lobby. You shake hands, and the writer departs, quickly lost in the crowds of other mortals on the sidewalk at the end of the work day. You hope you've gotten her the breakthrough she needs, if only to see where her inventive mind goes next.

*[Return to the office]
~gloriaConversationLevel++
~storyEnd = 1

    -> END
    
=== part_two ===
The {giftForGloria} doesn't have the spark of inspiration in it. The object feels dead in your hands. But it is pretty, and maybe Gloria can look fondly on it in later years and remember what you discussed with her. You slip the {giftForGloria} into her purse as she saves her current document and powers down the laptop.

*["Seems like you're onto something."]
-"We'll see. It'll take some time. Always does." Gloria gathers her belongings and gives you a smile. "Thank you. For everything. It's hard to find your compass when you're so deep in the business. You have a nice way of making things feel less complicated. Like it's obvious what's important. I really appreciate your help, Erato."
*["My pleasure. Let me walk you out."]
-You and Gloria head out to the lobby. You shake hands, and the writer departs, quickly lost in the crowds of other mortals on the sidewalk at the end of the work day. You hope you've gotten her the breakthrough she needs, if only to see where her inventive mind goes next.

*[Return to the office]
~gloriaConversationLevel++
~storyEnd = 1

    -> END
