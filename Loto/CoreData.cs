using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppTest
{
    class CoreData
    {
        private string[][] matrix;
        public CoreData()
        {
            matrix = new string[12][];
            for (int i = 0; i < 12; i++)
                matrix[i] = new string[12];
            //GetData();
        }
        public void GetData(string a)
        {
            try
            {
                string text = a;
                string[] data = text.Split(new char[0]);
                int k = 0;
                for (int i = 0; i < 12; i++)
                    for (int j = 0; j < 12; j++)
                    {
                        matrix[i][j] = data[k];
                        k++;
                    }
            }
            catch (Exception ex)
            {
                for (int i = 0; i < 12; i++)
                    for (int j = 0; j < 12; j++)
                        matrix[i][j] = "0";
            }
        }
        public string[] GetNumbers(int poz)
        {
            if (poz >= 1 && poz <= 12)
                return matrix[12 - poz];
            else
                return null;
        }
        /*  public int[] GetNumbers()
          {
              int[] nr = new int[12];
              for (int i = 0; i < 12; i++)
                  nr[i] = 0;
              for (int i = 0; i < 12; i++)
                  nr[i] = GetMax(ref values);
              return nr;
          }*/
        private int GetMax(ref int[] vec)
        {
            int poz = 0, max = 0;
            for (int i = 0; i < 50; i++)
            {
                if (vec[i] > max)
                {
                    max = vec[i];
                    poz = i;
                }
            }
            vec[poz] = 0;
            return poz;
        }
        public int[] GetRandomNumbers()
        {
            int[] nrs = new int[6] { 0, 0, 0, 0, 0, 0 };
            int i = 0;
            int[] nr = new int[51];
            for (int z = 0; z < 50; z++)
                nr[z] = 0;
            Random rand = new Random();
            for (i = 0; i < 4000000; i++)
            {
                int aux = rand.Next(1, 50);
                nr[aux]++;
            }
            for (i = 0; i < 6; i++)
                nrs[i] = GetMax(ref nr);
            return nrs;

        }
    }
}