using GrblExpress.Common.Interfaces;
using GrblExpress.Common.Types;

namespace GrblExpress.Common.Objects
{
    public class GrblMachine
    {
        public IMachineConnection? Connection { get; set; }

        public GrblMachineState State { get; set; } = GrblMachineState.Unknown;

        public Coordinates MachinePosition { get; set; } = new();

        public Coordinates WorkPosition { get; set; } = new();
    }
}
