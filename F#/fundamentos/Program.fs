// Learn more about F# at http://fsharp.org

open System


let checanome (nome:string) =
    if nome.Length > 5 then
        printf"Nome longo.\n"
    else 
        printf"Seu nome é curto"
    

[<EntryPoint>]
let main argv =
    printf "Aula 1\n"
    printfn "Digite seu nome: \n"
    //geralmente as expressoes declaradas não são mutaveis, elas nunca se alteram
    //nunca sofrem modificação
    let nome = Console.ReadLine()
    printf "Seu nome é %s\n" nome
    printf "==================================\n"
    printf "Aula 2 \n"
    let nome2 = Console.ReadLine()
    checanome nome2
    //não conseguimos alterar a expressao nome acima
    //mas se fizermos como abaixo, conseguimos
    let mutable nome2: string = Console.ReadLine()
    printf "Seu nome2 é %s\n" nome2
    nome2 <- "Pedro"
    printf "Seu nome2 é %s\n" nome2
    printf "==================================\n"
    printf "Aula 3 \n"

    //Iniciando estudos list comprehension
    let mutable nomeUsuario = ""
    let names = [
        while nomeUsuario <> "sair" do
            nomeUsuario <- Console.ReadLine()
            if nomeUsuario <> "sair" then
                yield nomeUsuario
    ]
    printf "Você tem %d amigos!\n" names.Length
    printf "==================================\n"
    printf "Aula 4\n"
    let mutable nomeUsuarios = ""
    let namess = [
        while nomeUsuarios <> "sair" do
            nomeUsuarios <- Console.ReadLine()
            if nomeUsuarios <> "sair" then
                yield nomeUsuarios
    ]
    //aplicando uma operacao em cima da minha lista namess
    namess |> List.map(fun n -> "Olá, "+ n)
        |> List.iter(fun n -> printf "-> %s \n" n)

    //outra forma
    //namess |> List.iter(fun n -> printf "-> %s \n" n)
    // let wellcomes = names |> List.map(fun n -> "Olá, "+ n)
    // wellcomes |> List.iter(fun welcome -> printf "%s \n" welcome)
    0 // return an integer exit code

