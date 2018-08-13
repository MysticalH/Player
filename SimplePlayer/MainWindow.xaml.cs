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
using Microsoft.Win32;
using System.Windows.Threading;
using SimplePlayer.Repository;
using SimplePlayer.Model;
using System.IO;

namespace SimplePlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// мультимедийный таймер
        /// </summary>
        private DispatcherTimer dispatcherTimer;

        private DateTime time;

        //private TimeSpan currentTime;

        private bool IsPlay = false;

        private bool IsControlsVisible = true;


        private PlayList playCollection;
                    
        private bool fullscreen = false;

        /// <summary>
        /// последние координаты мыши
        /// </summary>
        Point mousePoint = Mouse.GetPosition(null);
        

        /// <summary>
        /// таймер для сокрытия элементов управления
        /// </summary>
        private DispatcherTimer visibleTimer;
        
        


        public MainWindow()
        {
            InitializeComponent();

            MouseMove += MainWindow_MouseMove;

            playCollection = new PlayList();
            
            this.DataContext = this;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            
            this.MouseDoubleClick += MainWindow_MouseDoubleClick;
            
        }

        

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            
            ShowControllElements();
      
        }

        

        private void mePlayer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            ShowControllElements();
        }

        

        /// <summary>
        /// показать элементы управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowControllElements()
        {
            if (!IsControlsVisible)
            {
                if (mousePoint != Mouse.GetPosition(null))
                {
                    this.Cursor = Cursors.Arrow;
                    GridPlayerControlls.Visibility = Visibility.Visible;
                    dpListZone.Visibility = Visibility.Visible;
                    //lbPlayList.Visibility = Visibility.Visible;
                    miMainMenu.Visibility = Visibility.Visible;
                                       
                    mousePoint = Mouse.GetPosition(null);
                    IsControlsVisible = true;
                }
                
            }
             
        }

        /// <summary>
        /// спрятать элементы управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideControllElements(/*object sender, EventArgs e*/)
        {

                this.Cursor = Cursors.None;
                GridPlayerControlls.Visibility = Visibility.Collapsed;
                dpListZone.Visibility = Visibility.Collapsed;
                miMainMenu.Visibility = Visibility.Collapsed;
           
        }

#region TESTMOUSEREGION
        private void Menu_OnMouseLeave(object sender, MouseEventArgs e)
        {
            //Menu.Visibility = Visibility.Visible;
        }

        private void Menu_OnMouseEnter(object sender, MouseEventArgs e)
        {
            //Menu.Visibility = Visibility.Hidden;

        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            //Grid.Visibility = Visibility.Hidden;
        }

        private void Grid_OnMouseEnter(object sender, MouseEventArgs e)
        {
            //Grid.Visibility = Visibility.Visible;
        }
        #endregion
#region MEDIA_BUTTONS

        /// <summary>
        /// Запуск или остановка плеера
        /// </summary>
        private void PlayAndPause()
        {
            if (!IsPlay)
            {
                //HideControllElements();
                mePlayer.Play();

                dispatcherTimer.Start();

                btnPlayPath.Data = (Geometry)Application.Current.Resources["pauseStyle0"];
                IsPlay = true;
            }
            else
            {
                mePlayer.Pause();

                dispatcherTimer.Stop();

                ShowControllElements();

                btnPlayPath.Data = (Geometry)Application.Current.Resources["PlayStyle0"];
                IsPlay = false;
            }
        }

        /// <summary>
        /// следующий файл
        /// </summary>
        private void NextFile()
        {
            if (cbAutoPlay.IsChecked == true)
            {
                if (lbPlayList.SelectedIndex != lbPlayList.SelectedItems.Count)
                {
                    lbPlayList.SelectedIndex++;
                    if ((lbPlayList.SelectedItem) != null)
                    {
                        if (IsPlay)
                        {
                            mePlayer.Play();
                        }
                    }
                    
                }
                else
                {
                    mePlayer.Stop();
                }
                
            }
            
            
        }

        /// <summary>
        /// предыдущий файл
        /// </summary>
        private void PreviosFile()
        {
            if (lbPlayList.SelectedIndex != 0)
            {
                lbPlayList.SelectedIndex--;
                if ((lbPlayList.SelectedItem) != null)
                {
                    if (IsPlay)
                    {
                        mePlayer.Play();
                    }
                }
            }
            
            
        }

        /// <summary>
        /// Добавление файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOpenFile_OnClick(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFile = new OpenFileDialog()
            {
                DefaultExt = ".mp4",
                Multiselect = true,
                Filter = "Video Files|*.avi;*.mpeg;*.mpg;*.mp4;*.wmv;*.mkv;*.ts|Music Files|*.mp3;*.wma|All Files (*.*)|*.*",
                CheckFileExists = true
            };

            if (openFile.ShowDialog() == true)
            {
                var file = openFile.FileName;

                ((PlayList)Resources["playCollection"]).FilesCollection.Add(file);
                
            }
            lbPlayList.Items.Refresh();
        }

        /// <summary>
        /// кнопка старта и паузы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_OnClick(object sender, RoutedEventArgs e)
        {
            PlayAndPause();           
        }
        private void mePlayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayAndPause();
        }

        /// <summary>
        /// следующий файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            NextFile();
        }

        /// <summary>
        /// предыдущий файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevios_Click(object sender, RoutedEventArgs e)
        {
            PreviosFile();
        }


        /// <summary>
        /// на весь экран с кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFullScreen_Click(object sender, RoutedEventArgs e)
        {
            fullScreen();
            
        }

        

        #endregion
       

        private void mePlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            sPosition.Value = 0;
            sPosition.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
            dispatcherTimer.Tick += DispatcherTimer_Tick;

        }
#region SLIDERPOSITION
        /// <summary>
        /// передвижение слайдера во время воспроизведения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (IsControlsVisible)
            {

                HideControllElements();
                IsControlsVisible = false;
            }
                       
            lbTimeInfo.Content = TimeSpan.FromSeconds(Math.Round(sPosition.Value));
            sPosition.Value += 1;

        }


        /// <summary>
        /// начало перемещения позиции воспроизведения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sPosition_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mePlayer.Pause();
        }


        /// <summary>
        /// завершение перемещения позиции воспроизведения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sPosition_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            time = time.AddSeconds(sPosition.Value - time.Second);

            mePlayer.Position = TimeSpan.FromSeconds(sPosition.Value);

            mePlayer.Play();
            
        }

        #endregion

       
       

        /// <summary>
        /// на весь экран при дабл клике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            fullScreen();
        }
        private void fullScreen()
        {
            if (!fullscreen)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
            }

            fullscreen = !fullscreen;
        }

        private void mePlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            NextFile();
            
        }

        private void lbPlayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                mePlayer.Source = new Uri(lbPlayList.SelectedItem.ToString());
            }
            catch (Exception)
            {

                
            }
            
        }

#region DRAGDROP
        private void lbPlayList_Drop(object sender, DragEventArgs e)
        { 
            List<string> posibleExtensions = new List<string>() { ".avi", ".mpeg", ".mpg", ".mp4", ".wmv", ".mkv", ".ts", ".mp3", ".wma" };
            bool IsCorrect = true;

            if (e.Data.GetDataPresent(DataFormats.FileDrop,true) == true)
            {
               
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop) as string[];

                foreach(var file in files)
                {
                    if (!File.Exists(file))
                    {
                        IsCorrect = false;
                        break;
                    }
                    FileInfo fileInfo = new FileInfo(file);
                    if (!posibleExtensions.Contains(fileInfo.Extension))
                    {
                        IsCorrect = false;
                        break;
                    }
                }
                if (IsCorrect)
                {
                    
                    e.Effects = DragDropEffects.All;
                }
                else
                    e.Effects = DragDropEffects.None;
                    e.Handled = true;
           
            }

        }
        private void lbPlayList_PreviewDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            foreach (string filename in filenames)
                ((PlayList)Resources["playCollection"]).FilesCollection.Add(filename);
            e.Handled = true;
        }
#endregion

        /// <summary>
        /// удаление из плей листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFromList_Click(object sender, RoutedEventArgs e)
        {
            if (lbPlayList.SelectedItem != null)
            {
                ((PlayList)Resources["playCollection"]).FilesCollection.Remove(lbPlayList.SelectedItem.ToString());
                mePlayer.Source = null;
            }
            
        }

        private void mePlayer_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            
        }
    }
}
