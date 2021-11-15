using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameGrid GameGrid = new GameGrid(new List<Cell> { new Cell(2, 2), new Cell(1, 2), new Cell(3, 2), new Cell(4, 2), new Cell(5, 2), });
        private (int Rows, int Columns) DisplaySize = (10, 10);
        private List<List<TextBlock>> DisplayBoxes = new();

        public MainWindow()
        {
            InitializeComponent();
            GenerateGridView();
            Display(GameGrid);
        }

        private void GenerateGridView()
        {
            DisplayBoxes = new List<List<TextBlock>>();
            for (int i = 0; i < DisplaySize.Rows; i++)
            {
                GridForDisplay.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0;i < DisplaySize.Columns; i++)
            {
                GridForDisplay.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < DisplaySize.Rows; i++)
            {
                var rowBoxes = new List<TextBlock>();
                for (int j = 0; j < DisplaySize.Columns; j++)
                {
                    var textBlock = new TextBlock
                    {
                        Height = 20,
                        Width = 20,
                    };
                    Grid.SetRow(textBlock, i);
                    Grid.SetColumn(textBlock, j);
                    GridForDisplay.Children.Add(textBlock);
                    rowBoxes.Add(textBlock);
                }
                DisplayBoxes.Add(rowBoxes);
            }
        }

        private void ButtonStep_Click(object sender, RoutedEventArgs e)
        {
            GameGrid.Step();
            Display(GameGrid);
        }

        private void Display(GameGrid grid)
        {
            for (int i = 0; i < DisplayBoxes[0].Count; i++)
            {
                for (int j = 0; j < DisplayBoxes.Count; j++)
                {
                    if (grid.IsAlive(new Cell(j, i)))
                    {
                        DisplayBoxes[j][i].Text = "X";
                    }
                    else
                    {
                        DisplayBoxes[j][i].Text = "O";
                    }
                }
            }
        }
    }
}
