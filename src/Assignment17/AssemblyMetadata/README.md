# Assembly Metadata Inspector

<br>

A simple C# console-based Reflection application that dynamically loads an assembly and inspects its metadata. The application displays information about all types defined in the assembly, including their methods, properties, fields, and events.

<br>

## Features

<br>

- Load Assembly Dynamically
- Inspect Assembly Metadata
- View Types Defined in Assembly
- View Methods of Each Type
- View Properties of Each Type
- View Fields of Each Type
- View Events of Each Type
- Runtime Type Discovery
- Reflection-Based Analysis
- Structured Metadata Display

<br>

## Project Structure

<br>

```text
AssemblyMetadataInspector
│
├── Services
│   └── AssemblyInspector.cs
│
├── Helpers
│   └── DisplayHelper.cs
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

### Assembly Loading

<br>

The application loads an external assembly dynamically using Reflection.

<br>

Responsibilities:

<br>

- Load assembly from a specified file path
- Validate assembly path
- Handle loading exceptions

<br>

### Type Inspection

<br>

The application retrieves and displays all types defined within the assembly.

<br>

Responsibilities:

<br>

- Retrieve types using `GetTypes()`
- Display type names and metadata
- Iterate through assembly contents

<br>

### Member Inspection

<br>

For each discovered type, the application inspects its members.

<br>

Responsibilities:

<br>

- Retrieve methods
- Retrieve properties
- Retrieve fields
- Retrieve events

<br>

### Reflection APIs Used

<br>

- `Assembly.LoadFile()`
- `Assembly.GetTypes()`
- `Type.GetMethods()`
- `Type.GetProperties()`
- `Type.GetFields()`
- `Type.GetEvents()`

<br>

---

<br>

## Workflow

<br>

```text
Enter Assembly Path
            |
            v
Load Assembly
            |
            v
Retrieve Types
            |
            v
Inspect Each Type
            |
            v
Display Methods
Display Properties
Display Fields
Display Events
```

<br>

---

<br>

## Sample Execution

<br>

### Load Assembly

<br>

```text
Enter Assembly Path:

D:\Projects\MathApp.dll

Assembly Loaded Successfully
```

<br>

### Display Types

<br>

```text
Type: MathApp.Calculator

Type: UtilityApp.Validator

Type: DisplayApp.ConsoleUI
```

<br>

### Display Methods

<br>

```text
Methods:

Add()
Subtract()
Multiply()
Divide()
```

<br>

### Display Properties

<br>

```text
Properties:

Name
Version
```

<br>

### Display Fields

<br>

```text
Fields:

_pi
_calculationCount
```

<br>

### Display Events

<br>

```text
Events:

CalculationPerformed
```

<br>

---

<br>

## Reflection Methods Used

<br>

### Assembly Loading

<br>

```csharp
Assembly.LoadFile()
```

Used to load an assembly from a specified file path.

<br>

### Retrieving Types

<br>

```csharp
Assembly.GetTypes()
```

Returns all types defined within the assembly.

<br>

### Retrieving Methods

<br>

```csharp
Type.GetMethods()
```

Returns all methods defined within a type.

<br>

### Retrieving Properties

<br>

```csharp
Type.GetProperties()
```

Returns all properties defined within a type.

<br>

### Retrieving Fields

<br>

```csharp
Type.GetFields()
```

Returns all fields defined within a type.

<br>

### Retrieving Events

<br>

```csharp
Type.GetEvents()
```

Returns all events defined within a type.

<br>