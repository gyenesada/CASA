using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASA
{
    public partial class Form : System.Windows.Forms.Form
    {

        Graphics graphics;
        Graph graph = new Graph();
        List<Point> vertexPufferToDraw = new List<Point>();

        Pen vertexPen = new Pen(Color.Black, 2);
        Pen edgePen = new Pen(Color.Blue, 2);

        public Form()
        {
            InitializeComponent();
        }

        private void gráfBetöltéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            graphics = canvas.CreateGraphics();
            graphics.Clear(Color.White);

            Pen pen = new Pen(Color.Black, 2);
            Graph graph = new Graph(consoleTextBox.Text);
            consoleTextBox.Clear();

            foreach (var p in graph.getVertices())
            {
                graphics.DrawEllipse(pen, p.X - 3, p.Y - 3, 6, 6);
            }
        }
        
        private void kilépésToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void képernyőTörléseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            graph.deleteGraph();
        }


        #region Rajzoló
        private void canvas_Click(object sender, EventArgs e)
        {
            graphics = canvas.CreateGraphics();
            MouseEventArgs me = (MouseEventArgs)e;
            List<Point> vertices = graph.getVertices();
            Point p = me.Location;

            Point resultPoint;
            if (me.Button == MouseButtons.Left)
            {
                if (startCheckBox.Checked)
                {
                    graph.startIndex = closestPoint(p);
                }
                else if (destCheckBox.Checked)
                {
                    graph.destIndex = closestPoint(p);
                }
                else
                {
                    graph.addVertices(p);
                }

                refreshGraphics();
            }
            else if (me.Button == MouseButtons.Right)
            {
                if (edgeDeleteCheckBox.Checked)
                {
                    resultPoint = vertices[closestPoint(p)];

                    if (vertexPufferToDraw.Count == 0)
                    {
                        vertexPufferToDraw.Add(resultPoint);
                    }
                    else
                    {
                        graph.deleteConnection(vertexPufferToDraw.First(), resultPoint);
                        vertexPufferToDraw.Add(resultPoint);
                        refreshGraphics();
                        vertexPufferToDraw.Clear();
                    }
                }else
                {
                    resultPoint = vertices[closestPoint(p)];

                    if (vertexPufferToDraw.Count == 0)
                    {
                        vertexPufferToDraw.Add(resultPoint);
                    }
                    else
                    {
                        graph.addConnection(vertexPufferToDraw.First(), resultPoint);
                        vertexPufferToDraw.Clear();
                        refreshGraphics();
                    }
                }
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            graphics = canvas.CreateGraphics();
            List<Point> vertices = graph.getVertices();

            Point p = e.Location;

            foreach (Point vertex in vertices)
            {
                pointLabel.Text = "(" + p.X.ToString() + "," + p.Y.ToString() + ")";
            }
        }

        private void refreshGraphics()
        {
            List<Point> vertexToDraw = new List<Point>();
            vertexToDraw = graph.getVertices();
            UpperTriangleMatrix edgeMatrix = graph.getConnections();

            for (int i = 0; i < vertexToDraw.Count; i++)
            {
                if (i == graph.startIndex)
                {
                    vertexPen.Color = Color.Green;
                }
                else if (i == graph.destIndex)
                {
                    vertexPen.Color = Color.Orange;
                }
                else
                {
                    vertexPen.Color = Color.Black;
                }

                graphics.DrawEllipse(vertexPen, vertexToDraw[i].X - 3, vertexToDraw[i].Y - 3, 6, 6);
            }

            List<Point> edgesToDraw = edgeMatrix.getValues();
            List<Point> enabledEdges = edgeMatrix.getEnabledValues();

            foreach (var e in edgesToDraw)
            {
                Point firstPoint = vertexToDraw[e.X];
                Point secondPoint = vertexToDraw[e.Y];

                if(graph.shortestPathToColor.Contains(firstPoint) && graph.shortestPathToColor.Contains(secondPoint))
                {
                    edgePen.Color = Color.Green;
                }else
                {
                    edgePen.Color = Color.Black;
                }
                graphics.DrawLine(edgePen, firstPoint, secondPoint);
            }

            try
            {
                foreach (var e in enabledEdges)
                {
                    edgePen.Color = Color.Red;
                    graphics.DrawLine(edgePen, vertexToDraw[e.X], vertexToDraw[e.Y]);
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Nincs törlendő él!");
            }

        }

        #endregion

        #region CheckBoxKezelés
        private void squareOneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (squareOneCheckBox.Checked)
            {
                CasaCheckBox.Checked = false;
            }
        }

        private void CasaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CasaCheckBox.Checked)
            {
                squareOneCheckBox.Checked = false;
            }
        }

        private void directedErrorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (directedErrorCheckBox.Checked)
            {
                randomErrorCheckBox.Checked = false;
            }
        }

        private void randomErrorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (randomErrorCheckBox.Checked)
            {
                directedErrorCheckBox.Checked = false;
            }
        }

        private void startCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startCheckBox.Checked)
            {
                destCheckBox.Checked = false;
            }
        }

        private void destCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (destCheckBox.Checked)
            {
                startCheckBox.Checked = false;
            }
        }

        #endregion

        #region MainAlgorithms
        private void runButton_Click(object sender, EventArgs e)
        {
            if (randomErrorCheckBox.Checked && squareOneCheckBox.Checked)
            {
                MessageBox.Show("SquareOne és random");
            }
            else if (randomErrorCheckBox.Checked && CasaCheckBox.Checked)
            {
                MessageBox.Show("CASA és random");
            }
            else if (directedErrorCheckBox.Checked && squareOneCheckBox.Checked)
            {
                MessageBox.Show("SquareOne és directed");
            }
            else if (directedErrorCheckBox.Checked && CasaCheckBox.Checked)
            {
                MessageBox.Show("CASA és directed");
            }
            else
            {
                MessageBox.Show("Válasszon az opciók közül!", "Hiba!");
            }
        }
        #endregion

        private void dijkstraButton_Click(object sender, EventArgs e)
        {
            graph.Dijkstra();

            refreshGraphics();
        }

        private void edgeDeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (edgeDeleteCheckBox.Checked)
            {
                startCheckBox.Checked = false;
                destCheckBox.Checked = false;
                startCheckBox.Enabled = false;
                destCheckBox.Enabled = false;

            }
            else
            {
                startCheckBox.Enabled = true;
                destCheckBox.Enabled = true;
            }
        }

        public int closestPoint(Point p)
        {
            List<Point> vertices = graph.getVertices();
            int resultIndex = 0;
            double deltaX = vertices.First().X - p.X;
            double deltaY = vertices.First().Y - p.Y;

            double minDistance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            for (int i = 1; i < vertices.Count; i++)
            {
                deltaX = vertices.ElementAt(i).X - p.X;
                deltaY = vertices.ElementAt(i).Y - p.Y;

                double newDistance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    resultIndex = i;
                }
            }

            return resultIndex;
        }

        private void gráfTisztázásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.startIndex = -1;
            graph.destIndex = -1;
            graph.clearDeletedEdges();
            refreshGraphics();
        }
    }
}
