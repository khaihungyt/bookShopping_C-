   M S B A M L   `   `   `  ����I  EProject_PRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PRN212_AssignmentPRN212_Assignment  5   	   #    PRN212_Assignment.UsersWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1localclr-namespace:PRN212_Assignment     5   	     � Title$  
Users List��5   	   $	��450��6   $	��800��6)   .��5      ]� .+�5   
      PRN212_Assignment.Sidebar     CurrentPage$ Users��6   $
��Left=�6,   $	��200��6B   � 5
   
   $	��Top=�6   ���#34495E$��50��69    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��	User List��6   $��Center=�6)   
�������$��20(�6W   $��10q�6e   �� 5      -   5        $��LogoutButton��5   &   $��Logout��6   $��Center=�6:   $��
498,0,10,0q�6U   $��5q�6i   ���#E74C3C
�������6�   5      � 5   
   $��10q�6   .+�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��10q�66   .+�5      �� -   5        $��Export to File��5      $��10,0,0,0q�6Q   �� 5      -   5        $��Refresh��5      $��10,0,0,0q�6E   5      �� 5       $ 
Horizontal=�6   $��10q�66   .+�5!      �� $��Comment ID:��6    $��Center=�63   $��0,0,10,0q�6N   �� 5"      -   5        $��txtCommentId��5"      $	��150��62   $��0,0,20,0q�6>   �� 5#      -   5        $��	btnDelete��5#      $��Delete��6.   6?   5%      &   System.Windows.Controls.DataGrid  5'      -   5        $��CommentDataGrid��5'         AutoGenerateColumns$ False��62   $��10q�6N      SelectionMode$ Single=�6Z      Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 68   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6E   �� *	CommentId+  5*      $ 	CommentID��6-   $ * 6^   	 6@   �� *	CommentId+6^     5+      $ Username��6-   $ * 6\   	 6?   �� *
Username+6\     5,      $ BookName��6-   $ * 6\   	 6?   �� *
BookName+6\     5-      $ Comment Detail��6-   $ * 6b   	 6E   �� *
Comment1+6b   50      51      52      53      54      