using System.Globalization;
using System.Reflection;
using NLog;
using StellaConfiguration.Forms;
using StellaConfiguration.Properties;
using StellaUtils;

namespace StellaConfiguration;

internal static class Program
{
	private static readonly string AppName = Assembly.GetExecutingAssembly().GetName().Name!;
	private static readonly string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Genshin Stella Mod");
	private static readonly IniFile Settings = new(Path.Combine(AppData, "settings.ini"));

	internal static Logger Logger = null!;

	[STAThread]
	private static void Main()
	{
		// Ensure the settings/log directory exists before anything tries to read or write into it
		if (!Directory.Exists(AppData)) Directory.CreateDirectory(AppData);

		LogManagerHelper.Initialize(Path.Combine(Window.AppPath, "NLog.config"), AppName, Window.AppVersion);
		Logger = LogManagerHelper.GetLogger();

		// Set the correct language
		var currentLang = Settings.ReadString("Language", "UI");
		Logger.Info($"Loaded language from settings: {currentLang}");
		(currentLang, var systemCulture) = LanguageResolver.Resolve(currentLang);
		if (systemCulture != null)
		{
			Logger.Info($"System language detected: {systemCulture}. Using: {currentLang}");
			Settings.WriteString("Language", "UI", currentLang);
		}
		else
		{
			Logger.Info($"Using supported language: {currentLang}");
		}

		try
		{
			CultureInfo culture = new(currentLang);
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = culture;
			Logger.Info($"Application culture set to: {culture.Name}");
		}
		catch (CultureNotFoundException)
		{
			Logger.Error($"CultureNotFoundException! Invalid language detected: {currentLang}; Falling back to English...");
			CultureInfo fallback = new("en");
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = fallback;
		}

		// Init
		ApplicationConfiguration.Initialize();
		Application.ThreadException += (_, e) => Logger.Error(e.Exception);
		AppDomain.CurrentDomain.UnhandledException += (_, e) => Logger.Error((Exception)e.ExceptionObject);

		try
		{
			Application.Run(new Window { Icon = ImageResources.cat });

			Logger.Info("Application.Run(): new Window");
		}
		catch (Exception ex)
		{
			Logger.Error(ex);
			MessageBox.Show(ex.Message, Window.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
