﻿using System;
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
        List<int> minPath = new List<int>();
        List<Point> minPoints = new List<Point>();
        List<Point> casaDefaultPath = new List<Point>();
        List<List<Point>> arbPaths = new List<List<Point>>();

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
            deleteEdgeCasaCheckBox.Checked = false;
            firstDijkstra = false;
            edgeDeleteCheckBox.Checked = false;
            needrefreshCASA = false;
            needrefreshDijkstra = false;
            graph.deleteGraph();
            minPath.Clear();
            casaDefaultPath.Clear();
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
                        if (needrefreshCASA)
                        {
                            runCasa();
                            refreshGraphics();
                            needrefreshCASA = false;
                        }

                        vertexPufferToDraw.Clear();
                    }
                }
                else
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

                Font drawFont = new Font("Arial", 12);
                SolidBrush drawBrush = new SolidBrush(Color.DarkOrange);

                graphics.DrawEllipse(vertexPen, vertexToDraw[i].X - 5, vertexToDraw[i].Y - 5, 10, 10);
                graphics.DrawString(i.ToString(), drawFont, drawBrush, new PointF(vertexToDraw[i].X - 5, vertexToDraw[i].Y + 5));
            }

            List<Point> edgesToDraw = edgeMatrix.getValues();
            List<Point> enabledEdges = edgeMatrix.getEnabledValues();

            if (isCasaActive)
            {
                for (int i = 0; i < graph.Vertices.Count; i++)
                {
                    Point firstPoint = graph.Vertices[i];

                    for (int j = 0; j < graph.adjList[i].Count; j++)
                    {
                        Point secondPoint = graph.Vertices[graph.adjList[i][j]];
                        //Console.WriteLine(i + "-től fut él " + graph.adjList[i][j] + "-be");
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

                    graphics.DrawLine(edgePen, firstPoint, secondPoint);

                    for (int i = 0; i < casaDefaultPath.Count-1; i++)
                    {
                        edgePen.Color = Color.BlueViolet;
                        graphics.DrawLine(edgePen, casaDefaultPath[i], casaDefaultPath[i + 1]); 
                    }

                    for(int i = 0; i<graph.shortestPathToColor.Count-1; i++)
                    {
                        edgePen.Color = Color.Orange;
                        graphics.DrawLine(edgePen, graph.shortestPathToColor[i], graph.shortestPathToColor[i + 1]);
                    }
                    edgePen.Color = Color.Black;

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
            }
            catch (Exception ex)
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
            }
            else
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
                kozvetlenUtButton.Visible = true;
                arbmeghatButton.Visible = true;
            }
            else
            {
                deleteEdgeCasaCheckBox.Visible = false;
                kozvetlenUtButton.Visible = false;
                arbmeghatButton.Visible = false;
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
            }
            else
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
                runCasa();
            }
            else
            {
                MessageBox.Show("Válasszon az opciók közül!", "Hiba!");
            }
        }

        private void minPathMeghatarozas()
        {
            graph.printAllPaths(graph.startIndex, graph.destIndex);
            isCasaActive = true;
            refreshGraphics();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < graph.arborescences.Count; i++)
            {
                sb.Append("T" + i + ": ");
                for (int j = 0; j < graph.arborescences[i].Count; j++)
                {
                    sb.Append(graph.arborescences[i][j] + " ");
                }
                sb.Append("\n");
            }

            arborescenceLabel.Text = sb.ToString();
            isCasaActive = false;

            //Meghatároz egy minimális súlyú utat, mint közvetlen út.
            minPath.Clear();

            casaDefaultPath.Clear();

            int minLength = int.MaxValue;
            foreach (var path in graph.arborescences)
            {
                if (minLength > path.Count)
                {
                    minLength = path.Count;
                    minPath = path.ToArray().ToList();
                }
            }

            for (int i = 0; i < minPath.Count; i++)
            {
                casaDefaultPath.Add(graph.Vertices[minPath[i]]);
            }
            minPoints.Clear();
            for (int i = 0; i < minPath.Count - 1; i++)
            {
                minPoints.Add(new Point(minPath[i], minPath[i + 1]));
            }

            refreshGraphics();
        }

        private void runCasa()
        {
            UpperTriangleMatrix edgeMatrix = graph.getConnections();
            List<Point> edgesToDraw = edgeMatrix.getValues();
            List<Point> enabledEdges = edgeMatrix.getEnabledValues();
            

            for (int i = 0; i < enabledEdges.Count; i++)
            {
                if (minPoints.Contains(new Point(enabledEdges[i].X, enabledEdges[i].Y)) || minPoints.Contains(new Point(enabledEdges[i].Y, enabledEdges[i].X)))
                {
                    findNextArb(enabledEdges, minPoints);
                }
            }
            
            refreshGraphics();
        }

        public void findNextArb(List<Point> enabledEdges, List<Point> minPoints)
        {
            //összes arborescence a start és a destination között.
            arbPaths = new List<List<Point>>();
            List<Point> newPath = new List<Point>();

            for (int i = 0; i < graph.arborescences.Count; i++)
            {
                arbPaths.Add(new List<Point>());
                for (int j = 0; j < graph.arborescences[i].Count - 1; j++)
                {
                    arbPaths[i].Add(new Point(graph.arborescences[i][j], graph.arborescences[i][j + 1]));
                }
            }

            int index = 0;
            //megkeresem a minPoints indexét az arbPaths-ben. S oly jó lenne, ha működne.
            for(int i = 0; i<arbPaths.Count; i++)
            {
                if (arbPaths[i].All(minPoints.Contains) )
                {
                    index = i;
                }
            }

            newPath.Clear();
            newPath = defineNewRoute(enabledEdges, index);
            if (newPath.Count == 0)
            {
                casaDefaultPath.Clear();
                refreshGraphics();
                return;
            }

            List<int> newPathIndeces = new List<int>();

            newPathIndeces.Add(newPath.First().X);
            for(int i = 1; i < newPath.Count; i++)
            {
                newPathIndeces.Add(newPath.ElementAt(i).X);
            }
            newPathIndeces.Add(newPath.Last().Y);


            minPoints.Clear();
            for (int i = 0; i < newPathIndeces.Count - 1; i++)
            {
                minPoints.Add(new Point(newPathIndeces[i], newPathIndeces[i + 1]));
            }


            casaDefaultPath.Clear();
            for(int i = 0; i < newPathIndeces.Count; i++)
            {
                casaDefaultPath.Add(graph.getVertices()[newPathIndeces[i]]);
            }

        }

        private  List<Point> defineNewRoute( List<Point> enabledEdges, int index)
        {
            List<Point> newPath = new List<Point>();

            List<List<Point>> newRoutes = new List<List<Point>>();
            bool tartalmazza = false;

            //onnan indítjuk, ami az előző út indexe után van 0 helyett
            for(int i = index + 1; i<arbPaths.Count; i++)
            {
                tartalmazza = false;
                foreach(var enabled in enabledEdges)
                {
                    if (arbPaths[i].Contains(enabled))
                    {
                        tartalmazza = true;
                    }
                }

                if (!tartalmazza)
                {
                    newPath = arbPaths[i].ToArray().ToList();
                    if (newPath.Count != 0)
                    {
                        break;
                    }
                }
            }

            if(newPath.Count == 0)
            {
                tartalmazza = false;
                //tehát nem talált semmit a lista végéről, akkor lefuttatjuk az index-1ig megint.
                for (int i = 0; i < index-1; i++)
                {
                    tartalmazza = false;
                    foreach (var enabled in enabledEdges)
                    {
                        if (arbPaths[i].Contains(enabled))
                        {
                            tartalmazza = true;
                        }
                    }

                    if (!tartalmazza)
                    {
                        newPath = arbPaths[i].ToArray().ToList();
                        return newPath;
                    }
                }
            }

            return newPath;
        }

        private void mátrixMegjelenítésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //lefut minden lehetséges start-dest párosra az arborescence meghatározás.
            List<List<int>>[,] Matrix = new List<List<int>>[graph.Vertices.Count, graph.Vertices.Count];

            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                for (int j = 0; j < graph.Vertices.Count; j++)
                {
                    Matrix[i, j] = graph.printAllPaths(i, j).ToArray().ToList();
                }
            }
            MatrixForm mForm = new MatrixForm(Matrix, graph.Vertices.Count);
            mForm.Show();
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
            casaDefaultPath.Clear();
            minPath.Clear();
            isCasaActive = false;
            startCheckBox.Enabled = true;
            destCheckBox.Enabled = true;
            squareOneCheckBox.Checked = false;
            CasaCheckBox.Checked = false;
            cleanGraph();
        }

        private void cleanGraph()
        {
            graphics.Clear(Color.White);
            graph.clearDeletedEdges();
            graph.shortestPathToColor = new List<Point>();
            deleteEdgeCasaCheckBox.Checked = false;
            edgeDeleteCheckBox.Checked = false;
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

            sb.Append("vertex \t distance \t last vertex\n");
            for (int i = 0; i < graph.Vertices.Count; ++i)
            {
                sb.Append(i + "   \t         " + graph.distances[i] + "         \t   " + graph.path[i] + "\n");
            }
            shortestPathInfosLabel.Text = sb.ToString();
        }

        private void DrawArrowhead(PointF p, float nx, float ny)
        {
            float ax = 10 * (-ny - nx);
            float ay = 10 * (nx - ny);
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

        private void kozvetlenUtButton_Click(object sender, EventArgs e)
        {
            minPathMeghatarozas();
        }

        private void arbmeghatButton_Click(object sender, EventArgs e)
        {
           
            if (CasaCheckBox.Checked) if (CasaCheckBox.Checked)
                {
                    {
                        graph.printAllPaths(graph.startIndex, graph.destIndex); graph.printAllPaths(graph.startIndex, graph.destIndex);
                        isCasaActive = true; isCasaActive = true;
                        refreshGraphics(); refreshGraphics();

                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < graph.arborescences.Count; i++)
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
}
