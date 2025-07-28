using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm.Reports
{
    public partial class frmClassCard : Form
    {
        int? _classid;
        public frmClassCard()
        {
            InitializeComponent();
        }

        public int? ClassID
        {
            get
            {
                return _classid;
            }

            set
            {
                _classid = value;
                ucClassCard1.ClassID = value;
            }
        }
    }
}
