Season of Daemons, Day 54, 20 years PNW

- Brief description of the world/location, to set the backdrop of game:

    PNW stands for Post Nuclear War, but not a war as most people would picture it if you told them about it. This was, by all standards, a conventioal war between 2 young super-powers with a few notable exceptions. The vast majority of battles was fought by machines that were either autonomous or remotely controlled from secure and comfortable command centers. As a result, there were very few casualties among military personael of both sides.
    As the conflict dragged on, there was no winner in sight and it soon became clear that the winner would be determined only by who ran out of resources first. But the resourses were still plentiful in the world, so the war could go on for many decades - perhaps even a few centuries at the current pace. Some were quite comfortable with this idea, since to them, it meant buisness opportunity and the the hope that the planet would eventually adjust to this state. This did not sit well with those few who were able to look beyond a single human life span and consider what the world after the conflict would look like.
    A plan was set in motion, all existing archives were comed over for any bit inforamation, no matter its age or size, that could help end the war before the war ended them all. This process took many years and by the time the plan was beginning to form, some of their predictions started coming true: many mining, refining and fabrication companies had appeared and taken root in societies on both sides; the battles that took place no longer dominated the news headlines - only the occasional update would be seen.
    This state of the world lead a radical faction to belive that it was now, or never - something had to be done, or it would be too late. Some years prior, members of this faction had discovered an old and secret location: an bunker located beneath the ocean floor off the coast of a small, neutral country. Inside the bunker were the last nuclear warheads produced before all nuclear weapons were banned and destroyed decades earlier.
    There were 6 of the warheads in total, and their targets were already determined: the capital cities of the warring powers, their main industrial hubs and two key positions on the front lines - one for each army - that would ensure the destruction of as many war machines as possible. 
    
    //TODO:
    -Plan worked, massive loss of life, governments in ruins, chaos
    -Bigger group seeks to bring the faction to justice - basically starts another small war; in the final battle, onle last nuke is detonated - most powerfull & on the ground - heavy environmental damage, climate change, etc
    -Transition into description of the current state of the world
        -Fusion of "magic" and tech
        -Average QOL is somewhat lower
        -Resources are strictly rationed - preference for more natural materials

- Similar description of where you are heading and why
- Any additional info

You are: 

+ [Char_Type_01: "Magic Archetype"] -> Intro.Chose_Char_01
+ [Char_Type_02: "Tech Seeker"] -> Intro.Chose_Char_02
+ [Char_Type_03" "___"] -> Intro.Chose_Char_03

===Intro===

= Chose_Char_01
-Description of char 01
    -"Magic" comes from radiation-induced mutations; many "spells" are based on/influenced by radiation mechanics
->Intro.FoundPerson

= Chose_Char_02
-Description of char 01
    -Profession; high-sklii & high-danger; search for technology from before the war
->Intro.FoundPerson

= Chose_Char_03
-Description of char 01
    -Blarg
->Intro.FoundPerson

=FoundPerson
-stuff and dialogue
-choices depend on char class

-Person explains what is going one
-Character response:

{ Intro.Chose_Char_01: //If the player chose the first character
-Dialogue and choices specific to the first character
+Response 01 -> Responce01
+Response 02 ->Responce03
}

{Intro.Chose_Char_02:
-Same as first case 
+Response 01 ->Responce03
+Response 02 ->Responce01
}

{Intro.Chose_Char_02:
-Same as first and second case 
+Response 01 ->Responce02
+Response 02 ->Responce04
}



=Responce01
-Some responce 01
->IntroEnd

=Responce02
-Some responce 02
->IntroEnd

=Responce03
-Some responce 03
->IntroEnd

=Responce04
-Some responce 04
->IntroEnd



=IntroEnd
-More conversation before this(?), same model 

-results in either going to the town first or going straight to the old base.

+[Go tot the town first] ->Main_Location_Town

+[Go Straight to the old base] ->Main_Location_OldBase



===Main_Location_Town===



-some more dialogue and/or background
-likely find some clues and/or equipmanet
-once ready, go to the old base

->Main_Location_OldBase

===Main_Location_OldBase===



-things! mystery! excitment!
-maybe even some sweet loot...

->END