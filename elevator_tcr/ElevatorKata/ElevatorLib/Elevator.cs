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
            var orderedFloors = OrderFloorsByDirection(floors.ToList());
            foreach (var floor in orderedFloors)
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
        
        private List<int> OrderFloorsByDirection(List<int> floors)
        {
            var firstRequestedFloor = floors.FirstOrDefault();
            var isUpDirection = firstRequestedFloor > _currentFloor;
            var upRequests = floors.Where(f => f > firstRequestedFloor).OrderBy(f => f).ToList();
            var downRequests = floors.Where(f => f < firstRequestedFloor).OrderByDescending(f => f).ToList();

            var result = new List<int> { firstRequestedFloor };

            if (isUpDirection)
            {
                result.AddRange(upRequests);
                result.AddRange(downRequests);
                return result;
            }
            else
            {
                result.AddRange(downRequests);
                result.AddRange(upRequests);
                return result;
            }
        }
    }
}
