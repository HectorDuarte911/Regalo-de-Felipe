namespace Exam;
public enum Direction
{
    Up, Down, Left, Right
}
public static class Solution
{
    public static int FindNumber(char[,] board, string target, Direction[][] paths)
    {
        //Por los datos se supone que ninguno de los componentes puede ser null o estar vacio
        int MatchCount = 0;//Contador de match
        //Aqui asumo que si el board es de un solo espacio y el target es el char en ese espacio se debe contar cualquier direccion que se ponga como valida  
        if (board.GetLength(0) == 1 && board.GetLength(1) == 1)
        {
            if (target.Length == 1 && target[0] == board[0, 0]) return paths.Length;
            else return 0;
        }
        else
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)//Estos dos primeros for son para recorrer el array
                {
                    if (board[i, j] == target[0])//Aqui compruebo cual de las posiciones tiene el primer caracter del target
                    {
                        for (int k = 0; k < paths.Length; k++)//Aqui recorro todas los array de direcciones 
                        {
                            int Actualrow = i;
                            int Actualcolumn = j;//Inicio dos variables auxiliares para representar la posicion que estoy analizando
                            for (int l = 1; l < target.Length; l++)//Recorro los char de target desde el segundo char
                            {
                                switch (paths[k][l - 1])//Cambio los valores del recorrido segun la direccion 
                                {
                                    case Direction.Up:
                                        if (Actualrow - 1 >= 0) Actualrow--;
                                        break;
                                    case Direction.Down:
                                        if (Actualcolumn + 1 < board.GetLength(0)) Actualrow++;
                                        break;
                                    case Direction.Left:
                                        if (Actualcolumn - 1 >= 0) Actualcolumn--;
                                        break;
                                    case Direction.Right:
                                        if (Actualcolumn + 1 < board.GetLength(1)) Actualcolumn++;
                                        break;
                                }
                                if (target[l] != board[Actualrow, Actualcolumn]) break;//Compruebo si hay algun char que no coincido para continuar o abandonar la obcion actual
                                if (l == target.Length - 1) MatchCount++;//Si el bucle llega al ultimo char del target y no ha parado significa que la palbra se completo y por tanto aumentamos el contador inicial
                            }
                        }
                    }
                }
            }
        }
        return MatchCount;
    }
}

