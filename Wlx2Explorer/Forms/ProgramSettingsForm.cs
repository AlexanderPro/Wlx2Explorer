using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Wlx2Explorer.Configuration;
using Wlx2Explorer.Utils;
using Wlx2Explorer.Extensions;

namespace Wlx2Explorer.Forms
{
    partial class ProgramSettingsForm : Form
    {
        public ProgramSettings Settings { get; private set; }

        public ProgramSettingsForm(ProgramSettings settings)
        {
            InitializeComponent();
            try
            {
                InitializeControls(settings);
            }
            catch
            {
                tabMain.Enabled = false;
                btnOk.Enabled = false;
                MessageBox.Show("Failed to read settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeControls(ProgramSettings settings)
        {
            chbAutoStart.Checked = settings.AutoStartProgram;
            chbListerMaximized.Checked = settings.ListerFormMaximized;
            txtListerWidth.Text = settings.ListerFormWidth.ToString();
            txtListerHeight.Text = settings.ListerFormHeight.ToString();
            txtHighVersion.Text = settings.PluginHighVersion.ToString();
            txtLowVersion.Text = settings.PluginLowVersion.ToString();
            txtIniFile.Text = settings.PluginIniFile;
            if (settings.PluginIniFile.StartsWith(AssemblyUtils.AssemblyDirectory, StringComparison.InvariantCultureIgnoreCase))
            {
                txtIniFile.Text = settings.PluginIniFile.Substring(AssemblyUtils.AssemblyDirectory.Length).TrimStart('\\');
            }

            cmbListerFormKey1.DataSource = Enum.GetValues(typeof(VirtualKeyModifier));
            cmbListerFormKey1.SelectedItem = (VirtualKeyModifier)settings.ListerFormKey1;
            cmbListerFormKey2.DataSource = Enum.GetValues(typeof(VirtualKeyModifier));
            cmbListerFormKey2.SelectedItem = (VirtualKeyModifier)settings.ListerFormKey2;
            cmbListerFormKey3.ValueMember = "Id";
            cmbListerFormKey3.DisplayMember = "Text";
            cmbListerFormKey3.DataSource = ((VirtualKey[])Enum.GetValues(typeof(VirtualKey))).Where(x => !string.IsNullOrEmpty(x.GetDescription())).Select(x => new { Id = (int)x, Text = x.GetDescription() }).ToList();
            cmbListerFormKey3.SelectedValue = settings.ListerFormKey3;
            cmbSearchDialogKey1.DataSource = Enum.GetValues(typeof(VirtualKeyModifier));
            cmbSearchDialogKey1.SelectedItem = (VirtualKeyModifier)settings.SearchDialogKey1;
            cmbSearchDialogKey2.DataSource = Enum.GetValues(typeof(VirtualKeyModifier));
            cmbSearchDialogKey2.SelectedItem = (VirtualKeyModifier)settings.SearchDialogKey2;
            cmbSearchDialogKey3.ValueMember = "Id";
            cmbSearchDialogKey3.DisplayMember = "Text";
            cmbSearchDialogKey3.DataSource = ((VirtualKey[])Enum.GetValues(typeof(VirtualKey))).Where(x => !string.IsNullOrEmpty(x.GetDescription())).Select(x => new { Id = (int)x, Text = x.GetDescription() }).ToList();
            cmbSearchDialogKey3.SelectedValue = settings.SearchDialogKey3;
            cmbPrintDialogKey1.DataSource = Enum.GetValues(typeof(VirtualKeyModifier));
            cmbPrintDialogKey1.SelectedItem = (VirtualKeyModifier)settings.PrintDialogKey1;
            cmbPrintDialogKey2.DataSource = Enum.GetValues(typeof(VirtualKeyModifier));
            cmbPrintDialogKey2.SelectedItem = (VirtualKeyModifier)settings.PrintDialogKey2;
            cmbPrintDialogKey3.ValueMember = "Id";
            cmbPrintDialogKey3.DisplayMember = "Text";
            cmbPrintDialogKey3.DataSource = ((VirtualKey[])Enum.GetValues(typeof(VirtualKey))).Where(x => !string.IsNullOrEmpty(x.GetDescription())).Select(x => new { Id = (int)x, Text = x.GetDescription() }).ToList();
            cmbPrintDialogKey3.SelectedValue = settings.PrintDialogKey3;

            foreach (var plugin in settings.Plugins)
            {
                var fileName = plugin.Path;
                if (fileName.StartsWith(AssemblyUtils.AssemblyDirectory, StringComparison.InvariantCultureIgnoreCase))
                {
                    fileName = fileName.Substring(AssemblyUtils.AssemblyDirectory.Length).TrimStart('\\');
                }
                var index = gridViewPlugin.Rows.Add();
                var row = gridViewPlugin.Rows[index];
                row.Cells[0].Value = fileName;
                row.Cells[1].Value = string.Join(";", plugin.Extensions.ToArray());
            }
            gridViewPlugin.Columns[0].Width = gridViewPlugin.ClientSize.Width - 100;
            gridViewPlugin.Columns[1].Width = 100;
        }

        private void MaximizeWindowCheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            lblWindowWidth.Enabled = !checkBox.Checked;
            lblWindowHeight.Enabled = !checkBox.Checked;
            txtListerWidth.Enabled = !checkBox.Checked;
            txtListerHeight.Enabled = !checkBox.Checked;
            if (!checkBox.Checked)
            {
                txtListerWidth.Focus();
            }
        }

        private void BrowseWincmdIniClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                RestoreDirectory = true,
                FileName = "wincmd.ini",
                Filter = "Ini files (*.ini)|*.ini;|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var file = new InitializationFile(dialog.FileName);
                try
                {
                    file.LoadFile();
                }
                catch
                {
                    MessageBox.Show("Failed to read the file. May be wrong ini file format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var listerSection = file.GetSection("ListerPlugins");
                if (listerSection == null)
                {
                    MessageBox.Show("This file does not contain [ListerPlugins] section.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (gridViewPlugin.Rows.Count > 0 && 
                    MessageBox.Show("Do you want to clear the current list of the plugins.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gridViewPlugin.Rows.Clear();
                }
                foreach (var pair in listerSection)
                {
                    var fileName = pair.Value;
                    if (File.Exists(fileName))
                    {
                        var index = gridViewPlugin.Rows.Add();
                        var row = gridViewPlugin.Rows[index];
                        row.Cells[0].Value = fileName;
                        row.Cells[1].Value = string.Join(";", Plugin.GetSupportedExtensions(fileName));
                        gridViewPlugin.FirstDisplayedScrollingRowIndex = gridViewPlugin.RowCount - 1;
                        gridViewPlugin.Rows[index].Selected = true;
                    }
                }
            }
        }

        private void AddPluginClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Filter = "Plugin files (*.wlx;*.wlx64)|*.wlx;*.wlx64|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = dialog.FileName;
                if (fileName.StartsWith(AssemblyUtils.AssemblyDirectory, StringComparison.InvariantCultureIgnoreCase))
                {
                    fileName = fileName.Substring(AssemblyUtils.AssemblyDirectory.Length).TrimStart('\\');
                }
                if (IsGridViewContainFile(fileName))
                {
                    MessageBox.Show("The file already exists in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var index = gridViewPlugin.Rows.Add();
                var row = gridViewPlugin.Rows[index];
                row.Cells[0].Value = fileName;
                row.Cells[1].Value = string.Join(";", Plugin.GetSupportedExtensions(fileName));
                gridViewPlugin.FirstDisplayedScrollingRowIndex = gridViewPlugin.RowCount - 1;
                gridViewPlugin.Rows[index].Selected = true;
            }
        }

        private void DeletePluginClick(object sender, EventArgs e)
        {
            if (gridViewPlugin.SelectedRows.Count > 0)
            {
                var index = gridViewPlugin.SelectedRows[0].Index;
                gridViewPlugin.Rows.RemoveAt(index);
                index = (index < gridViewPlugin.Rows.Count) ? index : (gridViewPlugin.Rows.Count > 0) ? gridViewPlugin.Rows.Count - 1 : 0;
                if (gridViewPlugin.Rows.Count > 0)
                {
                    gridViewPlugin.Rows[index].Selected = true;
                }
            }
            else
            {
                MessageBox.Show("You should select an item in the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditPluginClick(object sender, EventArgs e)
        {
            if (gridViewPlugin.SelectedRows.Count > 0)
            {
                var row = gridViewPlugin.SelectedRows[0];
                var pluginSettingsForm = new PluginSettingsForm((string)row.Cells[0].Value, (string)row.Cells[1].Value);
                if (pluginSettingsForm.ShowDialog() == DialogResult.OK)
                {
                    var fileName = pluginSettingsForm.FileName;
                    var extensions = pluginSettingsForm.Extensions;
                    if (fileName.StartsWith(AssemblyUtils.AssemblyDirectory, StringComparison.InvariantCultureIgnoreCase))
                    {
                        fileName = fileName.Substring(AssemblyUtils.AssemblyDirectory.Length).TrimStart('\\');
                    }
                    row.Cells[0].Value = fileName;
                    row.Cells[1].Value = extensions;
                }
            }
            else
            {
                MessageBox.Show("You should select an item in the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DownPluginClick(object sender, EventArgs e)
        {
            if (gridViewPlugin.SelectedRows.Count > 0)
            {
                var index = gridViewPlugin.SelectedRows[0].Index;
                var newIndex = index < gridViewPlugin.Rows.Count - 1 ? index + 1 : gridViewPlugin.Rows.Count - 1;
                var selectedRow = gridViewPlugin.SelectedRows[0];
                gridViewPlugin.Rows.RemoveAt(index);
                gridViewPlugin.Rows.Insert(newIndex, selectedRow);
                gridViewPlugin.Rows[newIndex].Selected = true;
            }
        }

        private void UpPluginClick(object sender, EventArgs e)
        {
            if (gridViewPlugin.SelectedRows.Count > 0)
            {
                var index = gridViewPlugin.SelectedRows[0].Index;
                var newIndex = index > 0 ? index - 1 : 0;
                var selectedRow = gridViewPlugin.SelectedRows[0];
                gridViewPlugin.Rows.RemoveAt(index);
                gridViewPlugin.Rows.Insert(newIndex, selectedRow);
                gridViewPlugin.Rows[newIndex].Selected = true;
            }
        }

        private void PluginListDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditPluginClick(sender, (EventArgs)e);
        }

        private void OkClick(object sender, EventArgs e)
        {
            int listerWidth = 0;
            int listerHeight = 0;
            int highVersion = 0;
            int lowVersion = 0;
            string iniFile = "";
            DialogResult = DialogResult.Cancel;

            try
            {
                listerWidth = int.Parse(txtListerWidth.Text);
            }
            catch
            {
                MessageBox.Show("Window width must be an integer number.");
                Close();
            }

            try
            {
                listerHeight = int.Parse(txtListerHeight.Text);
            }
            catch
            {
                MessageBox.Show("Window height must be an integer number.");
                Close();
            }

            try
            {
                highVersion = int.Parse(txtHighVersion.Text);
            }
            catch
            {
                MessageBox.Show("The integral part of version must be an integer number.");
                Close();
            }

            try
            {
                lowVersion = int.Parse(txtLowVersion.Text);
            }
            catch
            {
                MessageBox.Show("The fractional part of version must be an integer number.");
                Close();
            }

            try
            {
                var fileInfo = new FileInfo(txtIniFile.Text);
                if (!fileInfo.Exists) fileInfo.Create().Close();
                iniFile = fileInfo.FullName;
            }
            catch
            {
                var message = string.Format("Failed to create the file \"{0}\"", txtIniFile.Text);
                MessageBox.Show(message);
                Close();
            }

            Settings = new ProgramSettings()
            {
                AutoStartProgram = chbAutoStart.Checked,
                ListerFormMaximized = chbListerMaximized.Checked,
                ListerFormWidth = listerWidth,
                ListerFormHeight = listerHeight,
                PluginLowVersion = lowVersion,
                PluginHighVersion = highVersion,
                PluginIniFile = txtIniFile.Text,
                ListerFormKey1 = (int)cmbListerFormKey1.SelectedValue,
                ListerFormKey2 = (int)cmbListerFormKey2.SelectedValue,
                ListerFormKey3 = (int)cmbListerFormKey3.SelectedValue,
                SearchDialogKey1 = (int)cmbSearchDialogKey1.SelectedValue,
                SearchDialogKey2 = (int)cmbSearchDialogKey2.SelectedValue,
                SearchDialogKey3 = (int)cmbSearchDialogKey3.SelectedValue,
                PrintDialogKey1 = (int)cmbPrintDialogKey1.SelectedValue,
                PrintDialogKey2 = (int)cmbPrintDialogKey2.SelectedValue,
                PrintDialogKey3 = (int)cmbPrintDialogKey3.SelectedValue
            };

            foreach (DataGridViewRow row in gridViewPlugin.Rows)
            {
                var fileName = (string)row.Cells[0].Value;
                var extensions = ((string)row.Cells[1].Value).Split(';').ToList();
                var pluginInfo = new PluginInfo(fileName, extensions);
                Settings.Plugins.Add(pluginInfo);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                CancelClick(sender, (EventArgs)e);
            }
        }

        private bool IsGridViewContainFile(string fileName)
        {
            foreach (DataGridViewRow row in gridViewPlugin.Rows)
            {
                if (string.Compare((string)row.Cells[0].Value, fileName, true) == 0) return true;
            }
            return false;
        }
    }
}