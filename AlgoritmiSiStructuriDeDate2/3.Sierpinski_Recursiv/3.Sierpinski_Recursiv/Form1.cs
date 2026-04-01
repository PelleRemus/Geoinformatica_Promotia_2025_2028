namespace _3.Sierpinski_Recursiv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Bitmap este pe post de imagine.
        Bitmap bitmap;
        // Graphics este pe post de pensula care deseneaza in bitmap.
        Graphics graphics;

        // Triunghiul lui Sierpinski
        private void button1_Click(object sender, EventArgs e)
        {
            // Un fel de "formula" atunci cand lucram cu bitmap si graphics, incepem cu initialiari:
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            // Incepem sa desenam pe imagine: Ii dam fundal negru
            graphics.Clear(Color.Black);
            // Apelam metoda recursiva cu punctele de start, adica cele 3 varfuri ale triunghiului initial
            Triangle([new Point(600, 50), new Point(50, 800), new Point(1150, 800)]);

            // Tot parte din formula, la final, "afisam" imaginea
            pictureBox1.Image = bitmap;
        }

        // Metoda recursiva pentru triunghi
        void Triangle(Point[] points)
        {
            // Pentru a desena un triunghi, putem folosi metoda DrawPolygon, cu 3 puncte
            graphics.DrawPolygon(Pens.White, points);

            // Conditie de oprire: distanta este mai mica decat 2 pixeli
            if (Distance(points[0], points[1]) < 2)
            {
                return;
            }

            // Apel recursiv: pentru fiecare punct, luam mijlocul dreptelor ce intersecteaza acel punct
            Triangle([points[0], MidPoint(points[0], points[1]), MidPoint(points[0], points[2])]);
            Triangle([points[1], MidPoint(points[1], points[0]), MidPoint(points[1], points[2])]);
            Triangle([points[2], MidPoint(points[2], points[0]), MidPoint(points[2], points[1])]);
        }

        // Patratul (Covorul) lui Sierpinski
        private void button2_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            graphics.Clear(Color.Black);
            Square([new Point(225, 50), new Point(975, 50), new Point(975, 800), new Point(225, 800)]);

            pictureBox1.Image = bitmap;
        }

        void Square(Point[] points)
        {
            if (Distance(points[0], points[1]) < 3)
            {
                return;
            }

            graphics.DrawPolygon(new Pen(Color.White, 2), points);


            // Mai simplu si intuitiv: 8 linii de cod pentru cele 8 patrate
            // Colturile sunt mai simple:
            Square([points[0], OneThird(points[0], points[1]), OneThird(points[0], points[2]), OneThird(points[0], points[3])]);
            Square([OneThird(points[1], points[0]), points[1], OneThird(points[1], points[2]), OneThird(points[1], points[3])]);
            Square([OneThird(points[2], points[0]), OneThird(points[2], points[1]), points[2], OneThird(points[2], points[3])]);
            Square([OneThird(points[3], points[0]), OneThird(points[3], points[1]), OneThird(points[3], points[2]), points[3]]);

            // Liniile de mijloc sunt mai complicate
            Square([OneThird(points[0], points[1]), OneThird(points[1], points[0]), OneThird(points[1], points[3]), OneThird(points[0], points[2])]);
            Square([OneThird(points[1], points[2]), OneThird(points[2], points[1]), OneThird(points[2], points[0]), OneThird(points[1], points[3])]);
            Square([OneThird(points[2], points[3]), OneThird(points[3], points[2]), OneThird(points[3], points[1]), OneThird(points[2], points[0])]);
            Square([OneThird(points[3], points[0]), OneThird(points[0], points[3]), OneThird(points[0], points[2]), OneThird(points[3], points[1])]);
        }

        // Metoda pentru mijlocul unei drepte
        Point MidPoint(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }
        Point OneThird(Point p1, Point p2)
        {
            return new Point((p1.X + p1.X + p2.X) / 3, (p1.Y + p1.Y + p2.Y) / 3);
        }

        // Metoda pentru calculul distantei intre doua puncte
        float Distance(Point p1, Point p2)
        {
            return (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
