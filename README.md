# Jeffsum.NET

Jeff Goldblum text placeholder generator of pure amazingness. (Unofficial .NET version of Jeffsum.com by @seanehalpin)


[![Build status](https://dev.azure.com/jamesmontemagno/Jeffsum/_apis/build/status/Jeffsum-CI)](https://dev.azure.com/jamesmontemagno/Jeffsum/_build/latest?definitionId=28)


**NuGets**

|Name|Info|
| ------------------- | :------------------: |
|Jeffsum.NET|[![NuGet](https://img.shields.io/nuget/v/Jeffsum.svg?label=NuGet)](https://www.nuget.org/packages/Jeffsum/)|
|Development Feed|[MyGet](https://www.myget.org/F/jeffsum/api/v3/index.json)|

## Usage

```csharp
using Jeffsum;
//optional
//using static Jeffsum.Goldblum;

// Goldblum.ReceiveTheJeff(count, jeffsumType);
// with static: ReceiveTheJeff(count, jeffsumType);

var words = Goldblum.ReceiveTheJeff(5, JeffsumType.Words); 
var quotes = Goldblum.ReceiveTheJeff(5, JeffsumType.Quotes); 
var paragraphs = Goldblum.ReceiveTheJeff(5, JeffsumType.Paragraphs); //default
```

* **count** - The amount of amazingness you want to receive. Valid 1-99.
* **jeffsumType** - Type of Jeffsum you want back: words, quotes, or paragraphs


## More Jeffsum
 
Find more Jeffsum at:
* [Jeffsum.com](http://jeffsum.com): Official website
* [Jeffsum Javascript Package](https://github.com/chlorophyllkid/jeffsum)

## License
Original idea by [@seanehalpin](https://twitter.com/seanehalpin)

The MIT License (MIT) see [License file](LICENSE)

### Want To Support This Project?
All I have ever asked is to be active by submitting bugs, features, and sending those pull requests down! Want to go further? Make sure to subscribe to my weekly development podcast [Merge Conflict](http://mergeconflict.fm), where I talk all about awesome Xamarin goodies and you can optionally support the show by becoming a [supporter on Patreon](https://www.patreon.com/mergeconflictfm).
