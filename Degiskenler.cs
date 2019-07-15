using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadtree
{
    class Degiskenler
    {
        
        public int [,] dugumMat;
        public int[,] rastDugum;
        public int[,] rastYon;
        public int[] dugumPath;
        public int [,] siraliMatX;
        public int [,] yonMat;
        //static public List<int> arraySorgu;
        public string[] renkler={"Beige","Bisque","Black","BlanchedAlmond","Blue","BlueViolet","Brown","BurlyWood","CadetBlue","Chartreuse","Chocolate","Coral","CornflowerBlue"};
        
        //static public  ArrayList arraySorgu;
        public  Degiskenler()
        {  
            renkler =new string[200];
            
            //arraySorgu = new List<int>();
            dugumMat = new int[20000, 2];
            siraliMatX = new int[20000, 2];
            yonMat = new int[20000, 4];
            dugumPath = new int[20000];
            //arraySorgu = new ArrayList();
            rastDugum = new int[20000,2];
            rastYon = new int[20000,4];
        }

    }
}
