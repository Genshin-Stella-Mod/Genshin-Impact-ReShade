using System.Reflection;
using CliWrap;
using CliWrap.Buffered;
using StellaConfiguration.Properties;
using StellaConfiguration.Scripts;

namespace StellaConfiguration.Forms;

internal partial class Window : Form
{
	internal static readonly string? AppName = Assembly.GetExecutingAssembly().GetName().Name;
	internal static readonly string AppVersion = Assembly.GetExecutingAssembly().GetName().Version!.ToString();
	internal static readonly string AppPath = AppDomain.CurrentDomain.BaseDirectory;
	private static readonly string AppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Genshin Stella Mod");

	private static readonly string Terminal = Path.Combine(AppPath, "data", "dependencies", "windows-terminal", "wt.exe");
	private static readonly string PrepareCfgPath = Path.Combine(AppData, "prepare-stella.ini");
	private static IniFile _prepareIni = null!;

	private static int _downloadOrUpdateShaders;
	private static int _updateReShadeConfig;
	private static int _deleteReShadeCache;

	internal Window()
	{
		InitializeComponent();
		_prepareIni = new IniFile(PrepareCfgPath);
	}

	private void Main_Load(object sender, EventArgs e)
	{
		// Resources
		var foundResources = CheckData.ResourcesPath();
		if (!foundResources)
		{
			checkBox7.Checked = true;
			checkBox7.Enabled = false;
		}
		else
		{
			var stellaModPlusSubscriber = CheckData.IsAStellaPlusSubscriber();
			if (stellaModPlusSubscriber && foundResources)
			{
				checkBox7.Checked = false;
				checkBox7.Enabled = false;
			}
			else
			{
				checkBox7.Checked = _prepareIni.ReadInt("PrepareStella", "DownloadOrUpdateShaders", 1) != 0;
			}
		}

		checkBox4.Checked = _prepareIni.ReadInt("PrepareStella", "UpdateReShadeConfig", 1) != 0;
		checkBox6.Checked = _prepareIni.ReadInt("PrepareStella", "DeleteReShadeCache", 1) != 0;

		SaveIniData();
	}

	private void Main_FormClosing(object sender, FormClosingEventArgs e)
	{
		SaveIniData();
	}

	private void DownloadOrUpdateShaders(object sender, EventArgs e)
	{
		var foundResources = CheckData.ResourcesPath();
		if (!foundResources && !checkBox7.Checked)
		{
			checkBox7.Checked = true;
			Program.Logger.Error($"The Stella Mod resources was not found: {foundResources}");

			MessageBox.Show(Resources.TheStellaResourcesDirWasNotFoundOnYourPC, AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		}

		_downloadOrUpdateShaders = checkBox7.Checked ? 1 : 0;
	}

	private void UpdateReShadeConfig_CheckedChanged(object sender, EventArgs e)
	{
		_updateReShadeConfig = checkBox4.Checked ? 1 : 0;
	}

	private void DeleteReShadeCache_CheckedChanged(object sender, EventArgs e)
	{
		_deleteReShadeCache = checkBox6.Checked ? 1 : 0;
	}

	private static void SaveIniData()
	{
		_prepareIni.WriteInt("PrepareStella", "DownloadOrUpdateShaders", _downloadOrUpdateShaders);
		_prepareIni.WriteInt("PrepareStella", "UpdateReShadeConfig", _updateReShadeConfig);
		_prepareIni.WriteInt("PrepareStella", "DeleteReShadeCache", _deleteReShadeCache);

		Program.Logger.Info("Saved ini config");
	}

	private async void LetsGo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		SaveIniData();

		var prepareStellaExe = Path.Combine(AppPath, "Prepare Stella Mod.exe");
		string[] requiredFiles = [prepareStellaExe, Terminal];
		foreach (var file in requiredFiles)
			if (!File.Exists(file))
			{
				Program.Logger.Error($"File {file} was not found");
				MessageBox.Show(string.Format(Resources.RequiredFile_WasNotFound, file), AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

		await Cli.Wrap(Terminal)
			.WithArguments(prepareStellaExe)
			.ExecuteBufferedAsync();

		Application.Exit();
	}
}
