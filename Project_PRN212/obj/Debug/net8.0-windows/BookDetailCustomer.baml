   M S B A M L   `   `   `  ����I  EProject_PRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PRN212_AssignmentPRN212_Assignment  5   	   *    $PRN212_Assignment.BookDetailCustomer   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PRN212_Assignment     5   	     � Title$  BookDetailCustomer��5   	   $	��550��6$   $	��800��61   .��5	      � .+�5
   
   �  � Orientation$ 
Horizontal=�6   $��
0,12,0,359q�6-   $��Right=�6A   $	��534��6]   .+�5      �� -   5         ��Name$ btnHomePage��5      $��	Home Page��6*   $��12q�6>   $
��auto��6J   $
��auto��6W   6e   �� 5      -   5        $ btnCart��5      $
��Cart��6&   $��12q�65   $
��auto��6A   $
��auto��6N   6\   �� 5      -   5        $ btnUserProfile��5      $��12q�6-   $
��auto��69   $
��auto��6F   6T   �� 5      -   5        $ 	btnLogOut��5      $��LogOut��6)   $��12q�6:   $
��auto��6F   $
��auto��6S   6a   5      �� 5   
   -   5         ��Name$ imgImage��5      $
��Left=�6"   $	��185��6=   $��	31,69,0,0q�6J   $	��Top=�6]   $	��274��6u   �� 5   
   $��378,69,61,212q�6   
�������.+�5      �� -   5        $��lblNameBook��5      $��
Name Book:��6'   6?   �� 5      -   5        $��lblDescription��5      $��Description:��6*   6C   �� 5      -   5        $��lblGenre��5      $��Genre:��6$   67   �� 5      -	   5        $��	lblNumber��5      $��Number:��6%   69   �� 5      -
   5         ��Name$ txtQuantity��5      $��96��6+   $��23��66   $
��Left=�6B   $��12q�6^    J� RenderTransformOrigin$ 0.5,0.5&�6j   .��6�   5      �� 5       �� Orientation$ 
Horizontal=�6   $��0,0,15,0q�62   $��52��6D   .+�5      �� -   5        $ btnAddtoCart��5      $��10q�6/   $
��auto��6;   $
��auto��6I   $��Add To Cart��6V   6l   �� 5      -   5        $ 	btnBuyNow��5      $
��auto��6,   $
��auto��6:   $��Buy Now��6G   $��10q�6Z   6f   5      5      �� 5   
   -   5         ��Name$ 
lblComment��5      $��Comment��6$   $��10,293,638,184q�66   6P   �� 5   
   -   5         ��Name$ lvCommentList��5      $��
0,329,0,72q�6*   $��Center=�6>   $	��800��6[   	 �� View	 5      �� 5       .P�5!      �� $
��Name��6%   
 �� Width$

 auto��63    �� DisplayMemberBinding 6@   ��  �� Path$
 Name�6m   �� 5"      $��Description��6%   $	
 500��6:    6F   �� $ Description�6z   �� 5#      $��Actions��6%   $

 auto��66    �� CellTemplate 5$      �� 5%      .R�5&   "   �� $ 	btnRemove��6)   -   5        $��Remove��5&   <    � DataContext 6e   �� $ 	CommentID�6�   5'      5)      5*      5,      ]� 5-   
   $��
10,0,10,10q�6   $��Bottom=�6(   .+�5.      �� -   5        $ 
lblcomment��5.      $��Comment:��6(   $��Center=�6;   6X   �� 5/      -   5        $��
tbxComment��5/   "   $	��642��6   $��1q�64   6J   �� 50      -   5        $ btnSend��50      $
��Send��6&   6M   51      52      53      