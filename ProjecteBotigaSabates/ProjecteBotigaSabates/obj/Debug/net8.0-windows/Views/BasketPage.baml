   M S B A M L   `   `   `  ����P  LProjecteBotigaSabates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ProjecteBotigaSabates.ViewsProjecteBotigaSabates.Views  5      S.clr-namespace:ProjecteBotigaSabates.Components ProjecteBotigaSabates.Components  5      ,    &ProjecteBotigaSabates.Views.BasketPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      =local)clr-namespace:ProjecteBotigaSabates.Views      5      G
components.clr-namespace:ProjecteBotigaSabates.Components      5      -   5          N� Title$  
BasketPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �  5      �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��70 �6    �� 5      $��* �6    .+�5      �� -   5        $��🗑️��5      $��10q�6#   $��50��6/   $��50��6;   $��Center=�6F   6�   �� 5      -   5         ��Name$ lv_lines��5      $��1��6O   $��10q�6\   $
��Auto=�5        �� SelectionMode$ Single=�6?   ��5   )   �� *LineasComanda+��5%      �� 5&       �� 
TargetType" ��6   .�5'      ��  �� Property � �� �� Value
 ���� 67   �� 5(       � ��
 �����68   �� 5)       � ��$ 5q�63    �� Triggers 5+      P� 5,      	 P� Property	 �@J�IsMouseOver
 P� Value$

 True��6=   . �5-   "   ��  � ��
 ���� 6?   5.      P� 5/      	 �@��
IsSelected$

 True��6<   . �50   "   ��  � ��
 ���� 6?   51      55      ��59      �� 5:      .R�5;      2   ,ProjecteBotigaSabates.Components.UCOrderLine  $	��120��61   $	��120��6>   $	��120��6N   $��10q�6^      	OrderLine 6j   �� 6�   5<      5@      5B      � 5E   
   $��1��6   $��10q�6    5F      �� 5G      $��* �6#    5I      �� 5J      $
��auto �6    �� 5K      $
��auto �6    �� 5L      $
��auto �6    �� 5M      $��* �6    .+�5P      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0��6O   .+�5Q      �� -   5         ��Name$ tb_total_enviament��5Q      $��
Shipping: ��68   $��15(�6J   $��10q�6X   6f   �� 5R      -   5        $ tb_total_base��5R      $��15(�63   $��10q�6A   6O   �� 5S      -   5        $ tb_total_comanda��5S      $��15(�66   $
��Bold"�6D   $��10q�6V   6d   5T      �� 5V      $ 
Horizontal=�6   $��Center=�62   $��1��6O   .+�5W      �� -   5         ��Name$ cb_tipus_enviament��5W      $��10q�67   $	��150��6C   6O   �� 5X      -   5        $��Finish and buy��5X      $��10q�62   $	��150��6>   5Y      �� 5Z      -	   5        $��Save basket��5Z      $��10q�6/   $	��150��6;   5[      5\      �� 5^      -
   5        $ tb_info_comanda��5^      $��Center=�61   $��2��6N   $��10q�6[   6i   � 5b      $��3��6    5c      �� 5d      $��* �6'   �� 5e      $��* �6'    5g      �� 5h      $	��220 �6$   �� 5i      $
��auto �6$   �� 5j      $
��auto �6$   �� 5k      $
��auto �6$   �� 5l      $
��auto �6$   �� 5m      $
��auto �6$   .+�5p      �� -   5         ��Name$ img_varietat��5p      $	��200��6.   $��2��6:   $��Center=�6N   �� 5r      -   5        $ tb_name��5r   )   $��Name:��6   $��20(�6;   $��5q�6I   $��2��6T   $��1��6h   6w   �� 5t      -   5        $ tb_color��5t   *   $��Color:��6   $��0��6<   $��2��6L   $��5q�6Y   6f   �� 5u      -   5        $ tb_talla��5u   *   $��Talla:��6   $��1��6<   $��2��6L   $��5q�6Y   6f   �� 5w      -   5        $ tb_preu��5w   -   $��	Price /u:��6   $��0��6>   $��3��6N   $��5q�6[   6h   �� 5x      -   5        $ tb_qunatitat��5x   .   $��
Qunatitat:��6   $��1��6D   $��3��6T   $��5q�6a   6n   �� 5z      -   5        $ tb_dto��5z   .   $��
Descompte:��6   $��0��6>   $��4��6N   $��5q�6[   6h   �� 5{      -   5        $ 	tb_impost��5{   +   $��Impost:��6   $��1��6>   $��4��6N   $��5q�6[   6h   �� 5}      -   5        $ tb_base_imposable��5}   +   $��Total: ��6   $
��Bold"�6F   $��0��6X   $��5��6h   $��5q�6u   6�   �� 5~      -   5        $ tb_total_impost��5~   4   $��Total + impost: ��6   $
��Bold"�6M   $��1��6_   $��5��6o   $��5q�6|   6�   5�      5�      5�      5�      