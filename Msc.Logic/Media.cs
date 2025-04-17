namespace Msc.Logic;

public class Media
{
	public Media() { }
	
	public string ConvertFileTypeToString(byte[] nums, bool includeCommas)
	{
		string stringType = "";
		if (includeCommas == false)
		{
			foreach(byte num in nums)
			{
				stringType = string.Concat(stringType, (char)num);
			}
			return stringType;
		}
		else
		{
			return null;
		}
	}
	
	public uint ConvertFileSizeToUint(byte[] bytes, bool usePadding)
	{
		string[] binaryStrings = bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray();
		string[] reversedBinaryStrings = binaryStrings.Reverse().ToArray();
		
		string combined = string.Join("", reversedBinaryStrings);
		uint fileSize = Convert.ToUInt32(combined, 2);
		
		
		return fileSize;
	}
	
	public string SimplifyFileSize(uint fileSize)
	{
		string fileSizeSimple = "";
		switch (fileSize)
		{
			case var size when size >= 1_000_000_000:
				fileSizeSimple = (size / 1_000_000_000.0).ToString("F1") + " GB";
				break;
			case var size when size >= 1_000_000:
				fileSizeSimple = (size / 1_000_000.0).ToString("F1") + " MB";
				break;
			case var size when size >= 1_000:
				fileSizeSimple = (size / 1_000.0).ToString("F1") + " KB";
				break;
			default:
				fileSizeSimple = fileSize.ToString("F1") + " Bytes";
				break;
		}
		
		return fileSizeSimple;
	
	}
	
	public string ConvertDataToIntsWithCommas(byte[] bytes, bool usePadding)
	{
		string combined = "";
		string[] binaryStrings = bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray();
		string[] reversedBinaryStrings = binaryStrings.Reverse().ToArray();
		
		combined = string.Join(", ", reversedBinaryStrings);
		
		
		return combined;
	}
	
}