<h1 align=center>Half-Life quotes API</h1>
<p align=center>A (very) simple API to retrieve some quotes of Half Life.</p>

## API

`GET /`

To run the API, you should specify the port in ENV:
```
$env:PORT=4444
./half-life-quotes.exe
```

Get a random quote in this format:
> http://localhost:PORT
```json
[
  {
    "quote":"Welcome to the HEV Mark 4 Protective System, for use in hazardous environment conditions.",
    "author":"HEV Suit"
  }
]
```


`GET /{number}`

return an array with `{number}` quotes.
> http://localhost:PORT/5
```json
[
  {
    "quote": "",
    "author": "Gordon Freeman"
  },
  {
    "quote": "Communications interface online.",
    "author": "HEV Suit"
  },
  {
    "quote": "Defensive weapon selection system activated.",
    "author": "HEV Suit"
  },
  {
    "quote": "Communications interface online.",
    "author": "HEV Suit"
  },
  {
    "quote": "Minor fracture detected.",
    "author": "HEV Suit"
  }
]
```

## Contributing
If you want to add some quotes, just add them in [`Quotes.fs`](https://github.com/Sigmw/half-life-quotes/blob/master/half-life-quotes/Quotes.fs) file and do a pull request!

## Credits
inspired by [Half-life-quotes](https://github.com/RedsonBr140/half-life-quotes)<br>
inspired by [Breaking Bad quotes](https://github.com/shevabam/breaking-bad-quotes)

## License
MIT License

---
