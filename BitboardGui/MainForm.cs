using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BitboardGui
{
    public partial class MainForm : Form
    {
        private readonly BitboardParser _bitboardParser;
        private readonly IList<TextBox> _bitboardsTextBoxes;
        private readonly IList<SolidBrush> _brushes;
        private readonly SolidBrush _emptyBrush;
        private readonly int _bitBoardCount;
        private int _boardSize;
        private int _boardCellCount;

        public MainForm() : this(new ulong[0])
        {
        }

        public MainForm(ulong[] bitboards)
        {
            InitializeComponent();
            _bitboardParser = new BitboardParser();
            var allBitboards = bitboards.ToList();

            _bitBoardCount = 13;
            _bitboardsTextBoxes = new TextBox[_bitBoardCount];
            _bitboardsTextBoxes[0] = Bitboard0TextBox;

            var colors = new List<Color>
            {
                Color.FromArgb(100, 0, 0),
                Color.FromArgb(0, 100, 0),
                Color.FromArgb(40, 70, 170),
                Color.FromArgb(100, 100, 0),
                Color.FromArgb(100, 0, 100),
                Color.FromArgb(0, 100, 100),
                Color.FromArgb(170, 70, 0),
                Color.FromArgb(0, 170, 100),
                Color.FromArgb(70, 30, 0),
                Color.FromArgb(180, 0, 100),
                Color.FromArgb(180, 150, 50),
                Color.FromArgb(120, 120, 120),
                Color.FromArgb(170, 170, 170),
            };

            var rng = new Random(0);
            while (colors.Count < _bitBoardCount)
            {
                var red = rng.Next(0, 256);
                var green = rng.Next(0, 256);
                var blue = rng.Next(0, 256);
                var color = Color.FromArgb(red, green, blue);
                colors.Add(color);
            }

            _brushes = colors.Select(x => new SolidBrush(x)).ToList();
            _emptyBrush = new SolidBrush(Color.FromArgb(80,80,80));
            _boardSize = 8;
            _boardCellCount = 64;

            var offset = 30;

            for (var i = 1; i < _bitBoardCount; i++)
            {
                var newLabel = new Label();
                newLabel.Parent = this;
                newLabel.Location = new Point(Bitboard0Label.Location.X, Bitboard0Label.Location.Y + offset*i);
                newLabel.Text = $"Bitboard {i}:";
                newLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                newLabel.Width = Bitboard0Label.Width;

                var newTextBox = new TextBox();
                newTextBox.Parent = this;
                newTextBox.Location = new Point(Bitboard0TextBox.Location.X, Bitboard0TextBox.Location.Y + offset * i);
                newTextBox.Size = Bitboard0TextBox.Size;
                newTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                _bitboardsTextBoxes[i] = newTextBox;
            }

            for (var i = 0; i < _bitboardsTextBoxes.Count; i++)
            {
                if (allBitboards.Count <= i)
                {
                    allBitboards.Add(0UL);
                }
                //BitboardsTextBoxes[i].BackColor = EmptyBrush.Color;
                _bitboardsTextBoxes[i].ForeColor = _brushes[i].Color;
                _bitboardsTextBoxes[i].Font = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            }

            for (var i = 0; i < allBitboards.Count; i++)
            {
                if (i >= _bitboardsTextBoxes.Count)
                {
                    break;
                }
                _bitboardsTextBoxes[i].Text = allBitboards[i].ToString();
            }

            DisplayBitBoards(allBitboards.ToArray());
        }

        private bool TryGetBitboards(out ulong[] bitboards, bool showError)
        {
            bitboards = new ulong[_bitboardsTextBoxes.Count];
            for (var i = 0; i < _bitboardsTextBoxes.Count; i++)
            {
                var text = _bitboardsTextBoxes[i].Text;
                if (!_bitboardParser.TryParseBitboard(text, out bitboards[i]))
                {
                    if (showError)
                    {
                        MessageBox.Show($"Invalid bitboard {i}");
                    }
                    return false;
                }
            }

            return true;
        }

        private void SyncBoardSize()
        {
            if (!int.TryParse(BoardSizeTextBox.Text, out var boardSize))
            {
                MessageBox.Show($"Invalid board size {BoardSizeTextBox.Text}");
                return;
            }

            _boardSize = boardSize;
            _boardCellCount = boardSize * boardSize;
        }

        private void ShowBitboardButton_Click(object sender, EventArgs e)
        {
            SyncBoardSize();
            if (!TryGetBitboards(out var bitboards, true))
            {
                return;
            }

            DisplayBitBoards(bitboards);
        }

        private IEnumerable<bool> BitboardToCells(ulong bitboard)
        {
            for (var i = 0; i < _boardCellCount; i++)
            {
                var cellExists = (bitboard & (1UL << i)) != 0;
                yield return cellExists;
            }
        }

        private void DisplayBitBoards(params ulong[] bitboards)
        {
            var cells = bitboards.Select(x => BitboardToCells(x).ToList()).ToList();

            var bmp = new Bitmap(MainPictureBox.Width, MainPictureBox.Height);

            var textBrush = new SolidBrush(Color.FromArgb(255,255,255));
            var cellWidth = bmp.Width/_boardSize;
            var cellHeight = bmp.Height/_boardSize;

            var font = new Font(Font, FontStyle.Bold);

            var borderIncrement = (cellWidth/2-5)/_bitboardsTextBoxes.Count;

            using (var graphics = Graphics.FromImage(bmp))
            {
                for (var i = 0; i < _boardCellCount; i++)
                {
                    var cellX = (_boardSize - 1) - (i/_boardSize);
                    var cellY = i % _boardSize;

                    graphics.FillRectangle(_emptyBrush, cellY * cellWidth, cellX * cellHeight, cellWidth, cellHeight);

                    var borderWidth = 0;
                    for (var j = 0; j < cells.Count; j++)
                    {
                        if (cells[j][i])
                        {
                            graphics.FillRectangle(_brushes[j], cellY * cellWidth + borderWidth + 1, cellX * cellHeight + borderWidth + 1, cellWidth - 2*borderWidth - 1, cellHeight - 2*borderWidth - 1);
                            borderWidth += borderIncrement;
                        }
                    }

                    var text = (char)(65+(cellY)) + (_boardSize-cellX).ToString();
                    graphics.DrawString(text, font, textBrush, cellY * cellWidth + cellWidth/2 - 8, cellX * cellHeight + cellHeight/2 - 10);
                    graphics.DrawString(i.ToString().PadLeft(2, '0'), font, textBrush, cellY * cellWidth + cellWidth / 2 - 8, cellX * cellHeight + cellHeight/2 + 2);
                }

                for (var i = 0; i < 9; i++)
                {
                    graphics.DrawLine(Pens.Black, cellWidth*i, 0, cellWidth*i, bmp.Height);
                    graphics.DrawLine(Pens.Black, 0, cellHeight*i, bmp.Width, cellHeight*i);
                }
            }

            MainPictureBox.Image = bmp;
            MainPictureBox.Invalidate();
        }

        private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!TryGetBitboards(out var bitboards, true))
            {
                return;
            }

            var x = e.X / (MainPictureBox.Width / _boardSize);
            var y = (_boardSize - 1) - (e.Y / (MainPictureBox.Height / _boardSize));
            var pos = x + (y * _boardSize);
            var bitboard = 1UL << pos;
            bitboards[0] ^= bitboard;
            _bitboardsTextBoxes[0].Text = "0x" + bitboards[0].ToString("X16");
            DisplayBitBoards(bitboards);
        }

        private void MainPictureBox_SizeChanged(object sender, EventArgs e)
        {
            SyncBoardSize();
            if (!TryGetBitboards(out var bitboards, false))
            {
                return;
            }

            DisplayBitBoards(bitboards);
        }
    }
}
