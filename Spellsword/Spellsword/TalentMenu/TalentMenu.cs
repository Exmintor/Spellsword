using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellsword
{
    public class TalentMenu : Menu
    {
        private TalentController controller;
        private Player player;
        private List<Talent> availableTalents;

        private Vector2 textLocation;

        public TalentMenu(Game game, Player player) : base(game)
        {
            this.color = new Color(Color.Black, 0.85f);
            controller = new TalentController(game);
            CurrentSprite = game.Content.Load<Texture2D>("EquipmentMenu");
            this.AnchorTopLeft(game);

            this.player = player;
            availableTalents = new List<Talent>();
            availableTalents.Add(new StrengthTalent());
            availableTalents.Add(new MagicTalent());
        }

        public void Update()
        {
            controller.Update(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            textLocation = this.Location + new Vector2(10, 10);
            DrawPlayerTalents(spriteBatch);
            IndentTextLocation();
            DrawAvailableTalents(spriteBatch);
        }

        public void ApplyTalent(int index)
        {
            if(index < availableTalents.Count)
            {
                Talent talentToApply = availableTalents[index];
                if (player.TalentPoints >= talentToApply.Cost)
                {
                    talentToApply.ApplyTalent(player);
                    player.AddTalent(talentToApply);
                    player.TalentPoints -= talentToApply.Cost;
                }
            }
        }

        private void DrawPlayerTalents(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Talent Points: " + player.TalentPoints, textLocation, Color.White);
            IndentTextLocation();
            spriteBatch.DrawString(font, "Current Talents:", textLocation, Color.White);
            IndentTextLocation();
            foreach(Talent talent in player.CurrentTalents)
            {
                spriteBatch.DrawString(font, talent.Name, textLocation, Color.White);
                IndentTextLocation();
            }
        }
        private void DrawAvailableTalents(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "AvailableTalents: ", textLocation, Color.White);
            IndentTextLocation();
            int i = 1;
            foreach(Talent talent in availableTalents)
            {
                spriteBatch.DrawString(font, i + "." + talent.Name, textLocation, Color.White);
                i++;
                IndentTextLocation();
            }
        }

        private void IndentTextLocation()
        {
            textLocation += new Vector2(0, 20);
        }
    }
}
