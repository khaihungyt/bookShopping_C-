   M S B A M L   `   `   `  ����  Project_PRN212    PRN212_Assignment.Orders   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Orders��5   	   $	��400��6   $	��800��6%   .��5      � ���#f8f5f5 � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   � $��0��6   $��10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��Center=�6B   .+�5      �� $��Full Name: ��6   $��16(�5      $
��Bold"�5      $��Center=�5      $��Bell MT)�5      $	��153��5      �� 5      -   5         ��Name$ UserNameTextBlock��5      $��5,0,0,0q�5      $��16(�5      $
��Bold"�5      $��Center=�5      $
��Left=�5      5      �� 5!      $ 
Horizontal=�6   $��1��62   $��Right=�6B   .+�5"      �� $��Search: ��6   $��16(�5#      $
��Bold"�5$      $��Center=�5%      $��Bell MT)�5&      $��60��5'      �� 5(      -   5         ��Name$ SearchTextBox��5(      $	��200��5)      $��5,0,10,0q�5*      $��Center=�5+      �� 5,      -   5        $��Search��5,      $	��100��5-      ���#428bca
�������50      51      52      �� 54   
   -   5         ��Name$ OrdersListView��54      $��1��55      $��10q�56      $��Stretch=�57      $��Stretch=�58       �� View 59      �� 5:      .P�5;      �� $��Order ID��6%    �� Width$	 150��67   	 �� HeaderTemplate	 5<      �� 5=      .R�5>   "   �� $��Center=�5?   $   $��Center=�5@   $   ��5>   ,   �� 5@   $   5A      
 �� CellTemplate
 5C      �� 5D      .R�5E   "   �� $��Center=�5F   $   $��Center=�5G   $   ��5E   ,   �� *	OrderId+5G   $   5H      5J      �� 5K      $��	Book Name��6%   $	 300��68   	 5L      �� 5M      .R�5N   "   �� $��Center=�5O   $   $��Center=�5P   $   ��5N   ,   �� 5P   $   5Q      
 5S      �� 5T      .R�5U   "   �� $��Center=�5V   $   $��Center=�5W   $   ��5U   ,   �� *
BookName+5W   $   5X      5Z      �� 5[      $��Quantity��6%   $	 150��67   	 5\      �� 5]      .R�5^   "   �� $��Center=�5_   $   $��Center=�5`   $   ��5^   ,   �� 5`   $   5a      
 5c      �� 5d      .R�5e   "   �� $��Center=�5f   $   $��Center=�5g   $   ��5e   ,   �� *
Quantity+5g   $   5h      5j      �� 5k      $��Order Status��6%   $	 200��6;   	 5l      �� 5m      .R�5n   "   �� $��Center=�5o   $   $��Center=�5p   $   ��5n   ,   �� 5p   $   5q      
 5s      �� 5t      .R�5u   "   �� $��Center=�5v   $   $��Center=�5w   $   ��5u   ,   �� *OrderStatus+5w   $   5x      5z      5{      5}      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��10q�6;   $��Right=�6G   .+�5�      �� -   5        $��Close��5�      $	��100��5�      $��0,0,10,0q�5�      ���#428bca
�������$��34��5�      5�      �� 5�      -   5        $��Export to Text File��5�      $	��150��5�      
��� � �
�������$��34��5�      5�      5�      5�      5�      