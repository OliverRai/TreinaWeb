// Learn more about F# at http://fsharp.org

open System

//semelhante a classes e structs?
type Person = {
    name: string
    age: int
}

let getOldestPerson people =
    people |> List.maxBy(fun p -> p.age)

let getYoungerPerson people =
    people |> List.minBy(fun p -> p.age)

//currying implícito
// let getPageableContent people pagenumber =
//     people  |> List.sortBy(fun p -> p.name) 
//             |> List.skip(((pagenumber - 1) * 3))
//             |> List.truncate(3)

//currying explícito
let getPageableContent people =
    let applypage page =
        people |> List.sortBy(fun p -> p.name) 
               |> List.skip(((page - 1) * 3))
               |> List.truncate(3)
    applypage

[<EntryPoint>]
let main argv =
    printf "Aula 5 - Types \n"
    let mutable name = ""
    printf "Digite o nome de seus amigos. Digite 'sair' quando quiser interromper! \n"
    let names = [
        while name <> "sair" do
            printf "Nome: "
            name <- Console.ReadLine()
            if name <> "sair" then
                printf "Idade: "
                let age = int(Console.ReadLine())
                yield { name = name; age = age }
    ]

    names |> List.map(fun n -> "Olá, "+ n.name)
        |> List.iter(fun welcome -> printf "-> %s \n" welcome)

    printf "\n Digite o nome para busca: \n"
    let searchArg = Console.ReadLine()
    
    printf "\nResultados\n"
    names |> List.where(fun person -> person.name.Contains(searchArg))
        |> List.map(fun person -> {name = person.name.ToUpper(); age = person.age})
        |> List.iter(fun person -> printf "-> %s, -%d \n" person.name person.age)
    printf "\n*****************************\n"
    let oldestPerson = names |> getOldestPerson
    let youngerPerson = names |> getYoungerPerson
    
    printf "Seu amigo mais velho é %s com %d anos \n" oldestPerson.name oldestPerson.age
    
    printf"Somando IDADES\n" 
    printf"A média das idades é de %d anos \n" ((names |> List.sumBy(fun person -> person.age)) / names.Length)
    printf "\n*****************************\n"
    let mutable pageNumber = 1
    while pageNumber <> 0 do
        printf "Digite a página desejada"
        pageNumber <- int(Console.ReadLine())
        if pageNumber <> 0 then
            // currying implícito
            // getPageableContent names pageNumber |> List.iter(fun p -> printf "-> %s, %d \n" p.name p.age)
            // currying explícito
            ((getPageableContent names) pageNumber) |> List.iter(fun p -> printf "-> %s, %d \n" p.name p.age)
            printf "\n*****************************\n"
    0 // return an integer exit code
