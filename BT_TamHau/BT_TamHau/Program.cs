using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BT_TamHau
{
    class Program
    {
        static int r = 0, n = 8, z = 1;
        static int[] column = new int[9];
        static string[,] pos = new String[9, 9];
        static void HienThi()
        {
            Console.Write("\n\n\t\t---- GIAI THUAT MIN-MAX _ BAI TOAN TAM HAU -----\n\n\n\n");
        }

        static void Search()
        {
            r = n % 12;
            if (r == 8)
            {
                for (int i = 1; i <= n; i++)
                {
                        if (i % 2 == 0)
                        {
                            column[z] = i;//col[1] = 2; col[2] = 4; col[3] = 6; col[4] = 8;
                            z++;
                        }

                        if (i % 2 != 0)
                        {
                            column[z + 4] = i;//col[5] = 1; col[6] = 3; col[7] = 5; col[8] = 7;
                        }
                }

                int j = 5;
                while (j <= n && column[j] < column[j + 1])
                {
                    int tmp = column[j];
                    column[j] = column[j + 1];
                    column[j + 1] = tmp;//col[6] = 1; col[5] = 3; col[7] = 7; col[8] = 5;
                    j = j + 2;
                }
               

            }
        }

        static void Xuat()
        {
            Console.Write("\t");
            for (int i = 1; i <= 8; i++)
            {  
                Console.Write("\t {0} ", i);   
            }
            Console.Write("\t\t\t____________________________________________________________");
            Console.WriteLine("\n \t    |");
            

            for (int i = 1; i <= 8; i++)
            {
                Console.Write("\t {0}  |", i);
                for (int j = 1; j <= n; j++)
                {
                    int f = column[i];
                    //Console.Write(" f = {0} ", f);
                    if ( j != f)//nếu  j(cột) trùng với f thì chọn vị trí này. Vì theo thuật toán hàng là stt, còn cột là danh sách 
                        //mảng column
                    {
                        pos[i, f] = "_";
                    }
                    else
                    {
                        pos[i, f] = "X";
                    }
                    Console.Write(" \t {0} ", pos[i, f]);
                }
                Console.Write("\t\t    | \n ");
                Console.WriteLine("\t    | ");
                
            }

            Console.Write("\n\n Tam vi tri cua quan hau co the la: \n");
            for (int i = 1; i <= 8; i++)
            {
                    int f = column[i];
                    Console.Write(" \t ({0}, {1}) \n ", i, f);
            }
        }


        static void Main(string[] args)
        {
            HienThi();
            Search();
            Xuat();
            Console.ReadLine();
        }
    }
}
