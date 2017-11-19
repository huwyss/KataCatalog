namespace KataGameOfLife
{
    public interface IBoard
    {
        int DimX { get; }
        int DimY { get; }

        bool IsAlive(int x, int y);
        void LoadBoard(string fields);
        int NumberAliveNeighbors(int x, int y);
        void SetAlive(int x, int y, bool alive);
        void SetBoardDim(int x, int y);
        string ToString();
    }
}