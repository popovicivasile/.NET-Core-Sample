# CoreStartSample for Machine Maintenance Management

Welcome to the CoreStartSample repository! This project demonstrates a machine maintenance management system utilizing Entity Framework with .NET 8.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Database Setup](#database-setup)
- [Technologies Used](#technologies-used)
- [License](#license)
- [Acknowledgements](#acknowledgements)

## Overview

CoreStartSample is a machine maintenance management system designed to help you keep track of maintenance activities, schedule repairs, and monitor machine performance. This application uses Entity Framework for database interactions and is built on the latest .NET 8 framework.

**Note:** Calculations and algorithms for maintenance scheduling and performance metrics are proprietary and not included in this repository.

## Features

- Track maintenance tasks and schedules.
- Manage machine details and performance logs.
- Utilize Entity Framework for data access.
- Built on .NET 8 for enhanced performance and security.

## Getting Started

Follow these instructions to set up the project on your local machine for development and testing purposes.

### Prerequisites

Ensure you have the following software installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or other supported databases
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/popovicivasile/MyAppTest.git
    ```
2. Navigate to the project directory:
    ```bash
    cd MyAppTest
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```
4. Build the project:
    ```bash
    dotnet build
    ```

### Usage

1. Run the application:
    ```bash
    dotnet run
    ```
2. Access the application at `https://localhost:5001` or `http://localhost:5000`.

### Database Setup

1. Open the `appsettings.json` file and configure your database connection string:
    ```json
    "ConnectionStrings": {
        "Service": "Data Source=localhost;Initial Catalog=Service;Integrated Security=True;Encrypt=False"
    }
    ```
2. Apply the migrations to your database:
    ```bash
    dotnet ef database update
    ```

## Technologies Used

- **.NET 8**: The latest framework for building scalable and high-performance applications.
- **Entity Framework Core**: An object-relational mapper (ORM) for .NET that enables developers to work with a database using .NET objects.
- **SQL Server**: A relational database management system from Microsoft.



