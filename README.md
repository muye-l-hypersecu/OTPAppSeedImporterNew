# OTPAppSeedImporter Developed by Mu Ye and Sakura
OTP App seed importer new version in C# and WinForms framework

## Features
- Windows desktop software
- Database integration

## Prerequisites
- .NET 8.0 or later
- SQLite database

## Getting Started
### 1. Run the application on Visual Studio
### 2. Create database (optional)
### 3. Seed File Format
Create a text file with serial numbers and seeds each separated by a comma.   
#### Format Requirements:
- Seeds: Exactly 40 hexadecimal characters (a-f, A-F, 0-9)
- A serial number and seed separated by a comma without any spaces
- One entry per line

### 4. Built in error checking 
- Does not allow users to input files that are the wrong format (i.e. seed file must be .txt, database file must be an SQLite .db file);
- Will fail to insert if there are duplicates, and will request the user to remove the duplicates from the inported seed list first.
- If schema is not created yet, it will first create it on the database.
- If the seed file contains duplicates or invalid row entries, they will automatically be removed from the parsed seed file output.
- Will only proceed if the files, and token type have been selected. If not, then it will show an error message.

### 5. User interface
- Displays file paths for .txt seed file and .db database file after they have been connected to the application.
- Displays all the token serial numbers and seeds that have been successfully parsed.
- Includes buttons to delete single token serial number, or to remove all the duplicates that are found in the database.
- Allows users to download all the successfully token serial numbers and seeds again.

## Resources
- Windows Forms
- C#
- OTPAppSeedImporter (Daniel's version)


## Setup Instructions: 

### Required software: 
- Visual Studio 2022 with WinForms installed
- DB Browser for SQLite
- .db file (empty is fine)

### Instructions
1. Clone the project
2. Load it in Visual Studio
3. Build the project first, either by clicking on the solution and building it, or by typing ```dotnet build``` in the terimal.
4. Run the project by clicking on run button, or by typing ```dotnet run``` in terminal.

Authors: Mu Ye, Sakura
