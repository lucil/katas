# Elevator Kata

## Overview
The Elevator Kata is a coding exercise designed to practice incremental development and test-driven development (TDD) using the Test Commit Revert (TCR) workflow. The goal is to simulate the behavior of an elevator system in a building while adhering to strict coding principles.

## Objective
Implement an elevator system that:
1. Handles floor requests from inside the elevator.
2. Handles "Up" or "Down" requests from outside the elevator.
3. Prioritizes requests based on the current direction of travel.
4. Optimizes movement to minimize unnecessary trips.


## Acceptance Criteria

The building has 10 floors from 0-9.
The elevator system must meet the following criteria:

#### 1. Starting State
- The elevator starts at floor 0 when initialized.
   * Example:
      * Given the elevator is initialized, then its current floor is 0.

#### 2. Handling Requests
- Passengers can request a valid floor (0 to 9), and the elevator moves to that floor.
- Requests for floors outside the valid range (invalid requests) are ignored.

   * Example:
      * Given the elevator is at floor 0, when a request is made to move to floor 5, then the elevator moves to floor 5.
      * Requests for floors outside the valid range (invalid requests) are ignored.

#### 3. Movement Constraints
- The elevator cannot move beyond the top floor (9) or below the ground floor (0).
   * Example:
      * Given the elevator is at floor 9, when a request is made to move up, then the elevator ignores the request and remains at floor 9.
      * Given the elevator is at floor 0,
when a request is made to move down,
then the elevator ignores the request and remains at floor 0.

#### 4. Idle State
- If no requests are pending, the elevator remains idle at its current floor.
   * Example:
      * Given the elevator is at floor 6, when no new requests are made, then the elevator stays at floor 6.

#### 5. Request Processing Order
- The elevator processes requests in the order they are received.
   * Example:
      * Given the elevator is at floor 0, when requests are made for floors 4 and 2 in that order, then the elevator moves to floor 4 first and then to floor 2.

#### 6. Directional Priority
- The elevator serves all requests in its current direction (up or down) before switching directions.
   * Example:
      * Given the elevator is at floor 3,
when requests are made for floors 5 (up), 7 (up), and 2 (down),
then the elevator moves to floor 5, then floor 7, and only after completing all "up" requests, it moves to floor 2.
      * Given the elevator is at floor 6 and moving down,
when requests are made for floors 4 (down), 2 (down), and 8 (up),
then the elevator moves to floor 4, then floor 2, and only after completing all "down" requests, it moves to floor 8.

#### 7. Request Queue
- The elevator can handle multiple requests and processes them one at a time.
   * Example:
      * Given the elevator is at floor 0,
when requests are made for floors 3, 7, and 5,
then the elevator processes each request sequentially.

#### 8. Completion of Requests
- After processing all requests, the elevator remains idle at the last requested floor.
   * Example:
      * Given the elevator is at floor 0,
when requests are made for floors 2 and 6,
then the elevator moves to floor 2, then to floor 6, and remains idle at floor 6.

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