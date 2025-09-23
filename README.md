# OTPAppSeedImporter by Mu Ye and Sakura
OTP App seed importer new version in C# and WinForms framework

### Table of Contents:
- Features
- Seed File Format
- Setup Instructions
- Database Specifications
- Credits

## Features:

### Main purpose: 
- Import token serial numbers and seeds from .txt file into an SQLite database.

### Application type:
- WinForms C# application.

### User interface:
- Displays file paths for .txt seed file and .db database file after they have been connected to the application.
- Displays all the token serial numbers and seeds that have been successfully parsed.
- Includes buttons to delete single token serial number, or to remove all the duplicates that are found in the database.
- Allows users to download all the successfully token serial numbers and seeds again.

### Built in error checking:
- Does not allow users to input files that are the wrong format (i.e. seed file must be .txt, database file must be an SQLite .db file);
- Will fail to insert if there are duplicates, and will request the user to remove the duplicates from the inported seed list first.
- If schema is not created yet, it will first create it on the database.
- If the seed file contains duplicates or invalid row entries, they will automatically be removed from the parsed seed file output.
- Will only proceed if the files, and token type have been selected. If not, then it will show an error message.

## Seed File Format
Create a text file with serial numbers and seeds each separated by a comma. 
#### Format Requirements:
- **Serial Number**: Must be in numerical format.  
- **Seeds**: Must meet the following requirements:
	- In hexadecimal format (a-f, A-F, 0-9), case insensitive.
	- Between 20 to 64 characters long (inclusive).
	- Even length.
- Format: ```Serial_Number```,```Seed``` 
	- No spaces allowed at all (or else it will see the entry as invalid)
	- Only one entry allowed per line.

Example .txt file format:
```
862503025416,AE7AB67157F90B1935B8E7979BAE30FB8C6EA5E5
123456789012,1234567890ABCDEF1234567890ABCDEF12345678
987654321098,FEDCBA0987654321FEDCBA0987654321FEDCBA09
```


## Setup Instructions: 

### OS: 
- Windows only, does not work cross platform.

### Required software: 
- Visual Studio 2022 with WinForms and .NET 8.0 or newer installed
- DB Browser for sqlite to create .db file.
- .db file (empty is fine, as the program will automatically create the schema for you if it doesn't exist yet)

### Instructions:
1. Clone the project
2. Load it in Visual Studio
3. Build the project first, either by clicking on the solution and building it, or by typing ```dotnet build``` in the terimal.
4. Run the project by clicking on run button, or by typing ```dotnet run``` in terminal.

## Database specifications: 

This project utilizes an SQLite ```.db``` file with 2 tables to store token info. The SQL queries to create the tables, as well as the specifications for each attribute are listed below.

The SQL queries to create these tables will run only if it doesn't exist in the database. If the table exists already, it will remain unchanged, eliminating the requirement of needing to manually create the tables in the ```.db``` file beforehand.

**Note: You do not need to manually execute the sql tables to initialize database. The program will do if for you if it hasn't been initialized yet.**

**Query that creates the table storing token info:**

```sql
CREATE TABLE IF NOT EXISTS tokenInfo (
	serialNumber INTEGER PRIMARY KEY,
	seed VARCHAR(64) NOT NULL,
	specId VARCHAR(6) NOT NULL,
	importTime DATETIME DEFAULT (datetime('now', 'localtime')),
	FOREIGN KEY (specID) REFERENCES tokenSpec(specID) ON DELETE CASCADE ON UPDATE CASCADE
 );
```

Specifications of attributes:

| Database Field | Value | Description |
|----------------|-------|-------------|
| `serialNumber` | From file | The token serial number. **Primary Key**. |
| `seed` | From file | Hexadecimal public key, 20-64 characters long. **Not Null** |
| `specId` | One of: HOTP, TOTP30, TOTP60 | Type of OTP token. **Foreign Key** referencing **tokenSpec** table. |
| `importTime` | Current Time with format: `YYYY-MM-DD HH:MM:SS` | Import Local time as **Default** |

**Query that creates the table storing token specifications:**

```sql
 Creates the table for the token info
 CREATE TABLE IF NOT EXISTS tokenSpec (
	specId VARCHAR(6) PRIMARY KEY,
	intervalLength INTEGER
 );
```

Specifications of attributes:

| Database Field | Description |
|----------------|-------------|
| `specId` | Type of OTP token. **Primary Key** |
| `intervalLength` | Length of interval (for TOTP) or 0 (for HOTP) |

**Query to import the token specs at the beginning (if haven't done so yet):**

```sql
 INSERT OR IGNORE INTO tokenSpec(specId, intervalLength) VALUES 
	("TOTP30", 30),
	("TOTP60", 60),
	("HOTP", 0);
```

## Credits:
- **Original version:** [OTPAppSeedImporter (Daniel's version)](https://github.com/hypersecu/OTPAppSeedImporter)
- **Authors:** Mu Ye, Sakura
