   M S B A M L   `   `   `  ���� G  CSimplePlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SimplePlayerSimplePlayer      SimplePlayer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:SimplePlayer       � Title$  
MainWindow��$	��350��$	��525�� � 	Resources    ArrowLeftStyle0��%i   &	        �YUF1 M 36,22L 36,26L 19.75,26L 27,33L 20.5,33L 11,24L 20.5,15L 27,15L 19.75,22L 36,22 Z�.��]� .+�o� -    o�Name$
 Menu��$	��Top=�.@�m� $
��File��.@�m� -    m�Name$ 
miOpenFile��$��	Open file��m� $��Add to playlist��m� $
��View��� -    �Name$
 Grid��$��Bottom=�
���   � � RowDefinitions �� ��  � ColumnDefinitions �� �� �� �� �� .+��� $��0��$��5���� $��1��$��0��$��Center=�
����� �.��
00:00:00�� $��1��$��1��
����� �.��F� 
����� �  navigate_previousStyle0#��[  �� Stretch$ Uniform=�$��20���� $��1��$��2��.��F� 
����� �  
PlayStyle0#��[ $ Uniform=�$��20���� -    ��Name$ btnPlay��$��1��$��3��.��F� 
����� �  navigate_nextStyle0#��[ $ Uniform=�$��20���� $��1��$��4��	 � Minimum$	 0Q�
 � Maximum$	
 100Q�$��5q��� -    ��Name$ 
lbPlayList��$��Right=�r� -    r�Name$ mePlayer��$
��Left=� r� Source$/ )E:\Artem\Videos\Eminem - Lose Yourself.ts?� r� LoadedBehavior$ Manual=�