   M S B A M L   `   `   `  ����I  EMusicPlayerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MusicPlayerAppMusicPlayerApp  5   	       MusicPlayerApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MusicPlayerApp     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�6.   .��5
      � ���	#FF1E1325.+�5   
   �� $
��Left=�6   $	��434��6/   $��Center=�6<   $	��123��6W   ���	#FF3024386c   �� 5   
   -   5         ��Name$
 Logo��5      $
��Left=�6   $��41��69   $��	42,10,0,0q�6E   $	��Top=�6X   $��42��6p   $��/salford.png��6{   $��UniformToFill=�6�   �� 5   
   -   5         ��Name$ YourPlaylistButton��5      $��Your Playlist��6-   $
��Left=�6E   $��0,94,0,0q�6`   $	��Top=�6r   $	��123��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��34��6�   $
��Bold"�6�   
���������6�   Z� ��6�   Z� 6  �� 5   
   -   5        $ ThemesButton��5      $��Themes��6'   $
��Left=�68   $��	0,132,0,0q�6S   $	��Top=�6f   $	��123��6~   $ 0.5,0.5&�6�   $��34��6�   
�������$
��Bold"�6�   ��6�   Z� ��6�   Z� 6  �� 5   
   -   5        $ LoginButton��5      $��Login��6&   $
��Left=�66   $��	0,343,0,0q�6Q   $	��Top=�6d   $	��123��6|   $ 0.5,0.5&�6�   $��34��6�   $
��Bold"�6�   
���������6�   Z� ��6�   Z� 6  �� 5   
   -   5        $ LogoutButton��5      $��Logout��6'   $
��Left=�68   $��
0,379,0,21q�6S   $	��123��6g   $ 0.5,0.5&�6s   $
��Bold"�6�   
���������6�   Z� ��6�   Z� 6�   �� 5   
   -   5         ��Name$ 	SearchBox��5      $��20,0,0,0q�6%   $	��422��68   $��25��6D   $��14(�5       �� TextWrapping$
 Wrap=�6   $	��Top=�60   $��253,12,125,0q�5   2   �� 5   
   $
��Left=�6   $��21��6+   $��
255,14,0,0q�67   $T��NResources/Images/search-searching-icon-vector-magnifying-260nw-1613155609.webp��6K   $	��Top=�6�   $��22��6�   $��UniformToFill=�6�   �� 5   
   -   5         ��Name$ AllSongLabel��5      $��	All Songs��6&   $
��Left=�6:   $��32��6U   $��
152,54,0,0q�6a   $	��Top=�6u   $	��135��6�   $��16(�6�   $
��Bold"�6�   
�������6�   �� 5   
   -	   5        	 ��Name$	 SongsListBox��5      $
��Left=�6(   $��
152,94,0,0q�6C   $	��Top=�6W   $	��624��6o   $	��300��6{   ��6�   Z� ��6�   Z� ��5      �� 5      .R�5      � $��10q�6   
 � ColumnDefinitions
 5      �� 5      $
��Auto �6/   �� 5       $��* �6/   .+�5$      �� $��60��6    $��60��6+   $��Center=�6P   $	��Top=�6m   ��67   �� *Image+6m   �� 5'       �� Orientation$ Vertical=�6%   $��1��6<   $��10, 0, 0, 0q�6L   .+�5(      �� 
�������$
��Bold"�6R   $��14(�6d   ��6;   �� *Title+6d   �� 5)      
�������$��Italic$�6Z   $��12(�6m   ��6;   �� *User.Username+6m   �� 5*      
�������$��12(�6X   ��6;   �� *ReleaseDate+6X   5+      5,      5-      5/      51      52      