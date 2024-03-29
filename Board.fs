namespace CS220

/// Board represents a 3x3 game board.
type Board () =
  let states = Array.create 9 EmptySlot

  /// Fold slots.
  member __.Fold folder acc =
    states
    |> Array.fold (fun (i, a) elt -> i + 1, folder i a elt) (1, acc)
    |> snd

  /// Make a copy of the board (create a new one).
  member __.Copy () =
    let b = Board ()
    let update i = function
      | Marked m -> b.Mark (i + 1) m |> ignore
      | _ -> ()
    states |> Array.iteri update
    b

  /// Print out the board to console.
  member __.PrintBoard () =
    let s1 = SlotState.toString states.[0]
    let s2 = SlotState.toString states.[1]
    let s3 = SlotState.toString states.[2]
    let s4 = SlotState.toString states.[3]
    let s5 = SlotState.toString states.[4]
    let s6 = SlotState.toString states.[5]
    let s7 = SlotState.toString states.[6]
    let s8 = SlotState.toString states.[7]
    let s9 = SlotState.toString states.[8]
    printfn "+---+---+---+"
    printfn "| %s | %s | %s |" s1 s2 s3
    printfn "+---+---+---+"
    printfn "| %s | %s | %s |" s4 s5 s6
    printfn "+---+---+---+"
    printfn "| %s | %s | %s |" s7 s8 s9
    printfn "+---+---+---+"

  /// Is the specified slot occupied?
  member __.IsOccupied num =
    match states.[num - 1] with
    | EmptySlot -> false
    | _ -> true

  /// Mark the given slot in the board. Returns "Error ()" when the slot is
  /// already occupied.
  member __.Mark num marker =
    if __.IsOccupied num then Error ()
    else states.[num - 1] <- Marked marker; Ok ()

  /// Undo marking for the given slot.
  member __.Clear num =
    states.[num - 1] <- EmptySlot

  /// Check the winner.
  member __.CheckWinner (): Marker option =
    BoardHelper.checkWinner states

  /// Check if the game ended in draw.
  member __.IsDraw (): bool =
    BoardHelper.isDraw states
