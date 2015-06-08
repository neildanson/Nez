module Intro

open Game

let rec intro() = 
    async { 
        let! e = game.LoopEvent
        return! match e with
                | Update(_) -> intro()
                | Draw(_) -> intro()
    }
