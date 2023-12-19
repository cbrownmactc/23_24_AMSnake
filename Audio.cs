using System;
using System.Windows.Media;

namespace AMSnake
{
    public static class Audio
    {
        public readonly static MediaPlayer GameOver = LoadAudio("game-over.wav");
        public readonly static MediaPlayer Ding = LoadAudio("ding.mp3");

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
