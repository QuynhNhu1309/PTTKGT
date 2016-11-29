using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geedy_Search_SaleMan
{
    class Program
    {

            static int n = 0;//số đỉnh
            static int[] tour = new int[10];
            static int s = 0;//đỉnh xuất phát
            //static int min = 0;
            static int length_value = 0;
            static int[,] a = new int[10, 10];//độ dài cung của từ đỉnh này đến đỉnh khác
            static int point = 0;
            static int cost = 0;
            static void Nhap()
            {
                Console.WriteLine("\n\n\t\t----- THUAT TOAN THAM LAM - BAI TOAN NGUOI DU LICH ----");
                Console.Write("\n\n\t\tNhap so dinh: ");
                n = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n\t\tNhap do dai tung cung: ");
            
                for (int i = 1; i <= n; i++)
                {
                    for (int j = i + 1; j <= n; j++)
                    {
                        Console.Write("\n\t\ta[{0},{1}] = ", i, j);
                        length_value = int.Parse(Console.ReadLine());
                        a[i, j] = length_value;
                        a[j, i] = a[i,j];
                    }
                    a[i, i] = 0;
                }

                do
                {
                    Console.Write("\n\n\t\tChon dinh xuat phat: ");
                    s = int.Parse(Console.ReadLine());
                    tour[1] = s;
                }
                while (s <= 0 || s > n);
            }
            static void Xuat()
            {
            
                Console.WriteLine("\n\n\t\tMa tran: ");
                
                for (int i = 1; i <= n; i++)
                {   Console.Write("\t\t\t");
                    for (int j = 1; j <= n; j++)
                    {
                        Console.Write("{0}", a[i, j]);
                        Console.Write("\t");
                    }
                    Console.WriteLine("\n");
                }
               
            }

            static bool KiemTra(int[] tour, int v, int n)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (tour[i] == v)//Kiểm tra đỉnh này đã đi qua chưa
                        return false;
                }
                return true;
            }

            static int TopNear(int s)
            {
                int min = 1000;
                
                for (int j = 1; j <= n; j++)
                {
                    bool test = KiemTra(tour, j, n);
                    if (a[s, j] > 0 && a[s, j] <= min && test == true)//Nếu chưa đi qua và là đỉnh có cung nhỏ nhất
                    {
                        min = a[s, j];
                        point = j;
                    }

                    if (a[s, j] > 0 && tour[n] != 0 && j == tour[1])//điều kiện thỏa đỉnh cuối cùng
                    {
                        point = tour[1];
                    }

                }
                return point;
            }

            static void Findway(int s)
            {
                int e = s;
                Console.Write("\n\t\tPATH = {0} --> ", s);
                for (int i = 2; i <= n +1 ; i++)
                {
                    int next = TopNear(e);//tìm đỉnh có độ dài cung nhỏ nhất và chưa đi qua
                    cost = cost + a[e, next];
                    tour[i] = next;
                    e = next;
                    
                    if (i != n + 1)
                    {
                        Console.Write("{0} --> ", tour[i]);
                    }
                    else
                    {
                        Console.Write("{0} ", tour[i]);
                    }
                }
                Console.Write("\n\n\t\tChi phi = {0}", cost);
            }

            static void KetLuan()
            {
                Console.WriteLine("\n\n\n\t\tBai toan su dung chien thuat tham lam\n\n");
                Console.WriteLine("\t\tDo phuc tap O(n2)");
            }


            static void Main(string[] args)
            {
                Nhap();
                Xuat();
                Findway(s);
                KetLuan();
                Console.ReadLine();
            }
    }
}
