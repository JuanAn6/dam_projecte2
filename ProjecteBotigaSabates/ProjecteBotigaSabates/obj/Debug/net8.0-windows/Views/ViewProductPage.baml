   M S B A M L   `   `   `  ����e  aMicrosoft.Web.WebView2.Wpf, Version=1.0.3179.45, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf  5      P LProjecteBotigaSabates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ProjecteBotigaSabates.ViewsProjecteBotigaSabates.Views 5      1   +ProjecteBotigaSabates.Views.ViewProductPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      ^wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf      5      =local)clr-namespace:ProjecteBotigaSabates.Views      5      -   5          N� Title$  ViewProductPage��5
      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   6-   �� 5      $	��200 �6   6-   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��2��6   $��3��6&    �� Orientation$ Vertical=�66   .+�5      �� -   5         ��Name$ tb_set_stock��5      $	��120��6,   $��Center=�68   $��5q�6U   �� 5      -   5        $��Set stock selected size��5      $	��120��67   $��Center=�6b   $��5q�6   6�   �� 5      -   5         ��Name$ tb_info_stock��5      $	��120��6/   $��Center=�6;   $��5q�6X   5       �� 5"   
   -   5         ��Name$ main_img��5"      $��0��6"   $��0��62   $	��200��6?   $��0 0 15 0q�6K   6_   � 5$   
   $��1��6   $��0��6   $��10q�6,    5%      �� 5&       5(      �� 5)      $
��auto �6    �� 5*      $
��auto �6    �� 5+      $
��auto �6    �� 5,      $
��auto �6    �� 5-      $
��auto �6    �� 5.      $
��auto �6    �� 5/      $
��auto �6    .+�52      �� $��0��6   $��0��6(   $��Talla:��65   $��	10 0 10 0q�6C   �� 53      -   5         ��Name$ 	cb_talles��53   H   $��0��6   $��1��6'   $��
10 0 10 10q�64   6[   �� 54      -   5        $ tb_stock��54   D   $��0��6   $��2��6(   $��Stock: ��65   $��
10 0 10 10q�6V   �� 56      $��0��6   $��3��6(   $��
Qunatity: ��65   $��
10 0 10 10q�6G   �� 57      -   5        $ tb_qunatity��57   4   $��0��6   $��4��6&   $��
10 0 10 10q�6I   �� 59      -	   5        $��0��59      $��5��6%   $��Add to basket��62   $��
10 0 10 10q�6m   �� 5:      -
   5        $ tb_info_add��5:   =   $��0��6   $��6��6(   $�� ��65   $��
10 0 10 10q�6R   $
��Wrap=�6f   5<      �� 5?   
   -   5         ��Name$ lv_imgs��5?      $��0��6$   $��1��64   $��2��6A   $��	0 10 15 0q�6U   $
��Auto=�5@      $��Disabled=�5A      ��5D      �� 5E      	 �� 
TargetType"	 ��6   .�5F      �� 
 �� Property
 � �� �� Value
 ���� 63   �� 5G      
 � ��
 �����64   �� 5H      
 � ��$ 1q�6/   5I      ��5L      �� 5M      .R�5N      �� $ 
Horizontal=�6!   5O      ��5R      �� 5S      .R�5T      �� $��50��68   $��50��6C   ��6   �� *
ImageUrl+6Q   5U      5X      � 5\   
   $��2��6   $��2��6    5]      �� 5^      $
��auto �6#   62    5`      �� 5a      $
��auto �6    60   �� 5b      $
��auto �6    60   �� 5c      $
��auto �6    60   �� 5d      $
��auto �6    60   .+�5f      �� -   5        $ tb_name��5f      $��0��6*   $��20(�67   6G   )   #Microsoft.Web.WebView2.Wpf.WebView2  5g      -   5          Name$ wb_desc��5g      $��1��6,   $	��150��69   $	��200��6I   6[   �� 5i      -   5        $ tb_preu��5i   &   $��Price:��6   $��2��68   6G   �� 5j      -   5        $ tb_color��5j   &   $��Color:��6   $��3��69   6H   5l      5n      5o      