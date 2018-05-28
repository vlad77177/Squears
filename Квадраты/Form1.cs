using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Квадраты
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            TimerMini = new Timer();
            TimerMini.Interval = 1000;
            TimerMini.Enabled = true;
            TimerMini.Tick += Tick;
        }

        /*Функции вывода графики*/
        Graphics g;
        Bitmap pic,minipic;

        Pen blackPen = new Pen(Color.Black, 5);
        Pen greyPen = new Pen(Color.Gray, 1);
        SolidBrush RedFull = new SolidBrush(Color.Red);
        SolidBrush BlueFull = new SolidBrush(Color.Blue);
        SolidBrush BlackFull = new SolidBrush(Color.Black);

        /*Для получения координат курсора*/
        int cursoreX;
        int cursoreY;

        /*Создание экземпляра основного класса Game*/
        Game GameNow=new Game();

        /*Класс Coordinates, для хранения координат ячеек*/
        public class Coordinates
        {
            public int X;
            public int Y;

            public Coordinates(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        /*Вспомогательный класс, в отличие от класса Coordinates содержит переменную Score, для хранения колличества очков*/
        public class ScoreAndCoordinates
        {
            public Coordinates coordinates=new Coordinates(-1,-1);
            public Int32 score;

            public ScoreAndCoordinates()
            {
                score = 0;
            }
        }

        /*Класс, хранящий координаты четырех вершин квадрата*/
        public class Squere
        {
            public Coordinates[] angles;
            public int Price;
            public bool New;

            /*Конструктор класса с известными переменными*/
            public Squere(Coordinates first,Coordinates second,Coordinates third,Coordinates fourth, bool n)
            {
                angles = new Coordinates[4];    //массив координат углов
                int XDistance = second.X - first.X;
                int YDistance = second.Y - first.Y;
                /*Цена квадрата Price*/
                Price = Convert.ToInt16(Math.Sqrt(Convert.ToInt16(Math.Pow(XDistance, 2)) + Convert.ToInt16(Math.Pow(YDistance, 2)))) - 1;
                angles[0] = new Coordinates(first.X, first.Y);
                angles[1] = new Coordinates(second.X, second.Y);
                angles[2] = new Coordinates(third.X, third.Y);
                angles[3] = new Coordinates(fourth.X, fourth.Y);
                New = n;
            }
            /*Конструктор класса с неизвестными переменными*/
            public Squere()
            {
                angles = new Coordinates[4];
                Price = 0;
                angles[0] = new Coordinates(-1, -1);
                angles[1] = new Coordinates(-1, -1);
                angles[2] = new Coordinates(-1, -1);
                angles[3] = new Coordinates(-1, -1);
                New = false;
            }
        }

        /*Класс ячеек, имеет лишь переменную color - цвет*/
        public class cell
        {
            public int color;            //0 - чисто, 1 - занято игроком(красный), 2 - занято компьютером(синий)

            public cell()
            {

                color = 0;
            }
        }

        /*Класс игры, основной класс*/
        public class Game
        {
            public cell[,] Cell;        //массив ячеек
            /*Индексы для поиска и записи новых квадратов игрока и компьютера*/
            public int squeresGamerIndex;
            public int squeresComputerIndex;
            /*Динамические массивы квадратов игрока и компьютера*/
            public List<Squere> squeresGamer = new List<Squere>();
            public List<Squere> squeresComputer=new List<Squere>();
            /*Фишки игрока и компьютера*/
            public int GamerChips;
            public int ComputerChips;
            public int level;

            public Game()
            {
                /*Конструктор игры, создание масива ячеек и обнуление результатов*/
                Cell = new cell[10, 10];
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        Cell[x,y]=new cell();
                    }
                }
                squeresGamer.Clear();
                squeresComputer.Clear();
                squeresGamerIndex = 0;
                squeresComputerIndex = 0;
                GamerChips = 32;
                ComputerChips = 32;
            }
            /*Функция очистки, начало новой игры*/
            public void Clear()
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        Cell[x, y] = new cell();
                    }
                }
                squeresGamer.Clear();
                squeresComputer.Clear();
                squeresGamerIndex = 0;
                squeresComputerIndex = 0;
                GamerChips = 32;
                ComputerChips = 32;    
            }
            /*Функция поиска квадрата, ищет квадрат*/
            public void SquereFound(int gamer,bool RealSquere)
            {   
                /*Координаты*/
                Coordinates first = new Coordinates(-1, -1);
                Coordinates second = new Coordinates(-1, -1);
                Coordinates third = new Coordinates(-1, -1);
                Coordinates fourth = new Coordinates(-1, -1);                
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        /*Ищу первую ячейку*/                            
                        if (Cell[x, y].color != gamer)
                        {
                            /*Если она не нужного нам цвета, то пропускает и ищем следующую*/
                            continue;
                        }
                        /*Если она нужная, записываем ее координаты*/
                        first.X = x;
                        first.Y = y;
                        int X = first.X;
                        int Y = first.Y;
                        X++;
                        /*Запускаем цикл для поиска второй ячейки*/
                        while (true)
                        {
                            if (X == 10)
                            {
                                X = 0;
                                Y++;
                            }
                            if (Y > 9)
                            {
                                break;
                            }
                            if (Cell[X, Y].color != gamer)
                            {
                                /*Если не нужного цвета - пропускаем*/
                                X++;
                                continue;
                            }
                            /*Иначе запишем координаты*/
                            second.X = X;
                            second.Y = Y;
                            /*Высчитаем разницу между координатами по X и Y, а затем по формуле найдем расстояние, то есть, гипотетическую цену квадрата*/
                            int XDistance = second.X - first.X;
                            int YDistance = second.Y - first.Y;
                            int Price = Convert.ToInt16(Math.Sqrt(Convert.ToInt16(Math.Pow(XDistance, 2)) + Convert.ToInt16(Math.Pow(YDistance, 2)))) - 1;
                            /*Цикл проверки на наличие квадрата, мысленно проведем линию между первой ячейкой и второй, переменная z покажет, с какой стороны мы будем искать квадрат*/
                            for (int z = 1; z < 3; z++)
                            {
                                /*Координаты*/
                                int XS_th = 0;
                                int YS_th = 0;
                                int XS_f = 0;
                                int YS_f = 0;
                                /*Occupansy - заполненность*/
                                int Occupansy = 0;
                                /*ImpossibleQu - возможность существования квадрата, false - существует, true - не существует*/
                                bool ImpossibleSq = false;
                                if (z == 1)
                                {
                                    /*Новые координаты для третьей и чествертой ячейки*/
                                    XS_th = first.X + YDistance;
                                    YS_th = first.Y - XDistance;
                                    XS_f = second.X + YDistance;
                                    YS_f = second.Y - XDistance;
                                }
                                if (z == 2)
                                {
                                    /*Зеркально отраженные координаты*/
                                    XS_th = first.X - YDistance;
                                    YS_th = first.Y + XDistance;
                                    XS_f = second.X - YDistance;
                                    YS_f = second.Y + XDistance;
                                }
                                /*Проверка, не выходят ли новые координаты за рамки игрового поля*/
                                if (XS_th >= 0 && YS_th >= 0 && XS_th < 10 && YS_th < 10)
                                {                                    
                                    if (Cell[XS_th, YS_th].color == gamer)
                                    {
                                        /*Если третья ячейка заполена нужным цветом, то записываем координаты и увеличиваем заполненность*/
                                        third.X = XS_th;
                                        third.Y = YS_th;
                                        Occupansy++;
                                    }
                                    else if (Cell[XS_th, YS_th].color != 0)
                                    {
                                        /*Если ячейка занята другим иггроком, то квадрат создать невозможно*/
                                        ImpossibleSq = true;
                                    }
                                }
                                else
                                {
                                    /*Если не входят, то квадрат создать невозможно*/
                                    ImpossibleSq = true;
                                }
                                /*Та же проверка и для четвертой ячейки*/
                                if (XS_f >= 0 && YS_f >= 0 && XS_f < 10 && YS_f < 10)
                                {
                                    if (Cell[XS_f, YS_f].color == gamer)
                                    {
                                        fourth.X = XS_f;
                                        fourth.Y = YS_f;
                                        Occupansy++;
                                    }
                                    else if (Cell[XS_f, YS_f].color != 0)
                                        ImpossibleSq = true;
                                }
                                else
                                    ImpossibleSq = true;                                
                                if (Occupansy == 2 && ImpossibleSq == false)
                                {        
                                    /*Если ячейки заполнены и квадрат создать возможно, то создаем его, в зависимости от цвета игрока*/
                                    if (gamer==1 && Price!=0)
                                    {
                                        CreateSquere(first, second, third, fourth, gamer, RealSquere);
                                    }
                                    if (gamer==2 && Price!=0)
                                    {
                                        CreateSquere(first, second, third, fourth, gamer, RealSquere);
                                    }
                                }
                            }
                            X++;
                        }
                    }
                }                
            }          
            /*Создаем кварат*/
            private void CreateSquere(Coordinates first, Coordinates second,Coordinates third,Coordinates fourth,int gamer,bool RealSquere)
            {
                List<Squere> LS = new List<Squere>();
                int Index = 0;
                /*Копируем нужные нам массивы, для игрока или для компьютера*/
                if (gamer == 1) 
                {
                    LS = squeresGamer;
                    Index = squeresGamerIndex;
                }
                if (gamer == 2) 
                {
                    LS = squeresComputer;
                    Index = squeresComputerIndex;
                }
                for (int i = 0; i < Index; i++)
                {
                    /*Сначала проверяем, есть ли  квадрат, котороый мы хотим записать в базе, similarity - сходство*/
                    int similarity = 0;
                    /*Для каждого квадрата сравниваем его углы с текущими координатами*/
                    for (int j = 0; j < 4; j++)
                    {
                        if ((first.X == LS[i].angles[j].X) && (first.Y == LS[i].angles[j].Y))
                            similarity++;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        if ((second.X == LS[i].angles[j].X) && (second.Y == LS[i].angles[j].Y))
                            similarity++;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        if ((third.X == LS[i].angles[j].X) && (third.Y == LS[i].angles[j].Y))
                            similarity++;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        if ((fourth.X == LS[i].angles[j].X) && (fourth.Y == LS[i].angles[j].Y))
                            similarity++;
                    }
                    if (similarity == 4)
                    {
                        /*Если мы нашли точно такой же квадрат в базе, то новый записывать не будем*/
                        return;
                    }
                }
                /*Иначе создаем квадрат в зависимости от игрока, и вычитаем/прибавляем фишки*/
                if (gamer == 1)
                {
                    if (RealSquere == true)
                    {
                        MessageBox.Show("Вы создали квадрат!");
                        ComputerChips = ComputerChips - (Convert.ToInt16(Math.Sqrt(Convert.ToInt16(Math.Pow(second.X - first.X, 2)) + Convert.ToInt16(Math.Pow(second.Y - first.Y, 2)))) - 1);
                        GamerChips = GamerChips + (Convert.ToInt16(Math.Sqrt(Convert.ToInt16(Math.Pow(second.X - first.X, 2)) + Convert.ToInt16(Math.Pow(second.Y - first.Y, 2)))) - 1);
                    }
                    squeresGamer.Add(new Squere(first, second, third, fourth,true));
                    squeresGamerIndex++;                    
                }
                if (gamer == 2)
                {
                    if(RealSquere==true)
                    {
                        MessageBox.Show("Ваш противник создал квадрат!");
                        GamerChips = GamerChips - (Convert.ToInt16(Math.Sqrt(Convert.ToInt16(Math.Pow(second.X - first.X, 2)) + Convert.ToInt16(Math.Pow(second.Y - first.Y, 2)))) - 1);
                        ComputerChips = ComputerChips + (Convert.ToInt16(Math.Sqrt(Convert.ToInt16(Math.Pow(second.X - first.X, 2)) + Convert.ToInt16(Math.Pow(second.Y - first.Y, 2)))) - 1);
                    }
                    squeresComputer.Add(new Squere(first, second, third, fourth,true));
                    squeresComputerIndex++;                    
                }
            }
            /*Запуск просчета игры*/
            public void RunGame(int X,int Y)
            {                
                /*Наш ход*/
                Cell[X, Y].color = 1;
                GamerChips--;                
                /*Проверка, создан ли квадрат*/
                SquereFound(1,true);
                /*Запускаю ход AI*/
                ScoreAndCoordinates ScAndCrd = RunAI();
                if (ComputerChips <= 0)
                {
                    MessageBox.Show("Вы выйграли XDD");
                    Clear();
                    return;
                }
                Cell[ScAndCrd.coordinates.X, ScAndCrd.coordinates.Y].color = 2;
                ComputerChips--;                
                SquereFound(2,true);
                if (GamerChips <= 0)
                {
                    MessageBox.Show("Вы проиграли :((");
                    Clear();
                    return;
                }           
            }
            /*Ход AI*/
            public ScoreAndCoordinates RunAI()
            {
                /*Новые координаты*/
                ScoreAndCoordinates scoreInThis=new ScoreAndCoordinates();
                /*Очки, чем их больше, тем выйгрышнее ситуация для компьютера, и наоборот*/
                Int32 sc;
                int gamer;
                /*В зависимости от глубины, считаем ход либо для игрока, либо для компьютера*/
                Coordinates cr = new Coordinates(-1, -1);             
                sc = Int32.MinValue;
                gamer = 2;                                
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {                        
                        if (Cell[x, y].color == 0)
                        {
                            /*Если ячека пуста, делаем ход*/
                            Cell[x, y].color = gamer;   
                            /*Запуск эвристики*/
                            scoreInThis.score = HeuristicEvaluation();                                                    
                            if (scoreInThis.score > sc)
                            {
                                sc = scoreInThis.score;
                                cr.X = x;
                                cr.Y = y;
                            }                                                  
                            /*Восстанавливаем ходы*/
                            Cell[x, y].color = 0;
                        }
                    }
                }
                /*Позвращаем полученные очки и координаты*/
                scoreInThis.score = sc;
                scoreInThis.coordinates.X = cr.X;
                scoreInThis.coordinates.Y = cr.Y;
                return scoreInThis;
            }
            /*Эвристическая оценка позиций*/
            public Int32 HeuristicEvaluation()
            {
                Int32 score = 0;
                /*Далее функция ищет первую, вторую, третью и четвертую ячейку аналогично фунции поиска квадрата*/
                Coordinates first = new Coordinates(-1, -1);
                Coordinates second = new Coordinates(-1, -1);
                Coordinates third = new Coordinates(-1, -1);
                Coordinates fourth = new Coordinates(-1, -1);
                for (int i = 1; i < 3; i++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        for (int x = 0; x < 10; x++)
                        {                           
                            if (Cell[x,y].color!=i)
                            {
                                continue;                                
                            }                            
                            first.X = x;
                            first.Y = y;
                            int X = first.X;
                            int Y = first.Y;
                            X++;
                            while (true)
                            {
                                if (X  == 10)
                                {
                                    X = 0;
                                    Y++;
                                }
                                if (Y > 9)
                                {
                                    break;
                                }
                                if (Cell[X,Y].color!=i)
                                {
                                        X++;
                                        continue;                                    
                                }
                                second.X = X;
                                second.Y = Y;
                                int XDistance = second.X - first.X;
                                int YDistance = second.Y - first.Y;
                                int Price = Convert.ToInt16(Math.Sqrt(Convert.ToInt16(Math.Pow(XDistance, 2)) + Convert.ToInt16(Math.Pow(YDistance, 2)))) - 1;
                                for (int z = 1; z < 3; z++)
                                {
                                    int XS_th=0;
                                    int YS_th=0;
                                    int XS_f=0;
                                    int YS_f=0;
                                    int Occupansy = 0;
                                    bool ImpossibleSq = false;
                                    if (z == 1)
                                    {
                                        XS_th = first.X + YDistance;
                                        YS_th = first.Y - XDistance;
                                        XS_f = second.X + YDistance;
                                        YS_f = second.Y - XDistance;
                                    }
                                    if (z == 2)
                                    {
                                        XS_th = first.X - YDistance;
                                        YS_th = first.Y + XDistance;
                                        XS_f = second.X - YDistance;
                                        YS_f = second.Y + XDistance;
                                    }
                                    if (XS_th >= 0 && YS_th >= 0 && XS_th < 10 && YS_th < 10)
                                    {
                                        if (Cell[XS_th, YS_th].color == i)
                                        {
                                            third.X = XS_th;
                                            third.Y = YS_th;
                                            Occupansy++;
                                        }
                                        else if (Cell[XS_th, YS_th].color != 0)
                                            ImpossibleSq = true;
                                    }
                                    else
                                        ImpossibleSq = true;
                                    if (XS_f >= 0 && YS_f >= 0 && XS_f < 10 && YS_f < 10)
                                    {
                                        if (Cell[XS_f, YS_f].color == i)
                                        {
                                            fourth.X = XS_f;
                                            fourth.Y = YS_f;
                                            Occupansy++;
                                        }
                                        else if (Cell[XS_f, YS_f].color != 0)
                                            ImpossibleSq = true;
                                    }
                                    else
                                        ImpossibleSq = true;
                                    /*Здесь и далее новый код*/
                                    if (Occupansy == 0 && ImpossibleSq == false)
                                    {
                                        /*Если клетки пусты, то мы имеем просто две ячейки, с которыми, гипотетически, можно создать квадрат, добавляем немного очком позиции или , наоборот, вычитаем*/
                                        if (i == 1 && level!=0)
                                        {
                                            score = score - Price; 
                                        }
                                        if (i == 2)
                                        {
                                            score = score + Price;
                                        }
                                    }
                                    if (Occupansy == 1 && ImpossibleSq == false)
                                    {
                                        /*Одна ячейка заполнена нужным цветов, не хватает еще одной, получим больше очком(или вычтем)*/
                                        if (i == 1 && level!=0)
                                        {
                                            score = score - (Price * 4);
                                        }
                                        if (i == 2)
                                        {
                                            if (level == 1)
                                                score = score + Price;
                                            else
                                                score = score + (Price * 4);
                                        }
                                    }
                                    if (Occupansy == 2 && ImpossibleSq == false)
                                    {
                                        /*Есть квадрат! Проверим, новый ли он. Если новый, то получим максимально возможноеколличество очков(или вычтем)*/
                                        bool NewSquereQ = FoundSquereInBase(first, second, third, fourth, i);
                                        if (i == 1 && NewSquereQ == false && level!=0)
                                        {
                                            score = score - (Price * 8);
                                        }
                                        if (i == 2 && NewSquereQ == false)
                                        {
                                            if (level == 1)
                                                score = score + (Price * 2);
                                            else
                                                score = score + (Price * 8);
                                        }
                                    }
                                }
                                X++;
                            }
                        }
                    }
                }
                return score;
            }
            /*Поиск квадрата в базе, функция во многом похожа на создание квадрата*/
            public bool FoundSquereInBase(Coordinates first, Coordinates second, Coordinates third, Coordinates fourth,int gamer)
            {
                List<Squere> LS=new List<Squere>();
                int Index=0;
                if (gamer == 1) //для игрока
                {
                    LS = squeresGamer;
                    Index = squeresGamerIndex;
                }
                if (gamer == 2) //для компа
                {
                    LS = squeresComputer;
                    Index = squeresComputerIndex;
                }
                for (int i = 0; i < Index; i++)
                {
                    int similarity = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if ((first.X == LS[i].angles[j].X) && (first.Y == LS[i].angles[j].Y))
                            similarity++;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        if ((second.X == LS[i].angles[j].X) && (second.Y == LS[i].angles[j].Y))
                            similarity++;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        if ((third.X == LS[i].angles[j].X) && (third.Y == LS[i].angles[j].Y))
                            similarity++;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        if ((fourth.X == LS[i].angles[j].X) && (fourth.Y == LS[i].angles[j].Y))
                            similarity++;
                    }
                    if (similarity == 4)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /*Графический вывод*/
        public void DrawPole()
        {
            pic = new Bitmap(500, 500);
            g = Graphics.FromImage(pic);
            g.Clear(Color.White);
            for (int x = 50; x < 500; )
            {
                g.DrawLine(greyPen, x, 0, x, 499);
                x = x + 50;
            }
            for (int y = 50; y < 499; )
            {
                g.DrawLine(greyPen, 0, y, 499, y);
                y = y + 50;
            }            
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (GameNow.Cell[x, y].color == 1)
                    {
                        Rectangle rect = new Rectangle(((x* 50)+2), ((y * 50)+2), 47, 47);
                        g.FillRectangle(RedFull, rect);
                    }
                    if (GameNow.Cell[x, y].color == 2)
                    {
                        Rectangle rect = new Rectangle(((x * 50) + 2), ((y * 50) + 2), 47, 47);
                        g.FillRectangle(BlueFull, rect);
                    }
                    /*if (GameNow.Cell[x, y].New == true)
                    {
                        Rectangle rect=new Rectangle(((x*50)+16),((y*50)+16),16,16);
                        g.FillEllipse(BlackFull, rect);
                    }*/
                }
            }
            g.DrawRectangle(blackPen, 0, 0, 499, 499);
            for (int ig = 0; ig < GameNow.squeresGamerIndex; ig++)
            {
                if (GameNow.squeresGamer[ig].New == true)
                {
                    Point p1 = new Point(((GameNow.squeresGamer[ig].angles[0].X * 50) + 25), ((GameNow.squeresGamer[ig].angles[0].Y * 50) + 25));
                    Point p2 = new Point(((GameNow.squeresGamer[ig].angles[1].X * 50) + 25), ((GameNow.squeresGamer[ig].angles[1].Y * 50) + 25));
                    Point p3 = new Point(((GameNow.squeresGamer[ig].angles[2].X * 50) + 25), ((GameNow.squeresGamer[ig].angles[2].Y * 50) + 25));
                    Point p4 = new Point(((GameNow.squeresGamer[ig].angles[3].X * 50) + 25), ((GameNow.squeresGamer[ig].angles[3].Y * 50) + 25));
                    g.DrawLine(new Pen(Color.Orange, 3), p1, p2);
                    g.DrawLine(new Pen(Color.Orange, 3), p1, p3);
                    g.DrawLine(new Pen(Color.Orange, 3), p4, p2);
                    g.DrawLine(new Pen(Color.Orange, 3), p4, p3);
                    GameNow.squeresGamer[ig].New = false;
                }
            }
            for (int ic = 0; ic < GameNow.squeresComputerIndex; ic++)
            {
                if (GameNow.squeresComputer[ic].New == true)
                {
                    Point p1 = new Point(((GameNow.squeresComputer[ic].angles[0].X * 50) + 25), ((GameNow.squeresComputer[ic].angles[0].Y * 50) + 25));
                    Point p2 = new Point(((GameNow.squeresComputer[ic].angles[1].X * 50) + 25), ((GameNow.squeresComputer[ic].angles[1].Y * 50) + 25));
                    Point p3 = new Point(((GameNow.squeresComputer[ic].angles[2].X * 50) + 25), ((GameNow.squeresComputer[ic].angles[2].Y * 50) + 25));
                    Point p4 = new Point(((GameNow.squeresComputer[ic].angles[3].X * 50) + 25), ((GameNow.squeresComputer[ic].angles[3].Y * 50) + 25));
                    g.DrawLine(new Pen(Color.Cyan, 3), p1, p2);
                    g.DrawLine(new Pen(Color.Cyan, 3), p1, p3);
                    g.DrawLine(new Pen(Color.Cyan, 3), p4, p2);
                    g.DrawLine(new Pen(Color.Cyan, 3), p4, p3);
                    GameNow.squeresComputer[ic].New = false;
                }
            }
            Pole.Image = pic;
        }
       
        /*Событие - клик мышкой по полю*/
        private void Pole_MouseClick(object sender, MouseEventArgs e)
        {            
            int X = Convert.ToInt16(cursoreX / 50);
            int Y = Convert.ToInt16(cursoreY / 50);
            if (GameNow.Cell[X, Y].color == 0)
            {
                GameNow.RunGame(X, Y);
            }
            else
                MessageBox.Show("Занято!!!");
            labelGamerChips.Text="Ваши фишки: " + GameNow.GamerChips;
            labelComputerChips.Text = "Фишки противника: " + GameNow.ComputerChips;
            DrawPole();
        }

        /*Событие движения мыши по полю,  координаты*/
        private void Pole_MouseMove(object sender, MouseEventArgs e)
        {
            cursoreX = Cursor.Position.X-this.Location.X-Pole.Location.X-10;
            cursoreY = Cursor.Position.Y-this.Location.Y-Pole.Location.Y-40;
            labelX.Text = "X:" + Convert.ToString(cursoreX);
            labelY.Text = "Y:" + Convert.ToString(cursoreY);
        }

        /*Новая ира*/
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            GameNow.Clear();
            GameNow.level = comboBox1.SelectedIndex;
            labelGamerChips.Text = "Ваши фишки: " + GameNow.GamerChips;
            labelComputerChips.Text = "Фишки противника: " + GameNow.ComputerChips;
            DrawPole();
        }

        /*Для вывода информации о квадратах*/
        private void buttonInf_Click(object sender, EventArgs e)
        {
            string Inf = "Квадраты игрока:\n";
            for (int i = 0; i < GameNow.squeresGamerIndex; i++)
            {
                Inf=Inf+"\n(" + GameNow.squeresGamer[i].angles[0].X + "," + GameNow.squeresGamer[i].angles[0].Y + ") ";
                Inf=Inf+"(" + GameNow.squeresGamer[i].angles[1].X + "," + GameNow.squeresGamer[i].angles[1].Y + ") ";
                Inf=Inf+"(" + GameNow.squeresGamer[i].angles[2].X + "," + GameNow.squeresGamer[i].angles[2].Y + ") ";
                Inf=Inf+"(" + GameNow.squeresGamer[i].angles[3].X + "," + GameNow.squeresGamer[i].angles[3].Y + ") ";
                Inf=Inf+"Price: " + GameNow.squeresGamer[i].Price;
            }
            Inf=Inf+"\n\nКвадраты компа:\n";
            for (int i = 0; i < GameNow.squeresComputerIndex; i++)
            {
                Inf=Inf+"\n(" + GameNow.squeresComputer[i].angles[0].X + "," + GameNow.squeresComputer[i].angles[0].Y + ") ";
                Inf=Inf+"(" + GameNow.squeresComputer[i].angles[0].X + "," + GameNow.squeresComputer[i].angles[0].Y + ") ";
                Inf=Inf+"(" + GameNow.squeresComputer[i].angles[0].X + "," + GameNow.squeresComputer[i].angles[0].Y + ") ";
                Inf=Inf+"(" + GameNow.squeresComputer[i].angles[0].X + "," + GameNow.squeresComputer[i].angles[0].Y + ") ";
                Inf=Inf+"Price: " + GameNow.squeresComputer[i].Price;
            }
            MessageBox.Show(Inf);
        }

        /*Правила игры*/
        private void buttonGuid_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resource1.Guid);
        }

        private void Tick(object sender, EventArgs e)
        {
            minipic = new Bitmap(100, 100);
            g = Graphics.FromImage(minipic);
            g.Clear(Color.White);
            for (int x = 10; x < 100; )
            {
                g.DrawLine(new Pen(Color.Gray,1), x, 0, x, 99);
                x = x + 10;
            }
            for (int y = 10; y < 99; )
            {
                g.DrawLine(new Pen(Color.Gray,1), 0, y, 99, y);
                y = y + 10;
            }
            g.DrawRectangle(new Pen(Color.Black, 1), 0, 0, 99, 99);
            Random rnd = new Random();
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    int p=0;
                    p=rnd.Next(0, 100);
                    if (p > 50 && p < 75)
                    {
                        Rectangle rect = new Rectangle(((x * 10) + 1), ((y * 10) + 1), 9, 9);
                        g.FillRectangle(RedFull, rect);
                    }
                    if (p > 75 && p < 100)
                    {
                        Rectangle rect = new Rectangle(((x * 10) + 1), ((y * 10) + 1), 9, 9);
                        g.FillRectangle(BlueFull, rect);
                    }
                }
            }
            pictureBoxNice.Image = minipic;
        }

    }
}
