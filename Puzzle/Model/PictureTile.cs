using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle.Model
{
    public class PictureTile : PictureBox
    {
        int index = 0;
        int imageIndex = 0;
        
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }

        public bool isMatch()
        {
            return (index == imageIndex);
        }
    }
}
