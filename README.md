# OTPAppSeedImporter by Mu Ye and Sakura
OTP App seed importer new version in C# and WinForms framework

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
- **Seeds**: Must be in hexadecimal format (a-f, A-F, 0-9) between 20 to 64 characters long (inclusive) and of even length.
- Format: ```Serial_Number```,```Seed``` 
	- No spaces allowed at all (or else it will see the entry as invalid)
- Only one entry allowed per line.


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

## Credits:
- Original version: [OTPAppSeedImporter (Daniel's version)](https://github.com/hypersecu/OTPAppSeedImporter)

Authors: Mu Ye, Sakura
