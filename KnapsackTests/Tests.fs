module Tests

// open System
open Xunit
open FsUnit.Xunit
open Knapsack


[<Fact>]
let ``Get max value should return the max value that can fit in the sack`` () =
    getMaxValue 9 [ 3; 4; 4; 8; 9 ] |> should equal 9
    getMaxValue 13 [ 3; 9 ] |> should equal 12 