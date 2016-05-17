using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Desenhar
{
    public class Snake
    {
        public int row, col;
        public Color cor;

        public Snake(int _row, int _col, Color _cor)
        {
            row = _row;
            col = _col;
            cor = _cor;
        }
    }
}
