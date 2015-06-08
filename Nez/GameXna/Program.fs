module Program

open Game
open Intro

let loop() = async {
    do! game.InitializeAsync

    do! game.LoadAsync

    let rec gameLoop() = async {
        do! intro ()

    }

    do! gameLoop()
}

do game.Run()