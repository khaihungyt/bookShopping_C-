   M S B A M L   `   `   `  ����I  EProject_PRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PRN212_AssignmentPRN212_Assignment  5   	   (    "PRN212_Assignment.AuthorListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PRN212_Assignment     5   	     � Title$  AuthorListWindow��5   	   $	��450��6"   $	��800��6/   .��5	      ]� .+�5   
      PRN212_Assignment.Sidebar     CurrentPage$ Authors��6   $
��Left=�6.   $	��200��6D   � 5   
   $	��Top=�6   ���#34495E$��50��69    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��Authors List��6   $��Center=�6,   
�������$��20(�6Z   $��10q�6h   �� 5      -   5        $��LogoutButton��5   &   $��Logout��6   $��Center=�6:   $��10q�6U   $��5q�6a   ���#E74C3C
�������$��1��6�   6�   5      � 5   
   $��10q�6   .+�5      �� .+�5      � $��10q�6    5      �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��0��6:   .+�5       �� $��Author Name:��6$   $��Center=�68   $��0,0,10,0q�6S   �� 5!      -   5        $��txtAuthorName��5!   "   $	��200��67   5"      �� 5#      -   5        $��Add New Author��5#      $	��153��6W   $��30��6c   $
��Left=�6o   $��2��6�   $��	407,0,0,0q�6�   5$      �� 5%      -   5        $��	lvAuthors��5%      $��10q�6,    �� View 5&      �� 5'      .P�5(      �� $��	Author ID��6-    �� Width$	 100��6@    �� DisplayMemberBinding 6L   ��  �� Path$ AuthorId��� 5)      $��Author Name��6-   $	 200��6B    6N   �� $ 
AuthorName��� 5*      $
��Edit��6-   $
 Auto��6;    �� CellTemplate 5+   "   �� 5,   &   .R�5-   *   �� -   5        $
��Edit��5-   1   6@   5.   '   50      �� 51      $��Delete��6-   $
 Auto��6=    52   "   �� 53   &   .R�54   *   �� -   5        $��Delete��54   1   6B   55   '   57      58      5:      5;      5<      5=      5>      