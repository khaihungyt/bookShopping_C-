   M S B A M L   `   `   `  ����I  EProject_PRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PRN212_AssignmentPRN212_Assignment  5   	   '    !PRN212_Assignment.OrderListWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PRN212_Assignment     5   	     � Title$  OrderListWindow��5   	   $	��624��6!   $
��1245��6.   .��5	      ]� .+�5   
      PRN212_Assignment.Sidebar  -   5          Name$ SidebarControl��5         CurrentPage$ Orders��60   $
��Left=�6E   $	��200��6[   � 5   
   $	��Top=�6   ���#34495E$��50��69    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��Orders List��6   $��Center=�6+   
�������$��20(�6Y   $��10q�6g   �� 5      -   5        $��LogoutButton��5   &   $��Logout��6   $��Center=�6:   $��10q�6U   $��5q�6a   ���#E74C3C
�������6�   5      � 5   
   $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5       ��  �� Orientation$ 
Horizontal=�6   $��10q�62   .+�5!      �� $��Sort by:��6   $��Center=�6,   $��0,0,10,0q�6G   �� 5"      -   5         ��Name$ SortComboBox��5"      $	��200��6b   $��30��6n   $��0,0,10,0q�6z   .@�5#      �� $��Sort by Order ID��6#   �� 5$      $��Sort by Customer Name��6#   �� 5%      $��Sort by Order Status��6#   5&      �� 5'      -   5         ��Name$ 	btnExport��5'      $��80��6,   $��Export��67   $��10,0,0,0q�6`   �� 5(      -   5        $ 
btnRefresh��5(      $��80��6-   $��Refresh��68   $��30,0,0,0q�6c   5)      �� 5,      $ 
Horizontal=�6   $��10q�62   $��1��6>   .+�5-      �� $��	Order ID:��6   $��Center=�6-   $��0,0,10,0q�6H   �� 5.      -   5         ��Name$ txtId��5.      $	��150��6*   $��0,0,20,0q�66   �� 5/      $��Order Status:��6   $��Center=�61   $��0,0,10,0q�6L   �� 50      -   5        $ cbStatus��50      $	��150��6-   �� 51      -   5        $ btnEdit��51      $��Track Order��6*   $��20,0,0,0q�6V   52      �� 55      -	   5        $��OrdersListView��55      $��0,10,0,0q�6-   $��2��6?   	 �� View	 56      �� 57      .P�58      �� $��OrderID��6)   
 �� Width$	
 100��6c    �� DisplayMemberBinding 6:   �� *	OrderId+6c   �� 59      $��Customer Name��6)   $	
 150��6j    6@   �� *
Username+6j   �� 5:      $��	Book Name��6)   $	
 150��6f    6<   �� *
BookName+6f   �� 5<      $��Quantity��6)   $	
 100��6e    6;   �� *
Quantity+6e   �� 5=      $��
Total Cost��6)   $	
 100��6h    6=   �� *	TotalCost+6h   �� 5>      $��Order Status��6)   $	
 150��6l    6?   �� *OrderStatus+6l   5?      5A      5B      5C      5D      