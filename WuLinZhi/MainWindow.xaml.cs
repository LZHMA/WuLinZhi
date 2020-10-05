using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WuLinZhi.Core.Effects;
using WuLinZhi.Core.Fight;
using WuLinZhi.Core.Forces;
using WuLinZhi.Core.Skills;

namespace WuLinZhi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainCharacter Player { get; set; }
        NPC DefaultNPC { get; set; }
        Arena Arena { get; set; }
        CharacterInFight _mainCharacterInFight,_npmInFight;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {

            Player = new MainCharacter
            {
                Name = "LZHMA",
                HP = 2000,
                MP = 5000,
                Vitality = 300,
                Strength = 260,
                Agility = 200,
            };
            Player.LearnedForces.AddRange(AllForces.GetAllForceNames());
            Player.EquippedForces.AddRange(Player.LearnedForces);
            Player.AttackSkills.Add(BasicAttackSkill.Skill);
            Player.SupportSkills.Add(BasicSupportSkill.Skill);
            BindCharacter(Player);

            DefaultNPC = new NPC()
            {
                Name = "ShiLaimu",
                HP = 1000,
                MP = 500,
                Vitality = 160,
                Strength = 130,
                Agility = 110,
            };
            DefaultNPC.AttackSkills.Add(BasicAttackSkill.Skill);
            DefaultNPC.SupportSkills.Add(BasicSupportSkill.Skill);
        }

        private void BindCharacter(MainCharacter mainCharacter)
        {
            this.characterName.SetBinding(TextBlock.TextProperty, new Binding("Name") { Source = mainCharacter });
            this.characterHP.SetBinding(TextBlock.TextProperty, new Binding("HP") { Source = mainCharacter });
            this.characterMP.SetBinding(TextBlock.TextProperty, new Binding("MP") { Source = mainCharacter });
            this.characterVitality.SetBinding(TextBlock.TextProperty, new Binding("Vitality") { Source = mainCharacter });
            this.characterStrength.SetBinding(TextBlock.TextProperty, new Binding("Strength") { Source = mainCharacter });
            this.characterAgility.SetBinding(TextBlock.TextProperty, new Binding("Agility") { Source = mainCharacter });
        }

        private void StartFight(object sender, RoutedEventArgs e)
        {
            Arena = new Arena(Player, DefaultNPC);
            _mainCharacterInFight = Arena.MainCharacterInFight;

            this.playerName.Text = _mainCharacterInFight.Name;
            this.playerHP.SetBinding(ProgressBar.MaximumProperty, new Binding("HPCap") { Source = _mainCharacterInFight });
            this.playerHP.SetBinding(ProgressBar.ValueProperty, new Binding("HPCurrent") { Source= _mainCharacterInFight});
            this.playerMP.SetBinding(ProgressBar.MaximumProperty, new Binding("MPCap") { Source = _mainCharacterInFight });
            this.playerMP.SetBinding(ProgressBar.ValueProperty, new Binding("MPCurrent") { Source = _mainCharacterInFight });
            this.playerShield.SetBinding(TextBlock.TextProperty, new Binding("Shield") { Source = _mainCharacterInFight });
            this.playerActionPoint.SetBinding(TextBlock.TextProperty, new Binding("ActionPointCurrent") { Source = _mainCharacterInFight });
            this.playerActionPointCap.Text = _mainCharacterInFight.ActionPointCap.ToString();
            this.playerAttackSkillsDataGrid.ItemsSource = new ObservableCollection<AttackSkill>(_mainCharacterInFight.AttackSkills);
            this.playerSupportSkillsDataGrid.ItemsSource = new ObservableCollection<SupportSkill>(_mainCharacterInFight.SupportSkills);

            _npmInFight = Arena.NPCInFight;
            this.enemyName.Text = _npmInFight.Name;
            this.enemyHP.SetBinding(ProgressBar.MaximumProperty, new Binding("HPCap") { Source = _npmInFight });
            this.enemyHP.SetBinding(ProgressBar.ValueProperty, new Binding("HPCurrent") { Source = _npmInFight});
            this.enemyMP.SetBinding(ProgressBar.MaximumProperty, new Binding("MPCap") { Source = _npmInFight });
            this.enemyMP.SetBinding(ProgressBar.ValueProperty, new Binding("MPCurrent") { Source = _npmInFight });
            this.enemyShield.SetBinding(TextBlock.TextProperty, new Binding("Shield") { Source = _npmInFight });

        }

        private void CancelInstruction(object sender, RoutedEventArgs e)
        {
            this.playerAttackSkillsDataGrid.UnselectAll();
            this.playerSupportSkillsDataGrid.UnselectAll();
            _mainCharacterInFight.ActionPointCurrent = _mainCharacterInFight.ActionPointCap;
        }

        private void PlayerAct(object sender, RoutedEventArgs e)
        {
            this.playerAct.IsEnabled = false;
            var selectedItems = this.playerSupportSkillsDataGrid.SelectedItems;
            foreach (SupportSkill skill in selectedItems)
            {
                _mainCharacterInFight.SupportSkillsToUse.Add(skill);
            }
            selectedItems = this.playerAttackSkillsDataGrid.SelectedItems;
            foreach (AttackSkill skill in selectedItems)
            {
                _mainCharacterInFight.AttackSkillsToUse.Add(skill);
            }
            this.playerAttackSkillsDataGrid.UnselectAll();
            this.playerSupportSkillsDataGrid.UnselectAll();
            try
            {
                Arena.PlayerRoundAct();
            }
            catch(ArgumentOutOfRangeException exception)
            {
                if(exception.Message.Equals(_npmInFight.Name))
                {
                    this.informationBlock.Text = "You win!";
                }
                else
                {
                    this.informationBlock.Text = "You lose!";
                }
            }
        }

        private void PlayerSkills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int actionPointCost=0;
            var selectedItems = this.playerAttackSkillsDataGrid.SelectedItems;
            foreach(Skill skill in selectedItems)
            {
                actionPointCost += skill.ActionPointCost;
            }
            selectedItems = this.playerSupportSkillsDataGrid.SelectedItems;
            foreach (Skill skill in selectedItems)
            {
                actionPointCost += skill.ActionPointCost;
            }
            _mainCharacterInFight.ActionPointCurrent = _mainCharacterInFight.ActionPointCap - actionPointCost;
            if (_mainCharacterInFight.ActionPointCurrent < 0|| _mainCharacterInFight.ActionPointCurrent== _mainCharacterInFight.ActionPointCap)
            {
                this.playerAct.IsEnabled = false;
            }
            else
            {
                this.playerAct.IsEnabled = true;
            }
        }
    }
}
