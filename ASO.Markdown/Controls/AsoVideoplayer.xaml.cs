using ASO.Markdown;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls
{
    /// <summary>
    /// Логика взаимодействия для AsoVideoplayer.xaml
    /// </summary>
    public partial class AsoVideoplayer : UserControl
    {
        Storyboard storyboard = new Storyboard();
        MediaTimeline mediaTimeline = new MediaTimeline();
        public AsoVideoplayer()
        {
            InitializeComponent();
            storyboard.CurrentTimeInvalidated += Storyboard_CurrentTimeInvalidated; ;
            storyboard.Children.Add(mediaTimeline);
        }

        private bool go_player;

        private void Storyboard_CurrentTimeInvalidated(object? sender, EventArgs e)
        {
            Clock storyboardClock = (Clock)sender;

            if (storyboardClock.CurrentProgress != null)
            {
                go_player = true;
                VideoSlider.Value = storyboardClock.CurrentTime.Value.TotalSeconds;
                go_player = false;
            }
        }

        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            VideoSlider.Maximum = Media.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void VideoSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!go_player)
                storyboard.Seek(Media, TimeSpan.FromSeconds(VideoSlider.Value), TimeSeekOrigin.BeginTime);
        }

        private void VideoSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            storyboard.Seek(Media, TimeSpan.FromSeconds(VideoSlider.Value), TimeSeekOrigin.BeginTime);
            storyboard.Resume(Media);
        }

        private void VideoSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            storyboard.Pause(Media);
        }

        private bool isPlaying = false;

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                storyboard.Pause(Media);
                isPlaying = false;
                PlayButton.Content = IconLibrary.Icons[IconType.Play];
            }
            else
            {
                PlayButton.Content = IconLibrary.Icons[IconType.Pause];
                storyboard.Resume(Media);
                isPlaying = true;
            }
        }

        public void SetSource(Uri source)
        {
            mediaTimeline.Source = source;
            storyboard.Begin(Media, true);
            storyboard.Pause(Media);
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Volume = VolumeSlider.Value/100;
        }
    }
}
