using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _5.Sortari_Culori
{
    public static class Engine
    {
        public static PictureBox display;
        public static TextBox textBox;
        public static Stopwatch stopWatch;

        public static void Initialize(PictureBox pb, TextBox tb)
        {
            display = pb;
            textBox = tb;
            Resources.GenerateRainbow();
            Resources.ShowRainbow();
        }

        public static void Swap(int i, int j)
        {
            Colour c = Resources.rainbow[i];
            Resources.rainbow[i] = Resources.rainbow[j];
            Resources.rainbow[j] = c;
            UpdatePositionsVisually(i, j);
        }

        public static void UpdatePositionsVisually(int i, int j)
        {
            Resources.ShowRainbow();
            Resources.DrawBlack(i);
            Resources.DrawBlack(j);
            display.Update();
            UpdateStopWatch();
        }

        public static void Shuffle()
        {
            Random r = new Random();
            for (int i = 1; i < Resources.n; i++)
            {
                int index = r.Next(i);
                Swap(i, index);
            }
        }

        public static void Bubble()
        {
            int k = 0;
            bool ok;
            do
            {
                ok = false;
                for (int i = 0; i < Resources.n - 1 - k; i++)
                    if (Resources.rainbow[i].value > Resources.rainbow[i + 1].value)
                    {
                        Swap(i, i + 1);
                        ok = true;
                    }
                k++;
            } while (ok);
        }

        public static void Insertion()
        {
            for (int i = 1; i < Resources.n; i++)
                for (int j = i; j > 0; j--)
                {
                    if (Resources.rainbow[j].value < Resources.rainbow[j - 1].value)
                        Swap(j, j - 1);
                }
        }

        public static void Selection()
        {
            for (int j = 0; j < Resources.n; j++)
            {
                int poz = j;
                for (int i = j + 1; i < Resources.n; i++)
                {
                    UpdatePositionsVisually(i, j);
                    if (Resources.rainbow[i].value < Resources.rainbow[poz].value)
                        poz = i;
                }
                Swap(j, poz);
            }
        }

        public static void QuickSort(int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(left, right);
                if (pivot > 1)
                {
                    QuickSort(left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(pivot + 1, right);
                }
            }
        }

        static int Partition(int left, int right)
        {
            int pivot;
            pivot = Resources.rainbow[left].value;
            while (true)
            {
                while (Resources.rainbow[left].value < pivot)
                {
                    left++;
                    UpdatePositionsVisually(left, right);
                }
                while (Resources.rainbow[right].value > pivot)
                {
                    right--;
                    UpdatePositionsVisually(left, right);
                }
                if (left < right)
                {
                    Swap(left, right);
                }
                else
                {
                    return right;
                }
            }
        }

        public static void RestartStopwatch()
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public static void UpdateStopWatch()
        {
            float timeInSeconds = (float)stopWatch.ElapsedMilliseconds / 1000;
            textBox.Text = $"{timeInSeconds.ToString("0.000")} s";
            textBox.Update();
        }

        public static void StopStopWatch()
        {
            stopWatch.Stop();
        }
    }
}
