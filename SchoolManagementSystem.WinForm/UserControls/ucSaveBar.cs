using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm.UserControls
{
    public partial class ucSaveBar : UserControl
    {
        public event EventHandler SaveChange;

        protected virtual void onSave()
        {
            SaveChange?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ClearInputsChange;

        protected virtual void onClearInputs()
        {
            ClearInputsChange?.Invoke(this, EventArgs.Empty);
        }

        private List<Control> _controls = new List<Control>();
        private bool _isValidated = true;

        public List<Control> InputControls => _controls;

        public ucSaveBar()
        {
            InitializeComponent();
        }

        public void GetInputControls(List<Control> Controls)
        {
            string[] prefixes = { "txt", "cb", "lbl", "dtp" };

            for (int i = 0; i < Controls.Count; i++)
            {
                string prfx = prefixes.FirstOrDefault(p => Controls[i].Name.StartsWith(p));
                if (prfx != null)
                {
                    Controls[i].Name = Controls[i].Name.Substring(prfx.Length);
                }
            }
        }

        private List<(string Name, object Value)> GetListValues(List<Control> controls)
        {
            List<(string Name, object Value)> Values = new List<(string Name, object Value)>();

            if (controls == null)
                return null;

            GetInputControls(controls);

            foreach (Control control in controls)
            {
                if (control is Label lable)
                    Values.Add((lable.Name, lable.Text.Trim()));

                if (control is TextBox textBox)
                    Values.Add((textBox.Name, textBox.Text.Trim()));

                if (control is DateTimePicker dateTimePicker)
                    Values.Add((dateTimePicker.Name, dateTimePicker.Value));

                if (control is CheckBox checkBox)
                    Values.Add((checkBox.Name, checkBox.Checked));
            }

            return Values;
        }

        public void Save<T>(T obj) where T : class
        {
            if (obj == null)
                return;

            List<(string Name, object Value)> values = GetListValues(InputControls);
            var props = obj.GetType().GetProperties();

            foreach (var prop in props)
            {
                //string[] prefixes = { "txt", "cb", "lbl" };
                //string prefix = prefixes.FirstOrDefault(p => prop.Name.StartsWith(p));
                //string propNameTrimmed = prefix != null ? prop.Name.Substring(prefix.Length) : prop.Name;

                var match = values.FirstOrDefault(v => v.Name == prop.Name);
                if (match.Name != null && prop.CanWrite)
                {
                    try
                    {
                        object convertedValue = Convert.ChangeType(match.Value, prop.PropertyType);
                        prop.SetValue(obj, convertedValue);
                    }
                    catch
                    {
                        // تجاهل أو سجل الخطأ إن حدث تحويل فاشل
                    }
                }
            }

            
            var ValidateMethd = obj.GetType().GetMethod("Validate", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            if (ValidateMethd != null)
            {
                var isValid = Convert.ToBoolean( ValidateMethd.Invoke(obj, null));
                if (!isValid)
                {
                    _isValidated = false;
                    var ErrorMessages = obj.GetType().GetProperty("ErrorMessages", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                    if (ErrorMessages == null)
                    {
                        MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var errors = ErrorMessages?.GetValue(obj) as IReadOnlyList<string>;
                    MessageBox.Show("Please fill all required fields." + string.Join(",\n", errors) , "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            var saveMethod = obj.GetType().GetMethod("Save", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            
            if(Convert.ToBoolean(saveMethod?.Invoke(obj, null)))
                Utilty.SusseccfullyMessage("Data saved successfully.");
            else
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ClickSave(object sender, EventArgs e)
        {
            onSave();
            if (chAutoClear.Checked)
                ClearInputs();
        }

        public void ClearInputs()
        {
            if (InputControls.Count == 0)
                return;

            foreach (Control control in InputControls)
            {
                if (control is TextBox textBox)
                    textBox.Clear();

                if (control is DateTimePicker dateTimePicker)
                    dateTimePicker.Value = DateTime.Today.AddYears(-18);

                if (control is CheckBox checkBox)
                    checkBox.Checked = false;

                if (control is Label label)
                    label.Text = string.Empty;
            }

            onClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
    }
}
