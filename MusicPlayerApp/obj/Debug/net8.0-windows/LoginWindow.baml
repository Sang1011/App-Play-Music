   M S B A M L   `   `   `  ����I  EMusicPlayerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MusicPlayerAppMusicPlayerApp  5   	        MusicPlayerApp.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MusicPlayerApp     5   	     � Title$  LoginWindow��5   	   $	��580��6   $
��1020��6*    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�6.   .��5
      � ���	#FF302438 � ColumnDefinitions 5   
   �� 5      $
��101* �6   �� 5      $
��919* �6   .+�5   
   �� -   5         ��Name$ CloseButton��5      $	��⇦��6&   $��55(�62   $
��Left=�6@   $	��Top=�6[   $��55��6s   $��56��6   $��0q�6�   
�������$
��Bold"�6�   $��	0,-10,0,0q�6�   $��8,-6,0,0q�6  ��6�   Z� 6  �� 5   
   $��LOGIN��6   $��55(�6    $
��Bold"�6.   $��231,25,332,448q�6@   $��Center=�6X   
�������$��1��6�   �� 5   
   $��Email��6   
�������$��24(�63   $
��Bold"�6A   $��0,157,759,325q�6S   $��Center=�6j   $��1��6�   �� 5   
   $��Password��6   
�������$��24(�66   $
��Bold"�6D   $��0,244,759,218q�6V   $��Center=�6m   $��1��6�   �� 5   
   -   5         ��Name$ EmailTextBox��5      $
��Left=�6(   $��43��6C   $��160,157,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��556��6�   $��24(�6�   $��1��6�   �� 5   
   -   5        $ PasswordTextBox��5      $
��Left=�6+   $��43��6F   $��160,244,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��556��6�   $��24(�6�   $��1��6�   �� 5   
   -   5        $ LoginButton��5      $��Login��6&   $
��Left=�66   $��216,366,0,0q�6Q   $	��Top=�6f   $��54��6~   $	��161��6�   $��24(�6�   $
��Bold"�6�   
����  �
�������$��0q�6�   $��1��6	  �� 5   
   -   5        $ 
QuitButton��5      $
��Quit��6%   $
��Left=�64   $��411,366,0,0q�6O   $	��Top=�6d   $��54��6|   $	��160��6�   $��24(�6�   $
��Bold"�6�   
���  ��
�������$��0q�6�   $��1��6  5      5      