using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper;

namespace SchoolManagementSystem.WinForm
{
    public partial class ucShowTable : UserControl
    {
        public class clsSettingButton
        {
            public string Name;
            public string Value;
            public bool Visiblet;
            public Type ColumnType;
            public Func<int, object> ProccessLogic;

            public clsSettingButton(string Name, bool Visible)
            {
                this.Name = Name;
                this.Visiblet = Visible;
                this.Value = this.Name;
            }

            public clsSettingButton(string Name, bool Visible, Type type, Func<int, object> proccessLogic)
            {
                this.Name = Name;
                this.Visiblet = Visible;
                this.Value = this.Name;
                this.ColumnType = type;
                ProccessLogic = proccessLogic;
            }

            public DataGridViewColumn ToColumn(int Index)
            {
                DataGridViewColumn column = null;

                switch(ColumnType?.Name)
                {
                    case "DataGridViewTextBoxColumn":
                        column = new DataGridViewTextBoxColumn
                        {
                            Name = Name,
                            HeaderText = Name,
                            Visible = Visiblet
                        };
                        break;
                    case "DataGridViewButtonColumn":
                        column = new DataGridViewButtonColumn
                        {
                            Name = Name,
                            HeaderText = Name,
                            Text = Name,
                            UseColumnTextForButtonValue = true,
                            Visible = Visiblet
                        };
                        break;
                }

                if (column != null)
                {
                    column.DisplayIndex = ++Index; // Adjust the display index to avoid conflicts
                }

                return column;
            }

            public void SetColumnValue(DataGridViewRow row, string IDColumnName)
            {
                if(ColumnType == typeof(DataGridViewTextBoxColumn))
                {
                    if(ProccessLogic != null)
                    {
                        row.Cells[Name].Value = ProccessLogic(Convert.ToInt32(row.Cells[IDColumnName].Value));
                    }
                    else
                    {
                        row.Cells[Name].Value = Value;
                    }
                }
            }
        }

        public class clsSettingColumn
        {
            public string Name { get; set; }
            public int Index { get; set; }
            public bool Visible { get; set; }
            public bool isEnableToEdit { get; set; }
            public bool Key { get; set; }

            public clsSettingColumn(string Name, int Index, bool Visible = true, bool isEnableToEdit = false, bool Key = false) 
            {
                this.Name = Name;
                this.Index = Index;
                this.Visible = Visible;
                this.isEnableToEdit = isEnableToEdit;
                this.Key = Key;
            }
        }

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

        public Type TypeRow { get; set; } = null;
        public clsSettingColumn[] ColumnsSetting { get; set; } = null;

        public clsSettingButton DeleteSetting = new clsSettingButton("Delete", true);

        public clsSettingButton EditSetting = new clsSettingButton("Edit", true);

        public clsSettingButton[] AddtionlyColumns = null;

        public int IndexKey
        { 
            get
            {
                GetIDColumnIndex();
                return _IndexKey;
            }
        }

        public string IDColumName { 
            get 
            {
                if (values != null)
                    return values.First(v => v.Key == true).Name.ToString().Trim();
                else if(ColumnsSetting != null)
                    return ColumnsSetting.First(c => c.Key == true).Name.ToString().Trim();
                return "";
            } }

        private void AddEditAndDeleteButton()
        {
            GetMaxDisplayIndex();
            // زر التعديل
            if(EditSetting.Visiblet)
            {
                _MaxIndex++;
                var editColumn = new DataGridViewButtonColumn();
                editColumn.Name = EditSetting.Name;
                editColumn.HeaderText = EditSetting.Name;
                editColumn.Text = EditSetting.Value;
                editColumn.DisplayIndex = _MaxIndex + 10;
                editColumn.UseColumnTextForButtonValue = true;
                editColumn.Visible = EditSetting.Visiblet;
                Table.Columns.Add(editColumn);
            }

            // زر الحذف
            if(DeleteSetting.Visiblet)
            {
                _MaxIndex++;
                var deleteColumn = new DataGridViewButtonColumn();
                deleteColumn.Name = DeleteSetting.Name;
                deleteColumn.HeaderText = DeleteSetting.Name;
                deleteColumn.Text = DeleteSetting.Value;
                deleteColumn.DisplayIndex = _MaxIndex + 10;
                deleteColumn.UseColumnTextForButtonValue = true;
                Table.Columns.Add(deleteColumn);
            }
        }

        private DataGridViewColumn SetNewColumn(clsSettingButton setting)
        {
            var column = new DataGridViewButtonColumn
            {
                Name = setting.Name,
                HeaderText = setting.Name,
                Text = setting.Value,
                DisplayIndex = _MaxIndex + 10,
                UseColumnTextForButtonValue = true,
                Visible = setting.Visiblet
            };

            if (setting.ColumnType != null)
            {
                //column.ValueType = setting.ColumnType; // Uncomment if you want to set the type
            }

            return column;
        }

        private void AddColumns()
        {
            if(AddtionlyColumns == null || AddtionlyColumns.Length == 0)
                return;

            foreach (var columnSetting in AddtionlyColumns)
            {
                GetMaxDisplayIndex();
                Table.Columns.Add(columnSetting.ToColumn(_MaxIndex));

                foreach (DataGridViewRow row in Table.Rows)
                {
                    columnSetting.SetColumnValue(row, IDColumName);
                }
            }
        }


        public ucShowTable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Enter Point of User Control
        /// </summary>
        public void LoadData(object DataSource)
        {
            _MaxIndex = 0;
            Table.DataSource = null;
            Table.Rows.Clear();
            Table.Columns.Clear();
            Table.DataSource = DataSource;

            EditColumns();

            AddColumns();

            AddEditAndDeleteButton();

            Table.Refresh();
        }

        public object ExportData()
        {
            return Table.DataSource;
        }

        public override void Refresh()
        {
            Table.Refresh();
            base.Refresh();
        }

        public void EditColumns()
        {
            if(values == null && ColumnsSetting == null)
                return;

            if (values == null)
            {
                foreach(DataGridViewColumn col in Table.Columns)
                {
                    for(int i = 0; i < ColumnsSetting.Length; i++)
                    {
                        if (col.DataPropertyName == ColumnsSetting[i].Name)
                        {
                            col.Visible = ColumnsSetting[i].Visible;
                            col.DisplayIndex = ColumnsSetting[i].Index;
                            if (Table.DataSource == null)
                                col.ReadOnly = ColumnsSetting[i].isEnableToEdit;
                            break;
                        }
                        else
                            col.Visible = false;
                    }
                }
                return;
            }

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

            if (Table.Columns[e.ColumnIndex].Name == EditSetting.Name)
            {
                Edit(Table.Rows[e.RowIndex], GetIDRecode(e.RowIndex));
            }

            if (Table.Columns[e.ColumnIndex].Name == DeleteSetting.Name)
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

        public bool IsNamePropContaindCells(DataGridViewCellCollection Cells, string Name)
        {
            for(int i = 0; i < Cells.Count; i++)
            {
                if (Cells[Name] != null)
                    return true;
            }

            return false;
        }

        public List<T> GetListOfRowsData<T>() where T : class
        {
            List<T> list = new List<T>();

            foreach (DataGridViewRow row in Table.Rows)
            {
                if (row.IsNewRow) continue; // لتجاهل صف الإضافة الجديد في DataGridView

                // الحصول على الدالة Find
                MethodInfo findMethod = typeof(T).GetMethod("Find", BindingFlags.Static | BindingFlags.Public);
                if (findMethod == null) continue;

                // استخراج قيمة المفتاح الأساسي من الصف
                object keyValue = Convert.ChangeType(row.Cells[IndexKey].Value, findMethod.GetParameters()[0].ParameterType);

                // استدعاء الدالة Find للحصول على الكائن
                object entityObj = null;
                try
                {
                    entityObj = findMethod.Invoke(null, new object[] { keyValue });
                    if (entityObj == null) continue;
                }
                catch(Exception e)
                {
                    Logger.LogExption(e, "logWin.txt");
                }

                // تعيين الخصائص من خلايا الجدول
                PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo prop in props)
                {
                    if (!prop.CanWrite) continue;
                    if (!IsNamePropContaindCells(row.Cells, prop.Name)) continue;

                    object cellValue = row.Cells[prop.Name].Value;

                    try
                    {
                        if (cellValue != null && cellValue != DBNull.Value)
                        {
                            object safeValue = Convert.ChangeType(cellValue, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                            prop.SetValue(entityObj, safeValue);
                        }
                    }
                    catch
                    {
                        // تجاهل القيم غير المتوافقة
                    }
                }

                list.Add((T)entityObj);
            }

            return list;
        }

        public List<T> GetRecodes<T>()
        {
            List<T> Recodelist = new List<T>();

            foreach(DataGridViewRow row in Table.Rows)
            {
                if (row.IsNewRow)
                    continue;
                object entityObj = Activator.CreateInstance(typeof(T));

                PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

                foreach(PropertyInfo prop in props)
                {
                    if (!prop.CanWrite) continue;
                    if (!IsNamePropContaindCells(row.Cells, prop.Name)) continue;

                    object cellValue = row.Cells[prop.Name].Value;

                    try
                    {
                        if (cellValue != null && cellValue != DBNull.Value)
                        {
                            object safeValue = Convert.ChangeType(cellValue, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                            prop.SetValue(entityObj, safeValue);
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.LogExption(e, "logWin.txt");
                    }

                }

                Recodelist.Add((T)entityObj);
            }

            return Recodelist;
        }

        public DataGridView GetTable()
        {
            return this.Table;
        }
    }
}
