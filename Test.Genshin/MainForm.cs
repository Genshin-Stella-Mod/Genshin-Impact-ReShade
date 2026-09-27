namespace GenshinTest;

internal partial class MainForm : Form
{
	internal MainForm()
	{
		InitializeComponent();
		StartPosition = FormStartPosition.Manual;
		Load += Form_Load;
	}

	private void Form_Load(object? sender, EventArgs e)
	{
		int screenWidth = Screen.PrimaryScreen!.WorkingArea.Width;
		int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

		Left = screenWidth - Width;
		Top = screenHeight - Height;
	}
}
