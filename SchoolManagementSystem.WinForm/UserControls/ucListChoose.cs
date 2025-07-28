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
        public event EventHandler DoubleClickChange;

        protected virtual void onChooseChange()
        {
            ChooseChange?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void onDoubleClickChange()
        {
            DoubleClickChange?.Invoke(this, EventArgs.Empty);
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

        private bool _isOpened = false;

        private void conClick(object sender, EventArgs e)
        {
            onChooseChange();
            lblTitle.ForeColor = Color.White;
        }

        private void lblTitle_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Equals(MouseButtons.Right))
            {
                lblTitle.ForeColor = Color.Black;
                onDoubleClickChange();
            }
        }
    }
}
