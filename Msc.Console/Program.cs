
//public string ChunkID { get; set; }        // "RIFF"
//public uint ChunkSize { get; set; }        // File size - 8
//public string Format { get; set; }         // "WAVE"
//public string Subchunk1ID { get; set; }    // "fmt "
//public uint Subchunk1Size { get; set; }    // 16 for PCM
//public ushort AudioFormat { get; set; }    // 1 = PCM
//public ushort NumChannels { get; set; }    // 1 (Mono), 2 (Stereo)
//public uint SampleRate { get; set; }       // 44100, 48000, etc.
//public uint ByteRate { get; set; }         // SampleRate * NumChannels * BitsPerSample/8
//public ushort BlockAlign { get; set; }     // NumChannels * BitsPerSample/8
//public ushort BitsPerSample { get; set; }  // 8, 16, 24, 32
//public string Subchunk2ID { get; set; }    // "data"
//public uint Subchunk2Size { get; set; }    // Size of audio data
//public byte[] Data { get; set; }           // Raw audio samples


// Open WAV file
using (FileStream fs = new FileStream("piano2.wav", FileMode.Open))
using (BinaryReader reader = new BinaryReader(fs))
{
    // Read header (e.g., RIFF chunk)
    var byteHeader = reader.ReadBytes(44); // WAV header is typically 44 bytes


    for (int i = 0; i < 44; i++)
    {
        switch (i)
        {
            case < 3: //First 4 nums but 0 indexed
            Console.Write((char)byteHeader[i]); // Convert byte to binary string
//              Console.Write((int)byteHeader[i] + ", ");  // Convert byte to binary string
                break;
            case 3:
            Console.WriteLine((char)byteHeader[i]);
//              Console.WriteLine((int)byteHeader[i]);  // Convert byte to binary string
                break;
            case < 8:
                //File size minus 8 bytes
                Console.WriteLine((int)byteHeader[i] + ", ");
                break;
            case < 11:
                //"WAVE" format, which is a subtype of RIFF
                Console.Write((char)byteHeader[i]);
                break;
            case 11:
                Console.WriteLine((char)byteHeader[i]);
                break;
            case < 15:
                //Start of the "fmt_" (format) subchunk
                Console.Write((char)byteHeader[i]);
                break;
            case 15:
                Console.WriteLine((char)byteHeader[i]);
                break;
            case < 19:
                //Size of the format subchunk (16 bytes)
                Console.Write(Convert.ToString((int)byteHeader[i]) + ", ");
                break;
            case 19:
                Console.WriteLine(Convert.ToString((int)byteHeader[i]));
                break;
            case 20:
                //Audio Format Code:
                Console.Write(Convert.ToString((int)byteHeader[i]) + ", ");
                break;
            case 21:
                Console.WriteLine(Convert.ToString((int)byteHeader[i]));
                break;
            case 22:
                //Number of channels:
                Console.Write(Convert.ToString((int)byteHeader[i]) + ", ");
                break;
            case 23:
                Console.WriteLine(Convert.ToString((int)byteHeader[i]));
                break;
            case < 27:
                //Sample Rate
                Console.Write(Convert.ToString((int)byteHeader[i]) + ", ");
                break;
            case 27:
                Console.WriteLine(Convert.ToString((int)byteHeader[i]));
                break;
            case < 30:
                //Byte Rate
                Console.Write(Convert.ToString((int)byteHeader[i]) + ", ");
                break;
            case 31:
                Console.WriteLine(Convert.ToString((int)byteHeader[i]));
                break;
            case 32:
                //Number of bytes for one sample including all channels
                Console.Write(Convert.ToString((int)byteHeader[i]) + ", ");
                break;
            case 33:
                Console.WriteLine(Convert.ToString((int)byteHeader[i]));
                Console.Write("Number of bits per sample (16 bits): ");
                break;
            case 34:
                //Number of bits per sample (16 bits)
                Console.Write(Convert.ToString((int)byteHeader[i]) + ", ");
                break;
            case 35:
                Console.WriteLine(Convert.ToString((int)byteHeader[i]));
                break;
            case < 39:
                //Start of the "data" subchunk,
                Console.Write((char)byteHeader[i] + ", ");
                break;
            case 39:
                Console.WriteLine((char)byteHeader[i]);
                Console.Write("Size of the \"data\" subchunk: ");
                break;
            case < 43:
                //Size of the "data" subchunk,
                Console.Write(Convert.ToString((int)byteHeader[i]) + ", ");
                break;
            case 43:
                Console.WriteLine(Convert.ToString((int)byteHeader[i]));
                break;
            default:
                break;
        }
    }
    Console.WriteLine("\nHeader printed successfully!");
}

//static uint BytesToInt32(byte[] bytes)
//{
//  if (bytes == null || bytes.Length != 4)
//  {
//      throw new ArgumentException("Byte array must be 4 bytes long.");
//  }
//
//  //Reverse Byte order (Little Endian)
//  Array.Reverse(bytes);
//  uint output = 0;
//
//  
//  return output;
//}

//static uint OneByteToInt32()
//{
//  private char[] 
//  //Process each byte
//  for (int i = 0; i < bytes.Length; i++)
//  {
//      // char[] letters = bytes[i].ToString().ToCharArray();
//      // for (int j = 0; j < letters.Length; j++)
//      // {
//      //     double result = Math.Pow(2, i + j);
//      //     Console.Write(result + ", ");
//      // }
//      Console.Write(Convert.ToString((int)bytes[i]) + ", ");
//  }
//}
    