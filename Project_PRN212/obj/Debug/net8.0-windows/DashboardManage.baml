   M S B A M L   `   `   `  ����I  EProject_PRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PRN212_AssignmentPRN212_Assignment  5   	   '    !PRN212_Assignment.DashboardManage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PRN212_Assignment     5   	     � Title$  DashboardManage��5   	   $	��450��6!   $	��800��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� ���#F0F0F0$	��200��6*   $��Stretch=�66   $��0,0,10,0q�6R   .+�5      �� $��Book Shopping��6   $��24(�6-   $
��Bold"�6;   $��	10,0,0,10q�6M    �� TextAlignment$ Center=�6`   �� 5      .+�5      �� -   5        $��
Dash Board��5      $��10,20,10,20q�6.   6C   �� 5      -   5        $��User Dashboard��5      $��10,20,10,20q�62   6G   �� 5      -   5        $��	Book List��5      $��10,20,10,20q�6-   6B   �� 5      -   5        $��Logout��5      $��10,20,10,20q�6*   ���#428bca
�������6g   5      5      �� 5   
   $��1��6   $��10q�6%   .+�5      �� $��	Dashboard��6   $��24(�6)   $
��Bold"�67   $��10q�6I   $ Center=�6U   � 5      $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5       $
��Auto �6$    5"      �� 5#      $��* �6'   �� 5$      $��* �6'   �� 5%      $��* �6'   .+�5)      �� 
���   �$��1q�6-    �� CornerRadius$ 5��6A   $��10q�6R   $��0��6^   $��0��6k   ._�5*      �� $��10q�6!   .+�5+      �� $��
Total User��6$   $��18(�66   $
��Bold"�6D   $ Center=�6V   �� 5,      -   5         ��Name$ TotalUsersTextBlock��5,   $   $��16(�6A   $ Center=�6O   5-      5.      �� 5/      
���   �$��1q�6-   $ 5��6A   $��10q�6R   $��0��6^   $��1��6k   ._�50      �� $��10q�6!   .+�51      �� $��Total Books��6$   $��18(�67   $
��Bold"�6E   $ Center=�6W   �� 52      -   5        $ TotalBooksTextBlock��52   $   $��16(�6A   $ Center=�6O   53      54      �� 55      
���   �$��1q�6-   $ 5��6A   $��10q�6R   $��0��6^   $��2��6k   ._�56      �� $��10q�6!   .+�57      �� $��Authors��6$   $��18(�63   $
��Bold"�6A   $ Center=�6S   �� 58      -   5        $ TotalAuthorsTextBlock��58   $   $��16(�6C   $ Center=�6Q   59      5:      �� 5=      
���   �$��1q�6-   $ 5��6A   $��10,10,10,10q�6R   $��1��6g   $��0��6t   $��3��6�   ._�5>      �� $��10q�6!   .+�5?      �� $��Total Revenue��6$   $��18(�69   $
��Bold"�6G   $ Center=�6Y   �� 5@      -   5        $ TotalRevenueTextBlock��5@   $   $��16(�6C   $ Center=�6Q   5A      5B      5C      5D      5E      5F      