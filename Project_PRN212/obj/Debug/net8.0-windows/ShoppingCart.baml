   M S B A M L   `   `   `  ����I  EProject_PRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PRN212_AssignmentPRN212_Assignment  5   	   $    PRN212_Assignment.ShoppingCart   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PRN212_Assignment     5   	     � Title$  ShoppingCart��5   	   $	��550��6   $	��800��6+   .��5	      � .+�5
   
   �� $	��Top=�6   $��44��6,   $��	0,0,587,0q�68   $��25(�6K   �� 5   
   $
�Book��6   $
��Bold"�6    �� 5   
   $�Shopping��6   $
��Bold"�6   
���  ��60   5      � 5   
    � Orientation$ 
Horizontal=�6   $��
0,12,0,422q�6-   $��Right=�6A   $	��534��6]   .+�5      �� -   5         ��Name$ btnHomePage��5      $��	Home Page��6*   $	��112��6>   $��30��6J   6V   �� 5      -   5        $ btnCart��5      $
��Cart��6&   $��12q�65   $	��100��6A   $��30��6M   �� 5      -   5        $ btnUserProfile��5      $��12q�6-   $	��100��69   $��30��6E   6Q   �� 5      -   5        $ 	btnLogout��5      $��Log Out��6)   $��12q�6;   $	��100��6G   $��30��6S   6_   5      �� 5   
   -   5         ��Name$ 
lvCartList��5      $��0,117,160,242q�6'    �� View 5      �� 5      .P�5      �� $��Image��6%    �� Width$	 100��64    �� CellTemplate 5      �� 5      .R�5   "   �� $	��100��6H   $	��100��6T   ��6(   ��  �� Path$ BookImg�6T   5      5      �� 5      $��	Name Book��6%   $	 200��68    �� DisplayMemberBinding 6D   �� $ BookName��� 5      $��Quantity��6%   $	 100��67    6D   �� $ Quantity��� 5       $��Price a Book��6%   $	 100��6;    6G   �� $ 	BookPrice��� 5!      $��Actions��6%   $	 100��66    5"      �� 5#      .R�5$   "   �� $ 	btnRemove��6)   -   5        $��Remove��5$   <   	 � DataContext	 6b   �� $ CartId�6�   5%      5'      5(      5*      �� 5+   
   $��474,297,104,154q�6   .+�5,      �� -   5        $��lblTotalPrice��5,      $��Total: ��6*   $
��Bold"�6<   6P   �� 5-      -   5        $��btnCheckOut��5-      $��	Check Out��6(   $��28��6<   $	��115��6H   6q   5.      5/      50      