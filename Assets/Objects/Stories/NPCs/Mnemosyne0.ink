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

->introduction

=== introduction ===

The company is housed in a neo-classical building, soaring Ionic columns and a white marble facade. You're surprised; you would have expected the architecture to be the real deal, all garishly painted and inlaid with gold. But this snowy appearance does instill the sense of grandeur and power that you'd expect of goddesses. Plus, you suppose they need to meet the expectations of the clientele.

<i>Clientele</i>. This is going to be different.

*[Go inside]
-You push through the revolving doors to the lobby. It's exactly what you expected. Clio is draped in an armchair, her nose buried in a musty book. Euterpe has her headphones on and her eyes closed. Terpsichore is choreographing what you expect will be the next big dance craze on TikTok. The others must be with mortals.

Then a glamorous gray-haired woman appears, dressed in a crisp white suit, a rope of diamonds, and towering stiletto sandals. When she sees you, her face breaks into a genuine smile. "Erato! I'm so glad you're here."
*["Hi."]
-"When you said you were going to join us again after so long...well, I didn't want to get my hopes up until I saw you." You're shocked to see her eyes go misty. Maybe you shouldn't have held out for so long. But she quickly recovers. "Now, there's a lot to discuss before you can start your first day. Come up to my office and we'll have a chat."

*[Follow her]
-She leads you up a marble staircase to a glass door. The words "Mnemosyne, CEO" are etched into the pane in a delicate script.
"Have a seat, dear."
*["Thanks...um, what do I call you? Boss? Madam CEO?"]
-"Goodness, there's no need for such formality. This may be a business now, but it's still a family business. You can always call me Mnemosyne. Or Mom, if you prefer."
Mnemosyne gestures toward two comfortable purple chairs, and you both sit.
"It's wonderful to have all nine of my daughters working for Muse, Inc at last. You have no idea how many clients came looking for you over the centuries. What a relief I don't have to turn them away any more." 
*["It's not like I wasn't working. I inspired loads of mortals. Just not for money."]
-She smiles. "You think I didn't keep tabs on you? I know you've been busy. And I know the corporate thing is different, but I promise you, it's so rewarding this way. We've inspired even more potent creativity under this model than as independent contractors following our own whims. Surely your sisters have told you?"
*["They may have mentioned it, yes. They all seem...happy."]
-"And I hope you will be too." Mnemosyne shifts in her chair. She's ready to get down to business. "Now, I know you've had your own ways for providing inspiration to the poets, but we have a more particular system at Muse, Inc. Do you need me to explain what we do here?"
*["Yes, explain what I need to do."]
->tutorial
*["Nope, I've got the muse thing down."]
-> exit

=== tutorial ===
"We're in the business of inspiration. Mortals think we help them like a therapist, listening and talking. And that is important of course. But the real magic is the amulets we craft for each blocked artist. The amulet helps the artist connect with what's most important to them in the current moment and unlock their best creations."

+["What's in an amulet?"]
-"An amulet is made of three reagents: a color, a material, and a vessel. You need one of each to craft a complete amulet. You have three clients today, so you'll gather three colors, three materials, and three vessels."
+["How do I know what ingredients to get?"]
-"Talking to a client will reveal clues about what will best inspire them. That information appears in your Dossier, which you can access any time. After you have a chat with a client, you'll teleport directly to the Temple of Ideas."
+["What happens at the Temple of Ideas?"]
-"That's where you'll gather reagents for the amulets. Scry the objects you find there until you find one that best matches what you discovered about the client. Be sure to check your Dossier while you're there. You can only bring one item back from the Temple per visit, and you can't swap reagents on future visits. So get the best information you can from clients and select your reagent carefully."
+["Then what?"]
-"When you have nine reagents in your Inventory, you'll be able to craft the amulets for each of the three artists. Remember, the Dossier is your best tool for crafting. Then you'll deliver the amulet and send your artist back into the world, hopefully ready to create something breathtaking."
+["This is a lot more complicated than the old way."]
-"Perhaps, but it's more effective too. Inspiration quality increased 250% with the amulets, and our customer satisfaction increased 380%." Mnemosyne levels you with a serious gaze. "We need happy clients, dear. Mortals can find inspiration anywhere these days with the internet. We may be immortal deities, but we still rely on customer satisfaction to drive business. Don't disappoint me, my daughter."
+["I'll do my best."]
-"I know you will. Now, are you ready to work? Or do you need me to repeat the official Muse, Inc training?"

+["I'm all set and ready to inspire!"]
-> exit
+["Actually, let's run through all of that one more time."]
-> tutorial

=== exit ===

Mnemosyne claps her hands. "Excellent! Your studio suite is downstairs to the left. Your clients are already in rooms there. Now go forth and work some wonders, Erato!"
*[Start work]
~mnemosyneConversationLevel++
~storyEnd = 1

    -> END
