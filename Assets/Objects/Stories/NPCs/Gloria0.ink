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

Gloria is a middle-aged Black woman pacing by the desk. When she notices you, her worried expression melts into relief.

"Erato! What a pleasure to meet you at last! I need your help. It's an emergency."

*["What's your writing emergency?"]
~gloriaProjectKnown = 1
*[Say nothing]
You expect her to continue, but instead she gives you an irritated look. "I thought I was paying for your insight." Apparently she dislikes lulls in conversation.
    **["Then you'll get insight. Tell me what's wrong."]
    ~gloriaProjectKnown = 1
-"I'm working on a romance novel and it's not going well."
*["Ooh, I love romance novels!"]
    She beams. "I knew you would! I mean, you're the muse of lyric and love poetry! How could you not? Have you read any of my series, Seduction and the Shifters?"
    **["Sorry, I haven't heard of it. Too many books, not enough time."]
    She nods. "I would've been shocked if you had. You're a busy goddess after all." It seems she appreciates honesty from you. <>
    **[(Lie) "Oh, totally! Seductive and shifty all the way! You're a genius!"]
    Gloria blushes a brilliant pink. "Wow. I'm flattered. Unless...are you lying to make me feel better?" Her face falls. "You are. Please don't. I'd rather you just help me get unblocked." <>
*["Ugh, romance novels?"]
    She frowns. 
    "I may not be a goddess, but I am a best-selling author published in twenty-nine countries and translated into seven languages. You might be all-powerful, but your opinions on literature are not widely shared. Maybe coming here was a mistake."
    **[(Lie) "I mean, I totally love romance novels! Just tell me the issue."]
    Gloria's frown deepens. "I don't need your coddling. I just need your help." <>
    **["I can inspire a six-year old to write a book report. I don't have to love the medium to do my job to perfection."]
    Gloria fixes you with an intense stare, but after a moment of scrutiny, she nods. It seems she appreciates honesty from you. <>
-She heaves a sigh.
"Right now, I just feel like I'm out of ideas. I wrote all five books in the Seduction and the Shifters series and never struggled to connect with the characters. They just popped into my head and flowed out onto the page. Easy peasy. I knew their desires, their challenges, all the stuff my peers would spend months plotting out was so obvious right away. It clicked."
*["Has anything changed since you wrote the Shifters series?"]
-"Yes. I moved across the country."
-> part_two

=== part_two ===

*["Where do you live now?"]
"Pittsburgh." She wrinkles her nose. "It wasn't my choice."
    **["You're clearly thrilled."]
    "Not in the slightest. But my husband got a job, and I can write anywhere. It was the right thing to do." She sighs again. "It's not that bad. I guess. I'm sure I'll learn to live with it. Eventually. It's just really different and change that big is hard."
    -> part_two
*["Where did you live back then?"]
"San Diego, born and raised. It's a wonderful place. Not a perfect place, has plenty of flaws like anywhere else. But it was home."
    **["What do you miss most?"]
    ~gloriaColorStage = 2
    ~dossierChanged = 1
    "The ocean. No question. Being surrounded by all that blue was incredible. There's nothing like a perfect azure sky over the Pacific. It's such a unique color. I really miss that." Gloria looks forlorn. "Pittsburgh is just so damn gray."
    -> part_two
    **["That sounds like a really hard change."]
    ~gloriaColorStage = 1
    ~dossierChanged = 1
    "Well, yeah. Moving is always hard. That's why people hate it. Plus Pittsburgh is usually gray, but San Diego was all about blue. The ocean, the sky, I really miss the blue. It was so beautiful."
    -> part_two
*-> part_three

=== part_three ===
*["Any other changes?"]
-Gloria shakes her head. "Just that writing has been way harder than it ever was before. So, what do you think, Erato? Can you fix me before my deadline?"
*["Of course. That's why I'm here."]
-"Great. Thanks." She gives you a smile. "I really hope so. I've been staring at my laptop screen for days and nothing I type has been worth keeping."
*["Try writing something now."]
-"Seriously? I've already got some inspiration in me?"
*["Yes. I'm just that good. I'll check back later."]
"Huh. I don't feel inspired." Gloria gives you a skeptical look. "But you're the muse here, not me. I'll try."
*["No. But I have to check on other clients."]
"Oh. Sure, I guess that makes sense. I'll try to start working."
-*["Don't worry, you'll think of something."]
~dossierChanged = 0
~gloriaConversationLevel++
~storyEnd = 1

-> END
