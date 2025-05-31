using PreyPredator2.Contracts;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PreyPredator2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IAnimalWorld _insectWorld;
        public MainWindow()
        {
            InitializeComponent();

            _insectWorld = new AnimalWorld(worldCanvas);

            for (int i = 0; i < 100; i++)
            {
                _insectWorld.AddAnimal(new Louse());
            }

            for (int i = 0; i < 10; i++)
            {
                _insectWorld.AddAnimal(new LadyBug());
            }
        }


        private void VolgendeRonde_Click(object sender, RoutedEventArgs e)
        {
            _insectWorld.ProcessRound();
            DisplayStatistics();
        }


        private void DisplayStatistics()
        {
            rondeLabel.Content = $"Ronde: {_insectWorld.CurrentRoundNumber}";

            int amountLouse = 0;
            int amountLadyBugs = 0;

            foreach (var bug in _insectWorld.AllAnimals)
            {
                if (bug is Louse)
                {
                    amountLouse++;
                }
                else if (bug is LadyBug)
                {
                    amountLadyBugs++;
                }
            }

            luisLabel.Content = $"Aantal luizen: {amountLouse}";
            ladybugLabel.Content = $"Aantal lieveheersbeestjes {amountLadyBugs}";

        }
    }
}