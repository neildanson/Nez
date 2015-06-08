module Game

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type LoopState = 
| Update of GameTime
| Draw of GameTime

type XnaGame() as this =
    inherit Game()

    let loadEvent = Event<_>()
    let initializeEvent = Event<_>()
    let loopEvent= Event<_>()
    
    do this.Content.RootDirectory <- "XnaGameContent"
    let graphicsDeviceManager = new GraphicsDeviceManager(this)

    
    override game.Initialize() =
        graphicsDeviceManager.GraphicsProfile <- GraphicsProfile.HiDef
        graphicsDeviceManager.PreferredBackBufferWidth <- 640
        graphicsDeviceManager.PreferredBackBufferHeight <- 480
        graphicsDeviceManager.ApplyChanges() 
        base.Initialize()
        initializeEvent.Trigger ()
    override game.LoadContent() =
        loadEvent.Trigger ()
        
    override game.Update gameTime = 
        loopEvent.Trigger (Update gameTime)

    override game.Draw gameTime = 
        game.GraphicsDevice.Clear(Color.CornflowerBlue)
        loopEvent.Trigger (Draw gameTime)

    member game.LoadAsync = Async.AwaitEvent loadEvent.Publish
    member game.InitializeAsync = Async.AwaitEvent initializeEvent.Publish
    member game.LoopEvent = Async.AwaitEvent loopEvent.Publish

let game = new XnaGame()
