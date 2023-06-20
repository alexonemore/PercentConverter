/* This file is part of PercentConverter.
 * Copyright (c) 2023 Alexandr Shchukin
 * Corresponding email: alexonemoreemail@gmail.com
 *
 * PercentConverter is free software:
 * you can redistribute it and/or modify it under the terms of
 * the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * PercentConverter is distributed in the hope that
 * it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with PercentConverter.
 * If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PercentConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new ChildForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private string[] ReadFiles(string[] paths)
        {
            return paths.Select(path =>
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return sr.ReadToEnd();
                }
            }).ToArray();
        }

        private void OpenChildForms(string[] names, string[] contents)
        {
            for (int i = 0; i < names.Length; ++i)
            {
                var childForm = new ChildForm(names[i], contents[i]);
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Filter = "Analysis (*.htm;*.html;*.txt)|*.htm;*.html;*.txt|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePaths = openFileDialog.FileNames;
                    var contents = ReadFiles(filePaths);
                    OpenChildForms(filePaths, contents);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Allow the file to be copied or moved to the control
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // Get the filenames of the dropped files
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var possibleExtensions = new HashSet<string> { ".txt", ".htm", ".html" };

            var filtratedFiles = files
                .Where(f => possibleExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()))
                .ToArray();

            var contents = ReadFiles(filtratedFiles);
            OpenChildForms(filtratedFiles, contents);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
@"Percent convertor.

Just drop your .htm files to window.

This program is licensed under the GNU General Public License Version 3.

Copyright (c) 2023 Alexandr Shchukin

Corresponding email: alexonemoreemail@gmail.com",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
