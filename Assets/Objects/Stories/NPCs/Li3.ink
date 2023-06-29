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

This time, Li is frowning and typing away on her phone. When you appear, she looks up. "These all still sound stupid, you know."
*["It always does at first. You'll know when you've got it right."]
-"I will? How do you know that?" 
*["I'm a muse, honey. It's kind of my thing."]
-"Oh yeah. Immortal goddess. I kind of forgot." Li gives you a small smile. "Thanks for your help, Erato. I still feel like a dork trying to do this, but it was really cool to talk to somebody about Nora. No one knows I like her."
You are willing to bet a very large sum of money that Li's friends, and possibly even Nora herself, are aware of the girl's feelings. But you let it slide.
*["Sure thing. I hope it works out for you two."]
-"Me too." She pauses. "Um. Before I go. Do you have any advice? For how I should...I don't know. Get her to like me more?"
*["Be yourself."]
-Li rolls her eyes. "Seriously? That's it? What is with you adults and that line? It's so cheesy."
*["I'm the love expert here, Li. Trust me on this one."]
-Li was clearly hoping for something more, but you can't help it. You've seen the comedies of errors and the mistaken identities and the love triangles and everything in between. Relationships always come back to the most basic, cheesiest tenets. If the kid gets a little confidence, maybe she'll start to understand that.
You slip the {giftForLi} into Li's bag as you walk her out of the office.{giftForLi == "empty token": Even though it's a dead object, no spark of inspiration within, she'll have a memento of your time together.} Hopefully it does the trick. 
*["Good-bye, Li. Good luck to you."]
-"Thanks. Maybe I'll see you around." The girl gives you both a wave and a smile, and leaves Muse, Inc to face her destiny.

*[Return to the office]
~dossierChanged = 0
~liConversationLevel++
~storyEnd = 1

    -> END
