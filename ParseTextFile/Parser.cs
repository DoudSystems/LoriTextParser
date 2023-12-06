using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Lori.Parser;

namespace ParseTextFile;

public class ParseText
{
    public static Dictionary<int, Dictionary<string, object?>> Parse(IList<Configuration> Configs, IEnumerable<string> TextFileLines)
    {
        var seqdict = new Dictionary<int, Dictionary<string, object?>>();
        for (var idx = 0; idx < TextFileLines.Count(); idx++)
        {
            var line = TextFileLines.ElementAtOrDefault<string>(idx);
            var dict = new Dictionary<string, object?>();
            foreach (var cfg in Configs)
            {
                var str = line!.Substring(cfg.StartPosition, cfg.Length);
                object? value = cfg.ColumnType switch
                {
                    Configuration.DataType.String => str,
                    Configuration.DataType.Integer => Convert.ToInt32(str.Trim()),
                    Configuration.DataType.Decimal => Convert.ToDecimal(str.Trim()),
                    Configuration.DataType.Boolean => Convert.ToBoolean(str.Trim()),
                    _ => null
                };
                dict.Add(cfg.ColumnName, value);
            }
            seqdict.Add(idx + 1, dict);
        }
        return seqdict;
    }
}
