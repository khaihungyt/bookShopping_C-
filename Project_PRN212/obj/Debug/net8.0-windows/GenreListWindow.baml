   M S B A M L   `   `   `  ����I  EProject_PRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PRN212_AssignmentPRN212_Assignment  5   	   '    !PRN212_Assignment.GenreListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PRN212_Assignment     5   	     � Title$  GenreListWindow��5   	   $	��450��6!   $	��800��6.   .��5	      ]� .+�5   
      PRN212_Assignment.Sidebar     CurrentPage$ Genres��6   $
��Left=�6-   $	��200��6C   � 5   
   $	��Top=�6   ���#34495E$��50��69    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��Genres List��6   $��Center=�6+   
�������$��20(�6Y   $��10q�6g   �� 5      -   5        $��LogoutButton��5   &   $��Logout��6   $��Center=�6:   $��
498,0,10,0q�6U   $��5q�6i   ���#E74C3C
�������6�   5      � 5   
   $��10q�6   .+�5      �� .+�5      � $��10q�6    5      �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��0��6:   .+�5      �� $��Genre Name:��6$   $��Center=�67   $��0,0,10,0q�6R   �� 5      -   5        $��txtGenreName��5   "   $	��200��66   5      �� 5       -   5        $��Add New Genre��5       $	��146��6U   $��30��6a   $
��Left=�6m   $��2��6�   $��	414,0,0,0q�6�   5!      �� 5"      -   5        $��lvGenres��5"      $��10q�6+    �� View 5#      �� 5$      .P�5%      �� $��Genre ID��6-    �� Width$	 100��6?    �� DisplayMemberBinding 6K   ��  �� Path$ GenreId��� 5&      $��
Genre Name��6-   $	 200��6A    6M   �� $ 	GenreName��� 5'      $
��Edit��6-   $
 Auto��6;    �� CellTemplate 5(   "   �� 5)   &   .R�5*   *   �� -   5        $
��Edit��5*   1   6@   5+   '   5-      �� 5.      $��Delete��6-   $
 Auto��6=    5/   "   �� 50   &   .R�51   *   �� -   5        $��Delete��51   1   6B   52   '   54      55      57      58      59      5:      5;      