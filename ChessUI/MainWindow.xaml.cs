using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChessLogic;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Image[,] pieceImages = new Image[8, 8];
        private GameState gameState;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
            gameState = new GameState(Board.Initial(), Player.White);
            DrawBoard(gameState.Board);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Ensure the window remains square
            double newSize = Math.Min(e.NewSize.Width, e.NewSize.Height);
            this.Width = newSize;
            this.Height = newSize;

            // Adjust the size of the BoardGrid
            BoardGrid.Width = newSize;
            BoardGrid.Height = newSize;
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Image img = new Image();
                    pieceImages[row, col] = img;
                    PieceGrid.Children.Add(img);
                }
            }
        }  
        
        private void DrawBoard(Board board)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = board[row, col];
                    pieceImages[row, col].Source = Images.GetImage(piece);
                }
            }
        }
    }
}
