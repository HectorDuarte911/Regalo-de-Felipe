namespace Exam;
public enum Direction
{
    Up, Down, Left, Right
}
public static class Solution
{
    public static int FindNumber(char[,] board, string message, Direction[][] paths)
    {
        int count = 0;
        int col = board.GetLength(1);
        int row = board.GetLength(0);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (board[i, j] == message[0])
                {
                    for (int k = 0; k < paths.Length; k++)
                    {
                        count += Marches(board, message, paths[k], i, j);
                    }
                }
            }
        }
        return count;
    }
    public static int Marches(char[,] board, string message, Direction[] path, int row, int col)
    {
        if (path.Length != message.Length - 1) return 0;
        for (int i = 0; i < path.Length; i++)
        {
            switch (path[i])
            {
                case Direction.Up: row--; break;
                case Direction.Down: row++; break;
                case Direction.Left: col--; break;
                case Direction.Right: col++; break;
            }
            if (row >= board.GetLength(0) || col >= board.GetLength(1) || row < 0 || col < 0) return 0;
            if (message[i + 1] != board[row, col]) return 0;
        }
        return 1;
    }
}



