namespace PrimitivesBenchmarks

open System
open System.Collections

open BenchmarkDotNet.Attributes

module Array2DEquality =

    type [<Measure>] m

    [<MemoryDiagnoser>]
    type Benchmark() =

        let values1 =
            let rand = new Random(42)
            Array.init 10 (fun _i -> Array2D.init 40 40 (fun _x _y -> rand.NextDouble() |> LanguagePrimitives.FloatWithMeasure<m^2>))
        let values2 = values1 |> Array.map (Array2D.copy)

        [<Benchmark>]
        member this.SelfEqualityOfArray2DFloat() =
            let mutable result = true
            for i = 0 to 9 do
                result <- values1.[i] = values1.[i]
            if not result then failwith "Incorrect"

        [<Benchmark>]
        member this.CopyEqualityOfArray2DFloat() =
            let mutable result = true
            for i = 0 to 9 do
                result <- values1.[i] = values2.[i]
            if not result then failwith "Incorrect"
