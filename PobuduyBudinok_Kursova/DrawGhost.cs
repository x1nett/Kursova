using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainWindow : Form
    {
        // Відображати місце падіння фігури
        private void DrawGhost()
        {
            // Список Ghost2 є тестовою позицією Ghost
            // Список привидів – це фактична позиція передмісць після тестування
            Control[] Ghost2 = { null, null, null, null };
            bool ghostFound = false;

            // Видалити попередній Ghost
            foreach (Control x in Ghost)
            {
                if (x != null)
                {
                    if (x.BackColor == Color.LightGray)
                    {
                        x.BackColor = Color.White;
                    }
                }
            }

            // Скопіюйте activePiece до Ghost2
            for (int x = 0; x < 4; x++)
            {
                Ghost2[x] = activePiece2[x];
            }

            // Тест Ghost2 у кожному рядку
            for (int x = 21; x > 1; x--)
            {
                // Отримайте позицію тестового Ghost2, починаючи з нижнього рядка
                if (currentPiece == 0) //I piece
                {
                    if (rotations == 0)
                    {
                        if (x == 2)
                        {
                            Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                            Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                            Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                            Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                        }
                        else
                        {
                            Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                            Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                            Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x - 2);
                            Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 3);
                        }
                    }
                    else if (rotations == 1)
                    {
                        if (x == 2) //ігнорувати
                        {
                            Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                            Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                            Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                            Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                        }

                        else //проблема
                        {
                            Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                            Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x);
                            Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                            Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x);
                        }
                    }
                }
                else if (currentPiece == 1) // L piece
                {
                    if (rotations == 0)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 2);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x);
                    }
                    else if (rotations == 1)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 1);
                    }
                    else if (rotations == 2)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 2);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 2);
                    }
                    else if (rotations == 3)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x - 1);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x);
                    }
                }
                else if (currentPiece == 2) // J piece
                {
                    if (rotations == 0)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 2);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x);
                    }
                    else if (rotations == 1)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x - 1);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x);
                    }
                    else if (rotations == 2)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 2);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 2);
                    }
                    else if (rotations == 3)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 1);
                    }
                }
                else if (currentPiece == 3) // S piece
                {
                    if (rotations == 0)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x - 1);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 1);
                    }
                    else if (rotations == 1)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 2);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 1);
                    }
                }
                else if (currentPiece == 4) // Z piece
                {
                    if (rotations == 0)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x);
                    }
                    else if (rotations == 1)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x - 1);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 2);
                    }
                }
                else if (currentPiece == 5) // O piece
                {
                    Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                    Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                    Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                    Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x);
                }
                else if (currentPiece == 6) //T piece
                {
                    if (rotations == 0)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x);
                    }
                    else if (rotations == 1)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 2);
                    }
                    else if (rotations == 2)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x - 1);
                    }
                    else if (rotations == 3)
                    {
                        Ghost2[0] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[0]), x - 1);
                        Ghost2[1] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[1]), x - 1);
                        Ghost2[2] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[2]), x - 2);
                        Ghost2[3] = grid.GetControlFromPosition(grid.GetColumn(Ghost2[3]), x);
                    }
                }

                //Якщо не збережено дійсного Ghost
                if (ghostFound == false)
                {
                    // Якщо всі квадрати в тесті Ghost2 білі
                    if (
                        (Ghost2[0].BackColor == Color.White | activePiece.Contains(Ghost2[0])) &
                        (Ghost2[1].BackColor == Color.White | activePiece.Contains(Ghost2[1])) &
                        (Ghost2[2].BackColor == Color.White | activePiece.Contains(Ghost2[2])) &
                        (Ghost2[3].BackColor == Color.White | activePiece.Contains(Ghost2[3]))
                        )
                    {

                        // Збереження Ghost
                        ghostFound = true;
                        for (int y = 0; y < 4; y++)
                        {
                            Ghost[y] = Ghost2[y];
                        }
                    }

                    // Якщо не все біле (і нічого не збережено), перевірити наступний рядок
                    else
                    {
                        continue;
                    }
                }

                //дійсний ghost уже збережено
                else if (ghostFound == true)
                {

                    //Не всі квадрати білі
                    if (Ghost2[0].BackColor != Color.White | Ghost2[1].BackColor != Color.White | Ghost2[2].BackColor != Color.White | Ghost2[3].BackColor != Color.White)
                    {

                        //Чи падає фігура нижче x?
                        if (grid.GetRow(activePiece[0]) >= x | grid.GetRow(activePiece[1]) >= x | grid.GetRow(activePiece[2]) >= x | grid.GetRow(activePiece[3]) >= x)
                        {
                            continue;
                        }


                        //Ресет
                        ghostFound = false;
                        for (int y = 0; y < 4; y++)
                        {
                            Ghost[y] = null;
                        }
                        continue;
                    }
                }
            }

            //Відмалювати ghost
            if (ghostFound == true)
            {
                for (int x = 0; x < 4; x++)
                {
                    Ghost[x].BackColor = Color.LightGray;
                }
            }
        }
    }
}