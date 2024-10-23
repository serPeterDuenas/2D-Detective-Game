// Should open all dialogues with a greetings.  Roberto is a litle too talkative and gives up. A lot of info right away. He should have the most amount of dialogue.

Hello. I am Detective Felix, and I wanted to ask you a few questions about the murder. #speaker:Detective Felix #text_color:white

Sure. I'd be glad to help out in anyway. You can ask me anything. #speaker:none #text_color:green

I'm as open as a book. 


I'll start by getting your name. #speaker:Detective Felix #text_color:white

Roberto.  #speaker:Roberto #text_color:green

Roberto... got it. #speaker:Detective Felix #text_color:white


-> MainChoices

=== MainChoices ===
Just a few questions regarding yourself, your relationship to Mr. Cruz, and where you were at the time of the murder. #speaker:Detective Felix #text_color:white

* [7:00 am]
    From what my partner has told me, we believe that the incident occured at exactly 7:00 am. #speaker:Detective Felix #text_color:white
    Could you tell me your whereabouts during this time?
    -> 7AM
    
* [Warehouse]
    Can you tell me a little bit about what you do here at the warehouse?  #speaker:Detective Felix #text_color:white
    You could tell me approximately how long you've been working here, what position, and so on.
    -> Warehouse
    
    
* [Mr. Cruz]
    -> MrCruz

* [Leave]
    -> Leave



=== 7AM ===
    At 7:00 am... well at that time I would've been here at the office checking up at emails.  #speaker:Roberto #text_color:green
    My shift starts at 6:30, and I almost always spend the first hour logging in to these snail-pace computers we've got here in the building.
    About 5 minutes just to boot up. Then I read and respond to any emails, and send out any if I need.
    I think by the time I got through any morning chores, the time was already 7:10, and I just started to do my walk around the warehouse. 
    That's when I saw the crowd of people gathering around Door 102, and knew something horrible had just happened. 
    The rest, well, I suppose that's why you're here. 
    If it's any help at all, I can tell you with certainty that only a few people would've been near Door 102 so early in the morning. 
    That door is usually reserved for afternoon loads, and that leaves only maintenance people and possibly a few lazy-workers wandering near it. 
    If I were you, I'd probably want to ask around for anyone who fits the bill.
    -> MainChoices
    
    
=== Warehouse ===
     Well I've been working here since this building opened a few years ago. #speaker:Roberto #text_color:green
     I've gone up from just an associate into one of the three operation managers. 
     I won't lie to you, Detective, working here isn't exactly glamorous at all. 
     But at least this place pays well, and it's better than any other job that might exist on this little island of ours.
     Before working this job, I was doing construction back in my home village over in Barrigada. 
     Barrigada? #speaker:Detective Felix #text_color:white 
     You live in a nice house out there?
     Hell no I don't!  #speaker:Roberto #text_color:green
     I live by myself in a tiny hut. It was my uncle's house before he passed.
     The goddamn bastard never told me how much the jungle loves to regrow every other week.
     I spend a whole day having to cut down the brush that grows out on my driveway, if you could call it that. 
     Fortunately, my uncle did leave a machete behind. Somehow that thing has never gotten dull.
     I think sumasaga si mañaina-ku in there...
     It's the only explanation!
     Sorry, I got off track. 
     This warehouse if fine, but I don't prefer it, if you're wondering. 
     Still, since no other jobs even exist here, this is the best thing I got going for me.
     I see no reason why I'd ever want to leave, or make this place any worse than it is.
    -> MainChoices
    
=== MrCruz ===
    I wanted to ask you a few questions regarding Mr. Cruz, if that's alright with you. #speaker:Detective Felix #text_color:white
    Fine by me. #speaker:Roberto #text_color:green
    -> CruzChoices
    
    

=== Leave ===
    That's all I have for now. #speaker:Detective Felix #text_color:white
    -> END
    
    
    
    

=== CruzChoices ===
Could you tell me about... #speaker:Detective Felix #text_color:white
* [Your relationship]
    Could you tell me a little bit more about your own relationship to Mr. Cruz?  #speaker:Detective Felix #text_color:white
    -> CruzRelationship
* [Enemies]
    Do you know anyone who would have a soured relationship with Mr. Cruz?  #speaker:Detective Felix #text_color:white
    Sour to the point that they would want to murder the man?
    -> Enemies  
* [Motivations]
    Could there be any motives behind the murder of Mr. Cruz? #speaker:Detective Felix #text_color:white
    -> Motivations
* [Back]
-> MainChoices



=== CruzRelationship ===
Me and Mr. Cruz were gay. Like hard lovers. Like I fucked him he fucked me type shit. #speaker:Roberto #text_color:green
-> CruzChoices

=== Enemies ===
He crushed just too much pussy, man. #speaker:Roberto #text_color:green
Just too much. Who wouldn't hate him?
-> CruzChoices

=== Motivations ===
Apparently he had the biggest dick in the whole warehouse. #speaker:Roberto #text_color:green
That might've been a reason... but who knows!?
-> CruzChoices