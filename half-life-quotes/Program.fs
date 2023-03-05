open System
open System.Net
open System.Text
open Newtonsoft.Json

let port = 
    match Environment.GetEnvironmentVariable("PORT") with
    | null -> "8080"
    | value -> value
let listener = new HttpListener()
listener.Prefixes.Add("http://localhost:" + port + "/")
listener.Start()

let handleRequest (context: HttpListenerContext) =
    match context.Request.Url.AbsolutePath with
    | "/" ->
        let quote = Quotes.GetRandomQuote(1)
        let json = JsonConvert.SerializeObject(quote, Formatting.Indented)
        let buffer = Encoding.UTF8.GetBytes(json)
        context.Response.ContentType <- "application/json"
        context.Response.ContentLength64 <- int64 buffer.Length
        context.Response.OutputStream.Write(buffer, 0, buffer.Length)
    | path ->
        let pathParts = path.Split('/')
        match pathParts.Length with
        | 2 when pathParts.[1].Length > 0 ->
            match System.Int32.TryParse(pathParts.[1]) with
            | true, limit ->
                let quotes = Quotes.GetRandomQuote(limit)
                let json = JsonConvert.SerializeObject(quotes, Formatting.Indented)
                let buffer = Encoding.UTF8.GetBytes(json)
                context.Response.ContentType <- "application/json"
                context.Response.ContentLength64 <- int64 buffer.Length
                context.Response.OutputStream.Write(buffer, 0, buffer.Length)
            | _ ->
                context.Response.StatusCode <- 400
                context.Response.StatusDescription <- "Bad Request"
                let responseString = "400: Bad Request - Invalid Limit"
                let buffer = Encoding.UTF8.GetBytes(responseString)
                context.Response.ContentLength64 <- int64 buffer.Length
                context.Response.OutputStream.Write(buffer, 0, buffer.Length)
        | _ ->
            context.Response.StatusCode <- 404
            context.Response.StatusDescription <- "Not Found"
            let responseString = "404: Not found"
            let buffer = Encoding.UTF8.GetBytes(responseString)
            context.Response.ContentLength64 <- int64 buffer.Length
            context.Response.OutputStream.Write(buffer, 0, buffer.Length)

    context.Response.OutputStream.Close()

printfn "\027[1;36m%s\027[0m" (sprintf "F#: Running API in http://localhost.com:%s" port)
while true do
 let context = listener.GetContext()
 handleRequest context
