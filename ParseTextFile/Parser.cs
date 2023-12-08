using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Lori.Parser;

namespace ParseTextFile;

public class ParseText
{
    private static string ErrorLogPath = Path.Combine(Directory.GetCurrentDirectory(), "InputErrors.log");
    private static string DateTimeStamp = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
    public static Dictionary<int, Dictionary<string, object?>> Parse(IList<Configuration> Configs, IEnumerable<string> TextFileLines)
    {
        var seqdict = new Dictionary<int, Dictionary<string, object?>>();
        var errorLog = new List<string>();
        for (var idx = 0; idx < TextFileLines.Count(); idx++)
        {
            var line = TextFileLines.ElementAtOrDefault<string>(idx);
            try
            {
                var dict = new Dictionary<string, object?>();
                foreach (var cfg in Configs)
                {
                    var str = line!.Substring(cfg.StartPosition, cfg.Length);
                    object? value = cfg.ColumnType switch
                    {
                        Configuration.DataType.String => str,
                        Configuration.DataType.Integer => ParseLong(str.Trim()),
                        Configuration.DataType.Decimal => ParseDecimal(str.Trim()),
                        Configuration.DataType.Boolean => ParseBool(str.Trim()),
                        _ => null
                    };
                    dict.Add(cfg.ColumnName, value);
                }
                seqdict.Add(idx + 1, dict);
            }
            catch (Exception ex)
            {
                errorLog.Add($"{DateTimeStamp} [{line!}] {ex.Message}");
            }
        }
        if(errorLog.Count > 0) {
            File.AppendAllLines(ErrorLogPath, errorLog);
        }
        return seqdict;
    }

    private static long ParseLong(string str)
    {
        long l;
        bool isLong = long.TryParse(str, out l);
        if (!isLong)
            throw new CannotBeConvertedToLongException($"[{str}] cannot be converted to long.");
        return l;
    }
    private static decimal? ParseDecimal(string str)
    {
        decimal d;
        bool isDecimal = decimal.TryParse(str, out d);
        if (!isDecimal)
            throw new CannotBeConvertedToDecimalException($"[{str}] cannot be converted to decimal.");
        return d;
    }
    private static bool? ParseBool(string str)
    {
        bool b;
        bool isBool = bool.TryParse(str, out b);
        if (!isBool)
            throw new CannotBeConvertedToBooleanException($"[{str}] cannot be converted to boolean.");
        return b;
    }
}
