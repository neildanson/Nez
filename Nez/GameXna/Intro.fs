module Intro

open Game
open Cube
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

//let projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians 65.0f, 4.0f / 3.0f, 0.3f, 1000.0f)
let projection = Matrix.CreateOrthographic(6.0f, 4.0f, 0.0f, 10000.0f)
let view = Matrix.CreateTranslation(0.0f, 0.0f, -5.0f)
let translate = Matrix.Identity

let vertexDecl = 
    new VertexDeclaration([| VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0)
                             VertexElement(12, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0) |])

let intro() = 
    async { 
        let vb = new VertexBuffer(game.GraphicsDevice, vertexDecl, cubeVertices.Length, BufferUsage.WriteOnly)
        vb.SetData cubeVertices
        let ib = 
            new IndexBuffer(game.GraphicsDevice, IndexElementSize.ThirtyTwoBits, cubeIndices.Length, BufferUsage.None)
        ib.SetData cubeIndices
        let effect = new BasicEffect(game.GraphicsDevice, TextureEnabled = true, VertexColorEnabled = false)
        
        let rec introLoop angle = 
            async { 
                let texture = Texture2D.FromStream(game.GraphicsDevice, System.IO.File.OpenRead("Debug.png"))
                let! e = game.LoopEvent
                return! match e with
                        | Update(_) -> 
                            effect.World <- translate * Matrix.CreateRotationY(MathHelper.ToRadians angle) * Matrix.CreateRotationX( MathHelper.ToRadians angle)
                            effect.View <- view
                            effect.Projection <- projection
                            introLoop (angle + 2.0f)
                        | Draw(_) -> 
                            effect.Texture <- texture
                            game.GraphicsDevice.Indices <- ib
                            game.GraphicsDevice.SetVertexBuffer vb
                            effect.CurrentTechnique.Passes.[0].Apply()
                            game.GraphicsDevice.DrawIndexedPrimitives
                                (PrimitiveType.TriangleList, 0, 0, cubeVertices.Length, 0, cubeIndices.Length / 3)
                            introLoop angle
            }
        return! introLoop 0.0f
    }
