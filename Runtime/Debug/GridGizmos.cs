using UnityEngine;
using Wsh.Mathematics;

namespace Wsh.GridSystem {
    public class GridGizmos<TGridObject> where TGridObject : BaseGridObject {

        private const int DEBUG_LINE_DURATION = 1000;

        private TextMesh[,] m_debugTextArray;
        private Vect2 m_tempVect01;
        private Vect2 m_tempVect02;
        private Vect2 m_tempVect03;

        public GridGizmos(Grid<TGridObject> grid) {
            m_debugTextArray = new TextMesh[grid.Row, grid.Column];

            m_tempVect01 = new Vect2();
            m_tempVect02 = new Vect2();
            m_tempVect03 = new Vect2();

            for(int x = 0; x < grid.Row; x++) {
                for(int y = 0; y < grid.Column; y++) {
                    grid.GetWorldPosition(x, y, ref m_tempVect01);
                    Vector3 localPosition = new Vector3(grid.CellSize * 0.5f + m_tempVect01.X, grid.CellSize * 0.5f + m_tempVect01.Y);
                    m_debugTextArray[x, y] = DebugUtils.CreateWorldText(grid.GetGridObject(x, y).ToString(), null, localPosition, 20, Color.white, TextAnchor.MiddleCenter);
                    grid.GetWorldPosition(x, y, ref m_tempVect02);
                    grid.GetWorldPosition(x, y + 1, ref m_tempVect03);
                    DebugDrawLine(new Vector3(m_tempVect02.X, m_tempVect02.Y), new Vector3(m_tempVect03.X, m_tempVect03.Y));
                    grid.GetWorldPosition(x + 1, y, ref m_tempVect03);
                    DebugDrawLine(new Vector3(m_tempVect02.X, m_tempVect02.Y), new Vector3(m_tempVect03.X, m_tempVect03.Y));
                }
            }

            grid.GetWorldPosition(0, grid.Column, ref m_tempVect01);
            grid.GetWorldPosition(grid.Row, 0, ref m_tempVect02);
            grid.GetWorldPosition(grid.Row, grid.Column, ref m_tempVect03);
            DebugDrawLine(new Vector3(m_tempVect01.X, m_tempVect01.Y), new Vector3(m_tempVect03.X, m_tempVect03.Y));
            DebugDrawLine(new Vector3(m_tempVect02.X, m_tempVect02.Y), new Vector3(m_tempVect03.X, m_tempVect03.Y));
            grid.onGridValueChanged += OnGridValueChanged;
        }

        private void DebugDrawLine(Vector3 from, Vector3 to) {
            Debug.DrawLine(from, to, Color.white, DEBUG_LINE_DURATION);
        }

        private void OnGridValueChanged(int x, int y, TGridObject value) {
            if(m_debugTextArray != null && m_debugTextArray[x, y] != null) {
                m_debugTextArray[x, y].text = value.ToString();
            }
        }

    }
}