using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mpdn.PlayerExtensions.Playlist
{
    public class Playlist : PlayerExtension<PlaylistSettings, PlaylistConfigDialog>
    {
        private const string Subcategory = "Playlist";

        private readonly PlaylistForm form = new PlaylistForm();
        
        private Form mpdnForm;
        private Point mpdnStartLocation;
        private Point formStartLocation;
        private bool moving;

        public PlaylistForm GetPlaylistForm
        {
            get { return form; }
        }

        public override ExtensionUiDescriptor Descriptor
        {
            get
            {
                return new ExtensionUiDescriptor
                {
                    Guid = new Guid("A1997E34-D67B-43BB-8FE6-55A71AE7184B"),
                    Name = "Playlist",
                    Description = "Adds playlist support with advanced capabilities",
                    Copyright = "Enhanced by Garteal"
                };
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            form.Setup(this);

            PlayerControl.PlayerStateChanged += OnPlayerStateChanged;
            PlayerControl.PlaybackCompleted += OnPlaybackCompleted;
            PlayerControl.FormClosed += OnFormClosed;
            PlayerControl.DragEnter += OnDragEnter;
            PlayerControl.DragDrop += OnDragDrop;
            PlayerControl.CommandLineFileOpen += OnCommandLineFileOpen;
            mpdnForm = PlayerControl.Form;
            mpdnForm.Move += OnMpdnFormMove;
            mpdnForm.MainMenuStrip.MenuActivate += OnMpdnFormMainMenuActivated;
            form.Move += OnFormMove;
            
            if (Settings.RememberWindowBounds)
            {
                form.RememberWindowBounds = Settings.RememberWindowBounds;
                form.WindowBounds = Settings.WindowBounds;
            }

            if (Settings.ShowPlaylistOnStartup)
            {
                form.Show(PlayerControl.VideoPanel);
            }

            if (!String.IsNullOrEmpty(Settings.PlaylistPathDisplay))
            {
                form.PlaylistPathDisplay = Settings.PlaylistPathDisplay;
            }

            if (Settings.AutomaticallyPlayFileOnStartup)
            {
                form.AutomaticallyPlayFileOnStartup = Settings.AutomaticallyPlayFileOnStartup;
            }

            if (Settings.RememberPreviouslyPlayedFile)
            {
                form.RememberLastPlayedFile = Settings.RememberPreviouslyPlayedFile;
                string[] files = { Settings.LastPlayedFile };
                form.AddFiles(files);
            }
        }

        public void Reinitialize()
        {
            form.PlaylistPathDisplay = Settings.PlaylistPathDisplay;
            form.PlayNextFileInDirectoryAfterPlayback = Settings.PlayNextFileInDirectoryAfterPlayback;
            form.AutomaticallyPlayFileOnStartup = Settings.AutomaticallyPlayFileOnStartup;
        }

        public override void Destroy()
        {
            PlayerControl.PlayerStateChanged -= OnPlayerStateChanged;
            PlayerControl.PlaybackCompleted -= OnPlaybackCompleted;
            PlayerControl.FormClosed -= OnFormClosed;
            PlayerControl.DragEnter -= OnDragEnter;
            PlayerControl.DragDrop -= OnDragDrop;
            PlayerControl.CommandLineFileOpen -= OnCommandLineFileOpen;
            mpdnForm.Move -= OnMpdnFormMove;
            mpdnForm.MainMenuStrip.MenuActivate -= OnMpdnFormMainMenuActivated;
            form.Move -= OnFormMove;

            base.Destroy();
            form.Dispose();
        }

        private void OnMpdnFormMainMenuActivated(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mpdnForm.MainMenuStrip.Items)
            {
                if (item.DropDownItems[0].Name == "mmenuQuickOpen")
                {
                    item.DropDownItems[0].Click -= OnMpdnFormOpenClick;
                    item.DropDownItems[0].Click += OnMpdnFormOpenClick;
                }

                if (item.DropDownItems[1].Name == "openToolStripMenuItem")
                {
                    item.DropDownItems[1].Click -= OnMpdnFormOpenClick;
                    item.DropDownItems[1].Click += OnMpdnFormOpenClick;
                }
            }
        }

        private void OnMpdnFormOpenClick(object sender, EventArgs e)
        {
            NewPlaylist();
        }

        private void OnPlayerStateChanged(object sender, EventArgs e)
        {
            if (PlayerControl.PlayerState == PlayerState.Playing)
            {
                if (form.CurrentItem != null && form.CurrentItem.FilePath != "")
                {
                    Settings.LastPlayedFile = form.CurrentItem.FilePath;
                }
            }

            if (Settings.AddFileToPlaylistOnOpen)
            {
                SetActiveFile();
            }
        }

        private void OnPlaybackCompleted(object sender, EventArgs e)
        {
            if (Settings.AddFileToPlaylistOnOpen && form.Playlist.Count > 1)
            {
                AddFileToPlaylist();
            }
            if (Settings.PlayNextFileInDirectoryAfterPlayback)
            {
                PlayNextInFolder();
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            Settings.WindowBounds = form.Bounds;
        }

        private void OnFormMove(object sender, EventArgs e)
        {
            if (moving)
                return;

            mpdnStartLocation = PlayerControl.Form.Location;
            formStartLocation = form.Location;
        }

        private void OnMpdnFormMove(object sender, EventArgs e)
        {
            moving = true;
            form.Left = formStartLocation.X + PlayerControl.Form.Location.X - mpdnStartLocation.X;
            form.Top = formStartLocation.Y + PlayerControl.Form.Location.Y - mpdnStartLocation.Y;
            moving = false;
        }

        public override IList<Verb> Verbs
        {
            get
            {
                return new[]
                {
                    new Verb(Category.File, string.Empty, "Open Playlist", "Ctrl+Alt+O", string.Empty, OpenPlaylist),
                    new Verb(Category.File, string.Empty, "Add file to playlist", "Ctrl+Alt+A", string.Empty, AddFileToPlaylist),
                    new Verb(Category.View, string.Empty, "Playlist", "Ctrl+Alt+P", string.Empty, ViewPlaylist),
                    new Verb(Category.Play, Subcategory, "Next", "Ctrl+Alt+N", string.Empty, () => form.PlayNext()),
                    new Verb(Category.Play, Subcategory, "Previous", "Ctrl+Alt+B", string.Empty, () => form.PlayPrevious())
                };
            }
        }

        public static bool IsPlaylistFile(string filename)
        {
            var extension = Path.GetExtension(filename);
            return extension != null && extension.ToLower() == ".mpl";
        }

        private void SetActiveFile()
        {
            if (PlayerControl.PlayerState != PlayerState.Playing || form.Playlist.Count > 1) return;
            if (string.IsNullOrEmpty(PlayerControl.MediaFilePath)) return;

            if (form.CurrentItem != null && form.CurrentItem.FilePath != PlayerControl.MediaFilePath)
            {
                form.ActiveFile(PlayerControl.MediaFilePath);
            }
            else if (form.CurrentItem == null)
            {
                form.ActiveFile(PlayerControl.MediaFilePath);
            }
        }

        private void PlayNextInFolder()
        {
            if (PlayerControl.MediaPosition != PlayerControl.MediaDuration) return;
            form.PlayNextFileInDirectory();
        }

        private void AddFileToPlaylist()
        {
            if (string.IsNullOrEmpty(PlayerControl.MediaFilePath)) return;
            var foundFile = form.Playlist.Find(i => i.FilePath == PlayerControl.MediaFilePath);
            if (foundFile != null) return;
            form.AddActiveFile(PlayerControl.MediaFilePath);
        }

        private void NewPlaylist()
        {
            form.NewPlaylist();
        }

        private void OpenPlaylist()
        {
            form.Show(PlayerControl.VideoPanel);
            form.OpenPlaylist();
        }

        private void ViewPlaylist()
        {
            form.Show(PlayerControl.VideoPanel);
        }

        public string GetDirectoryName(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            return Path.GetDirectoryName(path) ?? Path.GetPathRoot(path);
        }

        public IEnumerable<string> GetMediaFiles(string mediaDir)
        {
            var files = Directory.EnumerateFiles(mediaDir)
                .OrderBy(filename => filename).Where(file => form.openFileDialog.Filter.Contains(Path.GetExtension(file)));
            return files;
        }

        private void OnDragEnter(object sender, PlayerControlEventArgs<DragEventArgs> e)
        {
            e.Handled = true;
            e.InputArgs.Effect = DragDropEffects.Copy;
        }

        private void OnDragDrop(object sender, PlayerControlEventArgs<DragEventArgs> e)
        {
            var files = (string[])e.InputArgs.Data.GetData(DataFormats.FileDrop);

            if (files.Length == 1)
            {
                var filename = files[0];

                if (Directory.Exists(filename))
                {
                    var media = GetMediaFiles(filename);
                    form.ClearPlaylist();
                    form.AddFiles(media.ToArray());
                    form.SetPlaylistIndex(0);
                    return;
                }
                else if (IsPlaylistFile(filename))
                {
                    form.OpenPlaylist(filename);
                    return;
                }

                form.ActiveFile(filename);
                form.SetPlaylistIndex(0);
            }
            else
            {
                form.AddFiles(files);
                form.SetPlaylistIndex(0);
            }

            e.Handled = true;
        }

        private void OnCommandLineFileOpen(object sender, CommandLineFileOpenEventArgs e)
        {
            if (!IsPlaylistFile(e.Filename)) return;
            e.Handled = true;
            form.OpenPlaylist(e.Filename);
        }
    }

    public class PlaylistSettings
    {
        public bool ShowPlaylistOnStartup { get; set; }
        public bool AutomaticallyPlayFileOnStartup { get; set; }
        public bool AddFileToPlaylistOnOpen { get; set; }
        public bool RememberWindowBounds { get; set; }
        public bool RememberPreviouslyPlayedFile { get; set; }
        public bool PlayNextFileInDirectoryAfterPlayback { get; set; }
        public Rectangle WindowBounds { get; set; }
        public string LastPlayedFile { get; set; }
        public string PlaylistPathDisplay { get; set; }

        public PlaylistSettings()
        {
            ShowPlaylistOnStartup = false;
            AutomaticallyPlayFileOnStartup = false;
            AddFileToPlaylistOnOpen = false;
            RememberWindowBounds = false;
            RememberPreviouslyPlayedFile = false;
            PlayNextFileInDirectoryAfterPlayback = false;
        }
    }
}