# Ant Colony Optimization
A group of locations need to be visited. Each location has coordinates and working hours. Ant Colony Optimization algorithm finds the shortest path so that all locations are visited during working hours.

## Implementation
- Information is loaded from file. 
- File contains information about location's coordinates and working hours.
- Parameters for ACO algorithm need to be entered.
- Each ant builds its own path starting from a random location.
- Quality of the path is measured by its length and number of locations that are not reached on time.
- After a certain number of iterations best path is found and displayed.
- Red color indicates start location.
- Other locations are green.
- Locations that can not be visited on time have (!) after their names.
