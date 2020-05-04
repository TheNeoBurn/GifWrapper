using BjSTools.IO;
using BjSTools.IO.GifWrapperCtrls;
using BjSTools.IO.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GifDirectEditor {
    public partial class GifWrapperFrm : Form {
        private GifWrapper _wrapper = null;
        public GifWrapper Wrapper {
            get { return _wrapper; }
            set {
                _wrapper = value;
                UpdateList();
                UpdatePreview();
            }
        }
        private string _filename = null;

        private Control ctrlCurr = null;

        private GifPartHeaderCtrl              ctrlHeader;
        private GifPartGeneralHexViewCtrl      ctrlHex;
        private GifPartLwzImageCtrl            ctrlLwzImg;
        private GifPartMetaApplicationCtrl     ctrlMetaApp;
        private GifPartMetaGraphicsControlCtrl ctrlMetaCtrl;
        private GifPartMetaLoopCtrl            ctrlMetaLoop;
        private GifPartMetaTextCtrl            ctrlMetaText;


        public GifWrapperFrm() {
            InitializeComponent();

            #region Create controls
            ctrlHeader =   new GifPartHeaderCtrl();
            ctrlHeader.ValueChanged += gifPart_ValueChanged;
            ctrlHex =      new GifPartGeneralHexViewCtrl();
            ctrlHex.ValueChanged += gifPart_ValueChanged;
            ctrlLwzImg =   new GifPartLwzImageCtrl();
            ctrlLwzImg.ValueChanged += gifPart_ValueChanged;
            ctrlMetaApp =  new GifPartMetaApplicationCtrl();
            ctrlMetaApp.ValueChanged += gifPart_ValueChanged;
            ctrlMetaCtrl = new GifPartMetaGraphicsControlCtrl();
            ctrlMetaCtrl.ValueChanged += gifPart_ValueChanged;
            ctrlMetaLoop = new GifPartMetaLoopCtrl();
            ctrlMetaLoop.ValueChanged += gifPart_ValueChanged;
            ctrlMetaText = new GifPartMetaTextCtrl();
            ctrlMetaText.ValueChanged += gifPart_ValueChanged;
            #endregion

            #region Create icon list
            ImageList lst = new ImageList();
            lst.Images.Add(Resources.header);
            lst.Images.Add(Resources.lwzimg);
            lst.Images.Add(Resources.app);
            lst.Images.Add(Resources.comment);
            lst.Images.Add(Resources.ctrl);
            lst.Images.Add(Resources.text);
            lst.Images.Add(Resources.unknown);
            lst.Images.Add(Resources.eof);
            lst.Images.Add(Resources.garbage);
            lstParts.SmallImageList = lst;
            #endregion

            this.DragEnter += GifWrapperFrm_DragEnter;
            this.DragDrop += GifWrapperFrm_DragDrop;
        }

        private void gifPart_ValueChanged(object sender, EventArgs e) {
            UpdatePreview();

            GifPart part = (sender as IGifCtrl).GifPart;
            ListViewItem item = null;
            foreach (ListViewItem i in lstParts.Items) {
                if (i.Tag == part) {
                    item = i;
                    break;
                }
            }
            if (item != null) {
                UpdateListViewItem(item, part);
            }
        }

        #region Load and Save

        private void GifWrapperFrm_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void GifWrapperFrm_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                try {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    if (files != null && files.Length > 0) {
                        GifWrapper gif = new GifWrapper(files[0]);
                        Wrapper = gif;
                        _filename = files[0];
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error loading the GIF image:\r\n\r\n" + ex.Message, "Load error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuFileOpen_Click(object sender, EventArgs e) {
            OpenFileDialog d = new OpenFileDialog();
            d.AutoUpgradeEnabled = true;
            d.Filter = "GIF Image|*.gif|All files|*.*";
            d.FilterIndex = 0;
            d.Multiselect = false;
            d.RestoreDirectory = true;
            if (d.ShowDialog() == DialogResult.OK) {
                try {
                    GifWrapper gif = new GifWrapper(d.FileName);
                    Wrapper = gif;
                    _filename = d.FileName;
                } catch (Exception ex) {
                    MessageBox.Show("Error loading the GIF image:\r\n\r\n" + ex.Message, "Load error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuFileSave_Click(object sender, EventArgs e) {
            if (_wrapper == null) return;
            if (string.IsNullOrEmpty(_filename)) return;

            try {
                byte[] data = _wrapper.GetData();
                File.WriteAllBytes(_filename, data);
            } catch (Exception ex) {
                MessageBox.Show("Error saving the GIF image:\r\n\r\n" + ex.Message, "Save error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e) {
            if (_wrapper == null) return;

            try {
                byte[] data = _wrapper.GetData();
                SaveFileDialog d = new SaveFileDialog();
                d.AutoUpgradeEnabled = true;
                d.CheckFileExists = false;
                d.CheckPathExists = true;
                d.DefaultExt = ".gif";
                d.FileName = string.IsNullOrEmpty(_filename) ? "image.gif" : Path.GetFileName(_filename);
                d.Filter = "GIF Image|*.gif|All files|*.*";
                d.FilterIndex = 0;
                d.RestoreDirectory = true;
                if (d.ShowDialog() == DialogResult.OK) {
                    File.WriteAllBytes(d.FileName, data);
                }
            } catch (Exception ex) {
                MessageBox.Show("Error saving the GIF image:\r\n\r\n" + ex.Message, "Save As error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void menuBatchSetAllDelayTime_Click(object sender, EventArgs e) {
            if (_wrapper == null) return;

            decimal init = 0m;
            decimal cnt = 0m;
            foreach (GifPart part in _wrapper) {
                if (part is GifPartMetaData.GraphicsControl) {
                    init += (part as GifPartMetaData.GraphicsControl).DelayTime;
                    cnt++;
                }
            }
            if (cnt > 0) init = Math.Floor(init / cnt);

            SelectNumberFrm d = new SelectNumberFrm("Select Delay Time", "Delay Time", 65535, init);
            if (d.ShowDialog() == DialogResult.OK) {
                ushort val = Convert.ToUInt16(d.Value);
                foreach (GifPart part in _wrapper) {
                    if (part is GifPartMetaData.GraphicsControl) {
                        (part as GifPartMetaData.GraphicsControl).DelayTime = val;
                    }
                }
                UpdateExistingList();
                UpdatePreview();
            }
        }

        private void UpdatePreview() {
            if (this.InvokeRequired) {
                this.Invoke(new Action(UpdatePreview));
                return;
            }

            Image img = null;

            if (_wrapper != null) {
                try {
                    img = _wrapper.ToImage();
                } catch (Exception ex) {
                    img = new Bitmap(256, 256);
                    using (Graphics g = Graphics.FromImage(img))
                    using (Pen red = new Pen(Color.Red, 4f))
                    using (Font fnt = new Font(FontFamily.GenericSansSerif, 8f, FontStyle.Regular)) {

                        g.Clear(Color.Transparent);
                        g.DrawRectangle(red, 0, 0, 256, 256);
                        g.DrawLine(red, 0, 0, 256, 256);
                        g.DrawLine(red, 256, 0, 0, 256);

                        g.DrawString(ex.Message, fnt, Brushes.Black, new RectangleF(8, 8, 248, 248));
                    }
                }
            }

            if (picPreview.Image != null) picPreview.Image.Dispose();
            picPreview.Image = img;
        }

        private void UpdateList() {
            if (this.InvokeRequired) {
                this.Invoke(new Action(UpdateList));
                return;
            }

            SuspendLayout();

            lstParts.Items.Clear();

            if (_wrapper != null) {
                foreach (GifPart part in _wrapper) {
                    ListViewItem item = new ListViewItem();

                    UpdateListViewItem(item, part);

                    item.SubItems.Add(part.Length.ToString());
                    item.Tag = part;

                    lstParts.Items.Add(item);
                }
            }

            ResumeLayout();
        }

        private void UpdateExistingList() {
            if (this.InvokeRequired) {
                this.Invoke(new Action(UpdateList));
                return;
            }

            SuspendLayout();

            ListViewItem item;
            for (int i = 0; i < _wrapper.Count; i++) {
                GifPart part = _wrapper[i];

                if (lstParts.Items.Count <= i) { 
                    // Item count too low -> Append new item
                    item = new ListViewItem();
                    UpdateListViewItem(item, _wrapper[i]);
                    item.SubItems.Add(_wrapper[i].Length.ToString());
                    item.Tag = _wrapper[i];
                    lstParts.Items.Add(item);
                } else if (lstParts.Items[i].Tag != _wrapper[i]) {
                    // Item at this position does not match -> ...
                    #region Find item index
                    int index = -1;
                    for (int x = 0; x < lstParts.Items.Count; x++) {
                        if (lstParts.Items[x].Tag == part) {
                            index = x;
                            break;
                        }
                    }
                    #endregion
                    if (index == -1) { 
                        // The item is not included yet -> Insert new item
                        item = new ListViewItem();
                        UpdateListViewItem(item, _wrapper[i]);
                        item.SubItems.Add(_wrapper[i].Length.ToString());
                        item.Tag = _wrapper[i];
                        lstParts.Items.Insert(i, item);
                    } else { 
                        // Item found at a different location -> Update and relocated
                        item = lstParts.Items[index];
                        UpdateListViewItem(item, part);
                        lstParts.Items.RemoveAt(index);
                        lstParts.Items.Insert(i, item);
                    }
                } else { 
                    // Correct item at the correct position -> Update
                    item = lstParts.Items[i];
                    UpdateListViewItem(item, part);
                }
            }

            ResumeLayout();
        }

        private void UpdateListViewItem(ListViewItem item, GifPart part) {
            if (part is GifPartHeader) {
                item.Text = "Header";
                item.ImageIndex = 0;
            } else if (part is GifPartLwzImage) {
                GifPartLwzImage img = part as GifPartLwzImage;
                item.Text = string.Format("Image [{0}x{1} @{2}x{3}]", img.Width, img.Height, img.Left, img.Top);
                item.ImageIndex = 1;
            } else if (part is GifPartMetaData.ApplicationData) {
                GifPartMetaData.ApplicationData app = part as GifPartMetaData.ApplicationData;
                item.Text = string.Format("AppData [{0}]", app.AppIdentifier);
                item.ImageIndex = 2;
            } else if (part is GifPartMetaData.Loop) {
                GifPartMetaData.Loop loop = part as GifPartMetaData.Loop;
                item.Text = string.Format("AppData [Repeat: {0}]", loop.Iterations);
                item.ImageIndex = 2;
            } else if (part is GifPartMetaData.Comment) {
                GifPartMetaData.Comment cmt = part as GifPartMetaData.Comment;
                item.Text = string.Format("Comment [{0} bytes]", cmt.Content.Length);
                item.ImageIndex = 3;
            } else if (part is GifPartMetaData.GraphicsControl) {
                GifPartMetaData.GraphicsControl ctrl = part as GifPartMetaData.GraphicsControl;
                item.Text = string.Format("Control [Trans:{0}, Delay:{1}]", ctrl.UseTransparency ? "1" : "0", ctrl.UseUserInput ? "User" : ((ctrl.DelayTime).ToString() + "ms"));
                item.ImageIndex = 4;
            } else if (part is GifPartMetaData.TextDraw) {
                GifPartMetaData.TextDraw txt = part as GifPartMetaData.TextDraw;
                string txtt = txt.Text;
                item.Text = string.Format("Text [{2}, @{0}x{1}]", txt.Left, txt.Width, txtt.Length > 10 ? (txtt.Substring(0, 8) + "...") : txtt);
                item.ImageIndex = 5;
            } else if (part is GifPartMetaData) {
                GifPartMetaData mta = part as GifPartMetaData;
                item.Text = string.Format("Unknown [{0}]", mta.MetaType);
                item.ImageIndex = 6;
            } else if (part is GifPartTerminator) {
                item.Text = "EOF";
                item.ImageIndex = 7;
            } else if (part is GifPartGarbageData) {
                GifPartGarbageData grb = part as GifPartGarbageData;
                item.Text = "Garbage data";
                item.ImageIndex = 8;
            }
        }

        private void lstParts_SelectedIndexChanged(object sender, EventArgs e) {
            pnlPart.Controls.Clear();

            Control next = null;

            object obj = lstParts.SelectedItems.Count == 0 ? null : lstParts.SelectedItems[0].Tag;
            if (obj is GifPartHeader) {
                GifPartHeader head = obj as GifPartHeader;
                ctrlHeader.Part = head;
                next = ctrlHeader;
            } else if (obj is GifPartLwzImage) {
                GifPartLwzImage img = obj as GifPartLwzImage;
                ctrlLwzImg.Part = img;
                next = ctrlLwzImg;
            } else if (obj is GifPartMetaData.ApplicationData) {
                GifPartMetaData.ApplicationData meta = obj as GifPartMetaData.ApplicationData;
                ctrlMetaApp.Part = meta;
                next = ctrlMetaApp;
            } else if (obj is GifPartMetaData.Comment) {
                GifPartMetaData.Comment meta = obj as GifPartMetaData.Comment;
                ctrlHex.Part = meta;
                next = ctrlHex;
            } else if (obj is GifPartMetaData.GraphicsControl) {
                GifPartMetaData.GraphicsControl meta = obj as GifPartMetaData.GraphicsControl;
                ctrlMetaCtrl.Part = meta;
                next = ctrlMetaCtrl;
            } else if (obj is GifPartMetaData.Loop) {
                GifPartMetaData.Loop meta = obj as GifPartMetaData.Loop;
                ctrlMetaLoop.Part = meta;
                next = ctrlMetaLoop;
            } else if (obj is GifPartMetaData.TextDraw) {
                GifPartMetaData.TextDraw meta = obj as GifPartMetaData.TextDraw;
                ctrlMetaText.Part = meta;
                next = ctrlMetaText;
            } else if (obj is GifPartMetaData) {
                GifPartMetaData meta = obj as GifPartMetaData;
                ctrlHex.Part = meta;
                next = ctrlHex;
            } else if (obj is GifPartGarbageData) {
                GifPartGarbageData meta = obj as GifPartGarbageData;
                ctrlHex.Part = meta;
                next = ctrlHex;
            }


            if (ctrlCurr != next) {
                SuspendLayout();

                pnlPart.Controls.Clear();

                if (next != null) {
                    pnlPart.Controls.Add(next);
                    next.Dock = DockStyle.Fill;
                }

                ResumeLayout();

                ctrlCurr = next;
            }
        }

    }
}
