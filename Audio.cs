﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;

namespace AMSnake
{
    public static class Audio
    {
        public readonly static MediaPlayer GameOver = LoadAudio("game-over.wav");
        public readonly static MediaPlayer Ding = LoadAudio("ding.mp3");
        public readonly static MediaPlayer Background1 = LoadAudio("welcome-jungle.m4a",1,true,false);
        public readonly static MediaPlayer Background2 = LoadAudio("concrete-jungle.m4a",1,true,false);

        public readonly static List<MediaPlayer> BGMusic = new()
        {
            Background1, Background2
        };

        private static MediaPlayer LoadAudio(string filename,
            double volume = 1, bool repeat = false, bool autoReset = true)
        {
            MediaPlayer player = new();
            player.Open(new Uri($"Assets/{filename}", UriKind.Relative));
            player.Volume = volume;

            if (autoReset)
            {
                player.MediaEnded += Player_MediaEnded;
            }

            if (repeat)
            {
                player.MediaEnded += PlayerRepeat_MediaEnded;
            }

            return player;
        }

        private static void Player_MediaEnded(object sender, EventArgs e)
        {
            MediaPlayer m = sender as MediaPlayer;
            m.Stop();
            m.Position = new TimeSpan(0);
        }

        private static void PlayerRepeat_MediaEnded(object sender, EventArgs e)
        {
            MediaPlayer m = sender as MediaPlayer;
            m.Position = new TimeSpan(0);
            m.Play();
        }

    }
}
