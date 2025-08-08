# Basic C# Project - Race Statistics

This project demonstrates my knowledge of **basic C# programming** through the implementation of a console application that manages race results, stores them in a JSON file, and calculates statistics.

## Features

* **Menu-driven console UI** for user interaction.
* **Race result storage** using JSON serialization.
* **Statistics calculation**, including:

  * Average distances.
  * Total number of races.
  * Wins by vehicle.
* **Data persistence** using file I/O.
* **Basic separation of concerns** with classes for:

  * UI handling (`ConsoleUI`)
  * Data storage and retrieval (`EstadisticasRepository`)
  * Data model (`ResultadoCarrera`)

## Technologies Used

* **C#** (.NET)
* **System.Text.Json** for JSON serialization/deserialization.
* **File I/O** with `System.IO`.
* **Collections**: `List<>`, `Dictionary<,>`.

## Folder Structure

```
/ProjectRoot
│   Program.cs
│   ConsoleUI.cs
│   EstadisticasRepository.cs
│   ResultadoCarrera.cs
│   resultados.json (ignored in .gitignore)
│   .gitignore
│   README.md
```

## Example Workflow

1. The user starts the console application.
2. The program displays a menu with options to register a race result, view statistics, or exit.
3. Results are stored in **`resultados.json`**.
4. Statistics are calculated and displayed to the user.

## My Learning Goals in This Project

* Apply **object-oriented programming** principles.
* Work with **collections** and perform **data aggregation**.
* Manage **persistent storage** using JSON.
* Structure a **clean and maintainable** small-scale application.

---

**Author:** Francisco X. Vera F.

> This project is part of my C# learning journey and showcases my understanding of core concepts such as data modeling, file handling, serialization, and modular code organization.
