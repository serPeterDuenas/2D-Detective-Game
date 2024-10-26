VAR hasGivenItem = false

Good morning, Ma'am. I am Detective Felix. I just have a few questions to ask you regarding Mr. Cruz's murder. #speaker:Detective Felix #text_color:white
How long is this going to take? #speaker:none #text_color:light blue
I was trying to leave, but your partner insisted I stay put until you came.
I understand your anxiety, Miss. #speaker:Detective Felix #text_color:white 
But it's important that we first get you to answer a few questions. 
Fine. Whatever. #speaker:none #text_color:light blue
Can you tell me your name? #speaker:Detective Felix #text_color:white
Bianca. #speaker:Bianca #text_color:light blue
Bianca... okay. Like I said, just a few questions. #speaker:Detective Felix #text_color:white
-> MainChoices

=== MainChoices ===
Can you tell me about... #speaker:Detective Felix #text_color:white
    + [7:00 am]
        Where exactly were you at 7:00 am? #speaker:Detective Felix #text_color:white
    -> 7AM
    
+ [Warehouse]
    I wanted to ask you a few things about the warehouse. #speaker:Detective Felix #text_color:white
    -> Warehouse

    
+ [Mr. Cruz]
    I have a few questions about Mr. Cruz. #speaker:Detective Felix #text_color:white
    -> CruzChoices

+ [Leave]
    That's all I have for now. #speaker:Detective Felix #text_color:white
    -> END

=== 7AM ===
Why is that important?  #speaker:Bianca #text_color:light blue
It's just a question. #speaker:Detective Felix #text_color:white
Any little bit of info goes a long way in helping me put together the whole incident.
// Rich text
Do you think I killed him?! #speaker:Bianca #text_color:light blue
I never said anything of the sort, Miss. #speaker:Detective Felix #text_color:white
Whatever. #speaker:Bianca #text_color:light blue
At 7:00... I must've been here in the breakroom. Mariano can attest to that, he was here too.
And if you're wondering, no I'm not with that clown. He likes to follow me around.
I don't mind, he entertains me. 
-> 7AMChoices

-> MainChoices

=== 7AMChoices ===
* [Mariano]
Can you tell me more about Mariano.#speaker:Detective Felix #text_color:white
What is there to know? #speaker:Bianca #text_color:light blue
He's a player, or at least he thinks he is. He wears all that jewelry and does his hair up every day. 
That's probably why you'll never see an ounce of sweat off his head. He never works.
All he does is just try to talk a igrl, or like with me, follow one around.
Would you agree he might be.. dangerous? #speaker:Detective Felix #text_color:white
Dangerous? No! Of course not. #speaker:Bianca #text_color:light blue
Look, Mariano's certainly a little pushy, especially if a girl doesn't bite back for him.
// Rich text
But he would't kill somebody, if that's what you're wondering.
And like I already said, we were both here at 7:00 am, there's no way we could've been near Door 102.
-> 7AMChoices
* [Breakroom]
Why were you here in the breakroom? #speaker:Detective Felix #text_color:white
Stealing time. #speaker:Bianca #text_color:light blue
What? You think I'm a hard worker here? Hell no!
Especially not after how Mr. Cruz treated us during the heat wave a couple weeks back. 
I learned my lesson. It's not worth working hard here. All you get is more hard work, and for nothing.
-> 7AMChoices
* -> 7AM

=== Warehouse ===
-> MainChoices

=== CruzChoices ===
-> MainChoices