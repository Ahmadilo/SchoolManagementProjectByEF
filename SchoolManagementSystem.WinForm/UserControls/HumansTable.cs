using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm
{
    public partial class HumansTable : UserControl
    {
        public event EventHandler<int> EditClicked;

        public event EventHandler<int> DeleteClicked;

        public void Edit(object sender, int id)
        {
            EditClicked?.Invoke(sender, id);
        }

        public void Delete(object sender, int id)
        {
            DeleteClicked?.Invoke(sender, id);
        }

        private int _IndexKey = -1;
        private int _MaxIndex = 0;

        private void GetMaxDisplayIndex()
        {
            foreach(DataGridViewColumn column in Table.Columns)
            {
                if(column.Visible)
                {
                    if (_MaxIndex < column.DisplayIndex)
                        _MaxIndex = column.DisplayIndex;
                }
            }
        }

        private int GetMaxIndx()
        {
            int MaxIndex = 0;
            foreach (DataGridViewColumn column in Table.Columns)
            {
                if(MaxIndex < column.Index)
                    MaxIndex = column.Index;
            }

            return MaxIndex;
        }
        
        public (string Name, int index, bool Visible, bool Key)[] values = null;

        public string IDColumName { 
            get 
            {
                return values.First(v => v.Key == true).Name.ToString().Trim();
            } }

        private void AddEditAndDeleteButton()
        {
            GetMaxDisplayIndex();
            // زر التعديل
            _MaxIndex++;
            var editColumn = new DataGridViewButtonColumn();
            editColumn.Name = "Edit";
            editColumn.HeaderText = "Edit";
            editColumn.Text = "Edit";
            editColumn.DisplayIndex = _MaxIndex + 10;
            editColumn.UseColumnTextForButtonValue = true;
            Table.Columns.Add(editColumn);

            // زر الحذف
            _MaxIndex++;
            var deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.Name = "Delete";
            deleteColumn.HeaderText = "Delete";
            deleteColumn.Text = "Delete";
            deleteColumn.DisplayIndex = _MaxIndex + 10;
            deleteColumn.UseColumnTextForButtonValue = true;
            Table.Columns.Add(deleteColumn);
        }
        public HumansTable()
        {
            InitializeComponent();
        }

        public void LoadData(object DataSource)
        {
            _MaxIndex = 0;
            Table.DataSource = null;
            Table.Rows.Clear();
            Table.Columns.Clear();
            Table.DataSource = DataSource;

            EditColumns(values);

            AddEditAndDeleteButton();
        }

        public void EditColumns((string Name, int index, bool Visible, bool Key)[] values)
        {
            this.values = values;
            if (values == null)
                return;

            foreach(DataGridViewColumn column in Table.Columns)
            {
                for(int i = 0; i < values.Length; i++)
                {
                    if (column.DataPropertyName == values[i].Name)
                    {
                        column.Visible = values[i].Visible;
                        column.DisplayIndex = values[i].index;
                        break;
                    }
                    else
                        column.Visible = false;
                }
            }

        }

        public int GetIDRecode(int IndexRow)
        {
            return Convert.ToInt32(Table.Rows[IndexRow].Cells[_IndexKey].Value);
        }

        private void GetIDColumnIndex()
        {
            for (int i = 0; i < Table.Columns.Count; i++)
            {
                if (Table.Columns[i].Name == IDColumName)
                {
                    _IndexKey = i;
                    break;
                }
            }
        }

        private void Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            GetIDColumnIndex();

            if (Table.Columns[e.ColumnIndex].Name == "Edit")
            {
                Edit(Table.Rows[e.RowIndex], GetIDRecode(e.RowIndex));
            }

            if (Table.Columns[e.ColumnIndex].Name == "Delete")
                Delete(Table.Rows[e.RowIndex], GetIDRecode(e.RowIndex));

            if (Table.Columns[e.ColumnIndex].Name == "ID")
                MessageBox.Show(Table.Columns[e.ColumnIndex].Index.ToString());
        }

        public void RoleValues(string ColName, object RealValue, object MeanValue)
        {
            int Index = 0;

            for (int i = 0; i < Table.Columns.Count; i++)
            {
                if (Table.Columns[i].HeaderText.Trim() == ColName)
                {
                    Index = Table.Columns[i].Index;
                    break;
                }
            }

            for(int i = 0; i < Table.Rows.Count; i++)
            {
                if(Convert.ToInt32( Table.Rows[i].Cells[Index].Value) == Convert.ToInt32( RealValue))
                    Table.Rows[i].Cells[Index].Value = MeanValue;
            }
        }
    }
}
