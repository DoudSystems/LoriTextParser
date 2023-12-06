namespace Lori.Parser;

public class Configuration {

    public enum DataType { String, Integer, Decimal, Boolean }

    public string ColumnName { get; set; }  = string.Empty;
    public int StartPosition { get; set; } = default;
    public int Length { get; set; } = default;
    public DataType ColumnType { get; set; } = DataType.String;

    public Configuration(string ColumnName, int StartPosition, int Length, DataType ColumnType = DataType.String) {
        this.ColumnName = ColumnName;
        this.StartPosition = StartPosition;
        this.Length = Length;
        this.ColumnType = ColumnType;
    }
    public Configuration() {
    }
}
