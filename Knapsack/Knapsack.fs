module Knapsack

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
