namespace CS220

/// Marker type to be used in our tic-tac-toe game.
type Marker =
  /// O Mark
  | O
  /// X mark
  | X

module Marker =
  let toString = function
    | O -> "O"
    | X -> "X"

  /// Return an opposite sign.
  let getOpponent = function
    | O -> X
    | X -> O

