using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Quadtree
{
    
    public partial class Form1 : Form
    {
       /* private void MoveCursor()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 

            this.Cursor = new Cursor(Cursor.Current.Handle);

            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }*/
        

        public Form1()
        {
            InitializeComponent();
        }
        
        Degiskenler cls;
        
        
        int x,y;
        static int GlobUst = 0, GlobSag = 512, GlobAlt = 512, GlobSol = 0;
        static int Dogu = GlobSag, Bati = GlobSol,Kuzey = GlobUst, Guney = GlobAlt;
        bool butonSorgu=false,butonRastgele=false;
        Color renk;
        
        public bool durum = false;
        int dugumSay = 0;
        Graphics TreeNesne = null;
        Graphics agacaGoreNesne ;
        private static readonly Random rand = new Random();
        Pen dugumKalem = new Pen(System.Drawing.Color.Blue, 2);
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            cls = new Degiskenler();
             
            for(int i =0;i<100;i++)
            {
                for(int j=0;j<2;j++)
                {
                cls.dugumMat[i,j]=-1;
                cls.siraliMatX[i,j]=-1;
                }
             }

            panel1.Visible = false;
            radioDugum.Enabled = true;
            Rastgele.Visible = false;
            textbox_dugum.Visible = false;
            
            
            rastgeleBasla.Visible = true;
            dugumBasla.Visible = true;
            
            
            sorgu.Visible = false;
            cemberBoyut.Visible = false;


            label2.Visible = false;
            listBox2.Visible = false;
            
            label1.Visible = false;
            listBox1.Visible = false;
            
            
        }

        //Bu class tree agacının degişkenlerini ve duğumlerini tutuyor
        public class TreeNode
        {
            public int yon;
            public Point data;
            public TreeNode KB;
            public TreeNode KD;
            public TreeNode GB;
            public TreeNode GD;
            public int G;
            public int K;
            public int D;
            public int B;
            public  string path;
            public int renkIndis;
            
            public void pathAl()
            {
                path += " "+ yon+ " ";
            }
        }

        
       public class Tree
        {

           public List<Point> arraySorguPoint = new List<Point>();
            
            public TreeNode root;
            public Tree()
            {
                root = null;
                
            }
            public TreeNode getRoot()
            {
                return root;
            }
           /**
            * Elipse ile dugum kesişimi
            * @param localRoot  gönderilen agacnesnesinin Rootu
            * @param elipseNokta Elipsein pointi
            * @param yariCap Elipsin yaricapi
            */
            public void ara(TreeNode localRoot, Point elipseNokta, int yariCap){
                    int xKare = 0, yKare = 0;
                    double mesafe = 0;
                    if (localRoot != null)
                    {
                        xKare = Math.Abs(localRoot.data.X - elipseNokta.X) * Math.Abs(localRoot.data.X - elipseNokta.X);
                        yKare = Math.Abs(localRoot.data.Y - elipseNokta.Y) * Math.Abs(localRoot.data.Y - elipseNokta.Y);
                        mesafe = Math.Sqrt(xKare + yKare);
                        if (mesafe < yariCap)
                        {
                            Console.WriteLine(localRoot.data.X + " " + localRoot.data.Y + " " + "İcindeDir");
                            arraySorguPoint.Add(localRoot.data);
                            
                        }
                        ara(localRoot.KB, elipseNokta, yariCap);
                        ara(localRoot.GB, elipseNokta, yariCap);
                        ara(localRoot.KD, elipseNokta, yariCap);
                        ara(localRoot.GD, elipseNokta, yariCap);
                    }
               }

            
            /**
             * agaca veri ekleme
             * @param yeniVeri Agaca Gelen Veri Pointi
             */ 
            public void dugumEkle(Point yeniVeri)
            { 
                Dogu = GlobSag;
                Bati = GlobSol;
                Kuzey = GlobUst;
                Guney = GlobAlt;
                TreeNode newNode = new TreeNode();
                newNode.data.X = yeniVeri.X;
                newNode.data.Y = yeniVeri.Y;
                if (root == null)
                {                   
                    root = newNode;
                    
                    root.B=GlobSol;
                    root.D=GlobSag;
                    root.G=GlobAlt;
                    root.K=GlobUst;
                    root.renkIndis = 0;
                    
                }
                else
                {
                    TreeNode current = root;
                    TreeNode parent;
                    while (true)
                    {
                        parent = current;
                        
                        //Gelen Veri  parentının Batisinda mı
                        if (yeniVeri.X <= parent.data.X)
                        {
                            //Gelen veri parentından Kuzeyinde mi
                            if (yeniVeri.Y <= parent.data.Y)
                            {
                                current = parent.KB; 
                                Dogu = parent.data.X;
                                Guney = parent.data.Y;
                                
                                if (current == null)
                                {
                                    
                                    parent.KB = newNode;
                                    parent.KB.renkIndis = parent.renkIndis + 1;
                                    parent.KB.D = parent.data.X;
                                    parent.KB.G = parent.data.Y;

                                    parent.KB.K = parent.K;
                                    parent.KB.B = parent.B;
                                    
                                    parent.KB.yon = 0;
                                    parent.KB.path = parent.path + " " + parent.KB.yon;
                                    return;
                                }

                            }
                            else if (yeniVeri.Y > parent.data.Y)
                            {

                                current = parent.GB;
                                Dogu = parent.data.X;
                                Kuzey = parent.data.Y;
                               
                                if (current == null)
                                {
                                    parent.GB = newNode;

                                    parent.GB.renkIndis = parent.renkIndis + 1;
                                    parent.GB.D = parent.data.X;
                                    parent.GB.K = parent.data.Y;
                                    parent.GB.G = parent.G;
                                    parent.GB.B = parent.B;
                                    parent.GB.yon = 2;
                                    parent.GB.path = parent.path + " " + parent.GB.yon;
                                   
                                    return;
                                }
                            }
                        }

                        else if (yeniVeri.X > parent.data.X)
                        {
                            if (yeniVeri.Y <= parent.data.Y)
                            {

                                current = parent.KD;
                                Bati = parent.data.X;
                                Guney = parent.data.Y;
                               
                                if (current == null)
                                {
                                    parent.KD = newNode;

                                    parent.KD.renkIndis = parent.renkIndis + 1;
                                    parent.KD.B = parent.data.X;
                                    parent.KD.G = parent.data.Y;
                                    parent.KD.K = parent.K;
                                    parent.KD.D = parent.D;

                                    parent.KD.yon = 1;
                                    parent.KD.path = parent.path +" " + parent.KD.yon;
                                    return;
                                }
                            }
                            else if (yeniVeri.Y > parent.data.Y)
                            {

                                current = parent.GD;
                                Bati = parent.data.X;
                                Kuzey = parent.data.Y;
                               
                                
                                if (current == null)
                                {
                                    parent.GD = newNode;

                                    parent.GD.renkIndis = parent.renkIndis + 1;
                                    parent.GD.B = parent.data.X;
                                    parent.GD.K = parent.data.Y;
                                    parent.GD.G = parent.G;
                                    parent.GD.D = parent.D;

                                    parent.GD.yon = 3;
                                    parent.GD.path = parent.path+" "+parent.GD.yon;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
       
        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //Matristen alıp Cizdirme
            
            if (butonRastgele == true)
            {
                agacCiz(randT.root);
                
                //dugumDraw();
            }
            else
            {
                if (clk.root != null)
                {
                    
                    agacCiz(clk.root);
                }
            }
            
            
            if(butonSorgu==true){

                elipseCiz();
                sorguDugumBoya();
            }
        }
        //Grafiksel işlemler
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
       
        public void elipseCiz(){
            int cap = 12;
            elipse.X = p.X;
            elipse.Y = p.Y;

            cap = 2*Convert.ToInt16(cemberBoyut.Text);
     
            Graphics elipseNesne = panel1.CreateGraphics();
            Pen sorgu = new Pen(System.Drawing.Color.Red, 3);
            Pen dugum = new Pen(System.Drawing.Color.Red, 3);
            SolidBrush dugum1 = new SolidBrush(Color.Red);
            elipseNesne.DrawEllipse(sorgu, elipse.X-cap/2, elipse.Y-cap/2, cap, cap);
    }


       public void dugumDraw()
        {   
            ArrayList renkler = new ArrayList();
            
            int x=0,y=0;
            renk=System.Drawing.Color.FromArgb(((int)(((byte)(rand.Next(0, 255))))), ((int)(((byte)(rand.Next(0, 255))))), ((int)(((byte)(rand.Next(0, 255))))));
            Pen dugum = new Pen(System.Drawing.Color.Red, 3);
            SolidBrush dugum1 = new SolidBrush(Color.Red);
            Pen TreePen = new Pen(renk,2);

            TreeNesne = panel1.CreateGraphics();
            int Dogu = 0, Bati = 1, Kuzey = 2, Guney = 3;
            for(int i=0;i<dugumSay;i++){

                if (butonRastgele==false)
                {
                    Dogu = cls.yonMat[i, 0];
                    Bati = cls.yonMat[i, 1];
                    Kuzey = cls.yonMat[i, 2];
                    Guney = cls.yonMat[i, 3];
                    x = cls.dugumMat[i, 0];
                    y = cls.dugumMat[i, 1];
                    sorguDugumBoya();
                }
                else
                {
                    Dogu = cls.rastYon[i, 0];
                    Bati = cls.rastYon[i, 1];
                    Kuzey = cls.rastYon[i, 2];
                    Guney = cls.rastYon[i, 3];
                    x = cls.rastDugum[i, 0];
                    y = cls.rastDugum[i, 1];
                    sorguDugumBoya();
                }
                TreeNesne.DrawLine(TreePen, x, Kuzey, x, Guney);
                TreeNesne.DrawLine(TreePen, Bati, y, Dogu, y);
                TreeNesne.DrawEllipse(dugum, x - 2, y - 2, 4, 4);
                TreeNesne.FillEllipse(dugum1, x - 2, y - 2, 4, 4);
            }

          }
       

        public void sorguDugumBoya()
        {
            Graphics sorguDugumNesne = panel1.CreateGraphics();
            Pen dugumSorgular1 = new Pen(Color.Green, 3);
            SolidBrush dugumSorgular = new SolidBrush(Color.Green);
            int sorguDugumX = 0, sorguDugumY = 0;
              if (butonRastgele == true)
                {
                    for (int i = 0; i < randT.arraySorguPoint.Count; i++)
                    {
                        sorguDugumX = randT.arraySorguPoint[i].X;
                        sorguDugumY = randT.arraySorguPoint[i].Y;
                        sorguDugumNesne.DrawEllipse(dugumSorgular1, sorguDugumX - 3, sorguDugumY - 3, 6, 6);
                        sorguDugumNesne.FillEllipse(dugumSorgular, sorguDugumX - 3, sorguDugumY - 3, 6, 6);
                    }
                }
              else
              {
                  for (int i = 0; i < clk.arraySorguPoint.Count; i++)
                  {
                      sorguDugumX = clk.arraySorguPoint[i].X;
                      sorguDugumY = clk.arraySorguPoint[i].Y;
                      sorguDugumNesne.DrawEllipse(dugumSorgular1, sorguDugumX - 3, sorguDugumY - 3, 6, 6);
                      sorguDugumNesne.FillEllipse(dugumSorgular, sorguDugumX - 3, sorguDugumY - 3, 6, 6);
                  }
              }
        }
        
        static Color[] Colors = new Color[] { Color.Black, Color.Red,Color.Yellow, Color.DeepPink ,Color.DarkMagenta,Color.Blue,Color.Turquoise};
        Pen agacGoreDugum = new Pen(Color.Red, 2);

            /**
           * Daire ile dikdortgen kesisiyor mu
           * @param dugum cizilecek olan agacın rootdügümü
           */
        private void agacCiz(TreeNode dugum)
        {
            
                if(dugum!=null)
                {
                    agacaGoreNesne = panel1.CreateGraphics();
                    Pen agacaGoreCiz = new Pen(Colors[(dugum.renkIndis)%Colors.Length], 2);
                    SolidBrush agacaGoreCiz1 = new SolidBrush(Colors[(dugum.renkIndis) % Colors.Length]);
                    agacaGoreNesne.DrawLine(agacaGoreCiz, dugum.data.X, dugum.K, dugum.data.X, dugum.G);
                    agacaGoreNesne.DrawLine(agacaGoreCiz, dugum.B, dugum.data.Y, dugum.D, dugum.data.Y);
                    agacaGoreNesne.DrawEllipse(agacaGoreCiz, dugum.data.X - 2, dugum.data.Y - 2, 4, 4);
                    agacaGoreNesne.FillEllipse(agacaGoreCiz1, dugum.data.X - 2, dugum.data.Y - 2, 4, 4);
                        agacCiz(dugum.GB);
                        agacCiz(dugum.GD);
                        agacCiz(dugum.KB);
                        agacCiz(dugum.KD);
                }
        }
       
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
       
        Tree randT = new Tree();
        int kokDugumX = 0,kokDugumY=0;
        Tree clk = new Tree();
        Point elipse = new Point();
        Point p= new Point();
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            p.X = e.X;
            p.Y = e.Y;
            
            if(butonSorgu==false&& butonRastgele==false){
                if (dugumSay == 0)
                {
                    kokDugumX = p.X;
                    kokDugumY = p.Y;
                    listBox1.Items.Add((dugumSay+1) + "   " + p.X + " " + p.Y);
                    clk.dugumEkle(p); 

                    cls.dugumMat[dugumSay, 0] = kokDugumX;
                    cls.dugumMat[dugumSay, 1] = kokDugumY;
                    cls.yonMat[dugumSay, 0] = Dogu;
                    cls.yonMat[dugumSay, 1] = Bati;
                    cls.yonMat[dugumSay, 2] = Kuzey;
                    cls.yonMat[dugumSay, 3] = Guney;
                    Console.WriteLine(p.X + " " + p.Y);
                    Console.WriteLine(" ");
                    dugumSay++;
                }
                else
                {
                    if (p.X == cls.dugumMat[dugumSay - 1, 0] && p.Y == cls.dugumMat[dugumSay - 1, 1])
                    {
                        MessageBox.Show("Cizgilerin Üstüne Dugum oluşturmaya calıştınız.");
                    }
                    else
                    {
                        clk.dugumEkle(p);
                         
                        listBox1.Items.Add((dugumSay+1) + "     " + p.X + "     " + p.Y);
                        Console.WriteLine(p.X + " " + p.Y);
                        Console.WriteLine(" ");
                        x = p.X;
                        y = p.Y;
                        cls.dugumMat[dugumSay, 0] = x;
                        cls.dugumMat[dugumSay, 1] = y;
                        cls.yonMat[dugumSay, 0] = Dogu;
                        cls.yonMat[dugumSay, 1] = Bati;
                        cls.yonMat[dugumSay, 2] = Kuzey;
                        cls.yonMat[dugumSay, 3] = Guney;
                        
                        dugumSay++;
                    }

                }
                Console.WriteLine("Diğer Dugum girilebilir");
            }
            else if(butonSorgu==true)
            {
                elipse.X = e.X;
                elipse.Y = e.Y;
                int yariCap = 0;
                yariCap = Convert.ToInt32(cemberBoyut.Text);
                
                listBox1.Items.Add(" Elipsin noktaları" + " " + p.X + " " + p.Y);
                if(butonRastgele==false){
                    clk.arraySorguPoint.Clear();
                    clk.arraySorguPoint.Clear();
                    listBox2.Items.Clear();
                    clk.ara(clk.getRoot(), elipse, yariCap);
                   
                    listbox2Sirala(clk);
                    int i = 0;
                    while (i < clk.arraySorguPoint.Count)
                    {   
                        listBox2.Items.Add("Nokta " + (i+1) + " " + clk.arraySorguPoint[i]);
                        i++;
                    }
                }
                else if(butonRastgele==true)
                {
                    randT.arraySorguPoint.Clear();
                    randT.arraySorguPoint.Clear();
                    listBox2.Items.Clear();
                     randT.ara(randT.getRoot(), elipse, yariCap);
                     listbox2Sirala(randT);
                     int i = 0;
                     while (i < randT.arraySorguPoint.Count)
                     {
                         listBox2.Items.Add("Nokta " + (i+1) + " " + randT.arraySorguPoint[i]);
                         i++;
                     }
                }
            }

            panel1.Invalidate();
        }
            
            /**
            * Daire ile dikdortgen kesisiyor mu
            * @param sirala siralanıcak tree
            */
        public void listbox2Sirala(Tree sirala)
        {
            for (int j = 0; j < clk.arraySorguPoint.Count; j++)
            {
                for (int k = 0; k < clk.arraySorguPoint.Count; k++)
                {
                    if (j != k)
                    {
                        if (clk.arraySorguPoint[j].X < clk.arraySorguPoint[k].X)
                        {
                            Point tmp;
                            tmp = clk.arraySorguPoint[j];
                            sirala.arraySorguPoint[j] = clk.arraySorguPoint[k];
                            sirala.arraySorguPoint[k] = tmp;

                        }

                        else if (clk.arraySorguPoint[j].X == clk.arraySorguPoint[k].X)
                        {
                            if (clk.arraySorguPoint[j].Y < clk.arraySorguPoint[k].Y)
                            {
                                Point tmp;
                                tmp = clk.arraySorguPoint[j];
                                sirala.arraySorguPoint[j] = clk.arraySorguPoint[k];
                                sirala.arraySorguPoint[k] = tmp;
                            }

                        }
                    }
                }
            }
        }
          
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
        }

        
        private void cemberBoyut_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void radioDugum_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            listBox1.Visible = true;
            butonSorgu = false;
            sorgu.Visible = false;
            cemberBoyut.Visible = false;
            Rastgele.Visible = true;
            textbox_dugum.Visible = true;
            label2.Visible = false;
            listBox2.Visible = false;
        }

        private void radioSorgu_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            
            butonSorgu = true;
            sorgu.Visible = true;
            cemberBoyut.Visible = true;
            Rastgele.Visible = false;
            textbox_dugum.Visible = false;
            label2.Visible = true;
            listBox2.Visible = true;
        }

       
        private void sorgu_Click(object sender, EventArgs e)
        {
            if (cemberBoyut.Text == "")
            {
                MessageBox.Show("Deger girilmedi");
                return;

            }
            else
            {
                butonSorgu = true;
                listBox2.Visible = true;
                label2.Visible = true;
            }
            randT.arraySorguPoint.Clear();
            randT.arraySorguPoint.Clear();
            clk.arraySorguPoint.Clear();
            clk.arraySorguPoint.Clear();
            listBox2.Items.Clear();
        }

        private void Rastgele_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            butonSorgu = false;
            butonRastgele = true;
            int rastCount = 0, sayac = 0;
            if (sayac == 0)
            {
                clk.root = null;
                randT.root = null;
            }
            if (textbox_dugum.Text == "")
            {
                MessageBox.Show("Deger girilmedi");
                return;

            }
            else
            {
                rastCount = Convert.ToInt16(textbox_dugum.Text);
                Point rast = new Point();
                while (sayac < rastCount)
                {
                    int kord = 0;

                    kord = rand.Next(512);
                    rast.Y = kord;
                    kord = rand.Next(512);
                    rast.X = kord;
                    cls.rastDugum[sayac, 0] = rast.X;
                    cls.rastDugum[sayac, 1] = rast.Y;
                    randT.dugumEkle(rast);
                    listBox1.Items.Add("Nokta " + rast.X + " " + rast.Y);
                    cls.rastYon[sayac, 0] = Dogu;
                    cls.rastYon[sayac, 1] = Bati;
                    cls.rastYon[sayac, 2] = Kuzey;
                    cls.rastYon[sayac, 3] = Guney;
                    sayac++;

                }
                dugumSay = rastCount;
            }


            panel1.Refresh();
            
        }
       

        private void reset_Click(object sender, EventArgs e)
        {

            //Application.Restart();
            listBox1.Items.Clear();
            listBox1.Visible = false;
            listBox2.Items.Clear();
            
            clk.root = null;
            randT.root = null;
            dugumSay = 0;
            butonSorgu = false;
            panel1.Refresh();
            
            label1.Visible = false;
            label2.Visible = false;
            butonRastgele = false;
            

            radioDugum.Checked = true;
            panel1.Visible = false;

            Rastgele.Visible = false;
            textbox_dugum.Visible = false;

            dugumBasla.Visible = true;
            rastgeleBasla.Visible = true;

            clk.arraySorguPoint.Clear();
            randT.arraySorguPoint.Clear();
            radioDugum.Enabled = true;
            
        }

 
        private void dugumBasla_Click(object sender, EventArgs e)
        {
            radioDugum.Enabled = true;
            panel1.Visible = true;
            dugumBasla.Visible=false;
            rastgeleBasla.Visible = false;
            label1.Visible = true;
            listBox1.Visible = true;
            
        }

        private void rastgeleBasla_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            dugumBasla.Visible = false;
            rastgeleBasla.Visible = false;

            Rastgele.Visible = true;
            textbox_dugum.Visible = true;

            label1.Visible = true;
            listBox1.Visible = true;
            Cursor.Position = new Point(Cursor.Position.X + 355, Cursor.Position.Y);
          

        }

        private void cemberBoyut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sorgu_Click(this, new EventArgs());
            }
        }

        private void textbox_dugum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               Rastgele_Click(this, new EventArgs());
            }
        }
         
    }
}
