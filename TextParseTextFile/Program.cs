using System.ComponentModel.DataAnnotations;
using Lori.Parser;
using ParseTextFile;
Console.WriteLine("Text File Parser");

var filepath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "TextDataLines.txt");
var lines = System.IO.File.ReadAllLines(filepath);

var configs = new List<Configuration>() {
    new Configuration(ColumnName: "A", StartPosition: 0, Length: 10),
    new Configuration(ColumnName: "B", StartPosition: 10, Length: 5),
    new Configuration(ColumnName: "C", StartPosition: 15, Length: 7),
    new Configuration(ColumnName: "D", StartPosition: 22, Length: 10, ColumnType: Configuration.DataType.Decimal)
};

var seqdict = ParseText.Parse(configs, lines);

var x = 0;