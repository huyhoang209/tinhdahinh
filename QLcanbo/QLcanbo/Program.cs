﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLcanbo
{
    class Program
    {
        static void Main(string[] args)
        {
            QLCB cb72 = new QLCB();
            cb72.Menu();
            Console.ReadKey();
        }
    }
    class Utility
    {
        public static int Level()
        {
            int a72;
            while (true)
            {
                try
                {
                    a72 = int.Parse(Console.ReadLine());
                    if (a72 > 7)
                    {
                        Console.WriteLine("cap bac khong hon 7!");
                        a72 = int.Parse(Console.ReadLine());
                    }
                    return a72;
                }
                catch (System.Exception)
                {

                    Console.WriteLine("Nhap lai!!");
                }
            }
        }
        public static int choose()
        {
            int a72;
            while (true)
            {
                try
                {
                    a72 = int.Parse(Console.ReadLine());
                    return a72;
                }
                catch (System.Exception)
                {

                    Console.WriteLine("Nhap lai!!");
                }
            }
        }
    }
    class Canbo
    {
        public string fullName72;
        public string dob72;
        public string gender72;
        public Canbo() { }
        public Canbo(string name72, string dob72, string gender72)
        {
            this.fullName72 = name72;
            this.dob72 = dob72;
            this.gender72 = gender72;
        }

        public virtual void Input()
        {
            Console.WriteLine("=====NHap du lieu Can bo=====");
            Console.WriteLine("Nhap Ho va Ten : ");
            fullName72 = Console.ReadLine();
            Console.WriteLine("Nhap ngay sinh: ");
            dob72 = Console.ReadLine();
            Console.WriteLine("Nhap gioi tinh:  ");
            gender72 = Console.ReadLine();
        }
        public virtual void Display()
        {
            Console.Write("Ho va Ten: {0} , Ngay sinh : {1} , Gioi tinh: {2} ", fullName72, dob72, gender72);
        }
    }
    class CongNhan : Canbo
    {
        public int level72 { get; set; }
        public CongNhan() { }
        public CongNhan(string name72, string dob72, string gender72, int level72) : base(name72, dob72, gender72)
        {
            this.level72 = level72;
        }
        public override void Input()
        {
            base.Input();
            Console.WriteLine("Nhap cap bac: ");
            level72 = Utility.Level();
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine(" , Cap Bac: " + level72 + "/10");
        }
    }
    class Kysu : Canbo
    {
        public string nganh { get; set; }
        public Kysu() { }
        public Kysu(string name72, string dob72, string gender72, string nganh) : base(name72, dob72, gender72)
        {
            this.nganh = nganh;
        }
        public override void Input()
        {
            base.Input();
            Console.WriteLine("Nhap nganh dao tao: ");
            nganh = Console.ReadLine();
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine(" , Nganh dao tao: " + nganh);
        }
    }
    class Nhanvien : Canbo
    {
        public string job { get; set; }
        public Nhanvien() { }
        public Nhanvien(string name72, string dob72, string gender72, string job) : base(name72, dob72, gender72)
        {
            this.job = job;
        }
        public override void Input()
        {
            base.Input();
            Console.WriteLine("Nhap Cong viec: ");
            job = Console.ReadLine();
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine(" , Nhan vien phuc vu: " + job);
        }
    }
    class QLCB
    {
        private List<Canbo> listCanbo = new List<Canbo>();
        public QLCB() { }
        public void Menu()
        {
            int choose;
            do
            {
                Console.WriteLine("1. Nhap thong tin moi cho can bo");
                Console.WriteLine("2. Tim kiem theo ho va ten");
                Console.WriteLine("3. Hien thi thong tin cua toan can bo");
                Console.WriteLine("4. Thoat");
                choose = Utility.choose();
                switch (choose)
                {
                    case 1:
                        add();
                        break;
                    case 2:
                        search();
                        break;
                    case 3:
                        View();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Nhap lai !!!");
                        break;
                }
            } while (choose != 4);
        }

        public void add()
        {
            int num;
            do
            {
                Console.WriteLine("===Chon vi tri muon them===");
                Console.WriteLine("1.Nhan vien");
                Console.WriteLine("2.Ki Su");
                Console.WriteLine("3.Cong nhan");
                Console.WriteLine("4.Thoat");
                int d = Utility.choose();
                num = d;
                switch (d)
                {
                    case 1:
                        Nhanvien nv = new Nhanvien();
                        nv.Input();
                        listCanbo.Add(nv);

                        break;
                    case 2:

                        Kysu ks = new Kysu();
                        ks.Input();
                        listCanbo.Add(ks);

                        break;
                    case 3:

                        CongNhan cn = new CongNhan();
                        cn.Input();
                        listCanbo.Add(cn);

                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Nhap lai !!");
                        break;
                }
            } while (num != 4);
        }
        public void search()
        {
            Console.WriteLine("Nhap ten can bo can tim: ");
            string name = Console.ReadLine();
            for (int i = 0; i < listCanbo.Count; i++)
            {
                if (listCanbo[i].fullName72.Equals(name))
                {
                    listCanbo[i].Display();
                }
            }
        }
        public void View()
        {
            if (listCanbo.Count == 0)
            {
                Console.WriteLine("Khong co can bo trong danh sach , vui vong them can bo");
            }
            for (int i = 0; i < listCanbo.Count; i++)
            {
                listCanbo[i].Display();
            }
        }
    }
}
