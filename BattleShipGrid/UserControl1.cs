using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipGrid
{
    public partial class BattleShipGrid : UserControl
    {
        public BattleShipGrid()
        {
            InitializeComponent();

        }

        private int GridRectWidth { get { return Width / 10; } }
        private int GridRectHeight { get { return Height / 10; } }

        private Color PGridColor = Color.Black;
        public Color GridColor
        {
            get { return PGridColor; }
            set { PGridColor = value; }
        }

        protected override void OnClick(EventArgs e)
        {
            Refresh();
            Point coords = GetGridCoordOfMouse();

            DrawRect(Color.Aquamarine, Color.Chocolate, coords.X * GridRectWidth, coords.Y * GridRectHeight, Width / 10, Height / 10);

            //MessageBox.Show(PGridColor.ToString() + coords.X.ToString() + " " + coords.Y.ToString());
        }


        private Point GetGridCoordOfMouse()
        {
            Point mouse = this.PointToClient(Cursor.Position);
            int x = (int)Math.Floor((Decimal)mouse.X / GridRectWidth);
            int y = (int)Math.Floor((Decimal)mouse.Y / GridRectHeight);
            return new Point(x, y);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(pe);
            //Dessine la Grille
            DrawGrid();
            Point coords = GetGridCoordOfMouse();

            DrawRect(Color.Aquamarine, Color.Chocolate, coords.X * GridRectWidth, coords.Y * GridRectHeight, GridRectWidth, GridRectHeight);
        }

        private void DrawGrid()
        {
            for (int i = 1; i < 10; i++)
            {
                //ligne vertical
                DrawLine(PGridColor, GridRectWidth * i, 0, GridRectWidth * i, this.Size.Height);

                //Ligne Horizontale
                DrawLine(PGridColor, 0, GridRectHeight * i, this.Size.Width, GridRectHeight * i);
            }
        }

        private void DrawLine(Color couleur, int StartX, int StartY, int EndX, int EndY)
        {
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(couleur);
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            formGraphics.DrawLine(myPen, StartX, StartY, EndX, EndY);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private void DrawRect(Color BorderColor, Color FillColor, int x, int y, int width, int height)
        {

            Pen myPen;
            myPen = new System.Drawing.Pen(BorderColor);
            Brush brush = new SolidBrush(FillColor);
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(brush, x, y, width, height);
            formGraphics.DrawRectangle(myPen, x, y, width, height);
            myPen.Dispose();
            brush.Dispose();
            formGraphics.Dispose();

        }
    }
}
