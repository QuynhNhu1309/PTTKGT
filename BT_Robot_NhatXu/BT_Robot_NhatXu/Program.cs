using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BT_Robot_NhatXu
{
    class Program
    {

        static int n = 0, m = 0, coin = 0 ;//số hàng, số cột
        static int[,] a = new int[20, 20];//Bảng có kích thước n, m
        static int[,] F = new int[20, 20];//Gía trị max của đồng xu
        static void Nhap()
        {
            Console.WriteLine("\n\n\t--- CHIEN LUOC QUI HOACH DONG - BAI TOAN ROBOT NHAT CAC DONG XU ---");
            Console.Write("\n\n\t\tNhap so hang cua bang chua dong xu: ");
            n = int.Parse(Console.ReadLine());

            Console.Write("\n\n\t\tNhap so cot cua bang chua dong xu: ");
            m = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    Console.Write("\n\t\ta[{0},{1}] = ", i, j);
                    coin = int.Parse(Console.ReadLine());
                    a[i, j] = coin;
                }
            }


            for (int i = 1; i <= n; i++)
            {
                F[0, i] = 0;
                F[i, 0] = 0;
            }


        }

        static void RobotCoinCollection()
        {
            int max = 0;
            F[1, 1] = a[1, 1];
            for (int j = 2; j <= m; j++)
            {
                F[1, j] = F[1, j - 1] + a[1, j];
            }

            for (int i = 2; i <= n; i++)
            {
                F[i, 1] = F[i - 1, 1] + a[i, 1];
                for (int j = 2; j <= m; j++)
                {
                    if(F[i - 1, j] >= F[i, j -1])
                    {
                        max = F[i - 1, j];
                    }
                    else if(F[i - 1, j] < F[i, j -1])
                    {
                        max = F[i, j -1];
                    }
                    F[i, j] = max + a[i, j];
                }
            }
        }
        static void Xuat()
        {

            Console.WriteLine("\n\n\t\tMa tran: ");

            for (int i = 1; i <= n; i++)
            {
                Console.Write("\t\t\t");
                for (int j = 1; j <= m; j++)
                {
                    Console.Write("{0}", F[i, j]);
                    Console.Write("\t");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n\n\t\tDuong di lui cua robot la: ");
            int tmp_n = n, tmp_m = m;
            int h = tmp_n;
            while (tmp_n > 0)
            {
                h = tmp_n;
                
                int k = tmp_m;

                if (h == n && k == m)
                {
                    Console.Write("\n\t\t[{0}, {1}]\n\n", h, k);
                }

                if (h <= 1 && k <= 1)
                {
                    break;
                }
                if (F[h - 1, k] >= F[h, k - 1])
                {
                    if (h - 1 < 1)
                    {
                        Console.Write("\t\t[{0}, {1}]\n\n", h, k - 1);
                    }
                    else
                    {
                        Console.Write("\t\t[{0}, {1}]\n\n", h - 1, k);
                    }
                    tmp_n = h - 1;
                    tmp_m = k;
                }

                else if (F[h - 1, k] <= F[h, k - 1])
                {
                    if (k - 1 < 1)
                    {
                        Console.Write("\t\t[{0}, {1}]\n\n", h - 1, k);
                    }
                    else
                    {
                        Console.Write("\t\t[{0}, {1}]\n\n", h, k - 1);
                    }
                    tmp_n = h;
                    tmp_m = k - 1;
                }
                
            }
                
            

        }

        static void KetLuan()
        {
            Console.Write("\n\n \t\t Bai toan su dung chien luoc qui hoach dong\n\n");
            Console.Write("\t\t Do phuc tap cua giai thuat O(nm) \n\n");

        }


        static void Main(string[] args)
        {
            Nhap();
            RobotCoinCollection();
            Xuat();
            KetLuan();
            Console.ReadLine();
        }
    }
}
