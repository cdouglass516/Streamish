
module Tests
open Streamish.Models
open Streamish.Repositories
open System
open Xunit
open Xunit.Abstractions
open Moq
open Moq.FSharp.Extensions


[<Fact>]
let add_5_to_3_should_be_8() =
    let sampleFunction1 x = 100+200
    Assert.Equal(300, sampleFunction1())

[<Fact>]
let This_is_True() =
    Assert.True(true)



    
