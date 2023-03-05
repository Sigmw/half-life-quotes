module Quotes

open System
open Newtonsoft.Json

type Quote = {
    [<JsonProperty("quote")>]
    Quote: string
    [<JsonProperty("author")>]
    Author: string
}

let Quotes = [
    { Quote = "Welcome to the HEV Mark 4 Protective System, for use in hazardous environment conditions."; Author = "HEV Suit" }
    { Quote = "High-impact reactive armor activated."; Author = "HEV Suit" }
    { Quote = "Atmospheric contaminant sensors activated."; Author = "HEV Suit" }
    { Quote = "Vital signs monitoring activated."; Author = "HEV Suit" }
    { Quote = "Automatic medical systems engaged."; Author = "HEV Suit" }
    { Quote = "Defensive weapon selection system activated."; Author = "HEV Suit" }
    { Quote = "Munition level monitoring activated."; Author = "HEV Suit" }
    { Quote = "Communications interface online."; Author = "HEV Suit" }
    { Quote = "Have a very safe day."; Author = "HEV Suit" }
    { Quote = "Minor fracture detected."; Author = "HEV Suit" }
    { Quote = "Morphine administered."; Author = "HEV Suit" }

    { Quote = ""; Author = "Gordon Freeman" }

    { Quote = "Have you heard? They are killing scientists... our own race, turning against us."; Author = "Unnamed scientist" }
    { Quote = "Gordon doesn't need to hear all this, he's a highly trained professional!"; Author = "Unnamed scientist" }
    { Quote = "For god's sake open the silo doors!"; Author = "Unnamed scientist" }
    { Quote = "Oh, my GOD, WE'RE DOOMED!"; Author = "Unnamed scientist" }

    { Quote = "Morning Mr.Freeman, looks like you're running a late"; Author = "Barney Calhoun" }

    { Quote = "Forget about Freeman, we are cutting our losses and pulling out! Anyone left down there now is on his own."; Author = "HECU Captain" }
    { Quote = "I didn't sign on for this shit. Monsters, sure, but civilians?"; Author = "HECU soldier" }
    { Quote = "All I know for sure is he's been killing my buddies"; Author = "HECU soldier" }
    { Quote = "Body? What body?"; Author = "HECU soldier" }

    { Quote = "I have recommended your services to my … employers, and they have authorized me to offer you a job."; Author = "G-Man" }
    { Quote = "Quite a nasty piece of work you managed over there, I am impressed."; Author = "G-Man" }
    { Quote = "Gordon Freeman, in the flesh - or rather, in the hazard suit."; Author = "G-Man" }
]

let GetRandomQuote (limit : int) : Quote list =
    let mutable output = []
    let rand = new System.Random()
    let limit = if limit > List.length Quotes then List.length Quotes else limit
    for i = 0 to limit - 1 do
        let randomIndex = rand.Next(0, List.length Quotes)
        let randomQuote = List.item randomIndex Quotes
        output <- randomQuote :: output
    output





