using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorLib.Tests
{
    public class ElevatorTests
    {
        [Fact]
        public void StartsAtFloorZero()
        {
            var elevator = ElevatorTestsExtensions.CreateTestElevator();
            Assert.Equal(0, elevator.GetCurrentFloor());
        }

        [Fact(DisplayName ="Given the elevator is at floor 0, when a request is made to move to floor 5, then the elevator moves to floor 5")]
        public void MovesToFloorFiveFromFloorZero()
        {
            var elevator = ElevatorTestsExtensions.CreateTestElevator();
            elevator.RequestFloor(5);
            Assert.Equal(5, elevator.GetCurrentFloor());
        }

        [Fact(DisplayName = "Given the elevator is at floor 3, when a request is made to move to floor 10, then the elevator ignores the request.")]
        public void WhenElevetorIsToFloorThreeIgnoresRequestFromFloorTen()
        {
            var elevator = ElevatorTestsExtensions.CreateTestElevator(startingFloor: 3);

            elevator.RequestFloor(10);

            Assert.Equal(3, elevator.GetCurrentFloor());
        }

        [Fact(DisplayName = "Given the elevator is at floor 3, when a request is made to move to floor -1, then the elevator ignores the request.")]
        public void WhenElevetorIsToFloorThreeIgnoresRequestFromFloorMinus1()
        {
            var elevator = ElevatorTestsExtensions.CreateTestElevator(startingFloor: 3);

            elevator.RequestFloor(-1);

            Assert.Equal(3, elevator.GetCurrentFloor());
        }
        
        [Fact(DisplayName ="Given the elevator is at floor 0, when requests are made for floors 4 and 2 in that order, then the elevator moves to floor 4 first and then to floor 2.")]
        public void RequestsAreProcessedInAFIFOOrder()
        {
            var elevator = ElevatorTestsExtensions.CreateTestElevator(startingFloor: 0);

            elevator.RequestFloor([4, 2]);

            var movementLogs = elevator.GetOpenedDoors();

            Assert.Equal(new List<int> { 0, 4, 2 }, movementLogs);
        }

        [Fact(DisplayName = "Given the elevator is at floor 3, when requests are made for floors 5 (up), 7 (up), and 2 (down), then the elevator moves to floor 5, then floor 7, and only after completing all \"up\" requests, it moves to floor 2.")]
        public void RequestsAreProcessedInAFIFOOOrderFollowingTheSequence()
        {
            var elevator = ElevatorTestsExtensions.CreateTestElevator(startingFloor: 3);

            elevator.RequestFloor([5, 7, 2]);

            var movementLogs = elevator.GetOpenedDoors();

            Assert.Equal(new List<int> { 3, 5, 7, 2 }, movementLogs);
        }

        [Fact(DisplayName = "Given the elevator is at floor 3, when requests are made for floors 5 (up), and 2 (down), 7 (up) then the elevator moves to floor 5, then floor 7, and only after completing all \"up\" requests, it moves to floor 2.")]
        public void RequestsAreProcessedInAFIFOOOrderFollowingTheUpDirection()
        {
            var elevator = ElevatorTestsExtensions.CreateTestElevator(startingFloor: 3);

            elevator.RequestFloor([5, 2, 7]);

            var movementLogs = elevator.GetOpenedDoors();

            Assert.Equal(new List<int> { 3, 5, 7, 2 }, movementLogs);
        }

        [Fact(DisplayName = "Given the elevator is at floor 3, when requests are made for floors 2 (down), and 5 (up), 1 (down) then the elevator moves to floor 2, then floor 1, and only after completing all \"up\" requests, it moves to floor 5.")]
        public void RequestsAreProcessedInAFIFOOOrderFollowingTheDownDirection()
        {
            var elevator = ElevatorTestsExtensions.CreateTestElevator(startingFloor: 3);

            elevator.RequestFloor([2, 5, 1]);

            var movementLogs = elevator.GetOpenedDoors();

            Assert.Equal(new List<int> { 3, 2, 1, 5 }, movementLogs);
        }
    }

    public static class ElevatorTestsExtensions
    {
        public static Elevator CreateTestElevator(int minFloor = 0, int maxFloors = 10, int startingFloor = 0)
        {
            var elevator = new Elevator(minFloor, maxFloors);
            elevator.RequestFloor(startingFloor);
            return elevator;
        }
    }  
}