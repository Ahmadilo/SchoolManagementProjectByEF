# 📦 Proposal: Add Input Table User Control (`ucInputTable`)

## 🎯 Objective

Create a reusable user control `ucInputTable` that enables users to manage structured data in a tabular format, allowing easy **addition**, **editing**, and **deletion** of rows.

### Key Goals

- ✅ Support **dynamic columns** definition based on developer configuration.
- ✅ Allow binding to any `BindingList<T>`-based data structure.
- ✅ Expose methods to interact with specific rows programmatically.
- ✅ Maintain a clean and user-friendly interface.

---

## 🧩 UI Components Design

### 1. `GroupBox`

> **Purpose**: Visually encapsulates the table and gives users a clear boundary to focus on.

### 2. `DataGridView`

> **Purpose**: Displays tabular input. Each column is rendered based on its `InputColumnType`, with support for:
> - `TextBox`
> - `ComboBox`
> - `CheckBox`
> - `DateTimePicker` (optional for date types)

---

## 🧪 Code Usage Example

### 💡 Define Columns

```csharp
ucInputTable.Columns = new List<InputTableColumn>
{
    new InputTableColumn
    {
        PropertyName = "Name",
        HeaderText = "User Name",
        ColumnType = InputColumnType.TextBox,
        IsKey = true,
        ReadOnly = false
    },
    new InputTableColumn
    {
        PropertyName = "Email",
        HeaderText = "Email Address",
        ColumnType = InputColumnType.TextBox
    },
    new InputTableColumn
    {
        PropertyName = "PhoneNumber",
        HeaderText = "Phone Number",
        ColumnType = InputColumnType.TextBox
    },
    new InputTableColumn
    {
        PropertyName = "Role",
        HeaderText = "User Role",
        ColumnType = InputColumnType.ComboBox,
        DataSource = Enum.GetValues(typeof(UserRole))
    }
};
```

---

### 📥 Load Data

```csharp
BindingList<User> users = LoadUsersFromDatabase();
ucInputTable.LoadData(users);
```

---

### 🔍 Search for a Specific Row

```csharp
var selectedUser = ucInputTable.GetRow<User>(columnName: "Email", value: "test@example.com");

if (selectedUser != null)
{
    // Process the user
}
```

---

## 📌 Summary

| Feature                       | Status |
|-------------------------------|--------|
| Dynamic column definition     | ⏳     |
| Enum & list support           | ⏳     |
| Row searching support         | ⏳     |
| BindingList integration       | ⏳     |
| Supports CRUD-like behavior   | ⏳     |

---

## 🧠 Future Enhancements

- Add row-level validation rules.
- Export to CSV or Excel directly from the grid.
- Inline add/remove buttons for rows.
