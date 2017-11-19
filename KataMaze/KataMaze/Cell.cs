using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMaze
{
    public class Cell
    {
        public bool HasBeenVisited { get; set; }
        public bool IsPath { get; set; }
        public bool HasWalked { get; set; }

        private bool[] _wall;
        public bool HasWall(Direction direction)
        {
            return _wall[(int)direction];
        }

        public void SetWall(Direction direction, bool value)
        {
            _wall[(int) direction] = value;
        }

        public Cell()
        {
            HasBeenVisited = false;
            HasWalked = false;
            IsPath = false;

            _wall = new bool[4];
            SetWall(Direction.up, true);
            SetWall(Direction.down, true);
            SetWall(Direction.left, true);
            SetWall(Direction.right, true);
        }

        public Cell Clone()
        {
            Cell clone = new Cell();
            clone.HasBeenVisited = HasBeenVisited;
            clone._wall = _wall;
            return clone;
        }
    }
}
