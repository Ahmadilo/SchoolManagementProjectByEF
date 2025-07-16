using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagementSystem.WinForm.Units;

namespace SchoolManagementSystem.WinForm.UserControls
{
    public partial class ucExcelExport : UserControl
    {
        public virtual event EventHandler<string> SuccessfullyExported;

        protected virtual void onSuccessfullyExported()
        {
            SuccessfullyExported?.Invoke(this, this.FileName);
        }

        public virtual event EventHandler<string> FailedExported;

        protected virtual void onFailedExported()
        {
            FailedExported?.Invoke(this, this.FileName);
        }

        public virtual event EventHandler ValidtionExport;

        protected virtual void onValidtionExport()
        {
            ValidtionExport?.Invoke(this, EventArgs.Empty);
        }

        public virtual event EventHandler StartExport;

        protected virtual void onStartExport()
        {
            StartExport?.Invoke(this, EventArgs.Empty);
        }

        public ucExcelExport()
        {
            InitializeComponent();

            cmbExtensions.SelectedIndex = 1;
        }

        private object _rawData;
        private string[] _headers;

        public void SetData<T>(List<T> data, string[] headers) where T : class
        {
            _rawData = data;
            _headers = headers;
        }

        public string FileName { get => txtFileName.Text; private set => txtFileName.Text = value; }
        public string ErrorMessage { get; private set; }
        public bool isValidtion { get; set; } = true;

        private Type GetExportType()
        {
            switch(cmbExtensions.SelectedItem.ToString())
            {
                case ".pdf":
                    return typeof(PdfExporter<>);
                case ".xlsx":
                    return typeof(ExcelExporter<>);
            }

            return null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            onStartExport();

            onValidtionExport();
            if (!isValidtion)
                return;

            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("Please Enter The File Name.");
                return;
            }

            if (_rawData == null)
            {
                MessageBox.Show("The Data Not Imported Eite!");
                return;
            }


            try
            {
                var fileName = txtFileName.Text.Trim();
                var fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName + cmbExtensions.SelectedItem.ToString());

                Type dataType = _rawData.GetType().GetGenericArguments().FirstOrDefault();
                var exporterType = GetExportType().MakeGenericType(dataType);
                dynamic exporter = Activator.CreateInstance(exporterType);

                exporter.SetHeader(_headers);
                exporter.AddData((dynamic)_rawData);
                exporter.SaveToFile(fullPath);

                MessageBox.Show("The File Exporterd Successfully: " + fullPath);
                onSuccessfullyExported();
            }
            catch (Exception ex)
            {
                this.ErrorMessage = Helper.ExceptionHelper.GetRootException(ex).Message;
                Helper.Logger.LogExption(ex, "WinLog.txt");
                onFailedExported();
            }
        }
    }
}

/*
    UX of Excel Export User Control

    Funcationlty flow: the button Export when clicked the Control Reqoust Data,
And Take the Name of file from the User. then Start the Functionlty to Export Data to Excel.
Then return result of proccess to User Susseccfully or Failed.

    UX Flow: The User Enter the name of file and when he see the table is reade.
Clicked the button Export to Export the data to file Excel and see the result.

    UI Desigen: Group Box that contained the Export button and the and lable to Set statu.
and Text box to set the File name.
*/

/*

    Psudo Code:
    
    Tree of UI Control:

    Group Box [Excel Export]:
        - lable [Result] => {Susseccfully Save: <File Nmae> | Fialed Export | No Set}
        - Text Box [File Name]
        - Button [Export]

    main case Code:

    User.Click(btnExport).Funcation
    {
        if(txtFileName == not have value)
            then Stop prossecc and throw Mssage to User tell him => you must set File name!.
        
        Data = getDataFromTable();

        if(Data is null or Zero Rows)
            then stop proccess and throw mssage to user tell him => Failed to get Data from table.

        ExportResult = ExportDataToExcel(txtFileName);

        if(ExportResult is true)
            trow Message to user => the proccess is Susseccfully,
            and set the lblResult to to Grean and withe color.
        else
            trow message to user => the proccess is Failded,
            and set the lblResult to red and withe color.
    }

    Developer.Use(cuExcelExport).How
    {
        Drag & Drop;
        Custam Size;
        
        Go to Code:
            select Event SusseccfullyExport and set his functaion
            {
                ucExcelExport1.FileName to get FileName:
                {.. wirte his code with file Name}
            }
            
            select Event FaildExport (sender, ErrorMassage)
            {
                ucExcelExport1.ErrorMessage to git reasn to failded the proccess
                {.. write his code for case Failded to proccess}
            }
    }
*/
