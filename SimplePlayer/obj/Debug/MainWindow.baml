   M S B A M L   `   `   `  ����G  CSimplePlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SimplePlayerSimplePlayer  5   	   7 clr-namespace:SimplePlayer.ModelSimplePlayer.Model  5   	   A%clr-namespace:SimplePlayer.RepositorySimplePlayer.Repository  5   	       SimplePlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SimplePlayer     5   	   2media clr-namespace:SimplePlayer.Model     5   	   <
collection%clr-namespace:SimplePlayer.Repository     5   	     � Title$  SimplePlayer��5   	   $��435.5��6   $	��666��6-    � 	Resources 5      "  SimplePlayer.Model.MediaFile   playFile&    SimplePlayer.Repository.PlayList  playCollection��%:   &	        &	        5   
   6-     5   
   67   5      .��5      ]� -   5         ]�Name$ dpMainPanel��5      
���   � � DataContext 6%   ��  �� Source# [ .+�5   
   o� -   5         o�Name$ 
miMainMenu��5      $	��Top=�6#   .@�5      m� $
��File��6   .@�5      m� -   5         m�Name$ 
miOpenFile��5      $��	Open file��6/   6_   5      9� 5      .��5      �� -   5         ��Name$ 
cbAutoPlay��5      .��6/   	Auto play6:   5      5      � 5   
   -   5         �Name$ GridPlayerControlls��5      $��Bottom=�6,   
���   �	 � RowDefinitions	 5      �� 5      6"   �� 5      6"   .+�5"      �� -   5        
 ��Name$
 	sPosition��5"      $��0��6(   $��5��65    � Minimum$ 0Q�6I   5%      ]� 5&      $��1��6   $��5��6%   .+�5'      �� -   5         ��Name$ 
lbTimeInfo��5'      $
��Left=�6,   $��Center=�6B   
����� �.��6q   
00:00:006{   �� 5(      -   5         ��Name$ 
btnPrevios��5(      $
��Left=�6-   
����� �$��50��5)      $	��150��5*      .��5-      F� 
����� �  navigate_previousStyle0#��[ 6'    �� Stretch$ Uniform=�6W   $��20��6i   6w   5.      �� 5/      -	   5        $ btnPlay��5/      $
��Left=�6*   $��50��50      $	��150��51      .��52      F� -
   5         F�Name$ btnPlayPath��52      
����� �  
PlayStyle0#��[ 6<   $ Uniform=�6_   $��20��6q   6   53      �� 54      -   5        $ btnNext��54      $
��Left=�6*   $��50��55      $	��150��56      .��58      F� 
����� �  navigate_nextStyle0#��[ 6'   $ Uniform=�6S   $��20��6e   6t   59      �� 5;      -   5        $ btnFullScreen��5;      $��Right=�64   $��50��6K   .��5<      F� 
����� �  fullscreen_boxStyle0#��[ 6+   $ Uniform=�6X   $��20��6j   6x   5=      �� 5>      -   5        $
 sVolume��5>      $��Right=�6.   $��Right=�6E   $ 0Q�5?       � Value$	 0.4Q�5@       � Maximum$ 1Q�5A      $��5q�5B      $	��100��6)   $	��100��68   6I   5D      5G      � 5H   
   -   5        $ 
dpListZone��5H      $��Right=�6#   
���   �	 5I      �� 5J      $	��.9* �6    6/   �� 5K      $	��.1* �6    6/   .+�5M      �� -   5         ��Name$ 
lbPlayList��5M      $��0��6*   $��Stretch=�67   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5N       J� 	AllowDrop . $	��100��5P      $	��200��6#   $	��300��62   ��5M   S   ��  �� ElementName$ 
dpListZone�� �� Path$ ActualHeight���6�   �� # [ $ FilesCollection�5R      �� 5S      -   5        $ btnRemoveFromList��5S      $��1��60   $��30��6=   .��6l   Remove6u   5T      �� 5U   
   
���   �6&   r� 5V   
   -   5         r�Name$ mePlayer��5V      $
��Left=�6)    r� Stretch$
 Fill=�5X       r� LoadedBehavior$ Manual=�5Y   X    r� Source 5X   &   �� # [  $ PlayFile� r� Volume 5Y      �� $ sVolume��$ Value� �� Mode$ TwoWay=�5\   <   5_      5`      