using Microsoft.Win32;
using StellaConfiguration.Properties;
using StellaUtils;

namespace StellaConfiguration.Scripts;

internal static class CheckData
{
	public static bool IsAStellaPlusSubscriber()
	{
		return TryGetRegistryValue("Secret", out string? data) && !string.IsNullOrEmpty(data);
	}

	public static bool ResourcesPath()
	{
		using RegistryKey? key = Registry.CurrentUser.OpenSubKey(Variables.RegistryPath);
		if (key == null) return false;

		string? path = key.GetValue("ResourcesPath") as string;
		return !string.IsNullOrEmpty(path) && Directory.Exists(path) && File.Exists(Path.Combine(path, "data.json"));
	}

	private static bool TryGetRegistryValue(string keyName, out string? value)
	{
		try
		{
			using RegistryKey? key = Registry.CurrentUser.OpenSubKey(Variables.RegistryPath);
			if (key is not null)
			{
				value = key.GetValue(keyName) as string;
				bool data = !string.IsNullOrEmpty(value);
				Program.Logger.Info($"{keyName}: {data}");

				return data;
			}
		}
		catch (Exception ex)
		{
			Program.Logger.Error(ex);
			MessageBox.Show(string.Format(Resources.CheckData_SorryButSomethingWentWrong, ex.Message), Resources.CheckData_FatalError, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		value = null;
		return false;
	}
}
