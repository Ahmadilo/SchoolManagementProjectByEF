# ✅ Attendance Recording Flow Checklist

## 🧑‍💻 User Actions & 🖥️ System Responses

- [✅] **Get all classes**  
  > [System] Load list of available classes

- [✅] **Select class**  
  > [User] Choose one class from the list

- [✅] **Select date**  
  > [User] Choose the attendance date

- [✅] **Get subjects for selected class**  
  > [System] Load subjects linked to selected class

- [✅] **Select subject**  
  > [User] Choose one subject

- [✅] **Get students in selected class**  
  > [System] Load students of the selected class

- [✅] **Record attendances**  
  > [User] Mark students as present/absent (checkboxes or list)

- [✅] **Save attendances**  
  > [System] Save attendance records in the database

- [✅] **Done**  
  > [System] Show confirmation or success message


# ✅ Attendance Update Recording Flow Checklist

## 🧑‍💻 User Actions & 🖥️ System Responses

> Start Point: After **Done**

- [] **Change Action Type from Save to Update**
  > [System] After the Save Attandances Change button Text from "Save" to "Update"
  > [System] Update The ShowTable with recodes that have Attandances ID

- [] **User Edit the values in Attendances recodes**
  > [User] User edit Attandaces recodes that Saves

- [] **User Save the Updates**
  > [User] Click the Update Button
  > [System] Get

