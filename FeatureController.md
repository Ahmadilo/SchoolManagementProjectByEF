# Proposal: Implement Role-Based Feature Control

## 🎯 Objective

Transition from a simple role system using a string field in the `User` table to a robust, scalable role-feature management system based on:

- A `Roles` table
- A `Features` table
- A junction table `RoleFeatures` for permissions mapping

This new system will allow granular control over feature access per role, and support for hierarchical features if needed.

---

## 🧱 Database Design - Required Changes

### ✅ Create the following tables:

```sql
CREATE TABLE Features (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FeatureName NVARCHAR(200) NOT NULL,
    FeatureDescription NVARCHAR(MAX) NULL,
    FeatureType NVARCHAR(100) NOT NULL,
    FeatureParentID INT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (FeatureParentID) REFERENCES Features(Id)
);

CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) unique NOT NULL
);

CREATE TABLE RoleFeatures (
    RoleId INT NOT NULL,
    FeatureId INT NOT NULL,
    CanRead BIT DEFAULT 0,
    CanWrite BIT DEFAULT 0,
    PRIMARY KEY (RoleId, FeatureId),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    FOREIGN KEY (FeatureId) REFERENCES Features(Id)
);
```

## 📊 Plan and Steps

### 🗄️ Database Plan

1. **Create the `Features` Table**:
   - Define the structure with necessary fields.
   - Include a self-referencing foreign key for hierarchical features.

2. **Create the `Roles` Table**:
   - Define the structure with required fields.
   - Add a `RoleID` column to the `Users` table.

3. **Create the `RoleFeatures` Junction Table**:
   - Map roles to features.
   - Include read/write permissions for each mapping.

---

### 💻 Entity Framework (EF) Plan

1. **Add the `Features` Entity**:
   - Define the properties corresponding to the Features table.

2. **Add the `Roles` Entity**:
   - Define the properties of the Roles table.
   - Update the `User` entity to include `RoleID` as a foreign key.

3. **Add the `RoleFeatures` Entity**:
   - Define properties for mapping roles to features with permissions.

---

### 🧠 Logic Plan

1. **Add Enum for `Roles`**:
   - Define system roles (e.g., Admin, Teacher, Student).
   - Use the enum in the code to improve clarity.
   - Add the enum to the `clsUser` class.

2. **Add TreeNodes for `RoleFeatures`**:
   - Represent features in a tree structure for better UX.
   - Implement templates or permission presets for roles.

---

### 🖼️ UI Plan

1. **Update User CRUD Operations**:
   - Add a dropdown for selecting a role when creating/editing users.
   - Add a tab or section for managing feature permissions.


