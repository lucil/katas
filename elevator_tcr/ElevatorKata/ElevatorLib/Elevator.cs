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

        public void MoveTo(int floor)
        {
            if (floor < 0 || floor > 9)
            {
                throw new ArgumentException("Invalid floor request.");
            }
            _currentFloor = floor;
        }
    }
}
