using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wlx2Explorer.Forms
{
    partial class SearchForm : Form
    {
        public static string SearchingText { get; set; }

        public static bool SearchWholeWordsOnly { get; set; }

        public static bool SearchCaseSensitive { get; set; }

        public static bool SearchFromBeginning { get; set; }

        public static bool SearchBackwards { get; set; }

        static SearchForm()
        {
            SearchingText = "";
            SearchWholeWordsOnly = false;
            SearchCaseSensitive = false;
            SearchFromBeginning = false;
            SearchBackwards = false;
        }

        public SearchForm()
        {
            InitializeComponent();

            txtSearchText.Text = SearchingText;
            chbWholeWordsOnly.Checked = SearchWholeWordsOnly;
            chbCaseSensitive.Checked = SearchCaseSensitive;
            chbSearchFromBeginning.Checked = SearchFromBeginning;
            chbSearchBackwards.Checked = SearchBackwards;
        }

        private void OkClick(object sender, EventArgs e)
        {
            SearchingText = txtSearchText.Text;
            SearchWholeWordsOnly = chbWholeWordsOnly.Checked;
            SearchCaseSensitive = chbCaseSensitive.Checked;
            SearchFromBeginning = chbSearchFromBeginning.Checked;
            SearchBackwards = chbSearchBackwards.Checked;
            
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
            switch (e.KeyValue)
            {
                case 13:
                    {
                        OkClick(sender, (EventArgs)e);
                    } break;

                case 27:
                    {
                        CancelClick(sender, (EventArgs)e);
                    } break;
            }
        }
    }
}
