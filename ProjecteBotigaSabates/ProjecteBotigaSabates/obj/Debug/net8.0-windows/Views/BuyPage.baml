   M S B A M L   `   `   `  ����P  LProjecteBotigaSabates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ProjecteBotigaSabates.ViewsProjecteBotigaSabates.Views  5      )    #ProjecteBotigaSabates.Views.BuyPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null<x,http://schemas.microsoft.com/winfx/2006/xaml      5      Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      Bd2http://schemas.microsoft.com/expression/blend/2008      5      =local)clr-namespace:ProjecteBotigaSabates.Views      5      -   5          N� Title$  BuyPage��5	      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Card information��6   $��15(�6,   $��10q�6:   6H   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��0 0 0 10q�6;   .+�5      �� $��Name: ��6   $��	10 0 10 0q�6&   $	��100��69   6G   �� 5       -   5         ��Name$ tb_card_name��5       $��0 0 10 0q�6,   $	��200��6>   6L   5!      �� 5#   
   $��2��6   $ 
Horizontal=�6"   $��0 0 0 10q�6;   .+�5$      �� $��Number: ��6   $��	10 0 10 0q�6(   $	��100��6;   6I   �� 5%      -   5        $ tb_card_number��5%      $��0 0 10 0q�6.   $	��200��6@   6N   5&      �� 5(   
   $��3��6   $ 
Horizontal=�6"   $��0 0 0 10q�6;   .+�5)      �� $��CVV: ��6   $��	10 0 10 0q�6%   $	��100��68   6F   �� 5*      -   5        $ tb_card_cvv��5*      $��0 0 10 0q�6+   $��70��6=   6J   5+      �� 5-   
   $��4��6   $ 
Horizontal=�6"   $��0 0 0 10q�6;   .+�5.      �� $��Expire date: ��6   $��	10 0 10 0q�6-   $	��100��6@   6N   (  "System.Windows.Controls.DatePicker  5/      -   5          Name$ tb_card_date��5/      $��0 0 10 0q�6/   $	��200��6A      SelectedDateFormat$ Short=�6M   6j   50      �� 52   
   $��5��6   $ 
Horizontal=�6"   $��0 0 0 10q�6;   .+�53      	� -   5         	�Name$ rb_master_card��53       	� 	GroupName$ Tarjetas��62   $��10q�6G   .��54      �� $ 
Horizontal=�6   .+�55      �� $��/master_card.png��6   $��50��66   $��50��6A   $��5q�6M   �� 56      $��
MasterCard��6    $��Center=�62   $��5 0 0 0q�6M   57      58      	� 5:      -   5        $ rb_visa��5:      $ Tarjetas��6+   $��10q�6@   .��5;      �� $ 
Horizontal=�6   .+�5<      �� $��	/visa.jpg��6   $��50��6/   $��50��6:   $��5q�6F   �� 5=      $
��Visa��6    $��Center=�6,   $��5 0 0 0q�6G   5>      5?      5@      �� 5B   
   $ Vertical=�6   $��6��6,   $��0 0 0 10q�69   .+�5C      �� -   5        	 ��Name$	 tb_base_enviament��5C      $��15(�63   $��0 0 0 5q�6A   6T   �� 5D      -	   5        $	 tb_total_enviament��5D      $��15(�64   $��0 0 0 5q�6B   6U   �� 5E      -
   5        $	 tb_base_comanda��5E      $��15(�61   $��0 0 0 5q�6?   6R   �� 5F      -   5        $	 tb_total_comanda��5F      $��15(�62   $
��Bold"�6@   6U   5G      �� 5I   
   $ Vertical=�6   $��7��6,   $��0 0 0 10q�69   .+�5J      �� $ 
Horizontal=�6   .+�5K      �� -   5        
 ��Name$
 
btn_cancel��5K   *   $��Cancel��6   $��50��6>   $	��100��6J   6V   �� 5L      -   5        $
 btn_save��5L   '   $	��Buy��6   $��50��69   $	��100��6E   $��	10 0 10 0q�6Q   6d   5M      �� 5N      -   5        $	 tb_info��5N      $	��300��6)   $��	0 10 0 10q�65   $
��Left=�6H   5O      5Q      5R      