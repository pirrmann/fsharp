namespace PrimitivesBenchmarks

open BenchmarkDotNet.Running

module Main =

    [<EntryPoint>]
    let main argv =
        printfn "Running benchmarks..."
        let results = BenchmarkRunner.Run<Array2DEquality.Benchmark>()
        0
