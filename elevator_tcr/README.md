# Elevator Kata

## Overview
The Elevator Kata is a coding exercise designed to practice incremental development and test-driven development (TDD) using the Test Commit Revert (TCR) workflow. The goal is to simulate the behavior of an elevator system in a building while adhering to strict coding principles.

## Objective
Implement an elevator system that:
1. Handles floor requests from inside the elevator.
2. Handles "Up" or "Down" requests from outside the elevator.
3. Prioritizes requests based on the current direction of travel.
4. Optimizes movement to minimize unnecessary trips.

## Rules
1. The building has **10 floors** (0 to 9).
2. The elevator starts at **floor 0**.
3. Requests can come from:
   - **Inside the elevator**: Passengers select a floor.
   - **Outside the elevator**: Passengers press "Up" or "Down" buttons.
4. The elevator serves requests in the **current direction** before switching directions.
5. Invalid requests (e.g., floors outside the range 0-9) are ignored.
6. The elevator cannot move beyond the top or bottom floor.

## Acceptance Criteria

The elevator system must meet the following criteria:

### Basic Movement
1. The elevator starts at floor 0 when initialized.
2. The elevator can move up or down to a requested floor within the range of 0-9.

### Handling Requests
3. Passengers inside the elevator can request a floor.
4. Passengers outside the elevator can request the elevator by pressing "Up" or "Down" on a specific floor.

### Directional Priority
5. The elevator serves all requests in the current direction before switching directions.
6. If there are no requests in the current direction, the elevator changes direction to serve pending requests.

### Invalid Requests
7. Requests outside the valid floor range (0-9) are ignored.
8. If no requests are made, the elevator remains idle.

### Optimization (Pro)
9. The elevator minimizes unnecessary trips by optimizing the order of requests in its queue.


## Expected Behavior

| Scenario                              | Input Requests                  | Output (Floor Stops) |
|---------------------------------------|---------------------------------|----------------------|
| Simple request                        | Inside: 3                       | 0 → 3               |
| Multiple requests in one direction    | Inside: 2, 5                    | 0 → 2 → 5           |
| Directional priority                  | Inside: 2, Outside: 5 (Up)      | 0 → 2 → 5           |
| Switching directions                  | Inside: 2, Outside: 5 (Down)    | 0 → 2 → 5           |
| Invalid requests                      | Inside: -1, Outside: 10 (Down)  | Ignored             |

## Setup Instructions

### Prerequisites
1. Install the .NET SDK: [Download .NET](https://dotnet.microsoft.com/download).
2. Install Git: [Download Git](https://git-scm.com/).

---

### Project Setup
1. Clone the repository:
```bash
   git clone <repository-url>
   cd elevator_tcr/ElevatorKata
```

2. Build the solution

```bash
  dotnet build
```

3. Run the tests

```bash
  dotnet test
```

## TCR Workflow

To follow the **Test Commit Revert (TCR)** workflow:

1. Write a small test for a new feature or rule.
2. Run the TCR script:
```bash
   tcr.bat
```
3. Observe the results:
  - If tests pass:
      * The script will prompt you to enter a commit message.
      * Your changes will be committed automatically.
  - If tests fail:
      * The script will revert your changes to the last committed state.
      * You will see an error message: ❌ Tests failed. Reverting changes....
      * Repeat the process for the next small incremental change.