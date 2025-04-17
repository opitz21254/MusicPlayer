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
	
	public uint ConvertFileSizeToUint(byte[] bytes, bool isLast)
	{
		if (isLast)
		{
			return UInt32.MinValue;
		}
		
		string[] binaryStrings = bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray();
		string[] reversedBinaryStrings = binaryStrings.Reverse().ToArray();
		
		string combined = string.Join("", reversedBinaryStrings);
		uint fileSize = Convert.ToUInt32(combined, 2);
		
		return fileSize;
	}
}