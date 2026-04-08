namespace _7.ClosestPoints
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        Graphics graphics;

        private void button1_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            int length = 20;
            Point[] points = new Point[length];
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                points[i] = new Point(random.Next(pictureBox1.Width), random.Next(pictureBox1.Height));
                graphics.FillEllipse(Brushes.Red, points[i].X - 5, points[i].Y - 5, 11, 11);
            }
            Array.Sort(points, (a, b) => a.X - b.X);

            double[] closest = ClosestPoints(points, 0, points.Length - 1);
            graphics.DrawLine(new Pen(Color.Blue, 3), points[(int)closest[1]], points[(int)closest[2]]);

            pictureBox1.Image = bitmap;
        }

        double[] ClosestPoints(Point[] points, int left, int right)
        {
            // Conditie de oprire in caul a 3 puncte...
            if (right - left == 3)
            {
                // Presupunem ca cea mai mica este intre stanga si mijloc
                double distance = Distance(points[left], points[left + 1]);
                int i = left, j = left + 1;
                // Verificam daca este mai mica cea intre mijloc si dreapta
                if (distance > Distance(points[left + 1], points[right]))
                {
                    distance = Distance(points[left + 1], points[right]);
                    i = right;
                }
                // Sau daca este mai mica cea intre stanga si dreapta
                if (distance > Distance(points[left], points[right]))
                {
                    distance = Distance(points[left], points[right]);
                    i = left;
                    j = right;
                }
                return [distance, i, j];
            }
            // .. in cazul a doua puncte
            if (right - left == 2)
            {
                return [Distance(points[left], points[right]), left, right];
            }
            // .. sau daca cumva ajungem in situatia in care avem un singur punct sau niciunul, returnam infinit
            if (right - left <= 1)
            {
                return [Double.MaxValue, 0, 0];
            }

            // Baza algoritmului e de aici...
            int mid = (left + right) / 2;
            double[] leftRecursive = ClosestPoints(points, left, mid);
            double[] rightRecursive = ClosestPoints(points, mid + 1, right);
            double[] minDistance = leftRecursive;

            if (rightRecursive[0] < leftRecursive[0])
                minDistance = rightRecursive;
            // .. pana aici

            List<Point> coloana = new List<Point>();
            for (int i = left; i < right; i++)
            {
                if (Math.Abs(points[i].X - points[mid].X) < minDistance[0])
                    coloana.Add(points[i]);
            }
            coloana.Sort((a, b) => a.Y - b.Y);

            for (int i = 0; i < coloana.Count - 1; i++)
            {
                for (int j = i + 1; j < coloana.Count && (coloana[j].Y - coloana[i].Y) < minDistance[0]; j++)
                {
                    double dist = Distance(coloana[i], coloana[j]);
                    if (dist < minDistance[0])
                    {
                        minDistance[0] = dist;
                        minDistance[1] = Array.IndexOf(points, coloana[i]);
                        minDistance[2] = Array.IndexOf(points, coloana[j]);
                    }
                }
            }

            return minDistance;
        }

        double Distance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }
}
