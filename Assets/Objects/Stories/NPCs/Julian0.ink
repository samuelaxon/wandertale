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

Julian can't be that old, early thirties tops, but he gives the appearance of a world-weary soul. His skin is pale, pasty. When you appear, he flings one arm out and the other clutches at his chest.

"Erato, my goddess!," he cries. "At long last we meet! I throw myself upon your tender mercies!"

*["That's an enthusiastic greeting."]
"But of course, gracious one! How could I not be?" The guy falls to his knees. <> 
*[Say nothing.]
The young man slowly sinks to his knees. His joints creak as his kneecaps touch the ground. <>

-"I've desired your counsel for near-on ten years. When I heard you would be offering your services to poets in distress at Muse, Inc, I knew I had to be the first to bask in your greatness."
*["How about you tell me about yourself while you bask."]
~julianProjectKnown = 1
"As your muse-liness wishes." He clears his throat. <>
*[Say nothing]
~julianProjectKnown = 1
"I see the legends of your patient ear were not exaggerated." He finally offers an introduction. <>
-"I am Julian Fitzroy. One day, I shall be a poet laureate, a beloved literary figure of great renown!" He bows.
*["And what is keeping you from being a poet laureate?"]
-"Ah. Alas, the fiduciary demands of modern life have required me to ply my wordsmithing in a less, um, artistically gratifying fashion."
*["What a shame. It must feel like a waste of your talents."]
For the first time, his haggard look drops away. Flattery seems to resonate with him. "I knew you would understand! <>
*["You mean you have a day job? Lots of writers do."]
His long face somehow gets even longer. There's even a tear welling in his eye. Frank talk does not seem to be the way to connect with him. "But...but this job erodes my will. <>
-It sucks the very soul from my body!"
*["And what is this soul-sucking job?"]
-He moans. "I write the poems in greeting cards. The tritest, most saccharine treacle known to humanity. And with all my creative energy spent on generic rhyming sentiments, I have had no power to compose more meaningful verses. I need my muse to return. I need your guidance most desperately, Erato!"
*["What kind of poems do you want to be writing?"]
-Julian stares into the distance, a wistful look crossing his face. "Ones like I wrote at the Phosphoros and Hesperos Retreat."
*["How Hellenic."]
-"I thought you would approve. In my more fanciful moments, I believed your spirit was there among us. A group of promising young poets, including myself, were paired with accomplished writers who acted as our mentors. It was the greatest experience of my artistic life."
-> part_two

=== part_two ===

*["Who was your mentor?"]
"Carlotta Estanza. One of Italy's most lauded scribes. She said I had a luminous, soaring style."
    **[(Lie) "Wow, Carlotta Estanza! Impressive!"]
    Julian preens. "It was quite the feather in my cap, it's true. Under her guidance, I felt that anything was within my grasp. I could read even the most challenging of poets and find beauty in them. And my own writing all felt laden with promise. Even when in the tarnished early drafts, I could tell a glittering diamond would be revealed with enough time and polish."
    -> part_two
    **["I've never heard of her."]
    Julian blinks. "I'm surprised. You are the embodiment of lyric verse, and she's as lyric as they come, in English or Italian. She was an inspiration to me even before I met her."
    -> part_two
*["Where was the camp?"]
"At a private estate owned by Aris Petrakis. Heir to the Petrakis Olive Oil and Ouzo fortune. He's been a patron of the creative arts for decades, handpicking the best budding talents to nurture into full bloom. Not just writers, but all sorts of creative disciplines."
    **["Wow. You must be good to catch his eye."]
    ~julianMaterialStage = 2
    ~dossierChanged = 1
    "I like to think so. It was rarefied company. The energy among us was electric. We'd take our notebooks into a grove of red cedars and scribble away." His face lightens at the happy memory. "I remember feeling connected to those trees. Their bark, their scent. It felt so...potent."
    -> part_two
    **[Say nothing]
    ~julianMaterialStage = 1
    ~dossierChanged = 1
    Julian shakes his head, as if he's returning to reality from a dream. "Ah, my mind was wandering. Apologies, my goddess! Perils of our mortal minds. You asked about the location. Mister Petrakis' estate is on a few acres of heavily wooded land in Maine. I think the forest was part of what made the experience so valuable. I felt connected to the trees."
    -> part_two
*-> part_three

=== part_three ===
*["You should think about that camp while you write."]
-He looks slightly alarmed. "Write? Here? In your office? With your muse-ly eyes on me? I can barely compose anything but Valentine's day rhymes; how can I write a magnum opus with that pressure?"
*["My muse-ly eyes need to go check on another client."]
-"I see." Julian clasps his hands together and gives you a hopeful, wide-eyed look. You're reminded of a begging puppy dog. "But you will return? Favor me with more guidance? I don't know where to start."
*["Don't worry, you'll think of something."]
~dossierChanged = 0
~julianConversationLevel++
~storyEnd = 1
    -> END
