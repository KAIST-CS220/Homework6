namespace CS220

type TicTacToe (player, computer, playerFirst, ai: AI) =
  let board = Board ()
  let gameinterface = GameInterface (player, board)
  let mutable winner = None

  member __.ShouldStop () =
    match board.CheckWinner () with
    | Some w -> winner <- Some w; true
    | None -> board.IsDraw ()

  member __.Move nextPlayer nextMove =
    match board.Mark nextMove nextPlayer with
    | Ok () -> ()
    | Error () -> failwith "Fatal error"

  member __.Run () =
    let rec loop () =
      let nextMove = gameinterface.ReadNextMove ()
      __.Move player nextMove
      if __.ShouldStop () then
        board.PrintBoard ()
        winner
      else
        __.Move computer (ai.NextMove computer board)
        board.PrintBoard ()
        if __.ShouldStop () then winner
        else loop ()
    if playerFirst then () else __.Move computer (ai.NextMove computer board)
    board.PrintBoard ()
    loop () |> function
      | None -> printfn "[*] Game ended in draw.\n"
      | Some w -> printfn "[*] %s won the game.\n" (Marker.toString w)
