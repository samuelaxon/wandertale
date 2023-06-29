// VARIABLES

VAR alibi = "Edith Clark"
VAR victim = "Michel Clarque"
VAR storyEnd = 0
VAR gameEnd = 0

-> intro

===intro===

*Who were you with?
{
    -alibi == "Edith Clark":
    I was with {alibi} in the living room.
    
    -alibi == "Amelia Clark":
    I was with {alibi} in the kitchen.
}
*Tell me about the victim.
{
    -victim == "Michel Clarque":
    He was a total hack.
    
    -victim == "Mathilda Mason":
    She was the mean housekeeper.
}

-You end the investigation.

-> end_story

===end_story===
~storyEnd = 1 
-> END