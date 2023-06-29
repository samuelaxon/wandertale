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

You've just bid farewell to your last client when Mnemosyne's voice drifts down to you.
"Erato! Would you come up to my office, dear?"
Figures the boss would want to chat about your debut efforts in the family business.
*[Go up to the CEO suite]
-Mnemosyne is already relaxing in one of the purple chairs. She motions for you to join her. 
"Congratulations on finishing your first day at Muse, Inc. How was it?"
*["It was good! I think I helped people."]
"Wonderful! I'm so delighted." <>
*[Say nothing]
"Not ready to share? Well, I hope you'll stay with us. I already have piles of requests for you." <>
-Mnemosyne gives you a sly smile. "I wouldn't normally do this, but I had a quick chat with the Fates this afternoon. I can tell you how your inspiration will unfold in the lives of each of your creatively challenged writers. <>
-> part_two

=== part_two ===

{Who would you like to hear about first?"|"Who would you like to hear about next?"|"Just one final client."|}

*["Gloria."]
-> gloria_endings
*["Julian."]
-> julian_endings
*["Li."]
-> li_endings
*-> final_ending

=== gloria_endings ===
{
    -gloriaInspirationLevel == 6:
    "Your romance novelist will see massive success with her next series. It's titled Beasts of Bluestone Beach. The reviewers will applaud her for the taut action scenes, as well as for her continued efforts to improve representation in fantasy romance. The series will grow to seven titles, all best-sellers, and she'll find many loyal new fans." Mnemosyne beams, thrilled. "It seems you have given Gloria exactly what she most needed. I'm so pleased."
    *["Me too. I'm glad she was able to trust in herself, to connect her past and her future."]
    -> part_two
    *[Say nothing]
    -> part_two
    
    -gloriaInspirationLevel == 5:
    "Your romance novelist's next series will be reasonably successful. The book will see some critical reviews for treatment of the action scenes, but she will continue to please her core audience and will see modest growth in her fan base. The series will run for four books." Mnemosyne smiles. "Pretty good. It seems like you've done nearly perfect for her."
    *["Good for her. I hope she's happy with the results and keeps trusting in herself."]
    -> part_two
    *[Say nothing]
    -> part_two
    
    -gloriaInspirationLevel == 3 or gloriaInspirationLevel == 4:
    "Your romance novelist's next series will have a rocky start. The book will take critique for lackluster action scenes and a loss of the focus that marked her previous work. But she will retain a core audience. The series will only be three books long." Mnemosyne smiles. "Not bad, not great. It seems like you've helped her reconnect with a little bit of her writing soul."
    *["I had hoped to do better. But I'm glad it wasn't a disaster."]
    -> part_two
    *[Say nothing]
    -> part_two
    
    -else:
    "It seems that things will not go well with her next series. Gloria will abandon her favorite tropes from fantasy and try to write a romantic suspense instead. Her loyal fans say the book is still written well enough, but lacks heart. She will only write the single title before taking a hiatus from writing." Mnemosyne frowns. "That's most upsetting."
    *["It is. I feel terrible for not helping her more."]
    -> part_two
    *[Say nothing]
    -> part_two
    
}

=== julian_endings ===
{
    -julianInspirationLevel == 6:
    "Oh my. Julian will recommit to rediscovering his own voice, pursuing classes and mentorship with writers across a broad array of styles. He will have five chapbooks of poems published with increasingly more prestigious presses. His style will be called 'genuine' and 'luminous with feeling as well as glittering language.' He shall remain with the greeting card company until he takes a teaching post at a small university while continuing to publish." Mnemosyne sighs happily. "It sounds like Julian's time with you was a complete success."
    *["Great! I wasn't sure about him at first, but I'm glad he found his authentic voice."]
    -> part_two
    *[Say nothing]
    -> part_two
    
    -julianInspirationLevel == 5:
    "Julian will find renewed pleasure in the verses he writes at the greeting card company. His superiors will notice the greater feeling and care he puts into his poetry, and he will receive more creative freedom. Eventually, Julian will oversee the launch of several card lines that offer more elegant, eloquent poetry expressing a wider range of nuanced sentiments. He will even win a minor competition with his own poetry." Mnemosyne smiles. "It seems he finds contentment as well as purpose."
    *["He needed purpose. And less melodrama. I'm glad it worked out for him."]
    -> part_two
    *[Say nothing]
    -> part_two
    
    -julianInspirationLevel == 4 or julianInspirationLevel == 3:
    "Julian will find clearer focus in the verses he writes at the greeting card company. His superiors will notice the greater feeling and care he puts into his poetry, and he will receive more creative freedom. However, he will no longer pursue his own poetry, keeping his writing only for the interior of cards." Mnemosyne gives a half smile. "I suppose some purpose is better than none."
    *["I agree. I wish it had been more."]
    -> part_two
    *[Say nothing]
    -> part_two
    
    -else:
    "Your poet will spend a few more days at the greeting card company, but then quit in a rage, spouting Shakespearean-caliber insults at all of his colleagues. Not only that, but he will write increasingly bombastic poems and become increasingly depressed by their rejection. Eventually he will stop writing entirely and take an office job where he never taps into his creative side." Mnemosyne glowers. "What a shame."
    *["I didn't mean for that to happen at all!"]
    -> part_two
    *[Say nothing]
    -> part_two
    
}

=== li_endings ===

{
    -liInspirationLevel == 6:
    "It will take Li a few weeks, but she will ask Nora out and is accepted. On their first date, Nora will confess that she has always thought Li was cute and was too nervous to offer the date invitation. They will remain girlfriends until they part amicably when they leave for college, and the positive first relationship will set both of them up for healthy love lives as adults. Li will pursue music performance and join the Vancouver Philharmonic." Mnemosyne claps her hands. "Oh, I love when a child achieves their dreams!"
    *["She was such a sweetheart. I'm proud of her, finding her confidence like that."]
    -> part_two
    *[Say nothing]
    -> part_two
    
    -liInspirationLevel == 5:
    "Li will ask Nora out in a text. Apparently Nora won't be clear that it is a date, so she will decline for a prior engagement. Li will be upset, but will tell Nora why she's unhappy a few weeks later. The misunderstanding will eventually be an inside joke for the couple as they date through high school. They will remain girlfriends until they part amicably when they leave for college, and the positive first relationship will set both of them up for healthy love lives as adults. Li will still enjoy playing music, but purely as a hobby." Mnemosyne grins. "Pretty good, Erato. Teenagers are tricky, and this seems promising."
    *["I'm just glad she got the girl in the end and found some confidence."]
    -> part_two
    *[Say nothing]
    -> part_two
    
    -liInspirationLevel == 4 or liInspirationLevel == 3:
    "Li will ask Nora out in a text. Apparently Nora won't be clear that it is a date, so she will decline for a prior engagement. Li will be upset, but won't tell Nora why she's upset. A few months later, Nora will be the one to ask Li out. Things will be awkward at first after the misunderstanding, but the girls will date for their final year of high school. Li will never tell Nora about her aspirations in music, and will eventually set her sights elsewhere." Mnemosyne gives you a small smile. "At least the written part worked out in the end. I suppose Euterpe should have been a co-consult."
    *["I'm glad she got the girl. I hope she finds more confidence as she grows up."]
    -> part_two
    *[Say nothing]
    -> part_two
    
    -else:
    "Oh dear. Apparently Li never quite musters the courage to ask out Nora. The girls stay friendly for the remainder of their time in high school, but the platonic relationship is painful for Li to bear. She loses interest in music too and opts not to continue performing until she joins a community orchestra later in life." Mnemosyne wipes away a tear. "What a shame. That poor girl."
    *["I'm heartbroken. I wanted her to thrive, not lose any shred of confidence."]
    -> part_two
    *[Say nothing]
    -> part_two
    
}
    
=== final_ending ===

"Well, that's the end of the workday." Mnemosyne reaches over and takes your hand. "Creativity is a never-ending exploration, a dynamic adventure for mortals and immortals alike. I hope you've found your own inspiration here at Muse, Inc, Erato." She drops a kiss on your cheek. "Good luck, my dear."

*[End]
~storyEnd = 1
~gameEnd = 1


    -> END
