using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm
{
    public class Utilty
    {
        public static void SusseccfullyMessage(string message)
        {
            MessageBox.Show(message, "Susseccfully Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
