module InsertionSort

let sort keys =
    let rec insert el list =
        match list with
        | head :: tail when head >= el -> el :: list
        | head :: tail when head < el -> head :: insert el tail
        | _ -> [el]

    let rec innerSort sorted rest =
        match rest with
        | head :: tail -> innerSort (insert head sorted) tail
        | [] -> sorted

    innerSort [] keys