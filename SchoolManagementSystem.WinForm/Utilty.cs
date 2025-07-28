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
        
        public static void FaildedMessage(string message)
        {
            MessageBox.Show(message, "Failded Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        public static void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
