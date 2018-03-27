using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace SuperMarioBrothers.Sounds
{
    class SoundFactory
    {
        private List<SoundEffect> soundEffects;
        private SoundEffect jump;
        private SoundEffect oneUp;
        private SoundEffect breakBrick;
        private SoundEffect bump;
        private SoundEffect powerUp;
        private SoundEffect dead;
        private SoundEffect stomped;
        private SoundEffect coin;
        private SoundEffect powerUpAppear;
        private SoundEffect kick;
        private SoundEffect fireball;
        private SoundEffect pipe;
        private SoundEffect flagpole;
        private SoundEffect pause;
        private SoundEffect bigJump;
        private SoundEffect warning;




        private Song song;
        private Song star;
        private Song end;
        private Song hurry;
        private Song gameOver;
        private Song underWorld;
        private Song battle;

        private static SoundFactory instance = new SoundFactory();
        public static SoundFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private SoundFactory()
        {
            soundEffects = new List<SoundEffect>();
        }
        public void LoadSound(ContentManager contentManager)
        {
            jump = contentManager.Load<SoundEffect>("Sound/smb_jump-small");
            powerUp = contentManager.Load<SoundEffect>("Sound/smb_powerup");
            bump = contentManager.Load<SoundEffect>("Sound/smb_bump");
            oneUp = contentManager.Load<SoundEffect>("Sound/smb_1-Up");
            breakBrick = contentManager.Load<SoundEffect>("Sound/smb_breakblock");
            dead = contentManager.Load<SoundEffect>("Sound/smb_mariodie");
            stomped = contentManager.Load<SoundEffect>("Sound/smb_stomp");
            coin = contentManager.Load<SoundEffect>("Sound/smb_coin");
            powerUpAppear = contentManager.Load<SoundEffect>("Sound/smb_powerup_appears");
            kick = contentManager.Load<SoundEffect>("Sound/smb_kick");
            fireball = contentManager.Load<SoundEffect>("Sound/smb_fireball");
            pipe = contentManager.Load<SoundEffect>("Sound/smb_pipe");
            flagpole = contentManager.Load<SoundEffect>("Sound/smb_flagpole");
            pause = contentManager.Load<SoundEffect>("Sound/smb_pause");
            bigJump = contentManager.Load<SoundEffect>("Sound/smb_jump-super");
            warning = contentManager.Load<SoundEffect>("Sound/smb_warning");

            

            song = contentManager.Load<Song>("Sound/01-main-theme-overworld");
            star = contentManager.Load<Song>("Sound/05-starman");
            end = contentManager.Load<Song>("Sound/06-level-complete");
            hurry = contentManager.Load<Song>("Sound/18-hurry-overworld-");
            gameOver = contentManager.Load<Song>("Sound/09-game-over");
            underWorld = contentManager.Load<Song>("Sound/02-underworld");
            battle = contentManager.Load<Song>("Sound/08 boss battle");

            //MediaPlayer.Play(song);

            Add();
            Cancel();
        }
        public void PowerUpSound()
        {
            powerUp.Play();
        }
        public void BumpSound()
        {
            bump.Play();
        }
        public void OneUpSound()
        {
            oneUp.Play();
        }
        public void DeadSound()
        {
            dead.Play();
        }
        public void StompedSound()
        {
            stomped.Play();
        }
        public void CoinSound()
        {       
            coin.Play();
        }
        public void PowerUpAppearSound()
        {
            powerUpAppear.Play();
        }
        public void BreakBrickSound()
        {
            breakBrick.Play();
        }
        public void KickSound()
        {
            kick.Play();
        }

        public void FireballSound()
        {
           fireball.Play();
        }

        public void PipeSound()
        {
            pipe.Play();
        }

        public void FlagpoleSound()
        {
            flagpole.Play();
        }

        public void PauseSound()
        {
            pause.Play();
        }

        public void JumpSound()
        {
            jump.Play();
        }
        public void BigJumpSound()
        {
            bigJump.Play();
        }

        public void WarningSound()
        {
            warning.Play();
        }
        public Song Music()
        {
            return song;
        }

        public Song Fight()
        {
            return battle;
        }

        public Song Starman()
        {
            return star;
        }

        public Song Endgame()
        {
            return end;
        }

        public Song Hurrygame()
        {
            return hurry;
        }

        public Song Over()
        {
            return gameOver;
        }
        public Song Under()
        {
            return underWorld;
        }
        void Add()
        {
            soundEffects.Add(jump);
            soundEffects.Add(powerUp);
            soundEffects.Add(bump);
            soundEffects.Add(oneUp);
            soundEffects.Add(breakBrick);
            soundEffects.Add(dead);
            soundEffects.Add(stomped);
            soundEffects.Add(coin);
            soundEffects.Add(powerUpAppear);
            soundEffects.Add(kick);
            soundEffects.Add(fireball);
            soundEffects.Add(pipe);
            soundEffects.Add(flagpole);
            soundEffects.Add(pause);
            soundEffects.Add(bigJump);
            soundEffects.Add(warning);
        }
        void Cancel()
        {
            foreach (SoundEffect element in soundEffects)
            {
                element.CreateInstance().IsLooped = false;
            }
        }
    }
}
