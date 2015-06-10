module Program

open Game
open Intro

let loop() = 
    async { 
        do! game.LoadAsync
        do! game.InitializeAsync
        let rec gameLoop() = async { do! intro() }
        do! gameLoop()
    }

do loop() |> Async.StartImmediate
do game.Run()
