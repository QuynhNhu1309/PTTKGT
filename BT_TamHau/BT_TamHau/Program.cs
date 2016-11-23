using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BT_TamHau
{
    class Program
    {
        static int r = 0, n = 0, z = 1;
        static int[] column = new int[100];
        static string[,] pos = new String[100, 100];
        static void HienThi()
        {
            Console.Write("\n\n\t\t---- GIAI THUAT MIN-MAX _ BAI TOAN TAM HAU -----\n\n\n\n");
            Console.Write("Nhap so quan hau: ");
            n = int.Parse(Console.ReadLine());
        }

        static void Search()
        {
            r = n % 12;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    column[z] = i;//col[1] = 2; col[2] = 4; col[3] = 6; col[4] = 8;
                    //Console.Write("column[chan]= {0}", column[z]);
                    z++;
                }

                if (i % 2 != 0)
                {
                    int tmp = z + (n / 2);
                    column[tmp] = i;//col[5] = 1; col[6] = 3; col[7] = 5; col[8] = 7;

                    //Console.Write("\ncolumn[le]= {0}", column[tmp]);

                }
            }

            if (r == 8)
            {
                
                int j = n/2 + 1;
                while (j <= n && column[j] < column[j + 1])
                {
                    int tmp = column[j];
                    column[j] = column[j + 1];
                    column[j + 1] = tmp;//col[6] = 1; col[5] = 3; col[7] = 7; col[8] = 5;
                    //Console.Write("----\n");
                    //Console.Write("column hoan vi j = {0}, [j] = {1} ", j, column[j]);
                    //Console.Write("column hoan vi j + 1= {0}, [j + 1] = {1} ", j + 1, column[j + 1]);
                    j = j + 2;
                    
                }
               

            }


            if (r == 2)
            {

                int j = n / 2 + 1;
                while (j <= n && column[j] == 1 && column[j + 1] == 3)
                {
                    int tmp = column[j];
                    column[j] = column[j + 1];
                    column[j + 1] = tmp; //col[8] = 3, col[9] = 1
                    //Console.Write("----\n");
                    //Console.Write("column hoan vi j = {0}, [j] = {1} ", j, column[j]);
                    //Console.Write("column hoan vi j + 1= {0}, [j + 1] = {1} ", j + 1, column[j + 1]);
                    j = j + 2;

                }

                if (column[j] == 5)
                {
                    //column[n + 1] = 5;
                    Console.Write(" j = {0}", j);

                    for (j = n / 2 + 3; j < n; j++)
                    {
                        column[j] = column[j + 1];
                    }
                    column[n] = 5;

                    for (int k = 1; k <= n; k++)
                    {
                        //Console.Write("column[{0}] = {1}", k, column[k]);
                    }
                    
                }


            }

            if (r == 3 || r == 9)
            {
               
                for (int j = 0; j < n/2; j++)
                {
                    column[j] = column[j + 1];
                }
                column[n / 2] = 2;

                for (int j = n/2 + 1; j < n - 1; j++)
                {
                    column[j] = column[j + 2];
                }
                column[n - 1] = 1;
                column[n] = 3;


                    for (int k = 1; k <= n; k++)
                    {
                        //Console.Write("column[{0}] = {1}", k, column[k]);
                    }



            }




            
        }

        static void Xuat()
        {
            Console.Write("\t");
            for (int i = 1; i <= n; i++)
            {  
                Console.Write("\t {0} ", i);   
            }
            Console.Write("\t\t\t____________________________________________________________");
            Console.WriteLine("\n \t    |");
            

            for (int i = 1; i <= n; i++)
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

            Console.Write("\n\n Vi tri cua quan hau co the la: \n");
            for (int i = 1; i <= n; i++)
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
