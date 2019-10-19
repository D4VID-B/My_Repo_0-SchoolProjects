Season of Daemons, Day 54, 20 years PNW

Brief description of the world/location, to set the backdrop of game:

    PNW stands for Post Nuclear War, but not a war as most people would picture it if you told them about it. This was, by all standards, a conventioal war between 2 young super-powers with a few notable exceptions. The vast majority of battles was fought by machines that were either autonomous or remotely controlled from secure and comfortable command centers. As a result, there were very few casualties among military personael of both sides.
    As the conflict dragged on, there was no winner in sight and it soon became clear that the winner would be determined only by who ran out of resources first. But the resourses were still plentiful in the world, so the war could go on for many decades - perhaps even a few centuries at the current pace. Some were quite comfortable with this idea, since to them, it meant buisness opportunity and the the hope that the planet would eventually adjust to this state. This did not sit well with those few who were able to look beyond a single human life span and consider what the world after the conflict would look like.
    A plan was set in motion, all existing archives were comed over for any bit inforamation, no matter its age or size, that could help end the war before the war ended them all. This process took many years and by the time the plan was beginning to form, some of their predictions started coming true: many mining, refining and fabrication companies had appeared and taken root in societies on both sides; the battles that took place no longer dominated the news headlines - only the occasional update would be seen.
    This state of the world lead a radical faction to belive that it was now, or never - something had to be done, or it would be too late. Some years prior, members of this faction had discovered an old and secret location: an bunker located beneath the ocean floor off the coast of a small, neutral country. Inside the bunker were the last nuclear warheads produced before all nuclear weapons were banned and destroyed decades earlier.
    There were 6 of the warheads in total, and their targets were already determined: the capital cities of the warring powers, their main industrial hubs and two key positions on the front lines - one for each army - that would ensure the destruction of as many war machines as possible. 
    
    //TODO:
    Plan worked, massive loss of life, governments in ruins, chaos
    Bigger group seeks to bring the faction to justice - basically starts another small war; in the final battle, onle last nuke is detonated - most powerfull & on the ground - heavy environmental damage, climate change, etc
Transition into description of the current state of the world
Fusion of "magic" and tech
Average QOL is somewhat lower
Resources are strictly rationed - preference for more natural materials

Description of your general mission (more details in char desc)


You are: 

+ [Char_Type_01: "Magic Archetype"] -> Intro.Chose_Char_01
+ [Char_Type_02: "Tech Seeker"] -> Intro.Chose_Char_02
+ [Char_Type_03" "___"] -> Intro.Chose_Char_03

===Intro===

= Chose_Char_01
Description of char 01
"Magic" comes from radiation-induced mutations; many "spells" are based on/influenced by radiation mechanics
->Intro.FoundPerson

= Chose_Char_02
Description of char 01
Profession; high-sklii & high-danger; search for technology from before the war
->Intro.FoundPerson

= Chose_Char_03
Description of char 01
Blarg
->Intro.FoundPerson

=FoundPerson
stuff and dialogue
choices depend on char class

Person explains what is going one
Character response:

{ Intro.Chose_Char_01: //If the player chose the first character
Dialogue and choices specific to the first character
+Response 01 -> Responce01
+Response 02 ->Responce03
}

VAR CharSubType = 0 

{Intro.Chose_Char_02:
Same as first case 
+Tired Traveler: Probably Just Another Dead End 
~CharSubType = 3
->Responce03

+Optimistic Noob: Maybe This Will Lead Somewhere? 
~CharSubType = 1
->Responce01
}

{Intro.Chose_Char_03:
Same as first and second case 
+Response 01 ->Responce02
+Response 02 ->Responce04
}



=Responce01
Some responce 01
->IntroEnd

=Responce02
Some responce 02
->IntroEnd

=Responce03
Hey old man, you from, uh, [town name]?
I'm looking for an old military base, was told it would be somewhere around here - do you know where it might be?
->IntroEnd

=Responce04
Some responce 04
->IntroEnd



=IntroEnd
[Man responds, corrects town name]
[He is from the town - he is the herbalist]

{Responce01:
[You ask what a herbalist is, exactly and why the town doesn't have a Auto-Clinic]
[He explains what a herbalist is and that the people of his town don't trust high technology and many blame it for the current state of the world]


}


{Responce03:
Herbalist huh? So it's that bad around here...
[Man is a bit ofended, says the people of his town don't trust high technology]
Oh really? Then how do you defend agains bandits, mutants and war bots?
[Man explains that there is nobody here but the town]
Fine, good for all of you. So how about that old base - do you know where it is?
[Man says that there is no base around here - only a few war ruins and a zone behind a nearby hill that was marked as dengerous by the town's founders where nobody goes]
(Thoughts::)*A danger zone created by the founders of a town that hate hight technology, but know enough to mark off a danger zone and maintain it for years? Sounds like they don't want people to find out what's really inside it.*
So these Founders have been all around this area?
[Man affirms - says that they spent years looking for a perfect place to set up a small, independant town, so if you go into town an talk to them, they might be able to help out]


}



+[Go to the town first] 
{Responce03:
Thanks for the tip, I'll go do that.
}

{Responce01:
Thank you sir! I'm sure they'll have some information that I could use!
}
->Main_Location_Town

+[Go Straight to the Zone] ->Main_Location_OldBase



===Main_Location_Town===



some more dialogue and/or background
likely find some clues and/or equipmanet
once ready, go to the old base

->Main_Location_OldBase

===Main_Location_OldBase===

=Approaching_Base
{Intro.Chose_Char_02 && CharSubType==3:
[You catiously creep through the brush, it's been almost 20 minutes since you passed the warning labels, sou you must be well inside the zone at this point, but there is still nothing around you but heavy forest and occasional dead tree]
[Finally, after another 20 minutes have passed, you see a clearing in the woods]
[Just as you are about to step out into the open, you traking alarm goes off!]
[Before you can even start wondering what could have set it off in the middle of nowhere, you reflexes take over and you dive behind the nearest tree!]
[A minute goes by and nothing happens. You peek out into the clearing from behind the tree, your artificial eye zooming in as much as it can...]
[Then you see it - a grey, reinforced concrete wall, full of craks and holes, slowly being taken over by vines. On top of the wall, at regular intervals, you spot automated defence turrets: the old military base!]

A few of the turrets are missing, or look damaged, but it's hard to say for sure from this distance. The base, according to the mission was a small one, dug into the hillside and used as one of many controll centers during the robo-wars. These bases were rarely attacked, as there were hundreds of them onn both sides and they were all redundant anyway - you would have to find and destroy dosens of them before seeing any effect.

[You reach down and activate a small device on your belt - it's a signal emmiter, designed to fool the base's computer into thinking you are one of the soliders stationed there.]

[You step out from behind the tree and start walking towards the base, hopint that nobody has occupied it ... or that this base was not run by an AI]

[After a few minutes pass and nothing happens, you allow yourself to relax. The turrets are still tracking you, but it is unclear if they are out of ammo or the emitter you were given worls as it should. ]

[You slow down as you approach the wall - the turrets have turned away, so you debate your next move: go over the wall, or walk along it to reach the front gate]

}

{Intro.Chose_Char_02 && CharSubType == 1:
...
}

+[Try going over the wall]
[The wall is only 2 meters tall and there are enough dents and cracks for you to efortlessly climb over it. As you peek over the top, you see that the area inside the wall is split into two uneven parts, separated by a similar wall. You end up on the smaller, inner courtyard - empty, save for a few crumbling buildings.]

[After a brief scan of the courtyard, you head tpwards the entrance to the heart of the base, the heavy doors slightly adjar - enough for two average people to walk through side-by-side.]
->Exploring_Base //Bypass the front section of the base

+[Try following the wall to the front gate]
[]
->Entering_Base


=Entering_Base
{Intro.Chose_Char_02 && CharSubType==3:
There is no front gate - only a small, closed door, likely made from steel or titanium - no use trying to force it open. 
[You don't risk kicking the door - one will likely not do it and if anyone is inside, one kick will be enough to alert them.]
[You decide to walk back and try climbing over the wall.]
}

{Intro.Chose_Char_02 && CharSubType == 1:
...
}

->Exploring_Base

=Exploring_Base

Empty
Dusty
No visible battle damage
Only a few low-power LEDs - not even emergeny lighting
"Make your way to the base's power room - there is a device there. Extract it and bring it back here. You'll know it when you see it."

Junktion: to the right, a coridor marked "Reactor", to the left, a narrow and unmarked passage with a heavy-looking security door at the end.

*[Go straight to the reactor room]
->ReactorRoom

*[Check the door on the left]
It's locked shut and there is no keypad or any other lock you might think of.
Nothing else to do but turn around and go into the reactor room.
->ReactorRoom



=ReactorRoom

Room looks like the rest of the base.
See device
Exposition through flashbacks
Base suddenly powers on, but as you near the exit, the reactor starts breack down - alarm goes off

->Escaping_Base

=Escaping_Base
Run out of the room
Glance to the right - security door is open, corridor on the other side was once white, but is now almost all covered in red
Run outside, explosion behind you




->END