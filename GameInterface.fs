namespace CS220

open System

/// Tic Tac Toe game interface.
type GameInterface (player, board) =
  member val PlayerMark: Marker = player with get
  member val Board: Board = board with get

  member __.ReadNextMove () =
    printfn "Choose the next move for %s" <| Marker.toString player
    Console.Write ("> ")
    let idx = try Console.ReadLine () |> Convert.ToInt32 with _ -> -1
    if idx >= 1 && idx <= 9 && not (board.IsOccupied idx) then idx
    else Console.WriteLine ("\n[*] Invalid input is given.\n")
         __.ReadNextMove ()
