using System.Runtime.InteropServices;
using System.Text;

namespace StellaConfiguration.Scripts;

public class IniFile
{
	private readonly string _path;

	public IniFile(string path)
	{
		_path = path;
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
	private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
	private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

	public void WriteInt(string section, string key, int value)
	{
		WriteString(section, key, value.ToString());
	}

	public int ReadInt(string section, string key, int defaultValue)
	{
		int.TryParse(ReadString(section, key, defaultValue.ToString()), out int value);
		return value;
	}

	private void WriteString(string section, string key, string value)
	{
		WritePrivateProfileString(section, key, value, _path);
	}

	private string ReadString(string section, string key, string defaultValue)
	{
		StringBuilder sb = new(255);
		GetPrivateProfileString(section, key, defaultValue, sb, 255, _path);
		return sb.ToString();
	}
}
