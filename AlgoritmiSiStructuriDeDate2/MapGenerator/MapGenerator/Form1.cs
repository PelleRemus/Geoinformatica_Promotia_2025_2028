namespace MapGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap; // imaginea
        Graphics graphics;
        Random random = new Random();
        int n, m, size = 5, max = 13, min = -5;
        int[,] matrix;

        private void button1_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            n = pictureBox1.Width / size;
            m = pictureBox1.Height / size;
            matrix = new int[n, m];
            matrix[0, 0] = 4;

            for (int i = 1; i < n; i++)
            {
                if (i < m)
                    matrix[0, i] = 4;

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = 4;
                }

                for (int j = 1; j < m; j++)
                {
                    int stanga = matrix[i, j - 1];
                    int sus = matrix[i - 1, j];
                    int stangaSus = matrix[i - 1, j - 1];
                    int optiuni = 3 - Math.Abs(stanga - sus);
                    int aleator = random.Next(0, Math.Max(optiuni, 1)) - 1;
                    int value = Math.Max(stanga, sus) + aleator;

                    if (value > max)
                        value = max;
                    if (value < min)
                        value = min;
                    matrix[i, j] = value;
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    Color color = matrix[i, j] switch
                    {
                        -5 => Color.DarkBlue,
                        -4 => Color.Blue,
                        -3 => Color.CornflowerBlue,
                        -2 => Color.LightBlue,
                        -1 => Color.DeepSkyBlue,
                        0 => Color.LightGreen,
                        1 => Color.ForestGreen,
                        2 => Color.Green,
                        3 => Color.LimeGreen,
                        4 => Color.Lime,
                        5 => Color.YellowGreen,
                        6 => Color.Yellow,
                        7 => Color.Gold,
                        8 => Color.Orange,
                        9 => Color.DarkOrange,
                        10 => Color.OrangeRed,
                        11 => Color.Red,
                        12 => Color.DarkRed,
                        _ => Color.Black,
                    };
                    var brush = new SolidBrush(color);
                    graphics.FillRectangle(brush, i * size, j * size, size, size);
                }
            }

            pictureBox1.Image = bitmap;
        }
    }
}
