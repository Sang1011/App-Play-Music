   M S B A M L   `   `   `  ����I  EMusicPlayerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MusicPlayerAppMusicPlayerApp  5   	   !    MusicPlayerApp.DetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MusicPlayerApp     5   	   -   5          � Title$  Music Player��5   	   $	��500��6   $	��300��6+   ���	#FF302438 � WindowStartupLocation$ CenterScreen=�6e    � 
ResizeMode$ NoResize=�6�    � WindowStyle$ SingleBorderWindow=�6�   .��5	      � .+�5   
   �� ���	#FF121212 �� CornerRadius$ 20��6(   $��10q�6:   ._�5      �� $��Center=�6   $��Center=�66   $	��211��6Q   .+�5      �� $	��200��6   $	��200��6%   $ 10��62   $��1q�6D   ���	#FFBEB4C4��5      �� 5      -   5        	ImageSong�� �� ImageSource 5   8   �� *Image+._�5      �� 
�������$��Center=�5      $��Center=�65   $��16(�5      $
��Bold"�6&   5      �� 5      -   5         ��Name$ FavoriteButton��5      $	��♡��61   $��0q�6S   
�������$
��Bold"�6z   $��24(�6�   $��1��6�   $��0,0,0,0q�6�   $��45��6�   ��6=   Z� 6�   �� 5      $��	0,20,0,10q�6   .+�5      �� -   5         ��Name$ 	SongTitle��5       
�������$��16(�6]   $
��Bold"�6k    �� TextAlignment$ Center=�6}   ��63   �� *Title+6}   �� 5      -   5        $ 
ArtistName��5       
�������$��14(�6j   $ Center=�6x   ��64   �� *User.Username+6x   5      �� 5      .+�5      �� -   5        	 ��Name$	 ProgressSlider��5      
 � Minimum$
 0Q�65    � Maximum$	 100Q�6A    � Value$ 0Q�6O   
�������6Z   r� 5      -   5         r�Name$ mediaElement��5   #   �� 5        �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $	��0,5q�6W   .+�5!      �� -   5        $ CurrentTimeText��5!   $   $
��0:00��6=   
�������$��12(�6`   �� 5"      $	�� / ��6$   
�������$��12(�6F   �� 5#      -	   5        $ TotalTimeText��5#   $   $
��0:00��6;   
�������$��12(�6^   5$      5%      �� 5+      $ 
Horizontal=�6   $��Center=�66   $
��0,10q�6S   .+�5,      �� -
   5        $ 
BackButton��5,      $��40��61   $��40��6<   $��⏮️��6H   
������ 
�������$��16(�6�   6�   �� 5-      -   5        $ 
PlayButton��5-      $��60��61   $��60��6<   $��⏯️��6H   
������ 
�������$��20(�6�   6�   �� 5.      -   5        $ 
NextButton��5.      $��40��61   $��40��6<   $��⏭️��6H   
������ 
�������$��16(�6�   6�   5/      52      53      54      55      