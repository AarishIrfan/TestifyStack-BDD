# TestifyStack BDD Automation Framework

A comprehensive automated testing framework built with **SpecFlow**, **Selenium WebDriver** and **C#** for testing login functionality on the TestifyStack practice website.

## Project Overview

This project demonstrates **Behavior-Driven Development (BDD)** approach using Gherkin syntax to create readable and maintainable automated tests. The framework focuses on testing user authentication workflows with real-world scenarios.

## Technologies Used

- **C#** - Primary programming language
- **SpecFlow** - BDD framework for .NET
- **Selenium WebDriver** - Web automation tool
- **NUnit** - Testing framework
- **Microsoft Edge WebDriver** - Browser automation
- **Visual Studio** - IDE

## Prerequisites

Before running this project, ensure you have:

- [.NET 6.0 or later](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Microsoft Edge Browser](https://www.microsoft.com/edge)
- [Git](https://git-scm.com/)

## Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/AarishIrfan/TestifyStack-BDD.git
   cd TestifyStack-BDD
   ```

2. **Restore NuGet packages:**
   ```bash
   dotnet restore
   ```

3. **Build the project:**
   ```bash
   dotnet build
   ```

## Running Tests

### Via Visual Studio
1. Open the solution in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Open Test Explorer (Test → Test Explorer)
4. Run all tests or specific scenarios

### Via Command Line
```bash
dotnet test
```

### Via Test Explorer Tags
```bash
# Run only smoke tests
dotnet test --filter "Category=Smoke_Test_Login"
```

