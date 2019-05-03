﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CASA
{
    class Graph
    {
        public List<Point> Vertices = new List<Point>();
        UpperTriangleMatrix utMatrix = new UpperTriangleMatrix();
        StringBuilder shortestPathToDestination = new StringBuilder();
        public List<int> pathIndex = new List<int>();
        public List<Point> shortestPathToColor = new List<Point>();

        public int startIndex = -1;
        public int destIndex = -1;

        public Graph()
        {
            Vertices = new List<Point>();
        }

        public Graph(string graphText)
        {
            Vertices = readGraphFromConsole(graphText);
        }

        public List<Point> getVertices()
        {
            return Vertices;
        }

        //public static void readGraphFromFile()
        //{
        //    String line = "";
        //    try
        //    {
        //        StreamReader sr = new StreamReader("Graphs.txt");
        //        line = sr.ReadLine();

        //        while (line != null)
        //        {
        //            Console.WriteLine(line);
        //            line = sr.ReadLine();
        //        }

        //        sr.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        MessageBox.Show("Hiba", "A betöltés nem sikerült, a fájl nem található. Kérem adja meg manuálisan a gráf adatait!");
        //    }
        //}

        public static List<Point> readGraphFromConsole(string graphText)
        {
            string[] lines = graphText.Split('\n');

            List<Point> vertices = new List<Point>();

            foreach (string line in lines)
            {
                if (line.StartsWith("vertex"))
                {
                    int vertexName = int.Parse(line.Split(' ')[1]);
                    Point point = new Point() { X = int.Parse(line.Split(' ')[2]), Y = int.Parse(line.Split(' ')[3]) };

                    vertices[vertexName] = point;
                }
            }
            return vertices;
        }

        public void addVertices(Point point)
        {
            if (!Vertices.Contains(point))
            {
                Vertices.Add(point);

                Console.WriteLine(point.ToString());
                Console.WriteLine(Vertices.Count);
            }
        }

        public void addConnection(Point p1, Point p2)
        {
            int firstIndex = 0;
            int secondIndex = 0;

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices.ElementAt(i).X == p1.X && Vertices.ElementAt(i).Y == p1.Y)
                {
                    firstIndex = i;
                }

                if (Vertices.ElementAt(i).X == p2.X && Vertices.ElementAt(i).Y == p2.Y)
                {
                    secondIndex = i;
                }
            }

            if (firstIndex == secondIndex) return;
            utMatrix[new Point(firstIndex, secondIndex)] = 1;
        }

        public void deleteConnection(Point p1, Point p2)
        {
            int firstIndex = 0;
            int secondIndex = 0;

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices.ElementAt(i).X == p1.X && Vertices.ElementAt(i).Y == p1.Y)
                {
                    firstIndex = i;
                }

                if (Vertices.ElementAt(i).X == p2.X && Vertices.ElementAt(i).Y == p2.Y)
                {
                    secondIndex = i;
                }
            }

            if (firstIndex == secondIndex) return;
            utMatrix[new Point(firstIndex, secondIndex)] = 0;
        }

        public UpperTriangleMatrix getConnections()
        {
            return utMatrix;
        }

        public void deleteGraph()
        {
            Vertices.Clear();
            utMatrix.Clear();
            startIndex = -1;
            destIndex = -1;
            shortestPathToDestination = new StringBuilder();
        }
        

        #region Dijkstra
        
        public List<Point> Dijkstra()
        {
            int vertexNumber = Vertices.Count();
            int[] distances = new int[vertexNumber];
            bool[] shortestPathBool = new bool[vertexNumber];
            int[] path = new int[vertexNumber];

            for (int i = 0; i < vertexNumber; ++i)
            {
                distances[i] = int.MaxValue;
                path[i] = -1;
                shortestPathBool[i] = false;
            }

            if (startIndex == -1) throw new ArgumentException() ;
            distances[startIndex] = 0;

            for(int count = 0; count < vertexNumber - 1; ++count)
            {
                int u = shortestDistance(distances, shortestPathBool, vertexNumber);
                shortestPathBool[u] = true;

                for(int v = 0; v < vertexNumber; ++v)
                {
                    if(!shortestPathBool[v] &&  utMatrix[new Point(u,v)] != -1 && distances[u] != int.MaxValue && distances[u] + 1 < distances[v])
                    {
                        distances[v] = distances[u] + 1;
                        path[v] = u; //melyik csúcsból indult ki
                    }
                }


            }

            Console.WriteLine("Vertex    Distance from source       Last vertex");

            for (int i = 0; i < vertexNumber; ++i)
                Console.WriteLine("{0}\t  {1}\t   {2}", i, distances[i], path[i]);

            int index = destIndex;
            pathIndex.Add(index);
            while (index != startIndex)
            {
                index = path[index];
                shortestPathToDestination.Append(index + "-");
                pathIndex.Add(index);
            }

            Console.WriteLine(shortestPathToDestination.ToString());

            for(int i = 0; i<=pathIndex.Count - 2; i++)
            {
                shortestPathToColor.Add(Vertices[pathIndex[i]]);
                shortestPathToColor.Add(Vertices[pathIndex[i + 1]]);
            }

            return shortestPathToColor;
        }

        public int shortestDistance(int[] distance, bool[] shortestPath, int vertexNum)
        {
            int minValue = int.MaxValue;
            int minIndex = 0;

            for(int v = 0; v<vertexNum; ++v)
            {
                if(shortestPath[v] == false && distance[v] <= minValue)
                {
                    minValue = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        #endregion
    }
}
