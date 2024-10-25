// Should open all dialogues with a greetings.  Roberto is a litle too talkative and gives up. A lot of info right away. He should have the most amount of dialogue.
VAR hasPinkSlip = 0


Hello. I am Detective Felix, and I wanted to ask you a few questions about the murder. #speaker:Detective Felix #text_color:white
Sure. I'd be glad to help out in anyway. You can ask me anything. #speaker:none #text_color:green
For as shocking this whole sitaution is, I'm rather clear in the mind.
I can't say the same for a lot of the other folk here, as I'm sure you've either already seen or will see. 
Other than that, I'm as open as a book. 
Perfect. #speaker:Detective Felix #text_color:white
I'll start by first getting your name.
Roberto.  #speaker:Roberto #text_color:green
Roberto... got it. #speaker:Detective Felix #text_color:white
-> MainChoices

=== MainChoices ===
Can you tell me about... #speaker:Detective Felix #text_color:white
    + [7:00 am]
        Your whereabouts at 7:00 am. #speaker:Detective Felix #text_color:white
    -> 7AM
    
+ [Warehouse]
    I wanted to ask you a few things about the warehouse. #speaker:Detective Felix #text_color:white
    -> Warehouse

    
+ [Mr. Cruz]
    -> MrCruz

+ [Leave]
    -> Leave



=== 7AM ===
    At 7:00 am...? #speaker:Roberto #text_color:green
    At that time I would've been inside of the offices finishing up with my morning routine. 
    My shift starts at 6:30, and the first hour of work is spent logging into the computer here.
    The computers here are all piece of junk, I'll tell ya.
    Takes almost 10 minutes just to boot up. 
    Once it's up and going, I check and respond to any emails, and take a look at the day's objectives. 
    // If I use rich text, use "7:12 AM" as italiczed
    By the time I get done with that, I do my morning walk around the warehouse. Today I happeend to be done at 7:12 am.
    That's when I saw the crowd of people gathering around Door 102, and knew something horrible had just happened. 
    The rest, well, I suppose that's why you're here. 
    If it's any help at all, I can tell you with certainty that only a few people would've been near Door 102 so early in the morning. 
    That door is usually reserved for afternoon loads, and that leaves only maintenance people and possibly a few lazy-workers wandering near it. 
    If I were you, I'd probably want to ask around for anyone who fits the bill.
    Sure. I'll keep that in mind. #speaker:Detective Felix text_color:white
    -> MainChoices
    
    
=== Warehouse ===
     Sure. What would you like to know? #speaker:Roberto #text_color:green
     -> WarehouseChoices
     

=== WarehouseChoices ===
About the warehouse... #speaker:Detective Felix text_color:white
    +[Yourself]
    What do you do here at the warehouse? #speaker:Detective Felix text_color:white
    -> WarehouseYourself
    
    +[People]
    What type of people work here? #speaker:Detective Felix text_color:white
    -> WarehousePeople
    
    +[History]
     Tell me a little bit about the history of this place. #speaker:Detective Felix text_color:white
    -> WarehouseHistory
+ [Back]
That's all I have to ask about the warehouse.  #speaker:Detective Felix text_color:white
    -> MainChoices 
    
    

=== WarehouseYourself === 
I'm one of the three managers here. #speaker:Roberto #text_color:green
The work isn't great, but it's not too bad either.
Being here is certainly a saving grace compared to the alternatives. 
Not many jobs here on this small island of ours, right Detective?
Sure. A lot of people would say the same thing. #speaker:Detective Felix text_color:white
Do you commute far to get here? Ever come in late to work?
Not too far. I live out in Barrigada. #speaker:Roberto #text_color:green
That's why I'm never late... except for when there's a ton of overgrowth on my driveway.
I live by myself out there in a small hut. It was my uncle's house before, and the damn bastard never mentioned how the "driveway" gets overgrown weekly.
Fortunately, I do have a machete to cut it down whenever it gets too much.
I'm surprised it's never dulled.
I'm starting to think sumasaga si mañaina-ku in there! 
Sorry, I got a little off track.
No, I don't have a far commute. The only time I ever come in late is if I'd forgotten to clear the driveway.
-> WarehouseChoices


=== WarehousePeople === 
You get a lot of different kinds of people that work here, Detective. I'm sure you've already met some of them. #speaker:Roberto #text_color:green
Most people are just here for the paycheck.
// RICH TEXT!! NEED RICH TEXT!!
Some people, though, are total kådukus. Have you met Mariano? If you haven't then, you'll know exactly what I mean...
Other than that, I can't think any single person who'd be bloodthirsty or crazy enough to want to commit murder. 
Most people here, like I said, are just working for pay.
-> WarehouseChoices

=== WarehouseHistory === 
Well, I'm not really an historian, but the building started construction about five years ago. #speaker:Roberto #text_color:green
Mr. Cruz bought up some land from the Cepeda and Rosario families. 
They'd always been wanting to leave and go to America, so I guess that's why everything managed to go through. 
Three years ago, the warehouse fully opened, and I got my start on the very first day.
I was just an associate, but made my way up, and now I'm one of the three managers here.
Hopefully that was helpful. Don't see how that's important to Mr. Cruz's murder, Detective.
If that's not too offensive to say.
Just want to make sure I get the full picture #speaker:Detective Felix text_color:white
-> WarehouseChoices


    
=== MrCruz ===
    I wanted to ask you a few questions regarding Mr. Cruz, if that's alright with you. #speaker:Detective Felix #text_color:white
    Fine by me. #speaker:Roberto #text_color:green
    -> CruzChoices
    
    

=== CruzChoices ===
Could you tell me about... #speaker:Detective Felix #text_color:white

    * {!hasPinkSlip} [Your relationship]
    Tell me more about you and Mr. Cruz's relationship to each other. #speaker:Detective Felix #text_color:white
    -> CruzRelationshipNOSLIP

    + {hasPinkSlip} [Your relationship]
        Tell me more about you and Mr. Cruz's relationship to each other. #speaker:Detective Felix #text_color:white
    -> CruzRelationshipYESSLIP
    + [Mr. Cruz]
    Tell me a little bit about Mr. Cruz himself. #speaker:Detective Felix #text_color:white
    -> CruzHimself  
    + [Motivations]
    Would you know if there could be any motivations behind Mr. Cruz's murder. #speaker:Detective Felix #text_color:white
    Perhaps he upset the wrong people, or maybe the wrong kind of people work here.
    -> Motivations
    + [Back]
    That's all I have to ask about Mr. Cruz.  #speaker:Detective Felix text_color:white
    -> MainChoices 



// Dialogue if no item yet
// This uses Exteranl Function to SetCanGiveItem
=== CruzRelationshipNOSLIP ===
Me and Mr Cruz? #speaker:Roberto #text_color:green
Well... if I'm going to be honest with you, Detective, then I'll admit that he and I haven't been on best terms lately.
It's a multitude of factors. Too much, really, to count.
I'm here all day, Roberto. #speaker:Detective Felix text_color:white
Then I suppose I'll tell you about the most relevant things. #speaker:Roberto #text_color:green
If others haven't already told you, Mr. Cruz has been known to be very snippy with his fingers. 
Or to be more blunt: he steals. All the time.
I don't know if it's some kind of a mental condition, but he just couldn't help but snatch people's belongings out from under them.
Nobody was safe from it. 
Nobody would say anything either since he owns the whole building. 
He did, however, seem to stay away from the people closest to him. Myself included.
But that recently changed.
The heat wave that struck us a couple weeks back put us all over the edge, especially Mr. Cruz. 
The man went psycho!
Everyone here, including me, needed to take breaks, get water, stay hydrated. But Mr. Cruz didn't like that.
He thought I was being lazy, and scolded me in front of everyone. Like a child! 
I'm not one to want to lose this job, like I already said, there aren't any better options.
I kept my mouth shut and just listened to his barks.
Everything seemed to be going fine until, a couple days ago, I came into the office and saw a pink slip on my desk.
He stopped talking to me completely, too.
Do you still have the pink slip? #speaker:Detective Felix text_color:white
Yes, I keep it on me. Why? #speaker:Roberto #text_color:green
I may need to hold on to it for the investigation. #speaker:Detective Felix text_color:white
Really? Is that really necessary? #speaker:Roberto #text_color:green
I didn't do anything wrong, did I?
No. You didn't do anything wrong, Roberto.#speaker:Detective Felix text_color:white
This is just for my own investigation, like I said.
If you insist... #speaker:Roberto #text_color:green

I have a new item in my inventory. #speaker:Detective Felix text_color:white
~ hasPinkSlip = true
-> CruzChoices


// Dialogue if item already given
=== CruzRelationshipYESSLIP ===
Like I already said, me and Mr. Cruz weren't exactly on best terms recently. #speaker:Roberto #text_color:green
-> CruzChoices

=== CruzHimself ===
He crushed just too much pussy, man. #speaker:Roberto #text_color:green
Just too much. Who wouldn't hate him?
-> CruzChoices

=== Motivations ===
Apparently he had the biggest dick in the whole warehouse. #speaker:Roberto #text_color:green
That might've been a reason... but who knows!?
-> CruzChoices


=== Leave ===
    That's all I have for now. #speaker:Detective Felix #text_color:white
    -> END
    
    
    
    
