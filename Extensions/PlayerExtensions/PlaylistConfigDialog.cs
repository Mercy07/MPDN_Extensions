using System.Windows.Forms;
using Mpdn.Config;

namespace Mpdn.PlayerExtensions.Playlist
{
    public partial class PlaylistConfigDialog : PlaylistConfigBase
    {
        public PlaylistConfigDialog()
        {
            InitializeComponent();
        }

        protected override void LoadSettings()
        {
            cb_showPlaylistOnStartup.Checked = Settings.ShowPlaylistOnStartup;
            cb_automaticallyPlayFileOnStartup.Checked = Settings.AutomaticallyPlayFileOnStartup;
            cb_rememberWindowBounds.Checked = Settings.RememberWindowBounds;
            cb_rememberPlaylist.Checked = Settings.RememberPlaylist;
            cb_addFileToPlaylistOnOpen.Checked = Settings.AddFileToPlaylistOnOpen;
            cb_playNextFileInDirectoryAfterPlayback.Checked = Settings.PlayNextFileInDirectoryAfterPlayback;
        }

        protected override void SaveSettings()
        {
            Settings.ShowPlaylistOnStartup = cb_showPlaylistOnStartup.Checked;
            Settings.AutomaticallyPlayFileOnStartup = cb_automaticallyPlayFileOnStartup.Checked;
            Settings.RememberWindowBounds = cb_rememberWindowBounds.Checked;
            Settings.RememberPlaylist = cb_rememberPlaylist.Checked;
            Settings.AddFileToPlaylistOnOpen = cb_addFileToPlaylistOnOpen.Checked;
            Settings.PlayNextFileInDirectoryAfterPlayback = cb_playNextFileInDirectoryAfterPlayback.Checked;
        }

        private void btn_clearPreviouslyPlayedFiles_Click(object sender, System.EventArgs e)
        {
            Settings.RememberedFiles.Clear();
        }
    }

    public class PlaylistConfigBase : ScriptConfigDialog<PlaylistSettings>
    {
        
    }
}
