using System;

namespace _2048
{
    class Program
    {
        static int score = 0;
        static void Main(string[] args)
        {
            //int score = 0;
            int[,] field = createField();
            field = spawnNumberAtRandomPos(field);
            while (canPlay(field))
            {
                Console.Clear();
                Console.WriteLine($"Your SCORE: {score}");
                render(field);
                field = move(field,selectDirection());
            }
            Console.Clear();
            Console.WriteLine($"Your SCORE: {score}");
            render(field);
            Console.WriteLine($"GameOVER");
            Console.WriteLine($"Press 'ESC' for exit");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape) break;
            }
        }
        static int[,] createField()
        {
            Random rnd = new Random();
            int[,] field = new int[4, 4];

            int lenghtDimen0, lenghtDimen1;
            lenghtDimen0 = field.GetLength(0);
            lenghtDimen1 = field.GetLength(1);

            for (int i = 0; i < lenghtDimen0; i++)
            {
                for (int k = 0; k < lenghtDimen1; k++)
                {
                    field[i, k] = 0;
                }
            }
            return field;
        }
        static void render(int[,] field)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string sep = "-";
            for (int l = 0; l < field.GetLength(1) * 16; l++)
            {
                sep += "-";
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {              
                Console.WriteLine(sep);
                Console.Write("|");
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write("\t");
                    Console.ForegroundColor = setColor(field[i,j]);
                    Console.Write(field[i, j] + "\t");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine(sep);
            Console.ResetColor();
        }
        static ConsoleColor setColor(int value)
        {
            switch (value)
            {
                case 0:
                    return ConsoleColor.DarkYellow;
                case 2:
                    return ConsoleColor.Blue;
                case 4:
                    return ConsoleColor.Cyan;
                case 8:
                    return ConsoleColor.Gray;
                case 16:
                    return ConsoleColor.Green;
                case 32:
                    return ConsoleColor.Red;
                case 64:
                    return ConsoleColor.Yellow;
                case 128:
                    return ConsoleColor.DarkBlue;
                case 256:
                    return ConsoleColor.DarkCyan;
                case 512:
                    return ConsoleColor.DarkGray;
                case 1024:
                    return ConsoleColor.DarkGreen;
                case 2048:
                    return ConsoleColor.DarkRed;
                case 4096:
                    return ConsoleColor.DarkYellow;

                default:
                    return ConsoleColor.White;
            }
        }
        static bool canPlay(int[,] field)
        {
            bool hasEmpty = false;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                if (hasEmpty) break;
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    if(field[i,k] == 0)
                    {
                        hasEmpty = true;
                        break;
                    }
                }
            }

            bool canMarge = false;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    if (canMarge) break;
                    if (i == 0 && k == 0)
                    {
                        if (field[i, k] == field[i + 1, k] || field[i, k] == field[i, k + 1])
                        {
                            canMarge = true;
                            break;
                        }
                    }
                    else
                    if (i == field.GetLength(0) - 1 && k == field.GetLength(1) - 1)
                    {
                        if (field[i, k] == field[i - 1, k] || field[i, k] == field[i, k - 1])
                        {
                            canMarge = true;
                            break;
                        }
                    }
                    else
                    if (i == 0 && k == field.GetLength(1) - 1)
                    {
                        if (field[i, k] == field[i + 1, k] || field[i, k] == field[i, k - 1])
                        {
                            canMarge = true;
                            break;
                        }
                    }
                    else
                    if (i == field.GetLength(0) - 1 && k == 0)
                    {
                        if (field[i, k] == field[i - 1, k] || field[i, k] == field[i, k + 1])
                        {
                            canMarge = true;
                            break;
                        }
                    }
                }
            }




            return canMarge || hasEmpty;
        }
        static int[,] spawnNumberAtRandomPos(int[,] field)
        {
            Random rnd = new Random();
            bool canSpawn = false;
            int y = rnd.Next(0, field.GetLength(0));
            int x = rnd.Next(0, field.GetLength(1));
            for (int i = 0; i < field.GetLength(0); i++)
            {
                if (!canSpawn)
                {
                    for (int k = 0; k < field.GetLength(1); k++)
                    {
                        if (field[i, k] == 0)
                        {
                            canSpawn = true;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            if(!canSpawn)
            {
                return field;
            }

            bool spawned = false;
            while(!spawned)
            {
                if (field[y, x] == 0)
                {
                    field[y, x] = 2;
                    spawned = true;
                }
                else
                {
                    y = rnd.Next(0, field.GetLength(0));
                    x = rnd.Next(0, field.GetLength(1));
                }
            }
            return field;
        }
        static int[,] move(int[,] field,int direction)
        {
            int frow = field.GetLength(0);
            int fcol = field.GetLength(1);
            switch (direction)
            {
                case 1:
                    return moveUp(field);
                case 2:
                    return moveDown(field);
                case 3:
                    return moveLeft(field);
                case 4:
                    return moveRight(field);
                default:
                    return field;
            }
        }
        static int selectDirection()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        return 1;
                    case ConsoleKey.DownArrow:
                        return 2;
                    case ConsoleKey.LeftArrow:
                        return 3;
                    case ConsoleKey.RightArrow:
                        return 4;
                    default:
                        Console.WriteLine("Wrong Key");
                        Console.WriteLine(" ↑ ");
                        Console.WriteLine("← →");
                        Console.WriteLine(" ↓ ");
                        continue;
                }
            }
        }
        static int[,] moveUp(int[,] field)
        {
            int[,] copyField = field;
            bool canMove = false;
            int counter = 0;
            int[] col = new int[field.GetLength(0)];
            for (int k = 0; k < field.GetLength(1); k++)
            {
                for (int i = 0; i < col.Length; i++)
                {
                col[i] = 0;
                };

                //merge
                int xN1 = -1, yN1 = -1;
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    if (field[i, k] == 0)
                    {
                        continue;
                    }
                    else
                    {                       
                        if(xN1 >= 0 && field[xN1,yN1] == field[i,k])
                        {
                            addScore(field[xN1, yN1] + field[i, k]);
                            field[xN1, yN1] += field[i, k];
                            field[i, k] = 0;
                            xN1 = -1;
                            yN1 = -1;
                            canMove = true;
                        }
                        else
                        {
                            xN1 = i;
                            yN1 = k;
                        }
                    }
                }
                
                //end merge

                for (int i = 0; i < field.GetLength(0); i++)
                {
                    if(field[i,k]==0)
                    {
                        continue;
                    }
                    else
                    {
                        if (i-1 >= 0 && field[i - 1, k] == 0) canMove = true;
                        col[counter] = field[i, k];
                        counter++;
                    }
                }

                for (int i = 0; i < field.GetLength(0); i++)
                {
                        field[i, k] = col[i];
                }
                counter = 0;
            }
            
            if(canMove)
            {
                field = spawnNumberAtRandomPos(field);
                return field;
            }
            return copyField;
        }
        static int[,] moveDown(int[,] field)
        {
            int[,] copyField = field;
            bool canMove = false;
            int counter = 0;
            int[] col = new int[field.GetLength(0)];
            for (int k = 0; k < field.GetLength(1); k++)
            {
                for (int i = 0; i < col.Length; i++)
                {
                    col[i] = 0;
                };

                //merge
                int xN1 = -1, yN1 = -1;
                for (int i = field.GetLength(0) - 1; i >= 0; i--)
                {
                    if (field[i, k] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (xN1 >= 0 && field[xN1, yN1] == field[i, k])
                        {
                            addScore(field[xN1, yN1] + field[i, k]);
                            field[xN1, yN1] += field[i, k];
                            field[i, k] = 0;
                            xN1 = -1;
                            yN1 = -1;
                            canMove = true;
                        }
                        else
                        {
                            xN1 = i;
                            yN1 = k;
                        }
                    }
                }
                //end merge

                for (int i = field.GetLength(0)-1; i >= 0; i--)
                {
                    if (field[i, k] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (i + 1 < field.GetLength(1) && field[i + 1, k] == 0) canMove = true;
                        col[col.Length-counter-1] = field[i, k];
                        counter++;
                    }
                }

                for (int i = field.GetLength(0)-1; i >= 0; i--)
                {
                    field[i, k] = col[i];
                }
                counter = 0;
            }

            if (canMove)
            {
                field = spawnNumberAtRandomPos(field);
                return field;
            }
            return copyField;
        }
        static int[,] moveLeft(int[,] field)
        {
            int[,] copyField = field;
            bool canMove = false;
            int counter = 0;
            int[] col = new int[field.GetLength(0)];
            for (int k = 0; k < field.GetLength(1); k++)
            {
                for (int i = 0; i < col.Length; i++)
                {
                    col[i] = 0;
                };

                //merge
                int xN1 = -1, yN1 = -1;
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    if (field[k, i] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (yN1 >= 0 && field[yN1, xN1] == field[k, i])
                        {
                            addScore(field[yN1, xN1] + field[k, i]);
                            field[yN1, xN1] += field[k, i];
                            field[k, i] = 0;
                            xN1 = -1;
                            yN1 = -1;
                            canMove = true;
                        }
                        else
                        {
                            xN1 = i;
                            yN1 = k;
                        }
                    }
                }
                //end merge

                for (int i = 0; i < field.GetLength(0); i++)
                {
                    if (field[k, i] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (i - 1 >= 0 && field[k, i - 1] == 0) canMove = true;
                        col[counter] = field[k, i];
                        counter++;
                    }
                }

                for (int i = 0; i < field.GetLength(0); i++)
                {
                    field[k, i] = col[i];
                }
                counter = 0;
            }

            if (canMove)
            {
                field = spawnNumberAtRandomPos(field);
                return field;
            }
            return copyField;
        }
        static int[,] moveRight(int[,] field)
        {
            int[,] copyField = field;
            bool canMove = false;
            int counter = 0;
            int[] col = new int[field.GetLength(0)];
            for (int k = 0; k < field.GetLength(1); k++)
            {
                for (int i = 0; i < col.Length; i++)
                {
                    col[i] = 0;
                };

                //merge
                int xN1 = -1, yN1 = -1;
                for (int i = field.GetLength(0) - 1; i >= 0; i--)
                {
                    if (field[k, i] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (yN1 >= 0 && field[yN1, xN1] == field[k, i])
                        {
                            addScore(field[yN1, xN1] + field[k, i]);
                            field[yN1, xN1] += field[k, i];
                            field[k, i] = 0;
                            xN1 = -1;
                            yN1 = -1;
                            canMove = true;
                        }
                        else
                        {
                            xN1 = i;
                            yN1 = k;
                        }
                    }
                }
                //end merge

                for (int i = field.GetLength(0) - 1; i >= 0; i--)
                {
                    if (field[k, i] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (i + 1 < field.GetLength(1) && field[k, i + 1] == 0) canMove = true;
                        col[col.Length - counter - 1] = field[k, i];
                        counter++;
                    }
                }

                for (int i = field.GetLength(0) - 1; i >= 0; i--)
                {
                    field[k, i] = col[i];
                }
                counter = 0;
            }

            if (canMove)
            {
                field = spawnNumberAtRandomPos(field);
                return field;
            }
            return copyField;
        }
        static void addScore(int numberOfScore)
        {
            score += numberOfScore;
        }
    }


}
