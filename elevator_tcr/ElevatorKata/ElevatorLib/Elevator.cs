namespace ElevatorLib
{
    public class Elevator
    {
        private int _minFloor;
        private int _maxFloors;
        private int _currentFloor;
        private List<int> _movementLogs = new List<int>();

        public Elevator(int minFloor, int maxFloors)
        {
            _minFloor = minFloor;
            _maxFloors = maxFloors;
            _currentFloor = minFloor;
        }

        public int GetCurrentFloor()
        {
            return _currentFloor;
        }

        public List<int> GetOpenedDoors()
        {
            return _movementLogs;
        }

        public void RequestFloor(params int[] floors)
        {
            foreach (var floor in floors)
            {
                if (floor >= _minFloor && floor < _maxFloors)
                {
                    SetCurrentFloor(floor);
                }
            }
        }
        
        private void SetCurrentFloor(int floor)
        {
            _currentFloor = floor;
            _movementLogs.Add(floor);        
        }
    }
}
