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
using WuLinZhi.Core;
using WuLinZhi.Core.Character;
using WuLinZhi.Core.Equipment;

namespace WuLinZhi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            var me = new MainCharacter
            {
                Name = "LZHMA",
                HPBase = 2000,
                HPAmplification = 0,
                MPBase = 1000,
                MPAmplification = 0,
                VitalityBase = 300,
                StrengthBase = 260,
                AgilityBase = 200,
                Weapon = new EquipmentBase
                {
                    Name = "轩辕剑",
                    Type = EquipmentType.Weapon,
                    HP = 200,
                    MP = 100,
                    Vitiality = 50,
                    Strength = 30,
                    Agility = 40,
                    Price = 10,
                }
            };
            this.characterName.SetBinding(TextBlock.TextProperty, new Binding("Name") { Source = me });
        }
    }
}
