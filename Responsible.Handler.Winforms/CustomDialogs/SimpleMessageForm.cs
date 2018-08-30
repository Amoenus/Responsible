﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace Responsible.Handler.Winforms.CustomDialogs
{
    internal class SimpleMessageForm : Form
    {
        private PictureBox _pictureBox;
        private Panel _topPanel;
        private Panel _titlePanel;
        private Label _titleLabel;
        private Panel _panelDetail;
        private Panel _bottomPanel;
        private Panel _messagePanel;
        private RoundedButton _okRoundedButton;
        private TextBox _messageTextBox;

        private readonly string _title;
        private readonly string _message;
        private readonly Bitmap _gifImage;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public SimpleMessageForm(string title, string message, Bitmap gifImage, Color okButtonColour)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            _okRoundedButton.ButtonPenColour = okButtonColour;

            _title = title;
            _message = message;
            _gifImage = gifImage;
        }

        private async void AnimateAsync()
        {
            await Task.Run(() => Task.Delay(TimeSpan.FromSeconds(0.5)));
            await Task.Run(async () => await SetGifAsync());
        }

        private async Task SetGifAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                if (_pictureBox.InvokeRequired)
                {
                    _pictureBox.Invoke(new MethodInvoker(delegate { _pictureBox.Image = _gifImage; }));
                }
                else
                {
                    _pictureBox.Image = _gifImage;
                }
            });
        }

        private void SimpleMessage_Shown(object sender, EventArgs e)
        {
            _titleLabel.Text = _title;
            _messageTextBox.Text = _message;
            SetScrollOnMessageBox();
            AnimateAsync();
        }

        private void SetScrollOnMessageBox()
        {
            var textBoxRect = TextRenderer.MeasureText(_messageTextBox.Text, _messageTextBox.Font,
                new Size(_messageTextBox.Width, _messageTextBox.MaxLength),
                (TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl));

            try
            {
                _messageTextBox.ScrollBars = textBoxRect.Height > _messageTextBox.Height ? ScrollBars.Vertical : ScrollBars.None;
            }
            catch (Exception)
            {
                //ignored
            }
        }

        private void OkRoundedButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeComponent()
        {
            _topPanel = new Panel();
            _pictureBox = new PictureBox();
            _titlePanel = new Panel();
            _titleLabel = new Label();
            _panelDetail = new Panel();
            _messagePanel = new Panel();
            _bottomPanel = new Panel();
            _messageTextBox = new TextBox();
            _okRoundedButton = new RoundedButton();
            _topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(_pictureBox)).BeginInit();
            _titlePanel.SuspendLayout();
            _panelDetail.SuspendLayout();
            _messagePanel.SuspendLayout();
            _bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TopPanel
            // 
            _topPanel.Controls.Add(_pictureBox);
            _topPanel.Dock = DockStyle.Top;
            _topPanel.Location = new Point(0, 0);
            _topPanel.Name = "_topPanel";
            _topPanel.Size = new Size(541, 142);
            _topPanel.TabIndex = 1;
            // 
            // PictureBox
            // 
            _pictureBox.Location = new Point(200, 4);
            _pictureBox.Margin = new Padding(4, 5, 4, 5);
            _pictureBox.Name = "PictureBox";
            _pictureBox.Size = new Size(140, 130);
            _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _pictureBox.TabIndex = 0;
            _pictureBox.TabStop = false;
            // 
            // TitlePanel
            // 
            _titlePanel.AutoScroll = true;
            _titlePanel.Controls.Add(_titleLabel);
            _titlePanel.Dock = DockStyle.Top;
            _titlePanel.Location = new Point(0, 142);
            _titlePanel.Name = "_titlePanel";
            _titlePanel.Size = new Size(541, 44);
            _titlePanel.TabIndex = 2;
            // 
            // TitleLabel
            // 
            _titleLabel.Dock = DockStyle.Fill;
            _titleLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _titleLabel.Location = new Point(0, 0);
            _titleLabel.Name = "_titleLabel";
            _titleLabel.Size = new Size(541, 44);
            _titleLabel.TabIndex = 0;
            _titleLabel.Text = "Title";
            _titleLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // PanelDetail
            // 
            _panelDetail.AutoScroll = true;
            _panelDetail.Controls.Add(_messagePanel);
            _panelDetail.Controls.Add(_bottomPanel);
            _panelDetail.Dock = DockStyle.Fill;
            _panelDetail.Location = new Point(0, 186);
            _panelDetail.Name = "_panelDetail";
            _panelDetail.Size = new Size(541, 180);
            _panelDetail.TabIndex = 3;
            // 
            // MessagePanel
            // 
            _messagePanel.AutoScroll = true;
            _messagePanel.Controls.Add(_messageTextBox);
            _messagePanel.Dock = DockStyle.Fill;
            _messagePanel.Location = new Point(0, 0);
            _messagePanel.Name = "_messagePanel";
            _messagePanel.Size = new Size(541, 97);
            _messagePanel.TabIndex = 2;
            // 
            // BottomPanel
            // 
            _bottomPanel.Controls.Add(_okRoundedButton);
            _bottomPanel.Dock = DockStyle.Bottom;
            _bottomPanel.Location = new Point(0, 97);
            _bottomPanel.Name = "_bottomPanel";
            _bottomPanel.Size = new Size(541, 83);
            _bottomPanel.TabIndex = 1;
            // 
            // MessageTextBox
            // 
            _messageTextBox.BackColor = Color.White;
            _messageTextBox.BorderStyle = BorderStyle.None;
            _messageTextBox.Dock = DockStyle.Fill;
            _messageTextBox.Location = new Point(0, 0);
            _messageTextBox.Multiline = true;
            _messageTextBox.Name = "_messageTextBox";
            _messageTextBox.ReadOnly = true;
            _messageTextBox.ScrollBars = ScrollBars.Both;
            _messageTextBox.Size = new Size(541, 97);
            _messageTextBox.TabIndex = 0;
            _messageTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // OkRoundedButton
            // 
            _okRoundedButton.Location = new Point(200, 10);
            _okRoundedButton.Name = "_okRoundedButton";
            _okRoundedButton.Size = new Size(140, 64);
            _okRoundedButton.TabIndex = 0;
            _okRoundedButton.Text = "OK";
            _okRoundedButton.UseVisualStyleBackColor = true;
            _okRoundedButton.Click += OkRoundedButton_Click;
            // 
            // Mine
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(541, 366);
            Controls.Add(_panelDetail);
            Controls.Add(_titlePanel);
            Controls.Add(_topPanel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximumSize = new Size(1000, 428);
            Name = "SimpleMessageForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SimpleMessageForm";
            Shown += SimpleMessage_Shown;
            _topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(_pictureBox)).EndInit();
            _titlePanel.ResumeLayout(false);
            _panelDetail.ResumeLayout(false);
            _messagePanel.ResumeLayout(false);
            _messagePanel.PerformLayout();
            _bottomPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
