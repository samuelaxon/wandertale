VAR storyEnd = 0
VAR gameEnd = 0

VAR objectToAdd = ""
VAR tookItem = 0

VAR bobConversationLevel = 0

-> part_one

=== part_one ===
A rusty sword sits on the floor, its sharpest days behind it.

*[Take the sword.]
    ~objectToAdd = "sword"
    ~tookItem = 1
    ~storyEnd = 1
    -> END
*[Leave it.]
    ~storyEnd = 1
    -> END