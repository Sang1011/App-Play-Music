   M S B A M L   `   `   `  ����I  EMusicPlayerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MusicPlayerAppMusicPlayerApp  5   	   !    MusicPlayerApp.ArtistWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MusicPlayerApp     5   	   -   5          � Title$  ArtistWindow��5   	   $	��580��6   $
��1020��6+    � WindowStartupLocation$ CenterScreen=�68   .��5	      � ���	#FF1E1325.+�5   
   �� $
��Left=�6   $	��564��6/   $��Center=�6<   $	��123��6W   ���	#FF3024386c   �� 5   
   -   5         ��Name$ 	Workspace��5      $��Your Workspace��6$   $
��Left=�6=   $��0,97,0,0q�6X   $	��Top=�6j   $	��123��6�   $
��Bold"�6�   
����������	#FF523E5F$��34��6�   ��6�   Z� 6�   �� 5   
   -   5        $ 
QuitButton��5      $
��Quit��5      $
��Left=�5      $��	0,490,0,0q�5      $	��Top=�5      $	��123��5       J� RenderTransformOrigin$ 0.5,0.5&�5      $��34��5      $
��Bold"�5      
���������5      Z� ��5      Z� ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      �� 5       �� Binding 6&   �� *	IsEnabled+ �� RelativeSource �� *Self+ �� Value	 False6j   .a�5      �� 	 �� Property	 � ��
 �� Value
 �	#FF3024386;   �� 5      	 � ��
 �	#FF3024386;   5       5"      5$      �� 5'   
   -   5         ��Name$ ImageBackground��5'      $��152,11,26,304q�6B   $��UniformToFill=�6Y   ��6)   �� *Image+6Y   �� 5(   
   -   5         ��Name$ 	SearchBox��5(      $��20,0,0,0q�6%   $��23��68   $��14(�6D   $	��Top=�6R   $��336,34,239,0q�6�   �� 5)   
   $
��Left=�6   $��21��6+   $��
337,35,0,0q�67   $T��NResources/Images/search-searching-icon-vector-magnifying-260nw-1613155609.webp��6K   $	��Top=�6�   $��22��6�   $��UniformToFill=�6�   �� 5*   
   -   5        $��+ Add new song��5*      ���#83A6CE���#fff$��20(�6Q   $
��Bold"�6_   $ -0.268,0.401&�6�   $��805,259,26,253q�6�   �� 5,   
   -   5         ��Name$ SongsListBox��5,      $
��Left=�6(   $��155,315,0,0q�6C   $	��Top=�6X   $	��840��6p   $	��248��6|   ��6�   Z� ��6�   Z� ��5-      �� 5.      .R�5/      � $	��801��6   $��0 5 0 5q�6'    � ColumnDefinitions 50      �� 51      $
��Auto �6/   �� 52      $
��Auto �6/   �� 53      $��* �6/   .+�57      �� $��60��6    $��60��6+   $��Center=�6P   $	��Top=�6m   $��UniformToFill=�6�   ��67   �� *Image+6�   �� 5:       �� Orientation$ Vertical=�6%   $��1��6<   $��10, 0, 0, 0q�6L   .+�5;      �� 
�������$
��Bold"�6R   $��14(�6d   ��6;   �� *Title+6d   �� 5<      
�������$��Italic$�6Z   $��12(�6m   ��6;   �� *User.Username+6m   �� 5=      
�������$��12(�6X   ��6;   �� *ReleaseDate+6X   5>      �� 5A      $ 
Horizontal=�6%   $��2��6>   $��Right=�6N   $��Center=�6j   $��0,0,10,0q�6�   .+�5B      �� -   5        $
��🖉��5B   %   $��25��62   $��25��6=   $��0 0 5 0q�6I   ��6u   �� �� 5C      -	   5        $	��✖��5C   %   $��25��61   $��25��6<   ��6c   �� 5D      5E      5F      5H      5I      5J      