using Puzzle.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle.Controller
{
    public class PuzzleController
    {
        private int[] indices;
        private int nrOfSquares;
        private int size;
        
        public int NrOfSquares
        {
            get
            {
                return nrOfSquares;
            }
            set
            {
                nrOfSquares = value;
                indices = new int[nrOfSquares];
            }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public int[] Indices { get { return indices; } set { indices = value; } }

        /// <summary>
        /// Return the tile with given coordinates(x,y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pictureBoxes"></param>
        /// <returns></returns>
        public PictureTile SearchTile(int x, int y, PictureBox[] pictureBoxes)
        {
            for (int i = 0; i < nrOfSquares; i++)
            {
                if (((PictureTile)pictureBoxes[i]).X == x && ((PictureTile)pictureBoxes[i]).Y == y)
                    return ((PictureTile)pictureBoxes[i]);
            }
            return null;
        }


        /// <summary>
        /// Swap Tiles
        /// </summary>
        /// <param name="Tile1"></param>
        /// <param name="Tile2"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        public PictureTile SwapTiles(PictureTile Tile1, PictureTile Tile2, Image[] images)
        {
            int tmp = Tile2.ImageIndex;

            Tile2.Image = images[Tile1.ImageIndex];
            Tile2.ImageIndex = Tile1.ImageIndex;

            Tile1.Image = images[tmp];
            Tile1.ImageIndex = tmp;

            return Tile2;
        }
    }
}
