   M S B A M L   `   `   `  ����I  EProject_PRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PRN212_AssignmentPRN212_Assignment  5   	   )    #PRN212_Assignment.ProductListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:PRN212_Assignment     5   	     � Title$  Product List��5   	   $	��450��6   $	��800��6+   .��5      ]� .+�5   
      PRN212_Assignment.Sidebar     CurrentPage$ Products��6   $
��Left=�6/   $	��200��6E   � 5	   
   $	��Top=�6   ���#34495E$��50��69    � ColumnDefinitions 5
      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��Product List��6   $��Center=�6,   
�������$��20(�6Z   $��10q�6h   �� 5      -   5        $��LogoutButton��5   &   $��Logout��6   $��Center=�6:   $��
498,0,10,0q�6U   $��5q�6i   ���#E74C3C
�������6�   5      � 5   
   $��10q�6   .+�5      �� .+�5      � $��10q�6    5      �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��0��6:   .+�5      �� $��Sort by:��6$   $��Center=�64   $��0,0,10,0q�6O   �� 5      -   5        $��cmbSort��5   #   $	��150��62   $��24��6o   .@�5      �� $��Name A-Z��6+   
 � Tag$ NameA-Z��6>    �� 
IsSelected$
 True��6L   �� 5      $��Name Z-A��6+   $ NameZ-A��6>   5"      5#      �� 5%      $ 
Horizontal=�6!   $��1��6:   $��Right=�6J   .+�5&      �� -   5        $��Import��5&   !   $��80��6M   $��30��6X   �� 5'      -   5        $
��Save��5'   !   $��80��6K   $��30��6V   $	��5,0q�6b   �� 5(      -   5        $��Add New Book��5(   !   $	��136��6W   $��30��6c   5)      5*      �� 5,      -   5        $��lvBooks��5,      $��10q�6*    �� View 5-      �� 5.      .P�5/      �� $��#��6-    �� Width$
 Auto��68    �� DisplayMemberBinding 6E   �� 	 �� Path$	 BookId��� 50      $��Product Name��6-   $
 Auto��6C    6P   �� $	 BookName��� 51      $��Image��6-   $
 Auto��6<   
 �� CellTemplate
 52   "   �� 53   &   .R�54   *   �� $��50��6J   $��50��6U   ��60   �� *Image1+6U   55   '   57      �� 58      $��Quantity��6-   $
 Auto��6?    6L   �� $	 Quantity��� 59      $��Genre��6-   $
 Auto��6<    6I   �� $	 	GenreName��� 5:      $��Author��6-   $
 Auto��6=    6J   �� $	 
AuthorName��� 5;      $��Price Input��6-   $
 Auto��6B    6O   �� $	 
PriceInput��� 5<      $��Price Output��6-   $
 Auto��6C    6P   �� $	 PriceOutput��� 5=      $��Detail��6-   $
 Auto��6=   
 5>   "   �� 5?   &   .R�5@   *   �� -   5        $��Detail��5@   1   6B   5A   '   5C      �� 5D      $
��Edit��6-   $
 Auto��6;   
 5E   "   �� 5F   &   .R�5G   *   �� -   5        $
��Edit��5G   1   6@   5H   '   5J      �� 5K      $��Delete��6-   $
 Auto��6=   
 5L   "   �� 5M   &   .R�5N   *   �� -	   5        $��Delete��5N   1   6B   5O   '   5Q      5R      5T      5U      5W      5X      5Y      