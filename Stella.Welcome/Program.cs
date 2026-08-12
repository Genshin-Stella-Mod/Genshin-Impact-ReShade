using System.Globalization;
using System.Reflection;
using InfoBeforeStart.Forms;
using InfoBeforeStart.Properties;
using NLog;
using StellaUtils;

namespace InfoBeforeStart;

internal static class Program
{
	// App
	private static readonly string AppName = Assembly.GetExecutingAssembly().GetName().Name!;
	private static readonly string AppVersion = Assembly.GetExecutingAssembly().GetName().Version!.ToString();
	private static readonly string? AppPath = AppDomain.CurrentDomain.BaseDirectory;

	// Other
	private static readonly string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Genshin Stella Mod");
	private static readonly IniFile Settings = new(Path.Combine(AppData, "settings.ini"));

	// Logger
	private static Logger _logger = null!;

	[STAThread]
	private static void Main()
	{
		// Ensure the settings/log directory exists before anything tries to read or write into it
		if (!Directory.Exists(AppData)) Directory.CreateDirectory(AppData);

		// Prepare NLog
		LogManagerHelper.Initialize(Path.Combine(AppPath!, "NLog.config"), AppName, AppVersion);
		_logger = LogManagerHelper.GetLogger();

		// Set the correct language
		var currentLang = Settings.ReadString("Language", "UI");
		_logger.Info($"Loaded language from settings: {currentLang}");
		if (!Variables.SupportedLangs.Contains(currentLang))
		{
			var sysLang = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
			currentLang = Array.Find(Variables.SupportedLangs, lang => lang == sysLang) ?? "en";
			_logger.Info($"System language detected: {sysLang}. Using: {currentLang}");
			Settings.WriteString("Language", "UI", currentLang);
		}
		else
		{
			_logger.Info($"Using supported language: {currentLang}");
		}

		try
		{
			CultureInfo culture = new(currentLang);
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = culture;
			_logger.Info($"Application culture set to: {culture.Name}");
		}
		catch (CultureNotFoundException)
		{
			_logger.Error($"CultureNotFoundException! Invalid language detected: {currentLang}; Falling back to English...");
			CultureInfo fallback = new("en");
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = fallback;
		}

		ApplicationConfiguration.Initialize();
		Application.ThreadException += (_, e) => _logger.Error(e.Exception);
		AppDomain.CurrentDomain.UnhandledException += (_, e) => _logger.Error((Exception)e.ExceptionObject);

		try
		{
			Application.Run(new MainForm());

			_logger.Info("Application.Run(): new MainWindow");
		}
		catch (Exception ex)
		{
			_logger.Error(ex);

			MessageBox.Show(ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
