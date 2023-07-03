VAR storyEnd = 0
VAR gameEnd = 0

VAR objectToAdd = ""
VAR tookItem = 0

VAR bobConversationLevel = 0

-> part_one

=== part_one ===
Bob looks at you blankly. "Didn't we do this already? Yeesh."

That's all you're going to get out of Bob, it seems.

*["Goodbye."]
    -> exit

=== exit ===
~bobConversationLevel++
~storyEnd = 1
-> END