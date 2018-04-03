// Learn more about F# at http://fsharp.org

open System
open Knapsack

let getMaxValue (capacity:int) (weights: int list) =
    let capacities = Array.init (capacity + 1) (fun _ -> 0)
    capacities
    |> Array.mapi (fun i c -> (i, c))
    |> Array.fold (fun highestWeight (i, c) -> 
        weights
        |> List.fold (fun highestWeight w -> 
            if i - w >= 0 && capacities.[i - w] + w > highestWeight then
                capacities.[i] <- capacities.[i - w] + w
                capacities.[i - w] + w
            else
                highestWeight
            ) highestWeight
        ) 0

[<EntryPoint>]
let main argv =
    let numTestCases = Console.ReadLine() |> int
    [ 1 .. numTestCases ] |> List.map (fun _ -> 
        let capacity = Console.ReadLine().Split([| ' ' |]).[1] |> int
        let weights = Console.ReadLine().Split([| ' ' |]) |> Array.map int |> Array.toList
        getMaxValue capacity weights)
    |> List.iter (printfn "%i")
    0 // return an integer exit code
