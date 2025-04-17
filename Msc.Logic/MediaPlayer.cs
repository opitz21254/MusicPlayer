namespace Msc.Logic;

class MusicFile
{
	public string ChunkID { get; set; }
	public uint ChunkSize { get; set; }
	public string Format { get; set; }
	public string Subchunk1ID { get; set; }
	public uint Subchunk1Size { get; set; }
	public ushort AudioFormat { get; set; }
	public ushort NumChannels { get; set; }
	public uint SampleRate { get; set; }
	public uint ByteRate { get; set; }
	public ushort BlockAlign { get; set; }
	public ushort BitsPerSample { get; set; }
	public string Subchunk2ID { get; set; }
	public uint Subchunk2Size { get; set; }
	
	public byte[] Data { get; set; }
	
	
	public static MusicFile FromHeader(byte[] header)
	{
		var media = new Msc.Logic.Media();
		
		return new MusicFile
		{
			ChunkID = media.ConvertFileTypeToString(header[0..4], false),
			ChunkSize = media.ConvertFileSizeToUint(header[4..8], false),
			Format = media.ConvertFileTypeToString(header[8..12], false),
			Subchunk1ID = media.ConvertFileTypeToString(header[12..16], false),
			Subchunk1Size = media.ConvertFileSizeToUint(header[16..20], false),
			AudioFormat = (ushort)media.ConvertFileSizeToUint(header[20..22], false),
			NumChannels = (ushort)media.ConvertFileSizeToUint(header[22..24], false),
			SampleRate = media.ConvertFileSizeToUint(header[24..28], false),
			ByteRate = media.ConvertFileSizeToUint(header[28..32], false),
			BlockAlign = (ushort)media.ConvertFileSizeToUint(header[32..34], false),
			BitsPerSample = (ushort)media.ConvertFileSizeToUint(header[34..36], false),
			Subchunk2ID = media.ConvertFileTypeToString(header[36..40], false),
			Subchunk2Size = media.ConvertFileSizeToUint(header[40..44], false),

			Data = Array.Empty<byte>();
			
			void LoadMusicFile()
			{
				Data = new Array[ChunkSize - 40];
				for(int i = 0; i < ChunkSize - 40; i++)
				{
					Data[i] = media.ConvertFileTypeToUint(header[44..48]);
				}
			}
		};
	}