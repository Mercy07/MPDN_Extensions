namespace Mpdn.PlayerExtensions.Playlist
{
    partial class PlaylistConfigDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_playNextFileInDirectoryAfterPlayback = new System.Windows.Forms.CheckBox();
            this.cb_autoplay = new System.Windows.Forms.CheckBox();
            this.cb_showPlaylistOnStartup = new System.Windows.Forms.CheckBox();
            this.cb_addFileToPlaylistOnOpen = new System.Windows.Forms.CheckBox();
            this.cb_rememberLastPlayedFile = new System.Windows.Forms.CheckBox();
            this.cb_rememberWindowBounds = new System.Windows.Forms.CheckBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_displayFileNameOnly = new System.Windows.Forms.RadioButton();
            this.rb_displayFullPath = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_playNextFileInDirectoryAfterPlayback);
            this.groupBox1.Controls.Add(this.cb_autoplay);
            this.groupBox1.Controls.Add(this.cb_showPlaylistOnStartup);
            this.groupBox1.Controls.Add(this.cb_addFileToPlaylistOnOpen);
            this.groupBox1.Controls.Add(this.cb_rememberLastPlayedFile);
            this.groupBox1.Controls.Add(this.cb_rememberWindowBounds);
            this.groupBox1.Location = new System.Drawing.Point(189, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General settings";
            // 
            // cb_playNextFileInDirectoryAfterPlayback
            // 
            this.cb_playNextFileInDirectoryAfterPlayback.AutoSize = true;
            this.cb_playNextFileInDirectoryAfterPlayback.Location = new System.Drawing.Point(7, 65);
            this.cb_playNextFileInDirectoryAfterPlayback.Name = "cb_playNextFileInDirectoryAfterPlayback";
            this.cb_playNextFileInDirectoryAfterPlayback.Size = new System.Drawing.Size(209, 17);
            this.cb_playNextFileInDirectoryAfterPlayback.TabIndex = 5;
            this.cb_playNextFileInDirectoryAfterPlayback.Text = "Play next file in directory after playback";
            this.cb_playNextFileInDirectoryAfterPlayback.UseVisualStyleBackColor = true;
            // 
            // cb_autoplay
            // 
            this.cb_autoplay.AutoSize = true;
            this.cb_autoplay.Location = new System.Drawing.Point(7, 19);
            this.cb_autoplay.Name = "cb_autoplay";
            this.cb_autoplay.Size = new System.Drawing.Size(176, 17);
            this.cb_autoplay.TabIndex = 4;
            this.cb_autoplay.Text = "Automatically play file on startup";
            this.cb_autoplay.UseVisualStyleBackColor = true;
            // 
            // cb_showPlaylistOnStartup
            // 
            this.cb_showPlaylistOnStartup.AutoSize = true;
            this.cb_showPlaylistOnStartup.Location = new System.Drawing.Point(6, 134);
            this.cb_showPlaylistOnStartup.Name = "cb_showPlaylistOnStartup";
            this.cb_showPlaylistOnStartup.Size = new System.Drawing.Size(137, 17);
            this.cb_showPlaylistOnStartup.TabIndex = 3;
            this.cb_showPlaylistOnStartup.Text = "Show playlist on startup";
            this.cb_showPlaylistOnStartup.UseVisualStyleBackColor = true;
            // 
            // cb_addFileToPlaylistOnOpen
            // 
            this.cb_addFileToPlaylistOnOpen.AutoSize = true;
            this.cb_addFileToPlaylistOnOpen.Location = new System.Drawing.Point(7, 42);
            this.cb_addFileToPlaylistOnOpen.Name = "cb_addFileToPlaylistOnOpen";
            this.cb_addFileToPlaylistOnOpen.Size = new System.Drawing.Size(153, 17);
            this.cb_addFileToPlaylistOnOpen.TabIndex = 2;
            this.cb_addFileToPlaylistOnOpen.Text = "On file open, add to playlist";
            this.cb_addFileToPlaylistOnOpen.UseVisualStyleBackColor = true;
            // 
            // cb_rememberLastPlayedFile
            // 
            this.cb_rememberLastPlayedFile.AutoSize = true;
            this.cb_rememberLastPlayedFile.Location = new System.Drawing.Point(6, 111);
            this.cb_rememberLastPlayedFile.Name = "cb_rememberLastPlayedFile";
            this.cb_rememberLastPlayedFile.Size = new System.Drawing.Size(177, 17);
            this.cb_rememberLastPlayedFile.TabIndex = 1;
            this.cb_rememberLastPlayedFile.Text = "Remember previously played file";
            this.cb_rememberLastPlayedFile.UseVisualStyleBackColor = true;
            // 
            // cb_rememberWindowBounds
            // 
            this.cb_rememberWindowBounds.AutoSize = true;
            this.cb_rememberWindowBounds.Location = new System.Drawing.Point(6, 88);
            this.cb_rememberWindowBounds.Name = "cb_rememberWindowBounds";
            this.cb_rememberWindowBounds.Size = new System.Drawing.Size(192, 17);
            this.cb_rememberWindowBounds.TabIndex = 0;
            this.cb_rememberWindowBounds.Text = "Remember playlist size and position";
            this.cb_rememberWindowBounds.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_save.Location = new System.Drawing.Point(22, 146);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(99, 146);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_displayFileNameOnly);
            this.groupBox2.Controls.Add(this.rb_displayFullPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 67);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Playlist display";
            // 
            // rb_displayFileNameOnly
            // 
            this.rb_displayFileNameOnly.AutoSize = true;
            this.rb_displayFileNameOnly.Location = new System.Drawing.Point(6, 41);
            this.rb_displayFileNameOnly.Name = "rb_displayFileNameOnly";
            this.rb_displayFileNameOnly.Size = new System.Drawing.Size(123, 17);
            this.rb_displayFileNameOnly.TabIndex = 1;
            this.rb_displayFileNameOnly.TabStop = true;
            this.rb_displayFileNameOnly.Text = "Display filename only";
            this.rb_displayFileNameOnly.UseVisualStyleBackColor = true;
            // 
            // rb_displayFullPath
            // 
            this.rb_displayFullPath.AutoSize = true;
            this.rb_displayFullPath.Location = new System.Drawing.Point(6, 19);
            this.rb_displayFullPath.Name = "rb_displayFullPath";
            this.rb_displayFullPath.Size = new System.Drawing.Size(99, 17);
            this.rb_displayFullPath.TabIndex = 0;
            this.rb_displayFullPath.TabStop = true;
            this.rb_displayFullPath.Text = "Display full path";
            this.rb_displayFullPath.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Playlist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Playlist with advanced capabilities\r\nThanks to Zach, ryrynz, mrcorbo";
            // 
            // PlaylistConfigDialog
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 178);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaylistConfigDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Playlist Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_rememberWindowBounds;
        private System.Windows.Forms.CheckBox cb_addFileToPlaylistOnOpen;
        private System.Windows.Forms.CheckBox cb_rememberLastPlayedFile;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.CheckBox cb_autoplay;
        private System.Windows.Forms.CheckBox cb_showPlaylistOnStartup;
        private System.Windows.Forms.CheckBox cb_playNextFileInDirectoryAfterPlayback;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_displayFileNameOnly;
        private System.Windows.Forms.RadioButton rb_displayFullPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}