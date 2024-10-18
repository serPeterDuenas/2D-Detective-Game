INCLUDE Globals.ink

{ endingChoice == "": -> main | -> already_chose}

-> main

=== main ===
Do you want to stick around, or start solving the murder?

    + [Solve]
        -> chosen("Solve")
    + [Solve]
        -> chosen("Solve")

=== chosen(choice) ===

~ endingChoice = choice
You chose {choice}.
-> END


=== already_chose ===
You already chose {endingChoice}.
-> END