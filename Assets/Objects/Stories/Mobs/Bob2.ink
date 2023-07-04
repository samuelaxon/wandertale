VAR storyEnd = 0
VAR gameEnd = 0

VAR objectToAdd = ""
VAR tookItem = 0

VAR bobConversationLevel = 0

-> part_one

=== part_one ===
Bob is now just straight up pretending you're not there.

*["Fine then."]
    -> exit

=== exit ===
~storyEnd = 1
-> END