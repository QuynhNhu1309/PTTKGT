using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BT_ToMau_DoThi
{
    class Program
    {
        static int n = 0, n_color = 0;
        static int[] bac = new int[100];
        static int[,] a = new int[100, 100];
        static int[,] relative = new int[100, 100];
        static int[] mau = new int[100];
        
        static void Nhap()
        {
            Console.WriteLine("\n\n\t\t---------  GREEDY SEARCH_ BAI TOAN TO MAU DO THI ------\n\n");
            bac[0] = 0;
            Console.Write("\n\n\t\tNhap so dinh cua do thi can to mau: ");
            n = int.Parse(Console.ReadLine());

            //Console.Write("\n\n\t\tNhap so mau toi da can to: ");
            //n_color = int.Parse(Console.ReadLine());
            n_color = 99;
            Console.Write("\n\t\tNhap do dai tung cung.\n Neu 2 dinh khong co moi quan he thi nhap do dai = 0 nguoc lai thi nhap = 1\n");

            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    Console.Write("\n\t\ta[{0},{1}] = ", i, j);
                    a[i, j] = int.Parse(Console.ReadLine());
                    a[j, i] = a[i, j];
                    if (a[i, j] != 0 && a[i, j] != 1)
                    {
                        Console.WriteLine("\n\t\t Ban phai nhap 0 hoac 1. Nhap lai nao!");
                        j--;
                    }
                    

                }
                a[i, i] = 0;
                mau[i] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (a[i, j] > 0 || a[j, i] > 0)
                        bac[i] = bac[i] + 1;
                }
            }
        }

        static int Max_Function()
        {
            int point = 0, max = 0;
            for (int i = 1; i <= n; i++)
            {
                if (bac[i] > max)//Tìm đỉnh có bậc lớn nhất
                {
                    max = bac[i];
                    point = i;
                }
                if (bac[i] == 0 && mau[i] == 0)//Những đỉnh có bậc = 0 và chưa được tô màu
                {
                    max = bac[i];
                    point = i;
                }
            }
            return point;
        }

        static Boolean Check_Colour(int point)
        {
            int e = point;
            bool test = true; 
            for (int j = 1; j <= n; j++)
            {
                if (a[e, j] > 0 && mau[e] == mau[j])//e có quan hệ với đỉnh j và có trùng màu thì false
                {
                    test = false;
                    break;
                }
            }
            return test;
        }

        static void Colour()
        {
                int point = Max_Function();
                for (int color = 1; color <= n_color; color++)
                {
                    mau[point] = color;
                    if (Check_Colour(point))
                    {
                        bac[point] = 0;
                        for (int j = 1; j <= n; j++)
                        {
                            if ((a[point, j] > 0 || a[j, point] > 0) && mau[j] == 0)
                            {
                                bac[j] = bac[j] - 1;//Hạ bậc của những đỉnh có quan hệ mà chưa tô màu
                            }
                        }
                        break;
                    }

                }
            }

        static void Xuat()
        {
            for (int i = 1; i <= n; i++)
            {
                Colour();
            }

            for (int i = 1; i <= n; i++)
            {
                Console.Write("Mau cua dinh {0} la: {1}", i, mau[i]);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Nhap();
            Xuat();
            Console.ReadLine();
        }
    }
}
