using Msc.Logic;
using NUnit.Framework;
using Shouldly;

public class MediaTests
{
    private Media _media;
    private byte[] _fileHeader;
    
    [SetUp]
    public void Setup()
    {
        _media = new Media();
        
        //Load file data
        if (!File.Exists("piano2.wav"))
        {
            Assert.Fail("Music file is missing");
        }
        
        using (FileStream fs = new FileStream("piano2.wav", FileMode.Open))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            _fileHeader = reader.ReadBytes(44);
        }
        
    }
    
    [Test]
    public void TestStringFileType()
    {
        // ARRANGE
        byte[] byteArrUnderTest = _fileHeader.Take(4).ToArray();
        
        // Act
        string? result = _media?.ConvertFileTypeToString(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe("RIFF");
    }
    
    [Test]
    public void TestFileSize()
    {
        // Arrange
        // = 
        byte[] byteArrUnderTest = _fileHeader[4..8].ToArray();
        
        // Act
        uint result = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe(1210884u);
        
    }
}
