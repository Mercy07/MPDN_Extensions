using System.Windows.Forms;
using Mpdn.Config;

namespace Mpdn.PlayerExtensions.Playlist
{
    public partial class PlaylistConfigDialog : PlaylistConfigBase
    {
        public PlaylistConfigDialog()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            var tt = new ToolTip();
            tt.SetToolTip(btn_clearPreviouslyPlayedFiles, "Clear previously played file(s)");
        }

        protected override void LoadSettings()
        {
            cb_showPlaylistOnStartup.Checked = Settings.ShowPlaylistOnStartup;
            cb_autoplay.Checked = Settings.AutomaticallyPlayFileOnStartup;
            cb_rememberWindowBounds.Checked = Settings.RememberWindowBounds;
            cb_rememberPreviouslyPlayedFiles.Checked = Settings.RememberPreviouslyPlayedFiles;
            cb_addFileToPlaylistOnOpen.Checked = Settings.AddFileToPlaylistOnOpen;
            cb_playNextFileInDirectoryAfterPlayback.Checked = Settings.PlayNextFileInDirectoryAfterPlayback;

            if (Settings.PlaylistPathDisplay == "FullPath")
            {
                rb_displayFullPath.Checked = true;
            }
            else if (Settings.PlaylistPathDisplay == "FilenameOnly")
            {
                rb_displayFileNameOnly.Checked = true;
            }
        }

        protected override void SaveSettings()
        {
            Settings.ShowPlaylistOnStartup = cb_showPlaylistOnStartup.Checked;
            Settings.AutomaticallyPlayFileOnStartup = cb_autoplay.Checked;
            Settings.RememberWindowBounds = cb_rememberWindowBounds.Checked;
            Settings.RememberPreviouslyPlayedFiles = cb_rememberPreviouslyPlayedFiles.Checked;
            Settings.AddFileToPlaylistOnOpen = cb_addFileToPlaylistOnOpen.Checked;
            Settings.PlayNextFileInDirectoryAfterPlayback = cb_playNextFileInDirectoryAfterPlayback.Checked;
            
            if (rb_displayFullPath.Checked)
            {
                Settings.PlaylistPathDisplay = "FullPath";
            }
            else if (rb_displayFileNameOnly.Checked)
            {
                Settings.PlaylistPathDisplay = "FilenameOnly";
            }
        }

        private void btn_clearPreviouslyPlayedFiles_Click(object sender, System.EventArgs e)
        {
            Settings.PreviouslyPlayedFiles.Clear();
        }
    }

    public class PlaylistConfigBase : ScriptConfigDialog<PlaylistSettings>
    {
        
    }
}
