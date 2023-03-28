using ParseInt;

var numbersToParse = new List<string>
    {
        "one", "twenty", "two hundred", "forty-six",
        "two hundred forty-six",
        "one thousand thirty",
        "seven hundred eighty-three thousand nine hundred and nineteen",
        "one million seven hundred eighty-three thousand nine hundred and nineteen"
    };

foreach (var numberToParse in numbersToParse)
{
    Console.WriteLine($"{numberToParse}: {Parser.ParseInt(numberToParse)}");
}

