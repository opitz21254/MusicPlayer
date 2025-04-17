namespace Msc.Logic;

public class Media
{
	public Media() { }
	
	public string ConvertFileTypeToString(byte[] nums, bool isLast)
	{
		string stringType = "";
		if (isLast == false)
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
	
	public string ConvertFileSizeToUint(byte[] bytes, bool isLast)
	{
		string fileSizeSimple = "";
		if (isLast)
		{
			return "No Value";
		}
		
		string[] binaryStrings = bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray();
		string[] reversedBinaryStrings = binaryStrings.Reverse().ToArray();
		
		string combined = string.Join("", reversedBinaryStrings);
		uint fileSize = Convert.ToUInt32(combined, 2);
		
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
}