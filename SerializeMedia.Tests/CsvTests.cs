using SerializeMedia.Csv;
using Xunit;

namespace SerializeMedia.Tests;

public class CsvTests
{
    class InputData
    {
        public int i1, i2, i3, i4, i5;
        public InputData() { }
        public static InputData Get() => new InputData() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };

        public string ToCsvString(string separator)
        {
            return $"{i1}{separator}{i2}{separator}{i3}{separator}{i4}{separator}{i5}{separator}";
        } 
        
        public string CsvHeader(string separator)
        {
            return $"i1{separator}i2{separator}i3{separator}i4{separator}i5{separator}";
        } 
    }

    [Fact]
    public void SerializeOneObjectToCsv()
    {
        //arrange
        var data = InputData.Get();
        var csvMedia = new CsvMedia<InputData>();
        var csvFormat = csvMedia.Format;
        var expected = (csvFormat.AutoHeader ? data.CsvHeader(csvFormat.ValueSeparator) + csvFormat.RowSeparator : "") 
            + data.ToCsvString(csvFormat.ValueSeparator) 
            + csvFormat.RowSeparator;
        //act
        var media = csvMedia.AddContentToMedia(data);
        var actual = media.TranslateToString();
        //assert
        Assert.Equal(expected, actual);
    }
}