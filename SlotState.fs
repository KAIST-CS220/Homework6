namespace CS220

/// State of a slot.
type SlotState =
  /// Empty.
  | EmptySlot
  /// Marked.
  | Marked of Marker

module SlotState =
  let toString = function
    | EmptySlot -> " "
    | Marked m -> Marker.toString m
