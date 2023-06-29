VAR playerDangerStage = ""

VAR murderer = ""
VAR murdererGender = 0
VAR victim = ""
VAR victimGender = 0

VAR hidingSpot = ""
VAR murderWeapon = ""
VAR weaponType = 0

VAR directorAlibi = ""
VAR editorAlibi = ""
VAR processorAlibi = ""
VAR housekeeperAlibi = ""
VAR cookAlibi = ""
VAR screenwriterAlibi = ""
VAR actressAlibi = ""
VAR actorAlibi = ""

VAR playerFoundKey = 0
VAR playerFoundWeapon = 0
VAR playerFoundBody = 0
VAR playerVisitedDistillery = 0
VAR playerKnowsName = 0

VAR accuseMurdererSuccess = 0

VAR storyEnd = 0
VAR gameEnd = 0

-> start

=== start ===

He is a broad man in a brown suit. You can tell the fellow thinks highly of himself, even though his face shows distress. All his accessorizing is ostentatious, a bright red tie, diamond tie pin, and a heavy gold watch. The director holds out a hand as you approach.
"Detective, thank you for coming. Merci."
He has a thick, exaggerated French accent.

*["Who are you?"]
-"My name is Michel Clarque. This is my house. I can't believe such a tragedy could happen under my own roof.{victim == "Lulu": To my own muse.}{victim == "Lev": To my own protégé.}"
	
*["Tell me more about yourself."]
-"I direct motion pictures. One of ze leading artists of ze medium. A forethinker in film, some have said. Surely you've seen my debut release, <i>The Careless Few</i>? It has been called a revelation, a masterpiece, and a treasure. My new project is <i>Temptation Lane</i>. All of my guests today are involved in its production somehow."

*["Where were you at the time of the incident?"]
-"I was with {directorAlibi}."

-> questions

=== questions ===

*["What were you two doing?"]
{
-directorAlibi == "Amelia":
"My little sister developed ze film for my first major picture. I was explaining to her zat, with my new reputation, I should hire a studio of professionals for <i>Temptation Lane.</i> She had quite a fit over it." 
He shakes his head. 
"She just doesn't understand ze industry, I'm afraid."
-> questions

-directorAlibi == "Carlos":
Michel waves a dismissive hand. 
"Oh, he was asking me about ze grocery bills. Like I have time to worry about such banal things as money."
-> questions

-directorAlibi == "Edith":
"My older sister edited my first major picture. I was explaining to her zat, with my new reputation, I want to hire a real professional for <i>Temptation Lane</i>. One of ze studios. But Edith has always been jealous of my talent, and tries to claim credit for my creative vision. Kept telling me I would fail without her." 
He shakes his head. 
"A desperate ploy from a desperate woman. But I cannot stifle my voice, even for family."
-> questions

-directorAlibi == "Lev":
"He is such a bright young fellow. You know, ze first time I read one of his poems, I had zat moment. Ze lightning bolt of a genius idea! I knew his words had to be in my new picture. I am doing my best to show him ze world of film and feed his creative mind. Lev will go far if he listens to me."
    **["What were you two actually doing, Mister Clarque?"]
    "Ah. Yes. We had a script meeting today. He has never written a screenplay before, so I will need to give him much guidance. Ze test shoots are promising, but miss zat...je ne sais quoi. Which I will provide."
    -> questions

-directorAlibi == "Lulu":
"Ah. Yes." 
An indulgent grin creeps across his face. 
"We were discussing one of ze more delicate scenes in ze story. I wanted to see if an ingenue like Lulu would be able to portray ze heroine's sensual desires convincingly after her tragic fall. Lulu was delighted to run ze scene with me. We were quite enraptured in ze moment."
-> questions

-directorAlibi == "Mathilda":
"<i>We</i> were not doing anything. I was working on storyboards. Mathilda was in ze same room, cleaning. She is our housekeeper."
-> questions

-directorAlibi == "Rick":
"I was coaching him on ze role. As director, I am ze puppet master, pulling ze strings on my cast and crew alike. Rick knows his craft, of course, but even a star like him can benefit from my guidance."
-> questions
}

*["What can you tell me about the victim?"]
{
-victim == "Amelia":
"My younger sister. She was an odd one. Always reading. Never could understand her fascination with science. Where is ze greater artistic truth in a bunch of chemicals and equations?" 
He pauses. 
"But I am sorry about whatever horrid accident has befallen her. I wish she were not dead."
-> questions

-victim == "Carlos":
"He was our cook. Rick Santiago recommended him to me. Carlos was good at his job, but he and I did not have a personal relationship. I was his employer, after all, not his friend."
-> questions

-victim == "Edith":
"My older sister. Always jealous of me. I do not know why she could not be happy with her lot in life and support my dreams." 
Michel pauses. 
"I suppose I am sorry about whatever horrid accident has befallen her. But I will not miss her harridan behavior."
-> questions

-victim == "Lev":
He sighs and gazes out the window. 
"I saw ze spark of genius in his poetry. Ze grandeur of language, ze depth of emotion. It reminded me of my own work. I brought him to Hollywood to be my protégé. A shame he did not live to achieve greatness. Though perhaps there is a poetic justice at work here, his life coming to ze same tragic end as so many of his subjects..." 
Michel trails off, then shakes his head. 
"Apologies, my ramblings cannot be much help with your case. Artistes' minds wander that way sometimes."
-> questions

-victim == "Lulu":
"Ahh, Lulu. She was luminous. Ze loveliest woman I had ever seen. I knew she would inspire me to new heights with <i>Temptation Lane</i>." Michel leans in with a self-satisfied smile and whispers, "I think she was rather enamored of me, detective. Happens frequently to us famous artistes." 
When he pulls back, he looks genuinely sad. 
"I cannot imagine who would harm such a beautiful young talent."
-> questions

-victim == "Mathilda":
"She was ze housekeeper here. When I purchased ze mansion, I decided to continue her contract. She already knew all there was to know about ze property. She was just as a housekeeper should be: efficient and proud of her work."
-> questions

-victim == "Rick":
"He was ze lead in <i>The Careless Few</i>. I did everything I could to land him. Rick Santiago makes everything a smash. And after our first picture was a hit, he knew he would be a fool not to collaborate again." 
Michel sighs. 
"There is no way <i>Temptation Lane</i> will be anywhere near as good without him. Re-casting will be a horror."
-> questions
}

*{playerVisitedDistillery == 1}["What do you know about the distillery downstairs?"]
"I beg your pardon? Ze only rooms downstairs are ze ones my sisters use for their work on my pictures. There is no distillery."
	**["I saw it. Definitely a distillery."]
	His face screws up in anger.
	"I...I will not stand for this outrage! I am a respected Hollywood director and a law-abiding citizen. I would never flout ze law. I want a severe punishment for whoever has done such a debauched thing in my home!"
    	***["One case at a time, sir."]
    	Michel fumes. 
    	"I will get to ze bottom of it if you don't, detective."
    	-> questions

*{playerDangerStage == "high"}["Have you seen anything strange around the house?"]
"Ah, ze building is very old, detective. I want to add more contemporary touches now that ze theater is complete. Although Mathilda will not be pleased. She is quite protective of ze house.{victim == "Mathilda": I suppose I need not fear her derision now.}"
-> questions

*{playerDangerStage == "critical"}["What the hell is going on with this house?"]
"I beg your pardon, detective? I do not understand. It is simply an old house, passé but full of character."
You want to argue that nothing you've been seeing is character, but it would be a fool's argument. The house's owner has no idea about the horrors lurking in these walls. You press on, rattled but determined.
-> questions

*["Tell me again who your alibi was."]
"I was with {directorAlibi}."
-> questions

*["No further questions, Mister Clarque."]
~storyEnd = 1
-> END