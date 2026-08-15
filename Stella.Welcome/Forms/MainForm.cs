using System.Diagnostics;
using System.Runtime.InteropServices;
using InfoBeforeStart.Properties;
using NAudio.Wave;
using StellaUtils;
using Timer = System.Windows.Forms.Timer;

namespace InfoBeforeStart.Forms;

internal partial class MainForm : Form
{
	private readonly Timer _autoCloseTimer;
	private readonly Timer _timer;
	private int _displayCount;
	private int _remainingSeconds = 19;

	internal MainForm()
	{
		InitializeComponent();

		_timer = new Timer { Interval = 1000 };
		_timer.Tick += Timer_Tick;
		_timer.Start();

		_autoCloseTimer = new Timer { Interval = 1000 };
		_autoCloseTimer.Tick += AutoCloseTimer_Tick;
		_autoCloseTimer.Start();

		TimeSpan time = TimeSpan.FromSeconds(_remainingSeconds);
		label4.Text = string.Format(Resources.ThisInformationWillDisappearIn_, $"{time.Seconds:D2}");
	}

	[LibraryImport("user32.dll")]
	private static partial void SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

	private void Timer_Tick(object? sender, EventArgs e)
	{
		if (_displayCount < 3)
		{
			_displayCount++;
		}
		else
		{
			_timer.Stop();
			_timer.Dispose();
		}
	}

	private void AutoCloseTimer_Tick(object? sender, EventArgs e)
	{
		_remainingSeconds--;
		if (_remainingSeconds >= 0)
		{
			TimeSpan time = TimeSpan.FromSeconds(_remainingSeconds);
			label4.Text = string.Format(Resources.ThisInformationWillDisappearIn_, $"{time.Seconds:D2}");
		}
		else
		{
			label4.Text = Resources.Closing;
			_autoCloseTimer.Stop();
			Application.Exit();
		}
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		SetWindowPos(Handle, -1, 0, 0, 0, 0, 0x0002 | 0x0001);
	}

	// Sound Effect from Pixabay: https://pixabay.com/sound-effects/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=47485
	private async void Meow_Click(object sender, EventArgs e)
	{
		Random random = new();
		var mp3FilePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "sounds", "meows", $"{random.Next(1, 5)}.mp3");
		if (!File.Exists(mp3FilePath)) return;

		try
		{
			await using AudioFileReader audioFile = new(mp3FilePath);
			await using WaveChannel32 volumeStream = new(audioFile);
			using WaveOut outputDevice = new();
			outputDevice.Init(volumeStream);
			outputDevice.Play();

			await Task.Delay(TimeSpan.FromSeconds(audioFile.TotalTime.TotalSeconds));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void ViewDocs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(new ProcessStartInfo($"{Variables.Website}/docs?page=terms-of-use") { UseShellExecute = true });

		linkLabel3.Text = Resources.ViewDocs_TakeAMomentToReviewTheContentsOfThisInformation;
		linkLabel3.LinkBehavior = LinkBehavior.NeverUnderline;
		linkLabel3.Links.Clear();
	}
}
