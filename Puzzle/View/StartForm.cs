using Puzzle.Controller;
using Puzzle.Model;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Puzzle
{
    enum GameState
    {
        Running,
        Starting
    }

    public partial class StartForm : Form
    {
        private OpenFileDialog openFileDialog = null;
        private Image image;
        private PictureBox pictureBox = null;
        private PictureBox[] pictureBoxes = null;
        private Image[] images = null;

        private PictureTile blankTile = null;

        private PuzzleController ctrl;

        private GameState gameState;
        public StartForm()
        {
            InitializeComponent();

            //select first value by default from combobox
            squaresNrComboBox.SelectedIndex = 0;
            startBtn.Enabled = false;
            

            gameState = GameState.Starting;
        }

        private void imgBrowseBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog == null)
                openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image = CreateBitmapImage(Image.FromFile(openFileDialog.FileName));
                if (pictureBox == null)
                {
                    ShowSelectedImage();
                }
            }
            //image was selected
            if (image != null)
            {
                startBtn.Enabled = true;
                imgBrowseBtn.Enabled = false;
            }
        }

        private void ShowSelectedImage()
        {
            pictureBox = new PictureBox();
            pictureBox.Height = gameBoxPuzzle.Height;
            pictureBox.Width = gameBoxPuzzle.Width;
            gameBoxPuzzle.Controls.Add(pictureBox);
            pictureBox.Image = image;
        }


        /// <summary>
        /// Create Bitmap of image resizing it to fill the gameBox
        /// </summary>
        /// <param name="image"></param>
        /// <returns>created Bitmap</returns>
        private Bitmap CreateBitmapImage(Image image)
        {
            Bitmap objBmpImg = new Bitmap(gameBoxPuzzle.Width, gameBoxPuzzle.Height);
            Graphics objGraphics = Graphics.FromImage(objBmpImg);
            objGraphics.Clear(Color.White);
            objGraphics.DrawImage(image, new Rectangle(0, 0, gameBoxPuzzle.Width, gameBoxPuzzle.Height));
            objGraphics.Flush();

            return objBmpImg;
        }

        /// <summary>
        /// Create Bitmaps from an image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="images"></param>
        /// <param name="index"></param>
        /// <param name="numRow"></param>
        /// <param name="numCol"></param>
        /// <param name="unitX"></param>
        /// <param name="unitY"></param>
        private void CreateBitmapImage(Image img, Image[] images, int index, int numRow, int numCol, int unitX, int unitY)
        {
            images[index] = new Bitmap(unitX, unitY);
            Graphics objGraphics = Graphics.FromImage(images[index]);
            objGraphics.Clear(Color.White);

            objGraphics.DrawImage(image, new Rectangle(0, 0, unitX, unitY), new Rectangle(unitX * (index % numCol), unitY * (index / numCol), unitX, unitY), GraphicsUnit.Pixel);
            objGraphics.Flush();
        }


        private void startBtn_Click(object sender, EventArgs e)
        {
            if (gameState == GameState.Starting)
            {
                //set the nr of squares
                ctrl = new PuzzleController();
                ctrl.Size = int.Parse(squaresNrComboBox.SelectedItem.ToString());
                ctrl.NrOfSquares = (int)Math.Pow(ctrl.Size, 2.0);
                //disable active buttons to avoid overwriting of images
                GenerateLevel();

                //disable all buttons
                imgBrowseBtn.Enabled = false;
                squaresNrComboBox.Enabled = false;

                //switch button to "new game"
                gameState = GameState.Running;

                startBtn.Text = "New Game";
            }
            else if (gameState == GameState.Running)
            {
                RestartGame();
            }
        }

        /// <summary>
        /// reset the game to the initial state
        /// </summary>
        private void RestartGame()
        {
            //Prepare for restart game
            if (pictureBoxes != null)
            {
                //clear all the tiles
                RemoveTiles();
            }
            else if (pictureBox != null)
            {
                //clear the preview opened image
                gameBoxPuzzle.Controls.Remove(pictureBox);
                pictureBox.Dispose();
                pictureBox = null;
            }

            startBtn.Enabled = false;
            squaresNrComboBox.Enabled = true;
            imgBrowseBtn.Enabled = true;

            gameState = GameState.Starting;
            startBtn.Text = "Start";
        }

        /// <summary>
        /// Handle the on arrow keys press
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (pictureBoxes != null)
            {
                switch (keyData)
                {
                    case Keys.Down:
                        //Handle down arrow key
                        MoveTile(blankTile.X, blankTile.Y - 1);
                        CheckStatus();
                        break;
                    case Keys.Up:
                        //Handle up arrow key event
                        MoveTile(blankTile.X, blankTile.Y + 1);
                        CheckStatus();
                        break;
                    case Keys.Right:
                        //Handle right arrow key event
                        MoveTile(blankTile.X - 1, blankTile.Y);
                        CheckStatus();
                        break;
                    case Keys.Left:
                        //Handle left arrow key event
                        MoveTile(blankTile.X + 1, blankTile.Y);
                        CheckStatus();
                        break;
                }
            }
            return true;
        }


        private void RemoveTiles()
        {
            for (int i = 0; i < ctrl.NrOfSquares; i++)
            {
                pictureBoxes[i].Image = null;
                gameBoxPuzzle.Controls.Remove(pictureBoxes[i]);
            }
            pictureBoxes = null;
        }

        /// <summary>
        /// Splits the image into multiple squares of images
        /// Shuffle them algorithmically
        /// </summary>
        private void GenerateLevel()
        {
            if (pictureBox != null)
            {
                //clear the preview opened image
                gameBoxPuzzle.Controls.Remove(pictureBox);
                pictureBox.Dispose();
                pictureBox = null;
            }

            if (pictureBoxes == null)
            {
                //initialize the fragmented images
                images = new Image[ctrl.NrOfSquares];
                pictureBoxes = new PictureBox[ctrl.NrOfSquares];
            }

            //Scaling to fit in the gameBox
            int numRow = (int)Math.Sqrt(ctrl.NrOfSquares);
            int numCol = numRow;
            int unitX = gameBoxPuzzle.Width / numRow;
            int unitY = gameBoxPuzzle.Height / numCol;

            //Generates the splitted images on the board
            for (int i = 0; i < ctrl.NrOfSquares; i++)
            {
                ctrl.Indices[i] = i;
                if (pictureBoxes[i] == null)
                {
                    pictureBoxes[i] = new PictureTile();
                }
                pictureBoxes[i].Width = unitX;
                pictureBoxes[i].Height = unitY;

                ((PictureTile)pictureBoxes[i]).Index = i;

                CreateBitmapImage(image, images, i, numRow, numCol, unitX, unitY);

                pictureBoxes[i].Location = new Point(unitX * (i % numCol), unitY * (i / numRow));
                if (!gameBoxPuzzle.Controls.Contains(pictureBoxes[i]))
                    gameBoxPuzzle.Controls.Add(pictureBoxes[i]);
            }

            for (int i = 0; i < ctrl.NrOfSquares; i++)
            {
                pictureBoxes[i].Image = images[ctrl.Indices[i]];
                ((PictureTile)pictureBoxes[i]).ImageIndex = ctrl.Indices[i];
            }

            //create matrix
            int k = 0;
            for (int i = 0; i < ctrl.Size; i++)
                for (int j = 0; j < ctrl.Size; j++)
                {
                    ((PictureTile)pictureBoxes[k]).X = j;
                    ((PictureTile)pictureBoxes[k]).Y = i;
                    k++;
                }
            //shuffle the indices corresponding to the images and add them to the board

            //Create the Blank Tile
            using (Graphics grp = Graphics.FromImage(images[ctrl.Indices[ctrl.NrOfSquares - 1]]))
            {
                grp.FillRectangle(Brushes.White, 0, 0, unitX, unitY);
            }
            blankTile = ctrl.SearchTile(ctrl.Size - 1, ctrl.Size - 1, pictureBoxes);

            Shuffle();
        }


        /// <summary>
        /// Check if the picture tiles match and check if the game is over
        /// </summary>
        /// <returns></returns>
        private bool GameWon()
        {
            for (int i = 0; i < ctrl.NrOfSquares; i++)
            {
                if (((PictureTile)pictureBoxes[i]).ImageIndex != ((PictureTile)pictureBoxes[i]).Index)
                    return false;
            }
            return true;
        }


        /// <summary>
        /// checks current status
        /// </summary>
        private void CheckStatus()
        {
            if (GameWon())
            {
                RemoveTiles();
                gameBoxPuzzle.Controls.Add(pictureBox);
                ShowSelectedImage();

                //Blinking Full Image
                Task.Run(() =>
                {
                    Thread.Sleep(500);
                    this.Invoke(new Action(() =>
                    {
                        this.pictureBox.Visible = false;
                    }));
                    Thread.Sleep(300);
                    this.Invoke(new Action(() =>
                    {
                        this.pictureBox.Visible = true;
                    }));
                });
            }
        }

        /// <summary>
        /// Move the Blank Tile 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void MoveTile(int x, int y)
        {
            //check the range
            if (x >= 0 && y >= 0 && x < ctrl.Size && y < ctrl.Size)
            {
                PictureTile secondTile = ctrl.SearchTile(x, y, pictureBoxes);
                if (secondTile != null)
                {
                    blankTile = ctrl.SwapTiles(blankTile, secondTile, images);
                }
            }
            else
                return;
        }


        /// <summary>
        /// Shuffle the indices of the image tiles
        /// </summary>
        public void Shuffle()
        { 
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            { 
                switch (rnd.Next(4))
                {
                    case 0:
                        //Handle down arrow key
                        MoveTile(blankTile.X, blankTile.Y - 1);
                        break;
                    case 1:
                        //Handle up arrow key event
                        MoveTile(blankTile.X, blankTile.Y + 1);
                        break;
                    case 2:
                        //Handle right arrow key event
                        MoveTile(blankTile.X - 1, blankTile.Y);
                        break;
                    case 3:
                        //Handle left arrow key event
                        MoveTile(blankTile.X + 1, blankTile.Y);
                        break;
                }
            }
        }
    }
}
