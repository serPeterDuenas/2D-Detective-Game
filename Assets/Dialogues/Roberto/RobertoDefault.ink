// Should open all dialogues with a greetings.  Roberto is a litle too talkative and gives up. A lot of info right away. He should have the most amount of dialogue.
VAR hasPinkSlip = 0


Hello. I am Detective Felix, and I wanted to ask you a few questions about the murder. #speaker:Detective Felix #text_color:white #audio:default
Sure. I'd be glad to help out in anyway. You can ask me anything. #speaker:none #text_color:green #audio:roberto
I'm as open as a book. 
Perfect. #speaker:Detective Felix #text_color:white #audio:default
I'll start by first getting your name.
Roberto.  #speaker:Roberto #text_color:green #audio:roberto #audio:roberto
Roberto... got it. #speaker:Detective Felix #text_color:white #audio:default
-> MainChoices

=== MainChoices ===
Can you tell me about... #speaker:Detective Felix #text_color:white #audio:default
    + [7:00 am]
        Your whereabouts at 7:00 am. #speaker:Detective Felix #text_color:white #audio:default
    -> 7AM
    
+ [Warehouse]
    I wanted to ask you a few things about the warehouse. #speaker:Detective Felix #text_color:white #audio:default
    -> Warehouse

    
+ [Mr. Cruz]
    I wanted to ask you a few questions regarding Mr. Cruz, if that's alright with you. #speaker:Detective Felix #text_color:white #audio:default
    Fine by me. #speaker:Roberto #text_color:green #audio:roberto
    -> CruzChoices

+ [Leave]
    That's all I have for now. #speaker:Detective Felix #text_color:white #audio:default
    -> END



=== 7AM ===
    At 7:00 am...? #speaker:Roberto #text_color:green #audio:roberto
    At that time I would've been inside of the offices finishing up with my morning routine. 
    My shift starts at 6:30, and the first hour of work is spent logging into my computer.
    All these computers here, they're all just a pile of junk.
    Takes almost 10 minutes just for it to boot up, but once it's up and going, I check and respond to any emails, look over the day's objectives...
    Boring office stuff, Detective.
    // If I use rich text, use "7:12 AM" as italiczed
    By the time I get done with that, I do my morning walk around the warehouse. Today I happeend to be done at 7:12 am.
    That's when I saw the crowd of people gathering around Door 102, and knew something horrible had just happened. 
    The rest, well, I suppose that's why you're here. 
    If it's any help at all, I can tell you with certainty that only a few people would've been near Door 102 so early in the morning. 
    That door is usually reserved for afternoon loads, and that leaves only maintenance people and possibly a few lazy-workers wandering near it. 
    If I were you, I'd probably want to ask around for anyone who fits the bill.
    
    Sure. I'll keep that in mind. #speaker:Detective Felix #text_color:white #audio:default
    -> MainChoices
    
    
=== Warehouse ===
     Sure. What would you like to know? #speaker:Roberto #text_color:green #audio:roberto
     -> WarehouseChoices
     

=== WarehouseChoices ===
About the warehouse... #speaker:Detective Felix #text_color:white #audio:default
    +[Yourself]
    What do you do here at the warehouse? #speaker:Detective Felix #text_color:white #audio:default
    -> WarehouseYourself
    
    +[People]
    What type of people work here? #speaker:Detective Felix #text_color:white #audio:default
    -> WarehousePeople
    
    +[History]
     Tell me a little bit about the history of this place. #speaker:Detective Felix #text_color:white #audio:default
    -> WarehouseHistory
+ [Back]
That's all I have to ask about the warehouse.  #speaker:Detective Felix #text_color:white #audio:default
    -> MainChoices 
    
    

=== WarehouseYourself === 
I'm one of the managers here. #speaker:Roberto #text_color:green #audio:roberto
The work isn't great, but it's not too bad either.
Being here is certainly a saving grace compared to the alternatives. 
Not many jobs here on this small island of ours, right Detective?
Sure. A lot of people would say the same thing. #speaker:Detective Felix #text_color:white #audio:default
Do you commute far to get here? Ever come in late to work?
Not too far. I live out in Barrigada. #speaker:Roberto #text_color:green #audio:roberto
That's why I'm never late... except for when there's a ton of overgrowth on my driveway.
I live by myself out there in a small hut. It was my uncle's house before, and the damn bastard never mentioned how the "driveway" gets overgrown weekly.
Fortunately, I do have a machete to cut it down whenever it gets too much.
I'm surprised it's never dulled.
I'm starting to think sumasaga si mañaina-ku in there! 
Sorry, I got a little off track.
No, I don't have a far commute. The only time I ever come in late is if I'd forgotten to clear the driveway.
-> WarehouseChoices


=== WarehousePeople === 
You get a lot of different kinds of people that work here, Detective. I'm sure you've already met some of them. #speaker:Roberto #text_color:green #audio:roberto
Most people are just here for the paycheck.
// RICH TEXT!! NEED RICH TEXT!!
Some people, though, are total kådukus. Have you met Mariano? If you haven't then, you'll know exactly what I mean...
Other than that, I can't think any single person who'd be bloodthirsty or crazy enough to want to commit murder. 
Most people here, like I said, are just working for pay.
-> WarehouseChoices

=== WarehouseHistory === 
Well, the building started construction about five years ago. #speaker:Roberto #text_color:green #audio:roberto
Mr. Cruz bought up some land from the Cepeda and Rosario families. 
They'd always been wanting to leave and go to America, so I guess that's why everything managed to go through. 
Three years ago, the warehouse fully opened, and I got my start on the very first day.
I was just an associate, but made my way up, and now I'm one of the three managers here.
Hopefully that was helpful. Don't see how that's important to Mr. Cruz's murder, Detective.
If that's not too offensive to say.
Just want to make sure I get the full picture #speaker:Detective Felix #text_color:white #audio:default
-> WarehouseChoices

    
    

=== CruzChoices ===
Could you tell me about... #speaker:Detective Felix #text_color:white #audio:default

    * {!hasPinkSlip} [Your relationship]
    Tell me more about your relationship to Mr. Cruz. #speaker:Detective Felix #text_color:white #audio:default
    -> CruzRelationshipNOSLIP

    + {hasPinkSlip} [Your relationship]
        Tell me more about your relationship to Mr. Cruz. #speaker:Detective Felix #text_color:white #audio:default
    -> CruzRelationshipYESSLIP
    + [More on Mr. Cruz]
    What can you tell me about Mr. Cruz himself? #speaker:Detective Felix #text_color:white #audio:default
    -> CruzHimself  
    + [Motivations]
    Any possible any motivations behind Mr. Cruz's murder? #speaker:Detective Felix #text_color:white #audio:default
    -> Motivations
    + [Back]
    That's all I have to ask about Mr. Cruz.  #speaker:Detective Felix #text_color:white #audio:default
    -> MainChoices 



// Dialogue if no item yet
=== CruzRelationshipNOSLIP ===
Me and Mr Cruz? #speaker:Roberto #text_color:green #audio:roberto
Well... if I'm going to be honest with you, Detective, I'll admit that he and I haven't been on best terms lately.
It's a multitude of factors. Too much to count.
I'm here all day. #speaker:Detective Felix #text_color:white #audio:default
In that case... #speaker:Roberto #text_color:green #audio:roberto
If others haven't already told you, Mr. Cruz has been known to be very snippy with his fingers. 
He steals. All the time.
I don't know if it's some kind of a mental condition, but he just couldn't help but snatch people's belongings out from under them.
Nobody was safe from it. 
Nobody would say anything either since he owns the whole building. 
He did seem to restrain himself when it came to people closest to him.
But that all changed recently.
The heat wave from a couple weeks ago was especially tough here in the building since the AC barely works at all. 
I think the heat must've flipped a switch him.
The man completely lost his mind!
Everyone here needed to take plenty of breaks, get water, stay hydrated. But Mr. Cruz didn't like that.
When he saw me take a breather and sip some water, he scolded me like a child! 
I would've yelled back at him, but like I already said, there aren't any better jobs on this island. 
Things stayed tense around him, we stopped talking entirely. 
Then, three days ago, I came into the office and saw a pink slip on my desk.
Worst of all, I lost a special coin that's very, very dear to me. 
I have reason to think Mr. Cruz stole it from me, but I don't have any proof of that.
I see. #speaker:Detective Felix #text_color:white #audio:default
Let me ask you this...
-> CoinPinkSlip


=== CoinPinkSlip ===
    * [Coin]
   Tell me more about this coin of yours. #speaker:Detective Felix #text_color:white #audio:default
   It's a sentimental piece. #speaker:Roberto #text_color:green #audio:roberto
   It means a huge lot to me.
   My father casted it when I was a child. 
   He gathered all of the jewelry that had been passed down through the generations, and melted it down.
   He made a coin that has the imprint of the Seal of Guam, and said to me...
   "Este i espiritu gi todos familian-ta."
   "Siempre sustieni hao gi i korason-mu."
    -> CoinPinkSlip
    * [Pink Slip]
    Do you still have the pink slip? #speaker:Detective Felix #text_color:white #audio:default
    Yes, I keep it on me. Why? #speaker:Roberto #text_color:green #audio:roberto
    I may need to hold on to it for the investigation. #speaker:Detective Felix #text_color:white #audio:default
    Really? Is that really necessary? #speaker:Roberto #text_color:green #audio:roberto
    I didn't do anything wrong, did I?
    No. You didn't do anything wrong, Roberto.#speaker:Detective Felix #text_color:white #audio:default
    This is just for my own investigation, like I said.
    If you insist... #speaker:Roberto #text_color:green #action:giveItem #audio:roberto
 
    I have a new item in my inventory. #speaker:Detective Felix #text_color:white #audio:default
    ~ hasPinkSlip = true
    -> CoinPinkSlip
* -> CruzChoices



// Dialogue if item already given
=== CruzRelationshipYESSLIP ===
Like I already said, me and Mr. Cruz weren't exactly on best terms recently. #speaker:Roberto #text_color:green #audio:roberto
He's gone psycho just a couple weeks ago. 
We got into some heated talks, particularly him yelling at me. 
He wants to fire me, and I've got reason to suspect he stole my coin. 
I don't know what else you want me to say, Detective.
-> CruzChoices

=== CruzHimself ===
I'd honestly say that for 95% of the time, he's just an ordinary guy. #speaker:Roberto #text_color:green #audio:roberto
Nothing too stand-out about him. He's rich, that's for sure.
His family's an old mestizo clan.
His grandfather, Don Crisostomo Cruz, used to own half the ranches up in Yigo before he sold it over to the Americans. 
From what Mr. Cruz told me himself, his lineage, dating back to the 1700s, once possesed two of the richest haciendas on the island, too...
...but that was some time ago.
Other than being an old man and rich as fuck, he was just somebody obsessed with money. 
Which leads me to that other 5% of the time. 
He's a kleptomaniac, and I'm not the only one who'd say that openly. 
The man stole anything that looked even remotely valuable. 
He'd steal from people here at work, and if anyone spoke out against him, he'd just fire them on the spot. 
He was also a pervert.
I won't say too much about it, but there were definitely days where he'd lock himself in his office and close the blinds. 
What else needs to be said?
-> CruzChoices


=== Motivations ===
As you should already know by now, Mr. Cruz had the nasty habit of stealing from people. #speaker:Roberto #text_color:green #audio:roberto
Who knows, there's a good number of crazies that work here, Detective. He could've stolen from a person who got ticked the wrong way.
I'd honestly be on the lookout for anyone that shows even the slightest derangement.
-> CruzChoices


    
    
    
    
