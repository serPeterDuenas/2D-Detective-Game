INCLUDE Globals.ink

{ endingChoice == "": -> main | -> already_chose}

-> main

=== main ===
Do you want to stick around, or start solving the murder?

    + [Stay]
        -> chosen("Stay")
    + [Solve]
        -> chosen("Solve")
    + [Fuck you]
        -> chosen("Stay")

=== chosen(choice) ===

~ endingChoice = choice
You chose {choice}.
-> END


=== already_chose ===
You already chose {endingChoice}.
-> END