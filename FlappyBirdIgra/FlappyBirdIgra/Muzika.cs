using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdIgra
{
    internal class Muzika
    {
        SoundPlayer playSound;
        SoundPlayer playSound2;
        public Muzika()
        {
            this.playSound = new SoundPlayer();
            this.playSound2 = new SoundPlayer();
            playSound.SoundLocation = @"..\..\images\angru.wav";
            playSound2.SoundLocation = @"..\..\images\pile.wav";
        }
        public void Pusti()
        {
            playSound.PlayLooping();
        }
        public void PustiDugo()
        {
            playSound2.Play();
        }
        public void Stani()
        {
            playSound.Stop();
        }
    }
}
