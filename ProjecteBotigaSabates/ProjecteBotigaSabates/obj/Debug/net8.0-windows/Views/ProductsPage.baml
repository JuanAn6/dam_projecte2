   M S B A M L   `   `   `  ����P  LProjecteBotigaSabates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ProjecteBotigaSabates.ViewsProjecteBotigaSabates.Views  5      S.clr-namespace:ProjecteBotigaSabates.Components ProjecteBotigaSabates.Components  6?   .    (ProjecteBotigaSabates.Views.ProductsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      =local)clr-namespace:ProjecteBotigaSabates.Views      5      G
components.clr-namespace:ProjecteBotigaSabates.Components      6?   -   5          N� Title$  ProductsPage��5	      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6"    �� Orientation$ 
Horizontal=�62   $
��Left=�6K   .+�5      �� -   5         ��Name$ BreadCrumbs��5   +   $��BreadCrumbs��6   6C   5      �� 5   
   $��0��6   $��1��6"   $ 
Horizontal=�62   $��Center=�6K   .+�5      �� $��Search: ��6   �� 5      -   5         ��Name$ 	tb_search��5      $��Center=�6)   $	��200��6K   $��0 0 20 0q�6W   $��Center=�6�   6�   �� 5      -   5        $��Search��5      $��80��6&   $��Center=�6M   6l   5      � 5!   
   $��1��6   $��0��6    5"      �� 5#      $
��auto �6    �� 5$      $
��auto �6    �� 5%      $
��auto �6    .+�5*      �� $��Filtres��6   $��0��6'   66   �� 5+      $ Vertical=�6   $��1��60   $	��150��6=   .+�5,      �� $ 
Horizontal=�6   $	��150��66   .+�5-      �� -   5        $ sl_price_val��5-       $
��Left=�66   $	��100��6Q   �� 5.      -   5        $��Right=�5.   ?   $��Fetch��6[   $��5q�6k   6y   5/      �� 50      -   5         ��Name$ sl_price��56      $	��150��51       �� Orientation$ 
Horizontal=�6!   $
��Left=�6:    � Value$ 0Q�52      	 � Minimum$	 0Q�6   
 � Maximum$

 1000Q�6+    � SmallChange$ 1Q�53       � LargeChange$ 10Q�6%    �� TickPlacement$ BottomRight=�54       �� TickFrequency$ 10Q�61   56      58      R� 5:      -   5         R�Name$ trv_categories��5:      $��2��6/   6?   5;      �� 5=   
   -	   5         ��Name$ lv_products��5=      $��2��6I   $��1��6Y   $��10q�6f   $
��Auto=�5>       �� SelectionMode$ Single=�6C   ��5=   (   �� *
Products+��5?      �� 5@      .R�5A      A�  A� Columns$ 3��6"   5B      ��5E      �� 5F       �� 
TargetType" ��6   .�5G      ��  �� Property � �� �� Value
 ���� 63   �� 5H       � ��
 �����64   �� 5I       � ��$ 5q�6/    �� Triggers 5K      P� 5L       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5M      ��  � ��
 ���� 6;   5N      P� 5O       �@��
IsSelected$
 True��68   . �5P      ��  � ��
 ���� 6;   5Q      5U      ��5Y      �� 5Z      .R�5[      0   *ProjecteBotigaSabates.Components.UCProduct  $	��300��6+   $��10q�68      MyProd 6D   �� 6Z   5\      5`      � 5b   
   $��2��6   $��2��6    5c      �� 5d      $��* �6#   �� 5e      $
��auto �6#   �� 5f      $
��auto �6#   �� 5g      $
��auto �6#   �� 5h      $
��auto �6#   �� 5i      $��* �6#   .+�5l      �� -
   5        $��1��5l      $��10q�6%   $��80��62   $��Previous��6=   6P   �� 5m      -   5        $ tb_page��5m   @   $��2��6   $��5q�6(    �� Padding$ 10q�63   $��0��6Q   �� 5n      -   5        $ tb_max_page��5n   @   $��3��6   $��5q�6(   $ 10q�63   $��/0��6U   �� 5o      -   5        $��4��5o      $��10q�6%   $��80��62   $
��Next��6=   6L   5q      5s      5t      