using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using System.Xml.Serialization;

namespace Harkka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BLResource res = new BLResource();
        BLBuilding building = new BLBuilding();
        BLPopulation pop;
        Bonus bonus = new Bonus();
        BLScience science = new BLScience();

        /// <summary>
        /// Start timer to update resource values every second
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            pop = new BLPopulation((int)res.GetResource("Population").maxValue);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Start();
        }
        /// <summary>
        /// Is called every second.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            res.IncrementAllResources(pop, bonus);
            updateDataGrid();
        }

        private void buttonHarvest_Click(object sender, RoutedEventArgs e)
        {
            res.AddResource("Wood", 1);
            updateDataGrid();
        }

        private void buttonHunt_Click(object sender, RoutedEventArgs e)
        {
            res.AddResource("Food", res.GetResource("Population").value * 1);
            updateDataGrid();
        }
        /// <summary>
        /// Refresses Data grid to user interface.
        /// </summary>
        private void updateDataGrid()
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = res.res;
        }
        /// <summary>
        /// Refresses Button texts to user interface
        /// </summary>
        private void updateButtons()
        {
            buttonHut.Content = "Hut (" + building.GetBuilding("Hut").amount + ")";
            buttonTrap.Content = "Trap (" + building.GetBuilding("Trap").amount + ")";
            buttonMine.Content = "Mine (" + building.GetBuilding("Mine").amount + ")";
            buttonShrine.Content = "Shrine (" + building.GetBuilding("Shrine").amount + ")";
        }
        /// <summary>
        /// Refresses population tab labels in case of change of population division.
        /// </summary>
        private void updatePopulationLabels()
        {
            labelThinker.Content = "Thinkers (" + pop.pop.thinkers + ")";
            labelWoodcutter.Content = "Woodcutters (" + pop.pop.woodcutters + ")";
            labelForager.Content = "Foragers (" + pop.pop.foragers + ")";
            labelMiner.Content = "Miners (" + pop.pop.miners + ")";
            labelPriest.Content = "Priest (" + pop.pop.priests + ")";
            labelMerchant.Content = "Merchants (" + pop.pop.merchants + ")";
        }
        /// <summary>
        /// Refresses tooltips to current element.
        /// </summary>
        /// <param name="buildingName">Title</param>
        /// <param name="description">Description</param>
        /// <param name="requirements">Building requirements. Includes nextlines</param>
        private void updateToolTip(String buildingName, String description, String requirements)
        {
            labelToolTip.Content = buildingName + "\n\n" + description + "\n" + requirements;
        }
        /// <summary>
        /// Updates Hut Tooltip
        /// </summary>
        private void updateHutToolTip()
        {
            updateToolTip("Hut", "Comfty wooden hut for two.", building.GetRequirementsAsString("Hut"));
        }
        /// <summary>
        /// Updates Trap Tooltip
        /// </summary>
        private void updateTrapToolTip()
        {
            updateToolTip("Trap", "Tool for catching food.", building.GetRequirementsAsString("Trap"));
        }

        private void updateMineToolTip()
        {
            updateToolTip("Mine", "Mine where miner mine.", building.GetRequirementsAsString("Mine"));
        }

        private void updateShrineToolTip()
        {
            updateToolTip("Shrine", "Place of worship and prayer.", building.GetRequirementsAsString("Shrine"));
        }

        private void updateScienceMasonryToolTip()
        {
            
        }

        private void buttonWoodcutterPlus_Click(object sender, RoutedEventArgs e)
        {
            pop.AddWoodcutter();
            updatePopulationLabels();
        }

        private void buttonWoodcutterMinus_Click(object sender, RoutedEventArgs e)
        {
            pop.SubWoodcutter();
            updatePopulationLabels();
        }

        private void buttonForagerPlus_Click(object sender, RoutedEventArgs e)
        {
            pop.AddForager();
            updatePopulationLabels();
        }

        private void buttonForagerMinus_Click(object sender, RoutedEventArgs e)
        {
            pop.SubForager();
            updatePopulationLabels();
        }

        private void buttonMinerPlus_Click(object sender, RoutedEventArgs e)
        {
            pop.AddMiner();
            updatePopulationLabels();
        }

        private void buttonMinerMinus_Click(object sender, RoutedEventArgs e)
        {
            pop.SubMiner();
            updatePopulationLabels();
        }

        private void buttonPriestPlus_Click(object sender, RoutedEventArgs e)
        {
            pop.AddPriest();
            updatePopulationLabels();
        }

        private void buttonPriestMinus_Click(object sender, RoutedEventArgs e)
        {
            pop.SubPriest();
            updatePopulationLabels();
        }
        private void buttonMerchantPlus_Click(object sender, RoutedEventArgs e)
        {
            pop.AddMerchant();
            updatePopulationLabels();
        }

        private void buttonMerchantMinus_Click(object sender, RoutedEventArgs e)
        {
            pop.SubMerchant();
            updatePopulationLabels();
        }
        /// <summary>
        /// Buys hut building if resources are efficent
        /// </summary>
        private void buttonHut_Click(object sender, RoutedEventArgs e)
        {
            if (building.IsRequirementsMetForBuilding("Hut", res))
            {
                building.BuyBuilding("Hut", res);
                res.AddMaxResource("Population", 2);
                res.AddResource("Population", 2);
                pop.pop.maxPopulation = (int)res.GetResource("Population").maxValue;
                pop.pop.thinkers += 2;
                updateDataGrid();
                updateButtons();
                updatePopulationLabels();
                updateHutToolTip();
            }
        }

        private void buttonTrap_Click(object sender, RoutedEventArgs e)
        {
            if (building.IsRequirementsMetForBuilding("Trap", res))
            {
                building.BuyBuilding("Trap", res);
                bonus.foodBonus = (1 + (building.GetBuilding("Trap").amount * 0.35f));
                updateDataGrid();
                updateButtons();
            }
        }

        private void buttonShrine_Click(object sender, RoutedEventArgs e)
        {
            if(building.IsRequirementsMetForBuilding("Shrine", res))
            {
                building.BuyBuilding("Shrine", res);
                bonus.religionBonus = (1 + (building.GetBuilding("Shrine").amount * 0.12f));
                updateDataGrid();
                updateButtons();
            }
        }

        private void buttonMine_Click(object sender, RoutedEventArgs e)
        {
            if(building.IsRequirementsMetForBuilding("Mine", res))
            {
                building.BuyBuilding("Mine", res);
                bonus.mineBonus = (1 + (building.GetBuilding("Mine").amount * 0.20f)); 
                updateDataGrid();
                updateButtons();
            }
        }

        private void buttonHut_MouseEnter(object sender, MouseEventArgs e)
        {
            updateHutToolTip();
        }
        
        private void buttonTrap_MouseEnter(object sender, MouseEventArgs e)
        {
            updateTrapToolTip();
        }

        private void buttonShrine_MouseEnter(object sender, MouseEventArgs e)
        {
            updateShrineToolTip();
        }

        private void buttonMine_MouseEnter(object sender, MouseEventArgs e)
        {
            updateMineToolTip();
        }
        /// <summary>
        /// Saves game file to xml.
        /// </summary>
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Resource));
                StreamWriter sw = new StreamWriter("save.xml");
                serializer.Serialize(sw, res.res);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Wipes game save data file
        /// </summary>
        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonScienceMasonry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonScienceAgriculture_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
