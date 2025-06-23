using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm.UserControls
{
    public partial class ucListChoose : UserControl
    {
        public event EventHandler ChooseChange;

        protected virtual void onChooseChange()
        {
            ChooseChange?.Invoke(this, EventArgs.Empty);
        }

        public ucListChoose()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        private void conClick(object sender, EventArgs e)
        {
            onChooseChange();
        }
    }
}
