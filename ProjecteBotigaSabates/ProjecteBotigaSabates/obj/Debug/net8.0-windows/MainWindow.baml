   M S B A M L   `   `   `  ����P  LProjecteBotigaSabates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjecteBotigaSabatesProjecteBotigaSabates  5   	   &     ProjecteBotigaSabates.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null<x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   Bd2http://schemas.microsoft.com/expression/blend/2008      5   	   Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   7local#clr-namespace:ProjecteBotigaSabates      5   	   -   5          � Icon$  	/logo.ico��5   	    � Title$ 
Juan Shoes��5	   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   $��0��6   $��
10 10 10 0q�6,    5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� -   5        $��0��5      $��0 0 0 0q�6%   
���   � � Cursor$
 Hand��6S   $
|�True��5      ._�5       �� $��Sign out��6   $��	10 0 10 0q�6,   6B   5!      �� 5#      -   5         ��Name$ tb_user_name��5#   (   $��2��6   $��Right=�5$      $	��Top=�5%      $��Example Name User��60   6L   � 5(      -   5         �Name$ grid_MainMenu��5(      $��1��6*   $��	20 0 20 0q�6:    5)      �� 5*      $��* �6'   �� 5+      $
��auto �6'   �� 5,      $
��auto �6'   �� 5-      $
��auto �6'   �� 5.      $
��auto �6'   �� 5/      $��* �6'   .+�52      �� -   5        $��1��52      $��0 0 0 0q�6)   
���   �$
 Hand��6W   $
|�True��6e   ._�55      �� $��Products��6    $��	10 0 10 0q�60   6E   56      �� 58      $��2��6   $��1 0 1 0q�6)   
���   �$
 Hand��6W   $
|�True��6e   ._�59      o� -   5         o�Name$ menu_categories��59      .@�5:      m� $��
Categories��6#   5;      5<      5=      �� 5?      -   5        $��3��5?      $��0 0 0 0q�6)   
���   �$
 Hand��6W   $
|�True��6e   ._�5A      ��  �� Orientation$ 
Horizontal=�6!   .+�5B      �� $��Basket��6$   $��10 0 2 0q�62   6G   �� 5C      -   5        $ tb_number_lines��5C   ,   $�� ��6$   6H   5D      5E      5G      5I       � 5J   
   -	   5        	  �Name$	 	MainFrame��5J      
  � NavigationUIVisibility$
 Hidden=�6#   $��0��6C   $��1��6S   �� 5K   
   -
   5        $ tb_info��5K   +   $	��100��6   $	��100��6<   $
��Wrap=�6K   6a   5L      5M      