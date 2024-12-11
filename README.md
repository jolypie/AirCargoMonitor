# Air Cargo Management System

## Overview

The Air Cargo Management System is a comprehensive application designed to facilitate the efficient management of airplanes, warehouses, and cargo packages.

## Purpose

The primary purpose of the application is to enable users to:

- Record and manage data for airplanes, warehouses, and cargo packages.
- Efficiently allocate cargo packages from warehouses to airplanes while adhering to airplane weight limitations.
- Monitor the status and location of all cargo packages.

## Technologies Used

- **Frontend**: Blazor Server, Bootstrap
- **Backend**: ASP.NET Core and C#
- **Database**: Entity Framework Core

## Implemented Features

### Airplane Management
- Each airplane has a unique ID.
- Maximum weight capacity is defined.
- Allocated cargo packages are displayed with details.

### Warehouse Management
- Add new cargo with description and weight.
- View warehouse contents in real-time:
  - Sort packages by weight or date.
  - Remove packages for airplane allocation.

### Cargo Allocation
- Select and assign cargo to airplanes.
- Automatically checks if the weight fits within airplane limits.
- Shows available weight capacity for each airplane.
- Option to return cargo from airplanes to the warehouse.

### Database and Relationships
- CRUD operations for Airplanes, Warehouses, and Cargo.
- Relationships between tables set with Entity Framework Core.
- Replaced foreign keys with meaningful details (e.g., showing warehouse names instead of IDs).


## Remaining Tasks

### Testing
- Perform functional and load testing to find and fix bugs.

### Debugging
- Fix errors found during testing.
- Improve error handling for a better user experience.

### Deployment
- Containerize the application using Docker.
- Deploy the project.

## Conclusion
The Air Cargo Management System is complete with all key features. Next steps include testing, debugging, and improving the user interface to ensure a smooth and reliable experience.

