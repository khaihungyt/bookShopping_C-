   M S B A M L   `   `   `  ����  Project_PRN212&     PRN212_Assignment.changePassword   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Change Password��5   	   $	��250��5   	   $	��500��6    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5   	   .��5      � ���#f8f5f5$��0,50,0,0q�6     � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��0��69   $��10q�6I   .+�5      �� $ 
Horizontal=�6   $��0,0,0,15q�62   .+�5      �� $��Current Password: ��6   $
��Bold"�66   $��16(�6H   $��Center=�6V   $��25��6q   $	��180��6}   G� 5      -   5         G�Name$ CurrentPasswordBox��5   *   $	��250��6   $��10,0,0,0q�6F   5      �� 5      $ 
Horizontal=�6   $��0,0,0,15q�62   .+�5      �� $��New Password: ��6   $
��Bold"�62   $��16(�6D   $��Center=�6R   $	��180��6m   $��25��6y   G� 5      -   5        $ NewPasswordBox��5   *   $	��254��6   $��10,0,0,0q�6B   5      �� 5!      $ 
Horizontal=�6   $��0,0,0,15q�62   .+�5"      �� $��Confirm New Password: ��6   $
��Bold"�6:   $��16(�6L   $��Center=�6Z   $	��180��6u   G� 5#      -   5        $ ConfirmNewPasswordBox��5#   *   $	��253��6   $��10,0,0,0q�6I   5$      5%      �� 5'   
   $ 
Horizontal=�6   $��1��6.   $��0��6;   $��Right=�6K   $��10q�6g   .+�5(      �� -   5        $��Update��5(      $	��100��6&   ���#428bca
�������$��34��6Z   $��0,0,10,0q�6�   �� 5)      -   5        $��Cancel��5)      $	��100��6&   ���#cccccc
���   �$��34��6Z   6f   5*      5+      5,      