namespace KataGameOfLife2
{
    public interface IBoard
    {
        int DimX { get; }
        int DimY { get; }

        bool IsAlive(int x, int y);
        void LoadBoard(string fields);
        string Print();
        void SetAlive(int x, int y, bool alive);
        void SetBoardDim(int dimx, int dimy);
    }
}