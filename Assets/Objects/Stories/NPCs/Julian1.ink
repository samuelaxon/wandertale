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

Julian appears to have collapsed in his chair, his limbs splayed in all directions and his back arching in what must be a very uncomfortable position. You wonder if he intentionally picked this pose of utter despondence for dramatic impact or if it came naturally. When he notices you, he springs into action, leaping up to clasp your hands and bow over them.

*["Yes, bow in submission, my mortal minion!"]
"As you wish, most majestic Erato! I am so grateful for your guidance thus far! <>
*["You know, 'hello' is the more typical greeting."]
He drops your hands, but bows once again, the motion stilted this time. "Apologies. I would not dream of offending you, majestic Erato. But I am overcome with gratitude. <>
-I've penned a few words, mere scraps of phraseology, but I've begun to feel like my old perspicacity has returned. Thank you, wise goddess! Thank you!"
*["Of course it has. You are in my presence!"]
"It is as you say, wonderous muse. And now <>
*[Say nothing] 
He barrels on. "I felt the light of your inspiration for a brief while after you departed, but it didn't take long for the words to lose their luster. Now <>
-that you have returned, I am sure these lines will begin to coalesce into a poem, not just the insipid ravings of a tortured soul."
Julian collapses back onto the floor in a woeful heap. You take the opportunity to peek at his work. As he'd said, it's mostly just a page of phrases and scattered words, but every one seems to tie back to his experience at the artists' retreat you discussed earlier, particularly the forest.
*["Tell me more about that retreat in Maine. What was a normal day like?"]
-"It was heavenly." He pops up, woe forgotten, and starts pacing the room as he reminisces. "Our days were spent in total immersion with the written word. We studied the works of legends, analyzed their creations for form and style. We spent hours dissecting our own drafts. We would debate the value of a comma, or whether a semicolon might have the stronger impact. We argued over the value of adjectives, the most active verbs, the superfluity of adverbs. No aspect of the poetic craft was left untouched."
*["Sounds...intense."]
"It was! I have never had such a transformative and...yes, intense experience in all my days. Sharing that with others creates a powerful bond. I confess that spending time with my colleagues did occasionally draw me away from writing. They were delightful, and <>
*["Did you actually write there?"]
"But of course. The focus was naturally to progress with our own skills. Thus the appeal of the remote location. Our colleagues were the only distraction. Although, I confess, they were <>
-a potent distraction."
*["There's a fine line between distraction and inspiration for a great poet, isn't there?"]
"An accurate observation, wise muse." Julian sits down and you take the chair next to his. "I was equal parts distracted and inspired by my peers, by the mentors, by our host. I think even by the very place."
    **["Yes. You knew there was something about the place. It spoke to your soul, didn't it?"]
    ~julianColorStage = 2
    ~dossierChanged = 1
    He adopts a thoughtful expression and falls silent for a rare moment. "Yes. Yes. It was...it was the trees. Sitting under those trees, with all those layers of branches dappled by shadows and bark and dirt. It was like being enveloped in a cloud of olive green. I would know that hue anywhere. <>
    **[Say nothing]
    ~julianColorStage = 1
    ~dossierChanged = 1
    He takes a rare moment to reflect. "It was...it was the trees. Sitting under those trees, with all those layers of branches. There was something special about the greenness in that forest. <>

*["I'm not sure the people were the only distraction."]
"But whatever could you mean?"
    **["I saw your drafts. You wrote about the forest quite a lot."]
    Julian blanches. His knees wobble and he sits down hard in his chair. "You...oh dear...you read them? They're just the barest, rawest roots of anything! They're just nonsense!"
        ***["Silence, mortal! I am aware of the stages of creative process!"]
        He keeps shaking with the force of your muse voice, but he stops babbling. "Of course. Of course you are. I didn't mean to question your wisdom."
    **[Say nothing]
    --His eyes dart over to the page where he'd been writing. 
    "Perhaps...perhaps I was drawn to the trees, yes."
    **[Say nothing]
    ~julianColorStage = 1
    ~dossierChanged = 1
    He takes a rare moment to reflect. "It was...it was the trees. Sitting under those trees, with all those layers of branches. There was something special about the greenness in that forest. <>
-I think I fell in love with the green there."
*["I can sense that. There's love in every word you've written.]
-"But...but is it all a lie? I went to Maine to reach ever-more dizzying heights of artistic prowess. But in the forest I felt...small. Like all the grandiloquent words didn't matter in the scheme of the cosmos. And it made me wonder...what was my poetry worth? I had the soaring, melodramatic verse, yes. But who would care other than the people I was writing alongside? Others who would analyze, examine, dissect, critique. What about people who would just...feel?"
Julian's voice trails away. You have your information, best to leave him be for awhile.
*["Reflect on that for awhile. I'll give you some privacy."]
-His anxious face returns. "You...you're going? But I have huge, overwhelming questions of artistic integrity to be answered! I need your help!"
*["I'll be back soon. Don't worry, you'll think of something. And I will help you."]
~dossierChanged = 0
~julianConversationLevel++
~storyEnd = 1

    -> END
