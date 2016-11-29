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
            Console.Write("\n\n\t\t---- GIAI THUAT MIN-MAX _ BAI TOAN QUAN HAU -----\n\n\n\n");
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

        static void KetLuan()
        {
            Console.Write("\n\n Bai toan su dung chien thuat vet can");
            Console.Write("\n\n Do phuc tap :O(n2)");
        }


        static void Main(string[] args)
        {
            HienThi();
            while (n < 4)
            {
                Console.Write(" \n \n So quan hau phai lon hon hoac 4");
                HienThi();
            }
            Search();
            Xuat();
            KetLuan();
                
           
            Console.ReadLine();
        }

                    //        Xây dựng một lời giải
                    //Có một giải thuật đơn giản tìm một lời giải cho bài toán n quân hậu với n = 1 hoặc n ≥ 4:
                    //1. Chia n cho 12 lấy số dư r. (r= 8 với bài toán tám quân hậu).
                    //2. Viết lần lượt các số chẵn từ 2 đến n.
                    //3. Nếu số dư r là 3 hoặc 9, chuyển 2 xuống cuối danh sách.
                    //4. Bổ sung lần lượt các số lẻ từ 1 đến n vào cuối danh sách, nhưng nếu r là 8, đổi chỗ từng cặp nghĩa là được 3, 1, 7,
                    //5, 11, 9, ….
                    //5. Nếu r = 2, đổi chỗ 1 và 3, sau đó chuyển 5 xuống cuối danh sách.
                    //6. Nếu r = 3 hoặc 9, chuyển 1 và 3 xuống cuối danh sách.
                    //7. Lấy danh sách trên làm danh sách chỉ số cột, ghép vào danh sách chỉ số dòng theo thứ tự tự nhiên ta được một lời
                    //giải của bài toán.
                    //Sau đây là một số ví dụ
                    //• 14 quân hậu (r = 2): 2, 4, 6, 8, 10, 12, 14, 3, 1, 7, 9, 11, 13, 5.
                    //• 15 quân hậu (r = 3): 4, 6, 8, 10, 12, 14, 2, 5, 7, 9, 11, 13, 15, 1, 3.
                    //• 20 quân hậu (r= 8): 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 3, 1, 7, 5, 11, 9, 15, 13, 19, 17
    }
}
