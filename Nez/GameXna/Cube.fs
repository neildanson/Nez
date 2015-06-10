module Cube

open Microsoft.Xna.Framework

type Vec = 
    struct
        val V : Vector3
        val T : Vector2
        new(v : Vector3, t : Vector2) = 
            { V = v
              T = t }
    end

let cubeVertices = 
    [| //Front
       Vec(Vector3(-1.0f, 1.0f, 1.0f), Vector2(0.25f, 1.0f / 3.0f))
       Vec(Vector3(1.0f, 1.0f, 1.0f), Vector2(0.5f, 1.0f / 3.0f))
       Vec(Vector3(1.0f, -1.0f, 1.0f), Vector2(0.5f, 2.0f / 3.0f))
       Vec(Vector3(-1.0f, -1.0f, 1.0f), Vector2(0.25f, 2.0f / 3.0f))
       //Right
       Vec(Vector3(1.0f, 1.0f, 1.0f), Vector2(0.5f, 1.0f / 3.0f))
       Vec(Vector3(1.0f, 1.0f, -1.0f), Vector2(0.75f, 1.0f / 3.0f))
       Vec(Vector3(1.0f, -1.0f, -1.0f), Vector2(0.75f, 2.0f / 3.0f))
       Vec(Vector3(1.0f, -1.0f, 1.0f), Vector2(0.5f, 2.0f / 3.0f))
       //Back
       Vec(Vector3(1.0f, 1.0f, -1.0f), Vector2(0.75f, 1.0f / 3.0f))
       Vec(Vector3(-1.0f, 1.0f, -1.0f), Vector2(1.0f, 1.0f / 3.0f))
       Vec(Vector3(-1.0f, -1.0f, -1.0f), Vector2(1.0f, 2.0f / 3.0f))
       Vec(Vector3(1.0f, -1.0f, -1.0f), Vector2(0.75f, 2.0f / 3.0f))
       //Left
       Vec(Vector3(-1.0f, 1.0f, -1.0f), Vector2(0.0f, 1.0f / 3.0f))
       Vec(Vector3(-1.0f, 1.0f, 1.0f), Vector2(0.25f, 1.0f / 3.0f))
       Vec(Vector3(-1.0f, -1.0f, 1.0f), Vector2(0.25f, 2.0f / 3.0f))
       Vec(Vector3(-1.0f, -1.0f, -1.0f), Vector2(0.0f, 2.0f / 3.0f)) |]

let cubeIndices = [| //Front 
                     0; 1; 2; 2; 3; 0; 
                     //Right
                     4; 5; 6; 6; 7; 4; 
                     //Back
                     8; 9; 10; 10; 11; 8; 
                     //Left
                     12; 13; 14; 14; 15; 12 |]
