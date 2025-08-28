namespace ElevatorLib
{
    public class Elevator
    {
        private int _currentFloor;

        public Elevator()
        {
            _currentFloor = 0; // Elevator starts at ground floor
        }

        public int GetCurrentFloor()
        {
            return _currentFloor;
        }
    }
}
