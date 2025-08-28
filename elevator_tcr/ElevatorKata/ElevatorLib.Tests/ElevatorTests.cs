using System;
using System.Collections.Generic;
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
            var elevator = new Elevator();
            Assert.Equal(0, elevator.GetCurrentFloor());
        }
    }
}
