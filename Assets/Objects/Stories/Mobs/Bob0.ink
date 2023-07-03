VAR storyEnd = 0
VAR gameEnd = 0

VAR objectToAdd = ""
VAR tookItem = 0

VAR bobConversationLevel = 0

-> part_one

=== part_one ===
Bob is just this guy, you know?

"Uh, hi, I guess," he mumbles.

*["Hello."]
    -> part_two
*["Goodbye."]
    -> exit

=== part_two ===
"Nice talking to you, stranger," he abruptly replies.

You suppose that's that, then.
*["Goodbye."]
    -> exit

=== exit ===
~bobConversationLevel++
~storyEnd = 1
-> END