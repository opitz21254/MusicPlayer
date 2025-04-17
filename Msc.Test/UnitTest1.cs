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
            _fileHeader = reader.ReadBytes(48);
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
        byte[] byteArrUnderTest = _fileHeader[4..8].ToArray();
        
        // Act
        uint num = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        string result = _media.SimplifyFileSize(num);
        
        // Assert
        result.ShouldBe("1.2 MB");
        
    }
    
    [Test]
    public void TestStringFileType2()
    {
        // ARRANGE
        byte[] byteArrUnderTest =_fileHeader.Take(8..12).ToArray();
        
        // Act
        string? result = _media?.ConvertFileTypeToString(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe("WAVE");
    }
    
    [Test]
    public void TestStringFileType3()
    {
        // ARRANGE
        byte[] byteArrUnderTest = _fileHeader.Take(12..16).ToArray();
        
        // Act
        string? result = _media?.ConvertFileTypeToString(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe("fmt ");
    }
    
    [Test]
    public void Subchunk1SizeFmt()
    {
        // Arrange
        byte[] byteArrUnderTest = _fileHeader[16..20].ToArray();
        
        // Act
        uint result = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe(16u);
    }
    
    [Test]
    public void CompressionType()
    {
        // Arrange
        byte[] byteArrUnderTest = _fileHeader[20..22].ToArray();
        
        // Act
        uint result = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe(1u);
    }
    
    [Test]
    public void MonOrStereo()
    {
        // Arrange
        byte[] byteArrUnderTest = _fileHeader[22..24].ToArray();
        
        // Act
        uint result = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe(2u);
    }
    
    [Test]
    public void SamplesPerSecond()
    {
        // Arrange
        byte[] byteArrUnderTest = _fileHeader[24..28].ToArray();

        // Act
        uint result = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe(48000u);
    }
    
    [Test]
    public void BytesPerSecond()
    {
        // Arrange
        byte[] byteArrUnderTest = _fileHeader[28..32].ToArray();
        
        // Act
        uint result = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe(192000u);
    }
    
    [Test]
    public void BytesPerSampleFrame()
    {
        // Arrange
        byte[] byteArrUnderTest = _fileHeader[32..34].ToArray();
        
        // Act
        uint result = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe(4u);
    }
    
    [Test]
    public void BitsPerSample()
    {
        // Arrange
        byte[] byteArrUnderTest = _fileHeader[34..36].ToArray();
        
        // Act
        uint result = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe(16u);
    }
    
    [Test]
    public void TestDataChunkID()
    {
        // Arrange – bytes 36 to 39 should be "data"
        byte[] byteArrUnderTest = _fileHeader[36..40].ToArray();
        
        // Act
        string? result = _media?.ConvertFileTypeToString(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe("data");
    }
    
    
    [Test]
    public void Subchunk2Size()
    {
        // Arrange
        byte[] byteArrUnderTest = _fileHeader[40..44].ToArray();
        
        // Act
        uint result = _media.ConvertFileSizeToUint(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe(1210848u);
    }
    
    
    [Test]
    public void RealMusicData()
    {
        // Arrange
        byte[] byteArrUnderTest = _fileHeader[44..48].ToArray();
        
        // Act
        string result = _media.ConvertDataToIntsWithCommas(byteArrUnderTest, false);
        
        // Assert
        result.ShouldBe("hi");
    }
}