# Air Cargo Managment System (MVP)

## Overview
This project is a basic Air Cargo Managment System built with **ASP.NET Core**, **Entity Framework**, and **Blazor Server**. The current implementation represents the ** MVP** stage.

## Implemented Features

### Pages
- **Warehouses**: Displays warehouse information.
- **Airplanes**: Displays airplane details.
- **Cargos**: Displays cargo data.

### Backend
- **Services and Controllers**:
  - Implemented for Warehouses, Airplanes, and Cargos.
  - All simple CRUD operations tested using **Postman**.

### Frontend
- Client-side pages show data from different tables:
  - Warehouses, Airplanes, and Cargos.
  - Foreign Key IDs are displayed as rows in tables (e.g., Warehouse ID in Airplanes table).

## Development Progress
- Fully functional CRUD operations for Warehouses, Airplanes, and Cargos.
- Database relationships established using **Entity Framework**.
- Data integration on Blazor pages with basic table displays.

## Next Steps
1. Enhance UI to replace raw Foreign Key IDs with meaningful details (e.g., display Warehouse names instead of IDs).
2. Add user interactions for creating and managing relationships between Warehouses, Airplanes, and Cargos.
3. Implementi more advanced business logic.
