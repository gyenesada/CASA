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
        Graph graph;
        List<Point> vertexPufferToDraw = new List<Point>();
        bool needrefreshDijkstra = false;
        bool needrefreshCASA = false;
        bool firstDijkstra = false;
        bool isCasaActive = false;

        Pen vertexPen = new Pen(Color.Black, 5);
        Pen edgePen = new Pen(Color.Blue, 3);

        public Form()
        {
            InitializeComponent();
            graph = new Graph();
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
            isCasaActive = false;
            shortestPathInfosLabel.Text = "";
            arborescenceLabel.Text = "";

            startCheckBox.Checked = false;
            destCheckBox.Checked = false;
            CasaCheckBox.Checked = false;
            squareOneCheckBox.Checked = false;
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
                if (edgeDeleteCheckBox.Checked || deleteEdgeCasaCheckBox.Checked)
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
                        if (needrefreshDijkstra)
                        {
                            graph.Dijkstra();
                            refreshGraphics();
                            refreshLabel();
                            needrefreshDijkstra = false;
                        }
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
                        refreshGraphics();
                        vertexPufferToDraw.Clear();
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

                graphics.DrawEllipse(vertexPen, vertexToDraw[i].X-5, vertexToDraw[i].Y-5, 10, 10);
            }

            List<Point> edgesToDraw = edgeMatrix.getValues();
            List<Point> enabledEdges = edgeMatrix.getEnabledValues();

            if (isCasaActive)
            {
                for(int i=0; i<graph.Vertices.Count; i++)
                {
                    Point firstPoint = graph.Vertices[i];

                    for(int j=0; j<graph.adjList[i].Count; j++)
                    {
                        Point secondPoint = graph.Vertices[graph.adjList[i][j]];
                        Console.WriteLine(i + "-től fut él " + graph.adjList[i][j] + "-be");
                        DrawArrow(firstPoint, secondPoint);
                    }
                }
            }
            else
            {
                foreach (var e in edgesToDraw)
                {
                    Point firstPoint = vertexToDraw[e.X];
                    Point secondPoint = vertexToDraw[e.Y];

                    if (graph.shortestPathToColor.Contains(firstPoint) && graph.shortestPathToColor.Contains(secondPoint))
                    {
                        edgePen.Color = Color.Green;
                    }
                    else
                    {
                        edgePen.Color = Color.Black;
                    }

                    graphics.DrawLine(edgePen, firstPoint, secondPoint);

                    if (firstDijkstra)
                    {
                        graph.Dijkstra();
                        needrefreshDijkstra = true;
                    }
                }
            }
            try
            {
                foreach (var e in enabledEdges)
                {
                    edgePen.Color = Color.Red;
                    if (squareOneCheckBox.Checked)
                    {
                        needrefreshDijkstra = true;
                    }
                    else if (CasaCheckBox.Checked)
                    {
                        needrefreshCASA = true;
                    }
                    graphics.DrawLine(edgePen, vertexToDraw[e.X], vertexToDraw[e.Y]);
                }
                edgePen.Color = Color.Black;
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
                cleanGraph();
                CasaCheckBox.Checked = false;
                edgeDeleteCheckBox.Visible = true;
                deleteEdgeCasaCheckBox.Visible = false;
            }else
            {
                edgeDeleteCheckBox.Visible = false;
            }
        }

        private void CasaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CasaCheckBox.Checked)
            {
                cleanGraph();
                edgeDeleteCheckBox.Visible = false;
                deleteEdgeCasaCheckBox.Visible = true;
                squareOneCheckBox.Checked = false;
                arbButton.Visible = true;
            }
            else
            {
                deleteEdgeCasaCheckBox.Visible = false;
                arbButton.Visible = false;
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

        private void edgeDeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (edgeDeleteCheckBox.Checked)
            {
                startCheckBox.Checked = false;
                destCheckBox.Checked = false;
                startCheckBox.Enabled = false;
                destCheckBox.Enabled = false;

                needrefreshDijkstra = true;
            }
            else
            {
                startCheckBox.Enabled = true;
                destCheckBox.Enabled = true;
            }
        }
        
        private void deleteEdgeCasaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (deleteEdgeCasaCheckBox.Checked)
            {
                startCheckBox.Checked = false;
                destCheckBox.Checked = false;
                startCheckBox.Enabled = false;
                destCheckBox.Enabled = false;

                needrefreshCASA = true;
            }else
            {
                startCheckBox.Enabled = true;
                destCheckBox.Enabled = true;
            }
        }

        #endregion

        #region MainAlgorithms
        private void runButton_Click(object sender, EventArgs e)
        {
            isCasaActive = false;
            if (squareOneCheckBox.Checked)
            {
                graph.Dijkstra();
                firstDijkstra = true;
                refreshLabel();                
                refreshGraphics();
            }
            else if (CasaCheckBox.Checked)
            {
                //graph.printAllPaths(graph.startIndex, graph.destIndex);
                //isCasaActive = true;
                //refreshGraphics();
            }
            else
            {
                MessageBox.Show("Válasszon az opciók közül!", "Hiba!");
            }
        }
        #endregion
        
        public int closestPoint(Point p)
        {
            List<Point> vertices = graph.getVertices();

            int resultIndex = 0;

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Él hozzáadása sikertelen.");
            }

            return resultIndex;
        }

        private void gráfTisztázásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.startIndex = -1;
            graph.destIndex = -1;
            cleanGraph();
        }

        private void cleanGraph()
        {
            graphics.Clear(Color.White);
            graph.clearDeletedEdges();
            graph.shortestPathToColor = new List<Point>();
            if (squareOneCheckBox.Checked)
            {
                isCasaActive = false;
            }else
            {
                isCasaActive = true;
            }
            needrefreshDijkstra = false;
            needrefreshCASA = false;
            firstDijkstra = false;
            shortestPathInfosLabel.Text = "";
            arborescenceLabel.Text = "";
            refreshGraphics();
        }
        
        private void refreshLabel()
        {
            StringBuilder sb = new StringBuilder();
            //kell?
            sb.Append("vertex \t distance \t last vertex\n");
            for (int i = 0; i < graph.Vertices.Count; ++i)
            {
                if (graph.distances[i] == int.MaxValue)
                {
                    sb.Append(i + "   \t          -         \t   " + graph.path[i] + "\n");
                }
                if (graph.path[i] == -1)
                {
                    sb.Append(i + "   \t         " + graph.distances[i] + "         \t   \n");
                }
                else
                {
                    sb.Append(i + "   \t         " + graph.distances[i] + "         \t   " + graph.path[i] + "\n");
                }
            }
            shortestPathInfosLabel.Text = sb.ToString();
        }

        private void DrawArrowhead(PointF p, float nx, float ny)
        {
            float ax = 10*(-ny - nx);
            float ay = 10*(nx - ny);
            PointF[] points =
            {
                new PointF(p.X + ax, p.Y + ay),
                p,
                new PointF(p.X - ay, p.Y + ax)
            };
            edgePen.Color = Color.Blue;
            graphics.DrawLines(edgePen, points);
            edgePen.Color = Color.Black;
        }

        private void DrawArrow(PointF p1, PointF p2)
        {
            graphics.DrawLine(edgePen, p1, p2);
            
            float vx = p2.X - p1.X;
            float vy = p2.Y - p1.Y;
            float dist = (float)Math.Sqrt(vx * vx + vy * vy);
            vx /= dist;
            vy /= dist;

            DrawArrowhead(p2, vx, vy);

        }

        private void arbButton_Click(object sender, EventArgs e)
        {
            if (CasaCheckBox.Checked)
            {
                graph.printAllPaths(graph.startIndex, graph.destIndex);
                isCasaActive = true;
                refreshGraphics();

                StringBuilder sb = new StringBuilder();
                for(int i = 0; i<graph.arborescences.Count; i++)
                {
                    sb.Append("T" + i + ": ");
                    for (int j = 0; j < graph.arborescences[i].Count; j++)
                    {
                        sb.Append(graph.arborescences[i][j] + " ");
                    }
                    sb.Append("\n");
                }

                arborescenceLabel.Text = sb.ToString();
            }
        }
    }
}
