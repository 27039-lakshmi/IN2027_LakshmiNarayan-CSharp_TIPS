# Object Property Inspector

<br>

A simple C# console-based Reflection application that inspects an object's properties at runtime and displays the name and current value of each property. The application demonstrates how Reflection can be used to retrieve metadata and interact with object members dynamically.

<br>

## Features

<br>

- Inspect Object Properties Dynamically
- Retrieve Object Type at Runtime
- Display Property Names
- Display Property Values
- Edit Property Values Dynamically
- Runtime Type Discovery
- Reflection-Based Property Inspection
- Automatic Type Conversion
- Input Validation for Property Selection

<br>

## Project Structure

<br>

```text
ObjectPropertyInspector
│
├── Models
│   └── Person.cs
│
├── Services
│   └── PropertyInspector.cs
│
└── Program.cs
```

<br>

## Technologies Used

<br>

- C#
- .NET
- Reflection
- Object-Oriented Programming (OOP)

<br>

## Design Overview

<br>

### Object Inspection

<br>

The application accepts an object and retrieves metadata about its properties using Reflection.

<br>

Responsibilities:

<br>

- Determine the object's type
- Retrieve available properties
- Display property names
- Display property values

<br>

### Property Editing

<br>

The application allows users to select a property and modify its value dynamically.

<br>

Responsibilities:

<br>

- Validate property name
- Accept new property value
- Convert input to the property's data type
- Update property value using Reflection

<br>

### Reflection APIs Used

<br>

- `GetType()`
- `GetProperties()`
- `GetProperty()`
- `PropertyInfo.GetValue()`
- `PropertyInfo.SetValue()`

<br>

---

<br>

## Workflow

<br>

```text
Create Object
      |
      v
Get Object Type
      |
      v
Retrieve Properties
      |
      v
Display Property Names & Values
      |
      v
Select Property
      |
      v
Enter New Value
      |
      v
Convert Value To Correct Type
      |
      v
Update Property
      |
      v
Display Updated Properties
```

<br>

---

<br>

## Sample Object

<br>

```csharp
public class Person
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string City { get; set; }
}
```

<br>

---

<br>

## Sample Execution

<br>

### Initial Property Display

<br>

```text
Name Lakshmi
Age 22
City Coimbatore
```

<br>

### Property Selection

<br>

```text
Enter property name to edit

Age
```

<br>

### Updating Property Value

<br>

```text
Enter new value for the Age

25
```

<br>

### Updated Property Display

<br>

```text
Name Lakshmi
Age 25
City Coimbatore
```

<br>

---

<br>

## Reflection Methods Used

<br>

### Get Object Type

<br>

```csharp
object.GetType()
```

Returns the runtime type of the object.

<br>

### Get All Properties

<br>

```csharp
Type.GetProperties()
```

Returns all public properties defined in the object.

<br>

### Retrieve a Specific Property

<br>

```csharp
Type.GetProperty()
```

Retrieves a property by name.

<br>

### Read Property Value

<br>

```csharp
PropertyInfo.GetValue()
```

Returns the current value of a property.

<br>

### Update Property Value

<br>

```csharp
PropertyInfo.SetValue()
```

Assigns a new value to a property at runtime.

<br>

---

<br>

## Validation

<br>

### Property Validation

<br>

- Property name must exist in the selected object.
- User is repeatedly prompted until a valid property name is entered.

<br>

### Value Validation

<br>

- Input is converted to the property's actual data type.
- Invalid conversions are handled using exception handling.

<br>

---

<br>

## Benefits

<br>

- Dynamic property inspection
- Dynamic property updates
- Reusable for any class
- No compile-time knowledge required
- Demonstrates practical use of Reflection
- Useful for debugging and administration tools

<br>